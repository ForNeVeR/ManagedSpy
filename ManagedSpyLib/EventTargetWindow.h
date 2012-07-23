#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;


namespace Microsoft {
namespace ManagedSpy {

	/// <summary>
	/// Summary for EventTargetWindow
	/// </summary>
	ref class EventTargetWindow : public System::Windows::Forms::Control
	{
	public:
		EventTargetWindow(void)
		{
		}
	protected:
		virtual void WndProc(Message% m) override;
	};
}
}