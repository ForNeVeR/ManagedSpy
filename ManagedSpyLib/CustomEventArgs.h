// Commands.h

#pragma once

using namespace System;

namespace Microsoft {
namespace ManagedSpy {
	
	[Serializable]
	ref class SerializableMouseEventArgs : EventArgs {
	public:
		SerializableMouseEventArgs(System::Windows::Forms::MouseEventArgs^ mArgs) {
			Button = mArgs->Button;
			Clicks = mArgs->Clicks;
			X = mArgs->X;
			Y = mArgs->Y;
			Delta = mArgs->Delta;
		}
		virtual String^ ToString() override {
			String^ strVersion = "{ MouseEventArgs [Button:" + Button.ToString() +
				" Clicks:" + Clicks.ToString() + " X:" + X.ToString() + " Y:" + Y.ToString() +
				" Delta:" + Delta.ToString() + "] }";
			return strVersion;
		}

		property MouseButtons Button;
        property int Clicks;
        property int X;
        property int Y;
        property int Delta;
	};

	ref class NonSerializableEventArgs : EventArgs {
	public:
		NonSerializableEventArgs(System::EventArgs^ nsArgs) {
			TypeName = nsArgs->GetType()->FullName;
		}
		virtual String^ ToString() override {
			String^ strVersion = "{ NonSerializable EventArgs [" + TypeName + "] }";
			return strVersion;
		}
		property String^ TypeName;
	};
}
}