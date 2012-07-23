#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Collections;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;
using namespace System::Collections::Generic;
using namespace System::Runtime::Serialization;
using namespace System::Reflection;
using namespace Microsoft::ManagedSpy;
using namespace System::IO;

namespace Microsoft {
namespace ManagedSpy {

	ref class PropertyDescriptorProxy : PropertyDescriptor
	{
	public:

		PropertyDescriptorProxy(PropertyDescriptor^ original) : PropertyDescriptor(original) {
			originalProperty = original;
		}

		virtual property Type^ ComponentType {
			Type^ get() override {
				return originalProperty->ComponentType;
			}
		}

        virtual property TypeConverter^ Converter {
            TypeConverter^ get() override{
				return originalProperty->Converter;
            }
        }

        virtual property bool IsLocalizable {
            bool get() override{
				return originalProperty->IsLocalizable;
            }
        }

        virtual property bool IsReadOnly {
			bool get() override{
				return originalProperty->IsReadOnly;
			}
		}

        virtual property Type^ PropertyType { 
			Type^ get() override{
				return originalProperty->PropertyType;
			}
		}

        virtual void AddValueChanged(Object^ component, EventHandler^ handler) override{
        }
        
		virtual bool CanResetValue(Object^ component) override{
				return false;
		}

        virtual PropertyDescriptorCollection^ GetChildProperties(Object^ instance,
			array<Attribute^>^ filter) override{
				return PropertyDescriptorCollection::Empty;
        }

		virtual Object^ GetEditor(Type^ editorBaseType) override{
				return originalProperty->GetEditor(editorBaseType);
        }

		virtual Object^ GetValue(Object^ component) override;

		virtual void ResetValue(Object^ component) override;
 
		virtual void SetValue(Object^ component, Object^ value) override;

		virtual bool ShouldSerializeValue(Object^ component) override {
				return false;
		}

	private:
		//we forward everything except get and set calls to the original
		//this gets us the correct editors, etc.
		PropertyDescriptor^ originalProperty;
	};
}
}