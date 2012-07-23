#include "StdAfx.h"
#include "Commands.h"
#include "ControlProxy.h"

using namespace Microsoft::ManagedSpy;

Object^ PropertyDescriptorProxy::GetValue(Object^ component) {
	ControlProxy^ proxy = (ControlProxy^)component;
	Object^ value = nullptr;
	if (proxy != nullptr) {
		value = Desktop::SendMarshaledMessage(proxy->Handle, WM_GETMGDPROPERTY, this->Name);
	}
	return value;
}

void PropertyDescriptorProxy::ResetValue(Object^ component) {
	ControlProxy^ proxy = (ControlProxy^)component;
	Object^ value = nullptr;
	if (proxy != nullptr) {
		value = Desktop::SendMarshaledMessage(proxy->Handle, WM_RESETMGDPROPERTY, this->Name);
	}
}

void PropertyDescriptorProxy::SetValue(Object^ component, Object^ value) {
	ControlProxy^ proxy = (ControlProxy^)component;
	if (proxy != nullptr) {
		List<Object^>^ params = gcnew List<Object^>();
		params->Add(this->Name);
		params->Add(value);
		Desktop::SendMarshaledMessage(proxy->Handle, WM_SETMGDPROPERTY, 
			params );
	}
}
