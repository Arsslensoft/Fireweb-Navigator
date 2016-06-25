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
// Generated by IDLImporter from file nsIContentSecurityPolicy.idl
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
    /// nsIContentSecurityPolicy
    /// Describes an XPCOM component used to model an enforce CSPs.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("d1680bb4-1ac0-4772-9437-1188375e44f2")]
	public interface nsIContentSecurityPolicy
	{
		
		/// <summary>
        /// Set to true when the CSP has been read in and parsed and is ready to
        /// enforce.  This is a barrier for the nsDocument so it doesn't load any
        /// sub-content until either it knows that a CSP is ready or will not be used.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetIsInitializedAttribute();
		
		/// <summary>
        /// Set to true when the CSP has been read in and parsed and is ready to
        /// enforce.  This is a barrier for the nsDocument so it doesn't load any
        /// sub-content until either it knows that a CSP is ready or will not be used.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetIsInitializedAttribute([MarshalAs(UnmanagedType.U1)] bool aIsInitialized);
		
		/// <summary>
        /// When set to true, content load-blocking and fail-closed are disabled: CSP
        /// will ONLY send reports, and not modify behavior.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetReportOnlyModeAttribute();
		
		/// <summary>
        /// When set to true, content load-blocking and fail-closed are disabled: CSP
        /// will ONLY send reports, and not modify behavior.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetReportOnlyModeAttribute([MarshalAs(UnmanagedType.U1)] bool aReportOnlyMode);
		
		/// <summary>
        /// A read-only string version of the policy for debugging.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetPolicyAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aPolicy);
		
		/// <summary>
        /// Whether this policy allows in-page script.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetAllowsInlineScriptAttribute();
		
		/// <summary>
        /// whether this policy allows eval and eval-like functions
        /// such as setTimeout("code string", time).
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetAllowsEvalAttribute();
		
		/// <summary>
        /// Log policy violation on the Error Console and send a report if a report-uri
        /// is present in the policy
        ///
        /// @param violationType
        /// one of the VIOLATION_TYPE_* constants, e.g. inline-script or eval
        /// @param sourceFile
        /// name of the source file containing the violation (if available)
        /// @param contentSample
        /// sample of the violating content (to aid debugging)
        /// @param lineNum
        /// source line number of the violation (if available)
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void LogViolationDetails(ushort violationType, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase sourceFile, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase scriptSample, int lineNum);
		
		/// <summary>
        /// Manually triggers violation report sending given a URI and reason.
        /// The URI may be null, in which case "self" is sent.
        /// @param blockedURI
        /// the URI that violated the policy
        /// @param violatedDirective
        /// the directive that was violated.
        /// @param scriptSample
        /// a sample of the violating inline script
        /// @param lineNum
        /// source line number of the violation (if available)
        /// @return
        /// nothing.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SendReports([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase blockedURI, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase violatedDirective, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase scriptSample, int lineNum);
		
		/// <summary>
        /// Called after the CSP object is created to fill in the appropriate request
        /// and request header information needed in case a report needs to be sent.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScanRequestData([MarshalAs(UnmanagedType.Interface)] nsIHttpChannel aChannel);
		
		/// <summary>
        /// Updates the policy currently stored in the CSP to be "refined" or
        /// tightened by the one specified in the string policyString.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RefinePolicy([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase policyString, [MarshalAs(UnmanagedType.Interface)] nsIURI selfURI, [MarshalAs(UnmanagedType.U1)] bool specCompliant);
		
		/// <summary>
        /// Verifies ancestry as permitted by the policy.
        ///
        /// Calls to this may trigger violation reports when queried, so
        /// this value should not be cached.
        ///
        /// @param docShell
        /// containing the protected resource
        /// @return
        /// true if the frame's ancestors are all permitted by policy
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool PermitsAncestry([MarshalAs(UnmanagedType.Interface)] nsIDocShell docShell);
		
		/// <summary>
        /// Delegate method called by the service when sub-elements of the protected
        /// document are being loaded.  Given a bit of information about the request,
        /// decides whether or not the policy is satisfied.
        ///
        /// Calls to this may trigger violation reports when queried, so
        /// this value should not be cached.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		short ShouldLoad(uint aContentType, [MarshalAs(UnmanagedType.Interface)] nsIURI aContentLocation, [MarshalAs(UnmanagedType.Interface)] nsIURI aRequestOrigin, [MarshalAs(UnmanagedType.Interface)] nsISupports aContext, [MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aMimeTypeGuess, [MarshalAs(UnmanagedType.Interface)] nsISupports aExtra);
		
		/// <summary>
        /// Delegate method called by the service when sub-elements of the protected
        /// document are being processed.  Given a bit of information about the request,
        /// decides whether or not the policy is satisfied.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		short ShouldProcess(uint aContentType, [MarshalAs(UnmanagedType.Interface)] nsIURI aContentLocation, [MarshalAs(UnmanagedType.Interface)] nsIURI aRequestOrigin, [MarshalAs(UnmanagedType.Interface)] nsISupports aContext, [MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aMimeType, [MarshalAs(UnmanagedType.Interface)] nsISupports aExtra);
	}
	
	/// <summary>nsIContentSecurityPolicyConsts </summary>
	public class nsIContentSecurityPolicyConsts
	{
		
		// 
		public const ulong VIOLATION_TYPE_INLINE_SCRIPT = 1;
		
		// 
		public const ulong VIOLATION_TYPE_EVAL = 2;
	}
}
