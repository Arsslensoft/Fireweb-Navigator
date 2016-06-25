// --------------------------------------------------------------------------------------------
// Version: MPL 1.1/GPL 2.0/LGPL 2.1
// 
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
// 
// <remarks>
// Generated by IDLImporter from file nsISaveAsCharset.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using System.Runtime.CompilerServices;
	
	
	/// <summary>
    ///This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this
    /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("33B87F70-7A9C-11d3-915C-006008A6EDF6")]
	public interface nsISaveAsCharset
	{
		
		[return: MarshalAs(UnmanagedType.LPStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string GetCharsetAttribute();
		
		/// <summary>
        /// see nsIEntityConverter.idl for possible value of entityVersion (entityNone for plain text).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Init([MarshalAs(UnmanagedType.LPStr)] string charset, uint attr, uint entityVersion);
		
		/// <summary>
        /// if the attribute does not specify any fall back (e.g. attrPlainTextDefault)
        /// </summary>
		[return: MarshalAs(UnmanagedType.LPStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string Convert([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string inString);
	}
	
	/// <summary>nsISaveAsCharsetConsts </summary>
	public class nsISaveAsCharsetConsts
	{
		
		// <summary>
        // attributes
        // </summary>
		public const ulong mask_Fallback = 0x000000FF;
		
		// <summary>
        // mask for fallback (8bits)
        // </summary>
		public const ulong mask_Entity = 0x00000300;
		
		// <summary>
        // mask for entity (2bits)
        // </summary>
		public const ulong mask_CharsetFallback = 0x00000400;
		
		// <summary>
        // mask for charset fallback (1bit)
        // </summary>
		public const ulong attr_FallbackNone = 0;
		
		// <summary>
        // no fall back for unconverted chars (skipped)
        // </summary>
		public const ulong attr_FallbackQuestionMark = 1;
		
		// <summary>
        // unconverted chars are replaced by '?'
        // </summary>
		public const ulong attr_FallbackEscapeU = 2;
		
		// <summary>
        // unconverted chars are escaped as \uxxxx
        // </summary>
		public const ulong attr_FallbackDecimalNCR = 3;
		
		// <summary>
        // unconverted chars are replaced by decimal NCR
        // </summary>
		public const ulong attr_FallbackHexNCR = 4;
		
		// <summary>
        // unconverted chars are replaced by hex NCR
        // </summary>
		public const ulong attr_EntityNone = 0;
		
		// <summary>
        // generate no Named Entity
        // </summary>
		public const ulong attr_EntityBeforeCharsetConv = 0x00000100;
		
		// <summary>
        // generate Named Entity before charset conversion
        // </summary>
		public const ulong attr_EntityAfterCharsetConv = 0x00000200;
		
		// <summary>
        // generate Named Entity after charset conversion
        // </summary>
		public const ulong attr_CharsetFallback = 0x00000400;
		
		// <summary>
        // default attribute for plain text
        // </summary>
		public const ulong attr_plainTextDefault = attr_FallbackNone+attr_EntityNone;
		
		// <summary>
        // generate entity before charset conversion, use decimal NCR
        // </summary>
		public const ulong attr_htmlTextDefault = attr_FallbackDecimalNCR+attr_EntityBeforeCharsetConv;
	}
}