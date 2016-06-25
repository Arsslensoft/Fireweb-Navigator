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
// Generated by IDLImporter from file IPeerConnection.idl
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
    /// Manager interface to PeerConnection.js so it is accessible from C++.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("c2218bd2-2648-4701-8fa6-305d3379e9f8")]
	public interface IPeerConnectionManager
	{
		
		/// <summary>
        /// Manager interface to PeerConnection.js so it is accessible from C++.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool HasActivePeerConnection(uint innerWindowID);
	}
	
	/// <summary>
    ///Do not confuse with nsIDOMRTCPeerConnection. This interface is purely for
    /// communication between the PeerConnection JS DOM binding and the C++
    /// implementation in SIPCC.
    ///
    /// See media/webrtc/signaling/include/PeerConnectionImpl.h
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("e61821ba-7772-4973-b583-1715e4bbaeed")]
	public interface IPeerConnectionObserver
	{
		
		/// <summary>
        ///JSEP callbacks </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnCreateOfferSuccess([MarshalAs(UnmanagedType.LPStr)] string offer);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnCreateOfferError(uint code);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnCreateAnswerSuccess([MarshalAs(UnmanagedType.LPStr)] string answer);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnCreateAnswerError(uint code);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnSetLocalDescriptionSuccess(uint code);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnSetRemoteDescriptionSuccess(uint code);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnSetLocalDescriptionError(uint code);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnSetRemoteDescriptionError(uint code);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnAddIceCandidateSuccess(uint code);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnAddIceCandidateError(uint code);
		
		/// <summary>
        ///Data channel callbacks </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void NotifyDataChannel([MarshalAs(UnmanagedType.Interface)] nsIDOMDataChannel channel);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void NotifyConnection();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void NotifyClosedConnection();
		
		/// <summary>
        ///Notification of one of several types of state changed </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnStateChange(uint state);
		
		/// <summary>
        ///Changes to MediaStreams </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnAddStream([MarshalAs(UnmanagedType.Interface)] nsIDOMMediaStream stream, [MarshalAs(UnmanagedType.LPStr)] string type);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnRemoveStream();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnAddTrack();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void OnRemoveTrack();
		
		/// <summary>
        ///When SDP is parsed and a candidate line is found this method is called.
        /// It should hook back into the media transport to notify it of ICE candidates
        /// listed in the SDP PeerConnectionImpl does not parse ICE candidates, just
        /// pulls them out of the SDP.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void FoundIceCandidate([MarshalAs(UnmanagedType.LPStr)] string candidate);
	}
	
	/// <summary>IPeerConnectionObserverConsts </summary>
	public class IPeerConnectionObserverConsts
	{
		
		// <summary>
        //Constants </summary>
		public const long kReadyState = 0x1;
		
		// 
		public const long kIceState = 0x2;
		
		// 
		public const long kSdpState = 0x3;
		
		// 
		public const long kSipccState = 0x4;
	}
	
	/// <summary>IPeerConnection </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("cc8327f5-66f4-42f4-820d-9a9db0474b6e")]
	public interface IPeerConnection
	{
		
		/// <summary>
        ///Must be called first. Observer events will be dispatched on the thread provided </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Initialize([MarshalAs(UnmanagedType.Interface)] IPeerConnectionObserver observer, [MarshalAs(UnmanagedType.Interface)] nsIDOMWindow window, Gecko.JsVal iceServers, [MarshalAs(UnmanagedType.Interface)] nsIThread thread, System.IntPtr jsContext);
		
		/// <summary>
        ///JSEP calls </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CreateOffer(Gecko.JsVal constraints, System.IntPtr jsContext);
		
		/// <summary>Member CreateAnswer </summary>
		/// <param name='constraints'> </param>
		/// <param name='jsContext'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CreateAnswer(Gecko.JsVal constraints, System.IntPtr jsContext);
		
		/// <summary>Member SetLocalDescription </summary>
		/// <param name='action'> </param>
		/// <param name='sdp'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetLocalDescription(int action, [MarshalAs(UnmanagedType.LPStr)] string sdp);
		
		/// <summary>Member SetRemoteDescription </summary>
		/// <param name='action'> </param>
		/// <param name='sdp'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetRemoteDescription(int action, [MarshalAs(UnmanagedType.LPStr)] string sdp);
		
		/// <summary>
        ///Adds the stream created by GetUserMedia </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AddStream([MarshalAs(UnmanagedType.Interface)] nsIDOMMediaStream stream);
		
		/// <summary>Member RemoveStream </summary>
		/// <param name='stream'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RemoveStream([MarshalAs(UnmanagedType.Interface)] nsIDOMMediaStream stream);
		
		/// <summary>Member CloseStreams </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CloseStreams();
		
		/// <summary>Member GetLocalStreamsAttribute </summary>
		/// <param name='jsContext'> </param>
		/// <returns>A Gecko.JsVal</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal GetLocalStreamsAttribute(System.IntPtr jsContext);
		
		/// <summary>
        /// MediaStream[]
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal GetRemoteStreamsAttribute(System.IntPtr jsContext);
		
		/// <summary>
        ///As the ICE candidates roll in this one should be called each time
        /// in order to keep the candidate list up-to-date for the next SDP-related
        /// call PeerConnectionImpl does not parse ICE candidates, just sticks them
        /// into the SDP.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AddIceCandidate([MarshalAs(UnmanagedType.LPStr)] string candidate, [MarshalAs(UnmanagedType.LPStr)] string mid, ushort level);
		
		/// <summary>
        ///Puts the SIPCC engine back to 'kIdle', shuts down threads, deletes state </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Close([MarshalAs(UnmanagedType.U1)] bool isSynchronous);
		
		/// <summary>
        ///Attributes </summary>
		[return: MarshalAs(UnmanagedType.LPStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string GetLocalDescriptionAttribute();
		
		/// <summary>Member GetRemoteDescriptionAttribute </summary>
		/// <returns>A System.String</returns>
		[return: MarshalAs(UnmanagedType.LPStr)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		string GetRemoteDescriptionAttribute();
		
		/// <summary>Member GetIceStateAttribute </summary>
		/// <returns>A System.UInt32</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetIceStateAttribute();
		
		/// <summary>Member GetReadyStateAttribute </summary>
		/// <returns>A System.UInt32</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetReadyStateAttribute();
		
		/// <summary>Member GetSipccStateAttribute </summary>
		/// <returns>A System.UInt32</returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetSipccStateAttribute();
		
		/// <summary>
        ///Data channels </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMDataChannel CreateDataChannel([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase label, ushort type, [MarshalAs(UnmanagedType.U1)] bool outOfOrderAllowed, ushort maxTime, ushort maxNum);
		
		/// <summary>Member ConnectDataConnection </summary>
		/// <param name='localport'> </param>
		/// <param name='remoteport'> </param>
		/// <param name='numstreams'> </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ConnectDataConnection(ushort localport, ushort remoteport, ushort numstreams);
	}
	
	/// <summary>IPeerConnectionConsts </summary>
	public class IPeerConnectionConsts
	{
		
		// 
		public const ulong kHintAudio = 0x00000001;
		
		// 
		public const ulong kHintVideo = 0x00000002;
		
		// 
		public const long kActionNone = -1;
		
		// 
		public const long kActionOffer = 0;
		
		// 
		public const long kActionAnswer = 1;
		
		// 
		public const long kActionPRAnswer = 2;
		
		// 
		public const long kIceGathering = 0;
		
		// 
		public const long kIceWaiting = 1;
		
		// 
		public const long kIceChecking = 2;
		
		// 
		public const long kIceConnected = 3;
		
		// 
		public const long kIceFailed = 4;
		
		// <summary>
        //for 'type' in DataChannelInit dictionary </summary>
		public const ulong kDataChannelReliable = 0;
		
		// 
		public const ulong kDataChannelPartialReliableRexmit = 1;
		
		// 
		public const ulong kDataChannelPartialReliableTimed = 2;
	}
}
