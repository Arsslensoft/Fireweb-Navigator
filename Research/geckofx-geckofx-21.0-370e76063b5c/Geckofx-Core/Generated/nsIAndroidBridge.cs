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
// Generated by IDLImporter from file nsIAndroidBridge.idl
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
	[Guid("0843f3c1-043e-4c64-9d8c-091370548c05")]
	public interface nsIBrowserTab
	{
		
		/// <summary>
        ///This Source Code Form is subject to the terms of the Mozilla Public
        /// License, v. 2.0. If a copy of the MPL was not distributed with this
        /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMWindow GetWindowAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetScaleAttribute();
	}
	
	/// <summary>nsIAndroidBrowserApp </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("d10377b4-1c90-493a-a532-63cb3f16ee2b")]
	public interface nsIAndroidBrowserApp
	{
		
		/// <summary>Member GetBrowserTab </summary>
		/// <param name='tabId'> </param>
		/// <returns>A nsIBrowserTab</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIBrowserTab GetBrowserTab(int tabId);
	}
	
	/// <summary>nsIAndroidViewport </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("59cfcb35-69b7-47b2-8155-32b193272666")]
	public interface nsIAndroidViewport
	{
		
		/// <summary>Member GetXAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetXAttribute();
		
		/// <summary>Member GetYAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetYAttribute();
		
		/// <summary>Member GetWidthAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetWidthAttribute();
		
		/// <summary>Member GetHeightAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetHeightAttribute();
		
		/// <summary>Member GetPageLeftAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetPageLeftAttribute();
		
		/// <summary>Member GetPageTopAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetPageTopAttribute();
		
		/// <summary>Member GetPageRightAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetPageRightAttribute();
		
		/// <summary>Member GetPageBottomAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetPageBottomAttribute();
		
		/// <summary>Member GetCssPageLeftAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetCssPageLeftAttribute();
		
		/// <summary>Member GetCssPageTopAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetCssPageTopAttribute();
		
		/// <summary>Member GetCssPageRightAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetCssPageRightAttribute();
		
		/// <summary>Member GetCssPageBottomAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetCssPageBottomAttribute();
		
		/// <summary>Member GetZoomAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetZoomAttribute();
	}
	
	/// <summary>nsIAndroidDisplayport </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("e1bfbc07-dbae-409d-a5b5-ef57522c1f15")]
	public interface nsIAndroidDisplayport
	{
		
		/// <summary>Member GetLeftAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetLeftAttribute();
		
		/// <summary>Member SetLeftAttribute </summary>
		/// <param name='aLeft'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetLeftAttribute(float aLeft);
		
		/// <summary>Member GetTopAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetTopAttribute();
		
		/// <summary>Member SetTopAttribute </summary>
		/// <param name='aTop'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetTopAttribute(float aTop);
		
		/// <summary>Member GetRightAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetRightAttribute();
		
		/// <summary>Member SetRightAttribute </summary>
		/// <param name='aRight'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetRightAttribute(float aRight);
		
		/// <summary>Member GetBottomAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetBottomAttribute();
		
		/// <summary>Member SetBottomAttribute </summary>
		/// <param name='aBottom'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetBottomAttribute(float aBottom);
		
		/// <summary>Member GetResolutionAttribute </summary>
		/// <returns>A System.Single</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		float GetResolutionAttribute();
		
		/// <summary>Member SetResolutionAttribute </summary>
		/// <param name='aResolution'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetResolutionAttribute(float aResolution);
	}
	
	/// <summary>nsIAndroidBridge </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("bbb8e0d7-5cca-4ad0-88be-538ce6d04f63")]
	public interface nsIAndroidBridge
	{
		
		/// <summary>Member HandleGeckoMessage </summary>
		/// <param name='message'> </param>
		/// <param name='retval'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void HandleGeckoMessage([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase message, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase retval);
		
		/// <summary>Member GetBrowserAppAttribute </summary>
		/// <returns>A nsIAndroidBrowserApp</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAndroidBrowserApp GetBrowserAppAttribute();
		
		/// <summary>Member SetBrowserAppAttribute </summary>
		/// <param name='aBrowserApp'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetBrowserAppAttribute([MarshalAs(UnmanagedType.Interface)] nsIAndroidBrowserApp aBrowserApp);
		
		/// <summary>Member GetDisplayPort </summary>
		/// <param name='aPageSizeUpdate'> </param>
		/// <param name='isBrowserContentDisplayed'> </param>
		/// <param name='tabId'> </param>
		/// <param name='metrics'> </param>
		/// <returns>A nsIAndroidDisplayport</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIAndroidDisplayport GetDisplayPort([MarshalAs(UnmanagedType.U1)] bool aPageSizeUpdate, [MarshalAs(UnmanagedType.U1)] bool isBrowserContentDisplayed, int tabId, [MarshalAs(UnmanagedType.Interface)] nsIAndroidViewport metrics);
	}
}
