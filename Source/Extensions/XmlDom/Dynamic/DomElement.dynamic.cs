// ***
// Do not edit this file. It has been generated by the ClassDynamizer tool.
// ***
#pragma warning disable 0108
using PHP.Core.Reflection;
using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PHP.Core;
namespace PHP.Library.Xml
{
	[Serializable()]
	public partial class DOMElement
	{
		protected DOMElement(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMElement(ScriptContext context, bool newInstance) : base(context, newInstance)
		{
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DOMElement(ScriptContext context, DTypeDesc caller) : this(context, true)
		{
			this.InvokeConstructor(context, caller);
		}
		private static object __get_nodeName(object instance)
		{
			return ((DOMElement)instance).nodeName;
		}
		private static object __get_nodeValue(object instance)
		{
			return ((DOMElement)instance).nodeValue;
		}
		private static void __set_nodeValue(object instance, object value)
		{
			((DOMElement)instance).nodeValue = value;
		}
		private static object __get_namespaceURI(object instance)
		{
			return ((DOMElement)instance).namespaceURI;
		}
		private static object __get_nodeType(object instance)
		{
			return ((DOMElement)instance).nodeType;
		}
		private static object __get_attributes(object instance)
		{
			return ((DOMElement)instance).attributes;
		}
		private static object __get_tagName(object instance)
		{
			return ((DOMElement)instance).tagName;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object __construct(ScriptContext __context, object name, 		[System.Runtime.InteropServices.OptionalAttribute()]
object value, 		[System.Runtime.InteropServices.OptionalAttribute()]
object namespaceUri)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "__construct");
					return null;
				}
			
			string tmp2 = null;
			if (value != Arg.Default)

				{
					tmp2 = PhpVariable.AsString(value);
					if (tmp2 == null)

						{
							PhpException.InvalidImplicitCast(value, "string", "__construct");
							return null;
						}
				}
			
			string tmp3 = null;
			if (namespaceUri != Arg.Default)

				{
					tmp3 = PhpVariable.AsString(namespaceUri);
					if (tmp3 == null)

						{
							PhpException.InvalidImplicitCast(namespaceUri, "string", "__construct");
							return null;
						}
				}
			__construct(tmp1, tmp2, tmp3);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object __construct(object instance, PhpStack stack)
		{
			stack.CalleeName = "__construct";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValueOptional(2);
			
			object arg3 = stack.PeekValueOptional(3);
			stack.RemoveFrame();
			return ((DOMElement)instance).__construct(stack.Context, arg1, arg2, arg3);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object getAttribute(ScriptContext __context, object name)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "getAttribute");
					return null;
				}
			return getAttribute(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object getAttribute(object instance, PhpStack stack)
		{
			stack.CalleeName = "getAttribute";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).getAttribute(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object getAttributeNS(ScriptContext __context, object namespaceUri, object localName)
		{
			
			string tmp1 = PhpVariable.AsString(namespaceUri);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(namespaceUri, "string", "getAttributeNS");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(localName);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(localName, "string", "getAttributeNS");
					return null;
				}
			return getAttributeNS(tmp1, tmp2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object getAttributeNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "getAttributeNS";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).getAttributeNS(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setAttribute(ScriptContext __context, object name, object value)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "setAttribute");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(value);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(value, "string", "setAttribute");
					return null;
				}
			return setAttribute(tmp1, tmp2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setAttribute(object instance, PhpStack stack)
		{
			stack.CalleeName = "setAttribute";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).setAttribute(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setAttributeNS(ScriptContext __context, object namespaceUri, object qualifiedName, object value)
		{
			
			string tmp1 = PhpVariable.AsString(namespaceUri);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(namespaceUri, "string", "setAttributeNS");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(qualifiedName);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(qualifiedName, "string", "setAttributeNS");
					return null;
				}
			
			string tmp3 = PhpVariable.AsString(value);
			if (tmp3 == null)

				{
					PhpException.InvalidImplicitCast(value, "string", "setAttributeNS");
					return null;
				}
			return setAttributeNS(tmp1, tmp2, tmp3);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setAttributeNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "setAttributeNS";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			
			object arg3 = stack.PeekValue(3);
			stack.RemoveFrame();
			return ((DOMElement)instance).setAttributeNS(stack.Context, arg1, arg2, arg3);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object removeAttribute(ScriptContext __context, object name)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "removeAttribute");
					return null;
				}
			return removeAttribute(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object removeAttribute(object instance, PhpStack stack)
		{
			stack.CalleeName = "removeAttribute";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).removeAttribute(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object removeAttributeNS(ScriptContext __context, object namespaceUri, object localName)
		{
			
			string tmp1 = PhpVariable.AsString(namespaceUri);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(namespaceUri, "string", "removeAttributeNS");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(localName);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(localName, "string", "removeAttributeNS");
					return null;
				}
			return removeAttributeNS(tmp1, tmp2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object removeAttributeNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "removeAttributeNS";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).removeAttributeNS(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object getAttributeNode(ScriptContext __context, object name)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "getAttributeNode");
					return null;
				}
			return getAttributeNode(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object getAttributeNode(object instance, PhpStack stack)
		{
			stack.CalleeName = "getAttributeNode";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).getAttributeNode(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object getAttributeNodeNS(ScriptContext __context, object namespaceUri, object localName)
		{
			
			string tmp1 = PhpVariable.AsString(namespaceUri);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(namespaceUri, "string", "getAttributeNodeNS");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(localName);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(localName, "string", "getAttributeNodeNS");
					return null;
				}
			return getAttributeNodeNS(tmp1, tmp2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object getAttributeNodeNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "getAttributeNodeNS";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).getAttributeNodeNS(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setAttributeNode(ScriptContext __context, object attribute)
		{
			
			DOMAttr tmp1 = attribute as DOMAttr;
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(attribute, "DOMAttr", "setAttributeNode");
					return null;
				}
			return setAttributeNode(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setAttributeNode(object instance, PhpStack stack)
		{
			stack.CalleeName = "setAttributeNode";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).setAttributeNode(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setAttributeNodeNS(ScriptContext __context, object attribute)
		{
			
			DOMAttr tmp1 = attribute as DOMAttr;
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(attribute, "DOMAttr", "setAttributeNodeNS");
					return null;
				}
			return setAttributeNodeNS(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setAttributeNodeNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "setAttributeNodeNS";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).setAttributeNodeNS(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object removeAttributeNode(ScriptContext __context, object attribute)
		{
			
			DOMAttr tmp1 = attribute as DOMAttr;
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(attribute, "DOMAttr", "removeAttributeNode");
					return null;
				}
			return removeAttributeNode(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object removeAttributeNode(object instance, PhpStack stack)
		{
			stack.CalleeName = "removeAttributeNode";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).removeAttributeNode(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object hasAttribute(ScriptContext __context, object name)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "hasAttribute");
					return null;
				}
			return hasAttribute(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object hasAttribute(object instance, PhpStack stack)
		{
			stack.CalleeName = "hasAttribute";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).hasAttribute(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object hasAttributeNS(ScriptContext __context, object namespaceUri, object localName)
		{
			
			string tmp1 = PhpVariable.AsString(namespaceUri);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(namespaceUri, "string", "hasAttributeNS");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(localName);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(localName, "string", "hasAttributeNS");
					return null;
				}
			return hasAttributeNS(tmp1, tmp2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object hasAttributeNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "hasAttributeNS";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).hasAttributeNS(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object getElementsByTagName(ScriptContext __context, object name)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "getElementsByTagName");
					return null;
				}
			return getElementsByTagName(tmp1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object getElementsByTagName(object instance, PhpStack stack)
		{
			stack.CalleeName = "getElementsByTagName";
			
			object arg1 = stack.PeekValue(1);
			stack.RemoveFrame();
			return ((DOMElement)instance).getElementsByTagName(stack.Context, arg1);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object getElementsByTagNameNS(ScriptContext __context, object namespaceUri, object localName)
		{
			
			string tmp1 = PhpVariable.AsString(namespaceUri);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(namespaceUri, "string", "getElementsByTagNameNS");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(localName);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(localName, "string", "getElementsByTagNameNS");
					return null;
				}
			return getElementsByTagNameNS(tmp1, tmp2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object getElementsByTagNameNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "getElementsByTagNameNS";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).getElementsByTagNameNS(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setIdAttribute(ScriptContext __context, object name, object isId)
		{
			
			string tmp1 = PhpVariable.AsString(name);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(name, "string", "setIdAttribute");
					return null;
				}
			if (!(isId is bool))

				{
					PhpException.InvalidImplicitCast(isId, "bool", "setIdAttribute");
					return null;
				}
			setIdAttribute(tmp1, (bool)isId);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setIdAttribute(object instance, PhpStack stack)
		{
			stack.CalleeName = "setIdAttribute";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).setIdAttribute(stack.Context, arg1, arg2);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setIdAttributeNS(ScriptContext __context, object namespaceUri, object localName, object isId)
		{
			
			string tmp1 = PhpVariable.AsString(namespaceUri);
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(namespaceUri, "string", "setIdAttributeNS");
					return null;
				}
			
			string tmp2 = PhpVariable.AsString(localName);
			if (tmp2 == null)

				{
					PhpException.InvalidImplicitCast(localName, "string", "setIdAttributeNS");
					return null;
				}
			if (!(isId is bool))

				{
					PhpException.InvalidImplicitCast(isId, "bool", "setIdAttributeNS");
					return null;
				}
			setIdAttributeNS(tmp1, tmp2, (bool)isId);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setIdAttributeNS(object instance, PhpStack stack)
		{
			stack.CalleeName = "setIdAttributeNS";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			
			object arg3 = stack.PeekValue(3);
			stack.RemoveFrame();
			return ((DOMElement)instance).setIdAttributeNS(stack.Context, arg1, arg2, arg3);
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public object setIdAttributeNode(ScriptContext __context, object attribute, object isId)
		{
			
			DOMAttr tmp1 = attribute as DOMAttr;
			if (tmp1 == null)

				{
					PhpException.InvalidImplicitCast(attribute, "DOMAttr", "setIdAttributeNode");
					return null;
				}
			if (!(isId is bool))

				{
					PhpException.InvalidImplicitCast(isId, "bool", "setIdAttributeNode");
					return null;
				}
			setIdAttributeNode(tmp1, (bool)isId);
			return null;
		}
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static object setIdAttributeNode(object instance, PhpStack stack)
		{
			stack.CalleeName = "setIdAttributeNode";
			
			object arg1 = stack.PeekValue(1);
			
			object arg2 = stack.PeekValue(2);
			stack.RemoveFrame();
			return ((DOMElement)instance).setIdAttributeNode(stack.Context, arg1, arg2);
		}
		private static void __PopulateTypeDesc(PhpTypeDesc desc)
		{
			desc.AddProperty("nodeName", PhpMemberAttributes.Public, new GetterDelegate(DOMElement.__get_nodeName), null);
			desc.AddProperty("nodeValue", PhpMemberAttributes.Public, new GetterDelegate(DOMElement.__get_nodeValue), new SetterDelegate(DOMElement.__set_nodeValue));
			desc.AddProperty("namespaceURI", PhpMemberAttributes.Public, new GetterDelegate(DOMElement.__get_namespaceURI), null);
			desc.AddProperty("nodeType", PhpMemberAttributes.Public, new GetterDelegate(DOMElement.__get_nodeType), null);
			desc.AddProperty("attributes", PhpMemberAttributes.Public, new GetterDelegate(DOMElement.__get_attributes), null);
			desc.AddProperty("tagName", PhpMemberAttributes.Public, new GetterDelegate(DOMElement.__get_tagName), null);
			desc.AddMethod("__construct", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.__construct));
			desc.AddMethod("getAttribute", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.getAttribute));
			desc.AddMethod("getAttributeNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.getAttributeNS));
			desc.AddMethod("setAttribute", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.setAttribute));
			desc.AddMethod("setAttributeNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.setAttributeNS));
			desc.AddMethod("removeAttribute", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.removeAttribute));
			desc.AddMethod("removeAttributeNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.removeAttributeNS));
			desc.AddMethod("getAttributeNode", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.getAttributeNode));
			desc.AddMethod("getAttributeNodeNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.getAttributeNodeNS));
			desc.AddMethod("setAttributeNode", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.setAttributeNode));
			desc.AddMethod("setAttributeNodeNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.setAttributeNodeNS));
			desc.AddMethod("removeAttributeNode", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.removeAttributeNode));
			desc.AddMethod("hasAttribute", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.hasAttribute));
			desc.AddMethod("hasAttributeNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.hasAttributeNS));
			desc.AddMethod("getElementsByTagName", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.getElementsByTagName));
			desc.AddMethod("getElementsByTagNameNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.getElementsByTagNameNS));
			desc.AddMethod("setIdAttribute", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.setIdAttribute));
			desc.AddMethod("setIdAttributeNS", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.setIdAttributeNS));
			desc.AddMethod("setIdAttributeNode", PhpMemberAttributes.Public, new RoutineDelegate(DOMElement.setIdAttributeNode));
		}
	}
}
