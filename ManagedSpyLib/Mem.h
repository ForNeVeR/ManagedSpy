#pragma once

#include "atlfile.h"
#include "atlstr.h"
#include "atlcoll.h"

using namespace System::IO;
using namespace System;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Collections::Generic;

//maximum number of concurrent transactions originating from this process.
#define MAXTID 999

struct MGD_CWPSTRUCT {
		System::IntPtr lParam;
		System::IntPtr wParam;
		int message;
		System::IntPtr hwnd;
	};

namespace Microsoft {
namespace ManagedSpy {

	struct SharedData {
		SIZE_T Size;
		BYTE Data[1];
	};

	class MemoryStore {

	public:
		~MemoryStore() {
			OnDestroy();
		}

		bool StoreParameters(Object^ params) {
			return StoreData(m_Params, params, m_paramKey);
		}
		bool StoreReturnValue(Object^ returnvalue) {
			return StoreData(m_ReturnValue, returnvalue, m_retvalKey);
		}

		Object^ GetParameters() {
			return GetData(m_Params, m_paramKey);
		}
		Object^ GetReturnValue() {
			return GetData(m_ReturnValue, m_retvalKey);
		}

		int Release() {
			m_nRefCount--;
			if (m_nRefCount == 0) {
				delete this;
				return 0;
			}
			return m_nRefCount;
		}

		int AddRef() {
			return ++m_nRefCount;
		}

		Object^ SendDataMessage(UINT Msg, Object^ parameter);

		static MemoryStore* CreateStore(IntPtr notificationWindow);
		static MemoryStore* OpenStore(MGD_CWPSTRUCT* message) {
			if (message== NULL) {
				return NULL;
			}
			return OpenStore((int)message->wParam, (int)message->lParam, true);
		}
		static MemoryStore* OpenStore(int processId, int transactionId, bool fAddRef);

	private:
		MemoryStore(int processID, int transactionID, IntPtr notificationWindow);
		
		void OnDestroy();
		bool StoreData(CAtlFileMapping<SharedData>& memory, Object^ data, LPCTSTR szMappingName);
		Object^ GetData(CAtlFileMapping<SharedData>& data, LPCTSTR szMappingName);

		CAtlFileMapping<SharedData> m_Params;
		CAtlFileMapping<SharedData> m_ReturnValue;
		CString						m_paramKey;
		CString						m_retvalKey;
		int							m_processId;
		int							m_transactionId;
		int							m_nRefCount;
		IntPtr						m_notificationWindow;

		static CAtlMap<int, CAtlMap<int, MemoryStore*>>		s_globalStore;
		static HANDLE										s_hMutex;

		static bool IsHandleValid(HANDLE handle) {
			return (handle != INVALID_HANDLE_VALUE && handle != (HANDLE)0);
		}
	};
}
}
