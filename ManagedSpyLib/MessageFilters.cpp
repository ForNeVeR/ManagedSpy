#include "Stdafx.h"
#include "Messages.h"
#include "MessageFilters.hpp"

void ManagedSpyLib::MessageFilters::Initialize()
{
    ChangeWindowMessageFilter(WM_GETPROXY, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_ISMANAGED, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_RELEASEMEM, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_SETMGDPROPERTY, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_GETMGDPROPERTY, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_RESETMGDPROPERTY, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_SUBSCRIBEEVENT, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_SUBSCRIBEEVENT, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_UNSUBSCRIBEEVENT, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_EVENTFIRED, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_WINDOWDESTROYED, MSGFLT_ADD);
    ChangeWindowMessageFilter(WM_HANDLECHANGED, MSGFLT_ADD);
}
