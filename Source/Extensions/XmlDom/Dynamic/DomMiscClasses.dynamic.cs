// ***
// Do not edit this file. It has been generated by the ClassDynamizer tool.
// ***
#pragma warning disable 0108
using PHP.Core.Reflection;
using System;
using System.Xml;
using System.Xml.Schema;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PHP.Core;
namespace PHP.Library.Xml
{
	[Serializable()]
	public partial class DOMConfiguration : PhpObject
	{
		protected DOMConfiguration(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMConfiguration(ScriptContext context, bool newInstance) : base(context, newInstance)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMConfiguration(ScriptContext context, DTypeDesc caller) : this(context, true)
		{
			this.InvokeConstructor(context, caller);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setParameter(ScriptContext __context, object name, object value)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "setParameter");
					return null;
				}
			setParameter(tmp1, value);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setParameter(object instance, PhpStack stack)
		{
			stack.CalleeName = "setParameter";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMConfiguration)instance).setParameter(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object getParameter(ScriptContext __context, object name)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "getParameter");
					return null;
				}
			getParameter(tmp1);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object getParameter(object instance, PhpStack stack)
		{
			stack.CalleeName = "getParameter";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMConfiguration)instance).getParameter(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object canSetParameter(ScriptContext __context, object name, object value)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "canSetParameter");
					return null;
				}
			canSetParameter(tmp1, value);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object canSetParameter(object instance, PhpStack stack)
		{
			stack.CalleeName = "canSetParameter";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMConfiguration)instance).canSetParameter(stack.Context, arg1, arg2);
		}
		private static void __PopulateTypeDesc(PhpTypeDesc desc)
		{
			desc.AddMethod("setParameter", PhpMemberAttributes.Public, new RoutineDelegate(DOMConfiguration.setParameter));
			desc.AddMethod("getParameter", PhpMemberAttributes.Public, new RoutineDelegate(DOMConfiguration.getParameter));
			desc.AddMethod("canSetParameter", PhpMemberAttributes.Public, new RoutineDelegate(DOMConfiguration.canSetParameter));
		}
	}
	[Serializable()]
	public partial class DOMUserDataHandler : PhpObject
	{
		protected DOMUserDataHandler(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMUserDataHandler(ScriptContext context, bool newInstance) : base(context, newInstance)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMUserDataHandler(ScriptContext context, DTypeDesc caller) : this(context, true)
		{
			this.InvokeConstructor(context, caller);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object handle(ScriptContext __context, object operation, object key, object data, object src, object dst)
		{
			if (!(operation is int))

				{
					PhpException.InvalidImplicitCast(operation, "int", "handle");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(key);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(key, "string", "handle");
					return null;
				}
			
			DOMNode tmp4 = src as DOMNode;
			if (tmp4 == null)

				{
					PhpException.InvalidImplicitCast(src, "DOMNode", "handle");
					return null;
				}
			
			DOMNode tmp5 = dst as DOMNode;
			if (tmp5 == null)

				{
					PhpException.InvalidImplicitCast(dst, "DOMNode", "handle");
					return null;
				}
			handle((int)operation, tmp2, data, tmp4, tmp5);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object handle(object instance, PhpStack stack)
		{
			stack.CalleeName = "handle";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			
			object arg3 = stack.PeekValue(3);
			
			object arg4 = stack.PeekValue(4);
			
			object arg5 = stack.PeekValue(5);
			stack.RemoveFrame();
			return ((DOMUserDataHandler)instance).handle(stack.Context, arg1, arg2, arg3, arg4, arg5);
		}
		private static void __PopulateTypeDesc(PhpTypeDesc desc)
		{
			desc.AddMethod("handle", PhpMemberAttributes.Public, new RoutineDelegate(DOMUserDataHandler.handle));
		}
	}
	[Serializable()]
	public partial class DOMLocator : PhpObject
	{
		protected DOMLocator(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMLocator(ScriptContext context, bool newInstance) : base(context, newInstance)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMLocator(ScriptContext context, DTypeDesc caller) : this(context, true)
		{
			this.InvokeConstructor(context, caller);
		}
		private static object __get_lineNumber(object instance)
		{
			return ((DOMLocator)instance).lineNumber;
		}
		private static object __get_columnNumber(object instance)
		{
			return ((DOMLocator)instance).columnNumber;
		}
		private static object __get_offset(object instance)
		{
			return ((DOMLocator)instance).offset;
		}
		private static object __get_relatedNode(object instance)
		{
			return ((DOMLocator)instance).relatedNode;
		}
		private static object __get_uri(object instance)
		{
			return ((DOMLocator)instance).uri;
		}
		private static void __PopulateTypeDesc(PhpTypeDesc desc)
		{
			desc.AddProperty("lineNumber", PhpMemberAttributes.Public, new GetterDelegate(DOMLocator.__get_lineNumber), null);
			desc.AddProperty("columnNumber", PhpMemberAttributes.Public, new GetterDelegate(DOMLocator.__get_columnNumber), null);
			desc.AddProperty("offset", PhpMemberAttributes.Public, new GetterDelegate(DOMLocator.__get_offset), null);
			desc.AddProperty("relatedNode", PhpMemberAttributes.Public, new GetterDelegate(DOMLocator.__get_relatedNode), null);
			desc.AddProperty("uri", PhpMemberAttributes.Public, new GetterDelegate(DOMLocator.__get_uri), null);
		}
	}
	[Serializable()]
	public partial class DOMDomError : PhpObject
	{
		protected DOMDomError(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMDomError(ScriptContext context, bool newInstance) : base(context, newInstance)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMDomError(ScriptContext context, DTypeDesc caller) : this(context, true)
		{
			this.InvokeConstructor(context, caller);
		}
		private static object __get_severity(object instance)
		{
			return ((DOMDomError)instance).severity;
		}
		private static object __get_message(object instance)
		{
			return ((DOMDomError)instance).message;
		}
		private static object __get_type(object instance)
		{
			return ((DOMDomError)instance).type;
		}
		private static object __get_relatedException(object instance)
		{
			return ((DOMDomError)instance).relatedException;
		}
		private static object __get_related_data(object instance)
		{
			return ((DOMDomError)instance).related_data;
		}
		private static object __get_location(object instance)
		{
			return ((DOMDomError)instance).location;
		}
		private static void __PopulateTypeDesc(PhpTypeDesc desc)
		{
			desc.AddProperty("severity", PhpMemberAttributes.Public, new GetterDelegate(DOMDomError.__get_severity), null);
			desc.AddProperty("message", PhpMemberAttributes.Public, new GetterDelegate(DOMDomError.__get_message), null);
			desc.AddProperty("type", PhpMemberAttributes.Public, new GetterDelegate(DOMDomError.__get_type), null);
			desc.AddProperty("relatedException", PhpMemberAttributes.Public, new GetterDelegate(DOMDomError.__get_relatedException), null);
			desc.AddProperty("related_data", PhpMemberAttributes.Public, new GetterDelegate(DOMDomError.__get_related_data), null);
			desc.AddProperty("location", PhpMemberAttributes.Public, new GetterDelegate(DOMDomError.__get_location), null);
		}
	}
	[Serializable()]
	public partial class DOMErrorHandler : PhpObject
	{
		protected DOMErrorHandler(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMErrorHandler(ScriptContext context, bool newInstance) : base(context, newInstance)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMErrorHandler(ScriptContext context, DTypeDesc caller) : this(context, true)
		{
			this.InvokeConstructor(context, caller);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object handleError(ScriptContext __context, object error)
		{
			
			DOMDomError tmp1 = error as DOMDomError;
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(error, "DOMDomError", "handleError");
					return null;
				}
			handleError(tmp1);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object handleError(object instance, PhpStack stack)
		{
			stack.CalleeName = "handleError";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMErrorHandler)instance).handleError(stack.Context, arg1);
		}
		private static void __PopulateTypeDesc(PhpTypeDesc desc)
		{
			desc.AddMethod("handleError", PhpMemberAttributes.Public, new RoutineDelegate(DOMErrorHandler.handleError));
		}
	}
	[Serializable()]
	public partial class DOMTypeinfo : PhpObject
	{
		protected DOMTypeinfo(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMTypeinfo(ScriptContext context, bool newInstance) : base(context, newInstance)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMTypeinfo(ScriptContext context, DTypeDesc caller) : this(context, true)
		{
			this.InvokeConstructor(context, caller);
		}
		private static object __get_typeName(object instance)
		{
			return ((DOMTypeinfo)instance).typeName;
		}
		private static object __get_typeNamespace(object instance)
		{
			return ((DOMTypeinfo)instance).typeNamespace;
		}
		private static void __PopulateTypeDesc(PhpTypeDesc desc)
		{
			desc.AddProperty("typeName", PhpMemberAttributes.Public, new GetterDelegate(DOMTypeinfo.__get_typeName), null);
			desc.AddProperty("typeNamespace", PhpMemberAttributes.Public, new GetterDelegate(DOMTypeinfo.__get_typeNamespace), null);
		}
	}
}