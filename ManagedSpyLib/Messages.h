#pragma once

//Spying sends: Create a controlproxy and send it back
static unsigned int WM_GETPROXY =			::RegisterWindowMessage(L"MSFT_ManagedSpy_GETPROXY");
//Spying sends: Is the window managed?
static unsigned int WM_ISMANAGED =			::RegisterWindowMessage(L"MSFT_ManagedSpy_ISMANAGED");
//Spying sends: release your reference to shared memory
static unsigned int WM_RELEASEMEM =			::RegisterWindowMessage(L"MSFT_ManagedSpy_RELEASEMEMORY");
//Spying sends: set a value on a control
static unsigned int WM_SETMGDPROPERTY =		::RegisterWindowMessage(L"MSFT_ManagedSpy_SETMGDPROPERTY");
//Spying sends: get a value on a control
static unsigned int WM_GETMGDPROPERTY =		::RegisterWindowMessage(L"MSFT_ManagedSpy_GETMGDPROPERTY");
//Spying sends: reset a value on a control
static unsigned int WM_RESETMGDPROPERTY =	::RegisterWindowMessage(L"MSFT_ManagedSpy_RESETMGDPROPERTY");
//Spying sends: subscribe to an event (ie, send back WM_EVENTFIRED) if this event is raised.
//note:  there is no guarantee of event ordering, so you may be called back after other user
//code has handled the event.
static unsigned int WM_SUBSCRIBEEVENT =		::RegisterWindowMessage(L"MSFT_ManagedSpy_SUBSCRIBEEVENT");
//Spying sends: stop sending event messages.
static unsigned int WM_UNSUBSCRIBEEVENT =	::RegisterWindowMessage(L"MSFT_ManagedSpy_UNSUBSCRIBEEVENT");
//Spied sends: an event was fired.
static unsigned int WM_EVENTFIRED =			::RegisterWindowMessage(L"MSFT_ManagedSpy_EVENTFIRED");
//Spied sends: a control was destroyed.
static unsigned int WM_WINDOWDESTROYED =	::RegisterWindowMessage(L"MSFT_ManagedSpy_WINDOWDESTROYED");
//Spied sends: a control has changed its handle.
static unsigned int WM_HANDLECHANGED =		::RegisterWindowMessage(L"MSFT_ManagedSpy_HANDLECHANGED");
