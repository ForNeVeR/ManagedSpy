#pragma once

#include "PropertyDescriptorProxy.h"

BOOL CALLBACK EnumChildrenCallback(HWND handle, LPARAM arg);

using namespace System::ComponentModel::Design;

namespace Microsoft {
namespace ManagedSpy {

	public ref class ProxyEventArgs {
	public:
		ProxyEventArgs(EventDescriptor^ ed, EventArgs^ args) {
			eventArgs = args;
			eventDescriptor = ed;
		}

		EventDescriptor^	eventDescriptor;
		EventArgs^			eventArgs;
	};

	public delegate void ControlProxyEventHandler(Object^ sender, ProxyEventArgs^ ed);

	/// <summary>
	/// Summary for ControlProxy
	/// </summary>
	[Serializable]
	public ref class ControlProxy :  public System::ComponentModel::ICustomTypeDescriptor
	{
	public:
		ControlProxy(IntPtr windowHandle);

		ControlProxy() {
			EnsureAssemblyResolve();
		}

		ControlProxy(Control^ instance);

		void OnHandleCreated(Object^ sender, EventArgs^ args);

		void OnHandleDestroyed(Object^ sender, EventArgs^ args);

		//ICustomTypeDescriptor overrides
		virtual System::ComponentModel::AttributeCollection^ GetAttributes() 
			= System::ComponentModel::ICustomTypeDescriptor::GetAttributes {
				if (ComponentType != nullptr) {
					return TypeDescriptor::GetAttributes(ComponentType);
				}
				return AttributeCollection::Empty;
		}
		virtual String^ GetClassName() 
			= System::ComponentModel::ICustomTypeDescriptor::GetClassName {
			return className;
		}
		virtual String^ GetComponentName() 
			= System::ComponentModel::ICustomTypeDescriptor::GetComponentName {
			return componentName;
		}
		virtual TypeConverter^ GetConverter() 
			= System::ComponentModel::ICustomTypeDescriptor::GetConverter {
				if (ComponentType != nullptr) {
					return TypeDescriptor::GetConverter(ComponentType);
				}
				return nullptr;
		}
		virtual EventDescriptor^ GetDefaultEvent() 
			= System::ComponentModel::ICustomTypeDescriptor::GetDefaultEvent {
				if (ComponentType != nullptr) {
					return TypeDescriptor::GetDefaultEvent(ComponentType);
				}
				return nullptr;
		}
		virtual PropertyDescriptor^ GetDefaultProperty()
			= System::ComponentModel::ICustomTypeDescriptor::GetDefaultProperty {
				if (ComponentType != nullptr) {
					PropertyDescriptor^ pd  = TypeDescriptor::GetDefaultProperty(ComponentType);
					if (pd != nullptr) {
						return GetProperties()[pd->Name];
					}
				}
				return nullptr;
		}
		virtual Object^ GetEditor(Type^ type)
			= System::ComponentModel::ICustomTypeDescriptor::GetEditor {
				if (ComponentType != nullptr) {
					return TypeDescriptor::GetEditor(ComponentType, type);
				}
				return nullptr;
		}
		virtual EventDescriptorCollection^ GetEvents(array<Attribute^>^ attributes)
			= System::ComponentModel::ICustomTypeDescriptor::GetEvents {
				if (ComponentType != nullptr) {
					return TypeDescriptor::GetEvents(ComponentType, attributes);
				}
				return EventDescriptorCollection::Empty;
		}
		virtual EventDescriptorCollection^ GetEvents()
			= System::ComponentModel::ICustomTypeDescriptor::GetEvents {
				if (eventsCache == nullptr) {
					if (ComponentType != nullptr) {
						eventsCache = TypeDescriptor::GetEvents(ComponentType);
					}
					else {
						eventsCache = EventDescriptorCollection::Empty;
					}
				}
				return eventsCache;
		}
		virtual PropertyDescriptorCollection^ GetProperties()
			= System::ComponentModel::ICustomTypeDescriptor::GetProperties {
			return GetProperties(nullptr);
		}

		virtual PropertyDescriptorCollection^ GetProperties(array<Attribute^>^ attributes)
			= System::ComponentModel::ICustomTypeDescriptor::GetProperties {

				if (properties == nullptr) { //we have to build the initial property proxy list
					if (ComponentType != nullptr) {
						PropertyDescriptorCollection^ pdcollorig = TypeDescriptor::GetProperties(ComponentType);
						PropertyDescriptorCollection^ pdcollManagedSpy = TypeDescriptor::GetProperties(ControlProxy::typeid);
						
						array<PropertyDescriptor^>^ pdcollnew = gcnew array<PropertyDescriptor^>(pdcollorig->Count + pdcollManagedSpy->Count);
						int i =0;
						for(;i < pdcollorig->Count; i++) {
							pdcollnew[i] = gcnew PropertyDescriptorProxy(pdcollorig[i]);
						}
						for(int j =0;j < pdcollManagedSpy->Count; j++, i++) {
							pdcollnew[i] = pdcollManagedSpy[j];
						}
						properties = gcnew PropertyDescriptorCollection(pdcollnew);
					}
				}

				PropertyDescriptorCollection^ filteredProps = properties;

				//now we can apply the filter:
				if (properties != nullptr && attributes != nullptr && attributes->Length>0) {
					ArrayList^ newlist = gcnew ArrayList();
					for(int i = 0; i < properties->Count; i++) {
						bool hide = false;
						for (int attrIdx = 0; attrIdx < attributes->Length; attrIdx++) {
							if (ShouldHideMember(properties[i], attributes[attrIdx])) {
								hide = true;
								break;
							}
						}
						if (!hide) {
							newlist->Add(properties[i]);
						}
					}
					if (newlist->Count != properties->Count) {
						array<PropertyDescriptor^>^ filteredPropArray = (array<PropertyDescriptor^>^)newlist->ToArray(PropertyDescriptor::typeid);
						filteredProps = gcnew PropertyDescriptorCollection(filteredPropArray);
					}
                }

			return filteredProps;
		}

		virtual Object^ GetPropertyOwner(PropertyDescriptor^ pd)
			= System::ComponentModel::ICustomTypeDescriptor::GetPropertyOwner {
			return this;
		}

		[Category("ManagedSpy Properties")]
		property IntPtr Handle;

		[Browsable(false)]
		property array<ControlProxy^>^ Children {
			array<ControlProxy^>^ get();
		}

		[Browsable(false)]
		property Process^ OwningProcess {
			Process^ get() {
				DWORD procid;
				GetWindowThreadProcessId((HWND)Handle.ToPointer(), &procid);
				Process^ owningprocess = nullptr;
				try {
					owningprocess = Process::GetProcessById(procid);
				}
				catch(ArgumentException^ ) { //process no longer running
					return nullptr;
				}

				return owningprocess;
			}
		}

		[Category("ManagedSpy Properties")]
		property bool IsManaged {
			bool get(); 
		}

		[Category("ManagedSpy Properties")]
		property Type^ ComponentType {
			Type^ get(); 
		}

		event ControlProxyEventHandler^ EventFired;

		void RaiseEvent(ProxyEventArgs^ args) {
			EventFired(this, args);
		}

		void SubscribeEvent(EventDescriptor^ ed);

		void SubscribeEvent(String^ eventName) {
			SubscribeEvent(GetEvents()[eventName]);
		}

		void UnsubscribeEvent(EventDescriptor^ ed);

		void UnsubscribeEvent(String^ eventName) {
			UnsubscribeEvent(GetEvents()[eventName]);
		}

		void SendMessage(int message, IntPtr wParam, IntPtr lParam);

		void SetEventWindow(IntPtr eventWindow) {
			eventWindowHandle = eventWindow;
		}

		[Browsable(false)]
		property ControlProxy^ Parent {
			ControlProxy^ get() {
				HWND hwnd = GetParent((HWND)Handle.ToPointer());
				if (hwnd != (HWND)NULL) {
					return FromHandle((IntPtr)hwnd);
				}
				return nullptr;
			}
		}

		Object^ GetValue(String^ propertyName) {
			PropertyDescriptorCollection^ pdColl = GetProperties();
			PropertyDescriptor^ pd = pdColl[propertyName];
			if (pd == nullptr) {
				return nullptr;
			}
			return pd->GetValue(this);
		}

		void SetValue(String^ propertyName, Object^ value) {
			PropertyDescriptorCollection^ pdColl = GetProperties();
			PropertyDescriptor^ pd = pdColl[propertyName];
			if (pd == nullptr) {
				return;
			}
			return pd->SetValue(this, value);
		}

		System::Drawing::Point^ PointToClient(System::Drawing::Point^ p) {
			POINT pt;
			pt.x = p->X;
			pt.y = p->Y;

			MapWindowPoints(NULL, (HWND)Handle.ToPointer(), &pt, 1);
            return gcnew System::Drawing::Point(pt.x, pt.y);
        }

        System::Drawing::Point^ PointToScreen(System::Drawing::Point^ p) {
			POINT pt;
			pt.x = p->X;
			pt.y = p->Y;

			MapWindowPoints((HWND)Handle.ToPointer(), NULL, &pt, 1);
            return gcnew System::Drawing::Point(pt.x, pt.y);
        }

		static ControlProxy^ FromHandle(System::IntPtr windowHandle);

		static property array<ControlProxy^>^ TopLevelWindows {
			array<ControlProxy^>^ get();
		}

	private:
		String^ className;
		String^ componentName;
		String^ typeName;
		List<String^>^ assemblyPaths;
		[NonSerialized]
		static List<Assembly^>^  assemblies = gcnew List<Assembly^>();
		[NonSerialized]
		static List<String^>^  loadedAssemblies = gcnew List<String^>();
		[NonSerialized]
		static bool subscribedAsmResolve = false;
		[NonSerialized]
		PropertyDescriptorCollection^ properties;
		[NonSerialized]
		Type^ componentType;
		[NonSerialized]
		EventDescriptorCollection^ eventsCache;
		[NonSerialized]
		IntPtr eventWindowHandle;
		[NonSerialized]
		IntPtr oldHandle;

        /// <devdoc> 
        ///     This function takes a member descriptor and an attribute and determines whether 
        ///     the member satisfies the particular attribute.  This either means that the member 
        ///     contains the attribute or the member does not contain the attribute and the default 
        ///     for the attribute matches the passed in attribute. 
        /// </devdoc> 
        bool ShouldHideMember(MemberDescriptor^ member, Attribute^ attribute) 
        {
            if (member == nullptr || attribute == nullptr) 
            {
                return true;
            }

			Attribute^ memberAttribute = member->Attributes[attribute->GetType()];
            if (memberAttribute == nullptr)
            {
                return !attribute->IsDefaultAttribute();
            }
            else 
            {
                return !(attribute->Match(memberAttribute));
            }
        }

		static void EnsureAssemblyResolve() {
			if (!subscribedAsmResolve) {
				subscribedAsmResolve = true;
				AppDomain::CurrentDomain->AssemblyResolve += gcnew ResolveEventHandler(ControlProxy::ProxyResolveEventHandler);
			}
		}

		static Assembly^ ProxyResolveEventHandler(Object^ sender, ResolveEventArgs^ args) {
			if (args->Name == ControlProxy::typeid->Assembly->GetName()->Name) {
				return ControlProxy::typeid->Assembly;
			}
			if (assemblies!= nullptr) {
				for(int i =0;i<assemblies->Count;i++) {
					if (args->Name == assemblies[i]->FullName || args->Name == assemblies[i]->GetName()->Name) {
						return assemblies[i];
					}
				}
			}
			return nullptr;
		}
	};
}
}
