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
// Generated by IDLImporter from file nsICryptoHMAC.idl
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
    /// nsICryptoHMAC
    /// This interface provides HMAC signature algorithms.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("8FEB4C7C-1641-4a7b-BC6D-1964E2099497")]
	public interface nsICryptoHMAC
	{
		
		/// <summary>
        /// Initialize the hashing object. This method may be
        /// called multiple times with different algorithm types.
        ///
        /// @param aAlgorithm the algorithm type to be used.
        /// This value must be one of the above valid
        /// algorithm types.
        ///
        /// @param aKeyObject
        /// Object holding a key. To create the key object use for instance:
        /// var keyObject = Components.classes["@mozilla.org/security/keyobjectfactory;1"]
        /// .getService(Components.interfaces.nsIKeyObjectFactory)
        /// .keyFromString(Components.interfaces.nsIKeyObject.HMAC, rawKeyData);
        ///
        /// WARNING: This approach is not FIPS compliant.
        ///
        /// @throws NS_ERROR_INVALID_ARG if an unsupported algorithm
        /// type is passed.
        ///
        /// NOTE: This method must be called before any other method
        /// on this interface is called.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Init(uint aAlgorithm, [MarshalAs(UnmanagedType.Interface)] nsIKeyObject aKeyObject);
		
		/// <summary>
        /// @param aData a buffer to calculate the hash over
        ///
        /// @param aLen the length of the buffer |aData|
        ///
        /// @throws NS_ERROR_NOT_INITIALIZED if |init| has not been
        /// called.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Update([MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] byte[] aData, uint aLen);
		
		/// <summary>
        /// Calculates and updates a new hash based on a given data stream.
        ///
        /// @param aStream an input stream to read from.
        ///
        /// @param aLen how much to read from the given |aStream|.  Passing
        /// UINT32_MAX indicates that all data available will be used
        /// to update the hash.
        ///
        /// @throws NS_ERROR_NOT_INITIALIZED if |init| has not been
        /// called.
        ///
        /// @throws NS_ERROR_NOT_AVAILABLE if the requested amount of
        /// data to be calculated into the hash is not available.
        ///
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void UpdateFromStream([MarshalAs(UnmanagedType.Interface)] nsIInputStream aStream, uint aLen);
		
		/// <summary>
        /// Completes this HMAC object and produces the actual HMAC diegest data.
        ///
        /// @param aASCII if true then the returned value is a base-64
        /// encoded string.  if false, then the returned value is
        /// binary data.
        ///
        /// @return a hash of the data that was read by this object.  This can
        /// be either binary data or base 64 encoded.
        ///
        /// @throws NS_ERROR_NOT_INITIALIZED if |init| has not been
        /// called.
        ///
        /// NOTE: This method may be called any time after |init|
        /// is called.  This call resets the object to its
        /// pre-init state.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Finish([MarshalAs(UnmanagedType.U1)] bool aASCII, [MarshalAs(UnmanagedType.LPStruct)] nsACStringBase retval);
		
		/// <summary>
        /// Reinitialize HMAC context to be reused with the same
        /// settings (the key and hash algorithm) but on different
        /// set of data.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Reset();
	}
	
	/// <summary>nsICryptoHMACConsts </summary>
	public class nsICryptoHMACConsts
	{
		
		// <summary>
        // Hashing Algorithms.  These values are to be used by the
        // |init| method to indicate which hashing function to
        // use.  These values map onto the values defined in
        // mozilla/security/nss/lib/softoken/pkcs11t.h and are
        // switched to CKM_*_HMAC constant.
        // </summary>
		public const int MD2 = 1;
		
		// 
		public const int MD5 = 2;
		
		// 
		public const int SHA1 = 3;
		
		// 
		public const int SHA256 = 4;
		
		// 
		public const int SHA384 = 5;
		
		// 
		public const int SHA512 = 6;
	}
}
