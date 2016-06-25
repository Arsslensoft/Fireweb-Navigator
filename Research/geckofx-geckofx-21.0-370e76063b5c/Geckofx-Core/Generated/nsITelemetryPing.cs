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
// Generated by IDLImporter from file nsITelemetryPing.idl
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
	[Guid("077ee790-3a9d-11e2-81c1-0800200c9a66")]
	public interface nsITelemetryPing : nsIObserver
	{
		
		/// <summary>
        /// Observe will be called when there is a notification for the
        /// topic |aTopic|.  This assumes that the object implementing
        /// this interface has been registered with an observer service
        /// such as the nsIObserverService.
        ///
        /// If you expect multiple topics/subjects, the impl is
        /// responsible for filtering.
        ///
        /// You should not modify, add, remove, or enumerate
        /// notifications in the implemention of observe.
        ///
        /// @param aSubject : Notification specific interface pointer.
        /// @param aTopic   : The notification topic or subject.
        /// @param aData    : Notification specific wide string.
        /// subject event.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Observe([MarshalAs(UnmanagedType.Interface)] nsISupports aSubject, [MarshalAs(UnmanagedType.LPStr)] string aTopic, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.WStringMarshaler")] string aData);
		
		/// <summary>
        /// Return the current telemetry payload.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal GetPayload();
		
		/// <summary>
        /// Save histograms to a file.
        ///
        /// @param aFile - File to load from.
        /// @param aSync - Use sync writes.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SaveHistograms([MarshalAs(UnmanagedType.Interface)] nsIFile aFile, [MarshalAs(UnmanagedType.U1)] bool aSync);
		
		/// <summary>
        /// Collect and store information about startup.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GatherStartup();
		
		/// <summary>
        /// Notify observers when loads and saves finish. Used only for testing.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void EnableLoadSaveNotifications();
		
		/// <summary>
        /// Inform the ping which AddOns are installed.
        ///
        /// @param aAddOns - The AddOns.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetAddOns([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aAddOns);
		
		/// <summary>
        /// Send a ping to a test server. Used only for testing.
        ///
        /// @param aServer - The server.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void TestPing([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aServer);
		
		/// <summary>
        /// Load histograms from a file.
        ///
        /// @param aFile - File to load from.
        /// @param aSync - Use sync reads.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void TestLoadHistograms([MarshalAs(UnmanagedType.Interface)] nsIFile aFile, [MarshalAs(UnmanagedType.U1)] bool aSync);
	}
}
