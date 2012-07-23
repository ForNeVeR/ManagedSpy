#include "stdafx.h"

#include "Mem.h"
#include "Messages.h"
#include "Commands.h"

using namespace Microsoft::ManagedSpy;

CAtlMap<int, CAtlMap<int, MemoryStore*>> MemoryStore::s_globalStore;
HANDLE MemoryStore::s_hMutex = CreateMutex(NULL, FALSE, NULL);

Object^ MemoryStore::SendDataMessage(UINT Msg, Object^ parameter) {
	Object^ retvalObj = nullptr;
	if (parameter != nullptr) {
		StoreParameters(parameter);
	}
	::SendMessage((HWND)m_notificationWindow.ToPointer(), Msg, m_processId, m_transactionId);
	return GetReturnValue();
}

MemoryStore* MemoryStore::OpenStore(int processId, int transactionId, bool fAddRef) {
	MemoryStore* store = NULL;
	if (WaitForSingleObject(s_hMutex, INFINITE) == WAIT_OBJECT_0) {
		try {
			if (s_globalStore[processId].Lookup(transactionId, store)) {
				_ASSERTE(store != NULL);
				if (fAddRef) {
					store->AddRef();
				}
			}
			else if (fAddRef) {
				store = new MemoryStore(processId, transactionId, IntPtr::Zero);
				s_globalStore[processId][transactionId] = store;
			}
		}
		finally {
			ReleaseMutex(s_hMutex);
		}
	}
	return store;
}

void MemoryStore::OnDestroy() {
	if (WaitForSingleObject(s_hMutex, INFINITE) == WAIT_OBJECT_0) {
		try {
			s_globalStore[m_processId].RemoveKey(m_transactionId);
		}
		finally {
			ReleaseMutex(s_hMutex);
		}
	}
	if (m_notificationWindow != IntPtr::Zero) {
		::SendMessage((HWND)m_notificationWindow.ToPointer(), WM_RELEASEMEM, m_processId, m_transactionId);
	}
}

MemoryStore* MemoryStore::CreateStore(IntPtr notificationWindow) {
	MemoryStore* newStore = NULL;
	if (WaitForSingleObject(s_hMutex, INFINITE) == WAIT_OBJECT_0) {
		try {
			CAtlMap<int, MemoryStore*>& processMap = s_globalStore[GetCurrentProcessId()];

			int nextTid = 0;
			MemoryStore* store;
			//simple free id lookup.  A better performing lookup/store could be done here.
			while (processMap.Lookup(nextTid, store) && nextTid < MAXTID) {
				nextTid++;
			}
			if (nextTid < MAXTID) {
				newStore = new MemoryStore((int)GetCurrentProcessId(), nextTid, notificationWindow);
				processMap[nextTid] = newStore;
			}
			else {
				_ASSERTE(false); //out of transaction space.  A leak has occurred?
			}
		}
		finally {
			ReleaseMutex(s_hMutex);
		}
	}
	return newStore;
}

MemoryStore::MemoryStore(int processId, int transactionId, IntPtr notificationWindow) {
	m_paramKey.Format(_T("MSFT_ManagedSpy_PARAMS.%d.%d"), processId, transactionId);
	m_retvalKey.Format(_T("MSFT_ManagedSpy_RETVAL.%d.%d"), processId, transactionId);
	m_transactionId = transactionId;
	m_processId = processId;
	m_nRefCount = 1;
	m_notificationWindow = notificationWindow;
}


bool MemoryStore::StoreData(CAtlFileMapping<SharedData>& memory, Object^ data, LPCTSTR szMappingName) {
	if (IsHandleValid(memory.GetHandle())) {
		memory.Unmap();
	}
	MemoryStream^ stream = gcnew MemoryStream();
	BinaryFormatter^ formatter = gcnew BinaryFormatter();
	try {
		formatter->Serialize(stream, data);
	}
	catch(SerializationException^ ) {
		return false;
	}
	memory.MapSharedMem((unsigned long)stream->Length + sizeof(SIZE_T), szMappingName);
	if (((SharedData*)memory) == NULL) {
		return false;
	}
	((SharedData*)memory)->Size = (SIZE_T)stream->Length;
	BYTE* pdata = (BYTE*)((SharedData*)memory)->Data;

	array<unsigned char>^ streamdata = stream->GetBuffer();
	for(unsigned int i=0; i< ((SharedData*)memory)->Size; i++) {
		pdata[i] = streamdata[i];
	}
	return true;
}

Object^ MemoryStore::GetData(CAtlFileMapping<SharedData>& data, LPCTSTR szMappingName) {
	//we do this to allow these apis to work on the current process.
	if (!IsHandleValid(data.GetHandle())) {
		data.OpenMapping(szMappingName, 0);
	}
	if (((SharedData*)data) == NULL) {
		return nullptr;
	}
	array<unsigned char>^ sdata = gcnew array<unsigned char>(((SharedData*)data)->Size);
	BYTE* pdata = (BYTE*)((SharedData*)data)->Data;

	for(unsigned int i=0;i<((SharedData*)data)->Size; i++) {
		sdata[i] = pdata[i];
	}

	MemoryStream^ stream = gcnew MemoryStream(sdata);
	BinaryFormatter^ formatter = gcnew BinaryFormatter();
	Object^ retvalue = nullptr;

	try {
		retvalue = formatter->Deserialize(stream);
	}
	catch(SerializationException^ ) {
		retvalue = nullptr;
	}
	return retvalue;
}

