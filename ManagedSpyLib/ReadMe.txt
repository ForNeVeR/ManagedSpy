========================================================================
    DYNAMIC LINK LIBRARY : ManagedSpyLib Project Overview
========================================================================

ManagedSpyLib.vcproj
	ManagedSpyLib is a library that exposes one class called ControlProxy.  A ControlProxy 
	represents a System.Windows.Forms.Control in another process.  So, in other words, if
	you have a ControlProxy in process A, it represents, say, a System.Windows.Forms.Button
	in process B.
	The ControlProxy class allows you to retrieve property values and sync on events.
	Note that throughout the code and comments, we refer to process A as the "spying process"
	and process B as the "spied process".

AssemblyInfo.cpp
	This file contains assembly attribute information such as Company name and version.

Commands.cpp
Commands.h
	Commands contains handlers for custom window messages.  The way ManagedSpyLib works is that
	when you want to create a ControlProxy, get/set values, the library turns on a window hook
	in the destination process.  The commands class is what both sends these messages and receives
	them in the spied-on process.
	A confusing thing here is that part of the class is executing in the spying process and other
	parts execute in the spied process.  I've tried to annotate these as best I could.

ControlProxy.h
ControlProxy.cpp
	A ControlProxy is created inside the spied process and sent back to the spying process via
	binary serialization (therefore ControlProxy is fully serializable).
	Once deserialized on the spying process side, when you get or set values, the proxy will send
	window messages to get/set values.
	A ControlProxy is also left in a cache in the spied process to listen on events.  When an event
	is fired in the spied process, the ControlProxy will send a window message back to the listening
	process.  A current limitation is that ControlProxy events only supports one listening process.
	This can be fixed with a little sweat.

CustomEventArgs.h
	This contains a binary serializable version of MouseEventArgs.  Note that all EventArgs must
	be binary serializable or else they will not be sent to the event listener of the ControlProxy.

Mem.h
Mem.cpp
	The Mem files define the use of memory mapped files.  These are used to pass information between
	the spying and spied process.

Messages.h
	This lists all of the custom window messages we use

PropertyDescriptorProxy.h
PropertyDescriptorProxy.cpp
	We implement ICustomTypeDescriptor on ControlProxy.  This allows users to call TypeDescriptor.GetProperties
	on a ControlProxy and set/get property values as if it were the actual control.  This fucntionality is
	used in the ManagedSpy application by putting the ControlProxy in the PropertyGrid (The winforms propertygrid
	will automatically query ICustomTypeDescriptor).
	PropertyDescriptorProxy is a custom written PropertyDescriptor used in our ICustomTypeDescriptor implementation.

/////////////////////////////////////////////////////////////////////////////
Other notes:

	Some of the contents in Commands could be placed in ControlProxy to make things a bit clearer.
	Another option is to use .Net remoting instead of memory mapped files.

/////////////////////////////////////////////////////////////////////////////
