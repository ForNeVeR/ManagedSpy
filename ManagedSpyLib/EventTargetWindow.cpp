#include "StdAfx.h"
#include "Commands.h"
#include "EventTargetWindow.h"

using namespace System;
using namespace System::Collections::Generic;

void EventTargetWindow::WndProc(Message% m) {

	if (m.Msg == WM_EVENTFIRED) {
		//an event has been fired. 

		MemoryStore* store = MemoryStore::OpenStore((int)m.WParam, (int)m.LParam, true);
		if (store!= NULL) {
			List<Object^>^ params= (List<Object^>^)store->GetParameters();
			if (params != nullptr) {
				_ASSERTE(params->Count == 3);
				if (Desktop::proxyCache->ContainsKey((IntPtr)params[0])) {
					ControlProxy^ proxy = Desktop::proxyCache[(IntPtr)params[0]];
					_ASSERTE(proxy != nullptr);
					//fire the event.
					EventDescriptorCollection^ events = proxy->GetEvents();
					if (events != nullptr && (int)params[1]<= events->Count && (int)params[1]>=0) {
						proxy->RaiseEvent(gcnew ProxyEventArgs(events[(int)params[1]], (EventArgs^)params[2]));
					}
				}
			}
			store->Release();	//release, don't delete if in the same process.
		}
	}
	else if (m.Msg == WM_WINDOWDESTROYED) {
		if (Desktop::proxyCache->ContainsKey(m.WParam)) {
			Desktop::proxyCache->Remove(m.WParam);
		}
	}
	else if (m.Msg == WM_HANDLECHANGED) {
		ControlProxy^ proxy = nullptr;
		if (Desktop::proxyCache->ContainsKey(m.WParam)) {
			proxy = Desktop::proxyCache[m.WParam];
		}
		if (proxy != nullptr) {
			Desktop::proxyCache->Remove(m.WParam);
			Desktop::proxyCache->Add(m.LParam, proxy);
			proxy->Handle = m.LParam;
		}
	}
	else {
		Control::WndProc(m);
	}
}
