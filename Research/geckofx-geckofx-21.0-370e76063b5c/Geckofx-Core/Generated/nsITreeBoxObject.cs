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
// Generated by IDLImporter from file nsITreeBoxObject.idl
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
	[Guid("64BA5199-C4F4-4498-BBDC-F8E4C369086C")]
	public interface nsITreeBoxObject
	{
		
		/// <summary>
        /// Obtain the columns.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsITreeColumns GetColumnsAttribute();
		
		/// <summary>
        /// The view that backs the tree and that supplies it with its data.
        /// It is dynamically settable, either using a view attribute on the
        /// tree tag or by setting this attribute to a new value.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsITreeView GetViewAttribute();
		
		/// <summary>
        /// The view that backs the tree and that supplies it with its data.
        /// It is dynamically settable, either using a view attribute on the
        /// tree tag or by setting this attribute to a new value.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetViewAttribute([MarshalAs(UnmanagedType.Interface)] nsITreeView aView);
		
		/// <summary>
        /// Whether or not we are currently focused.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetFocusedAttribute();
		
		/// <summary>
        /// Whether or not we are currently focused.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetFocusedAttribute([MarshalAs(UnmanagedType.U1)] bool aFocused);
		
		/// <summary>
        /// Obtain the treebody content node
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIDOMElement GetTreeBodyAttribute();
		
		/// <summary>
        /// Obtain the height of a row.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetRowHeightAttribute();
		
		/// <summary>
        /// Obtain the width of a row.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetRowWidthAttribute();
		
		/// <summary>
        /// Get the pixel position of the horizontal scrollbar.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetHorizontalPositionAttribute();
		
		/// <summary>
        /// Return the region for the visible parts of the selection, in device pixels.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIScriptableRegion GetSelectionRegionAttribute();
		
		/// <summary>
        /// Get the index of the first visible row.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetFirstVisibleRow();
		
		/// <summary>
        /// Get the index of the last visible row.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetLastVisibleRow();
		
		/// <summary>
        /// Gets the number of possible visible rows.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetPageLength();
		
		/// <summary>
        /// Ensures that a row at a given index is visible.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void EnsureRowIsVisible(int index);
		
		/// <summary>
        /// Ensures that a given cell in the tree is visible.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void EnsureCellIsVisible(int row, [MarshalAs(UnmanagedType.Interface)] nsITreeColumn col);
		
		/// <summary>
        /// Scrolls such that the row at index is at the top of the visible view.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScrollToRow(int index);
		
		/// <summary>
        /// Scroll the tree up or down by numLines lines. Positive
        /// values move down in the tree. Prevents scrolling off the
        /// end of the tree.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScrollByLines(int numLines);
		
		/// <summary>
        /// Scroll the tree up or down by numPages pages. A page
        /// is considered to be the amount displayed by the tree.
        /// Positive values move down in the tree. Prevents scrolling
        /// off the end of the tree.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScrollByPages(int numPages);
		
		/// <summary>
        /// Scrolls such that a given cell is visible (if possible)
        /// at the top left corner of the visible view.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScrollToCell(int row, [MarshalAs(UnmanagedType.Interface)] nsITreeColumn col);
		
		/// <summary>
        /// Scrolls horizontally so that the specified column is
        /// at the left of the view (if possible).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScrollToColumn([MarshalAs(UnmanagedType.Interface)] nsITreeColumn col);
		
		/// <summary>
        /// Scroll to a specific horizontal pixel position.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ScrollToHorizontalPosition(int horizontalPosition);
		
		/// <summary>
        /// Invalidation methods for fine-grained painting control.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Invalidate();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void InvalidateColumn([MarshalAs(UnmanagedType.Interface)] nsITreeColumn col);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void InvalidateRow(int index);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void InvalidateCell(int row, [MarshalAs(UnmanagedType.Interface)] nsITreeColumn col);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void InvalidateRange(int startIndex, int endIndex);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void InvalidateColumnRange(int startIndex, int endIndex, [MarshalAs(UnmanagedType.Interface)] nsITreeColumn col);
		
		/// <summary>
        /// A hit test that can tell you what row the mouse is over.
        /// returns -1 for invalid mouse coordinates.
        ///
        /// The coordinate system is the client coordinate system for the
        /// document this boxObject lives in, and the units are CSS pixels.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetRowAt(int x, int y);
		
		/// <summary>
        /// A hit test that can tell you what cell the mouse is over.  Row is the row index
        /// hit,  returns -1 for invalid mouse coordinates.  ColID is the column hit.
        /// ChildElt is the pseudoelement hit: this can have values of
        /// "cell", "twisty", "image", and "text".
        ///
        /// The coordinate system is the client coordinate system for the
        /// document this boxObject lives in, and the units are CSS pixels.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetCellAt(int x, int y, ref int row, [MarshalAs(UnmanagedType.Interface)] ref nsITreeColumn col, [MarshalAs(UnmanagedType.LPStruct)] nsACStringBase childElt);
		
		/// <summary>
        /// Find the coordinates of an element within a specific cell.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetCoordsForCellItem(int row, [MarshalAs(UnmanagedType.Interface)] nsITreeColumn col, [MarshalAs(UnmanagedType.LPStruct)] nsACStringBase element, ref int x, ref int y, ref int width, ref int height);
		
		/// <summary>
        /// Determine if the text of a cell is being cropped or not.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsCellCropped(int row, [MarshalAs(UnmanagedType.Interface)] nsITreeColumn col);
		
		/// <summary>
        /// The view is responsible for calling these notification methods when
        /// rows are added or removed.  Index is the position at which the new
        /// rows were added or at which rows were removed.  For
        /// non-contiguous additions/removals, this method should be called multiple times.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RowCountChanged(int index, int count);
		
		/// <summary>
        /// Notify the tree that the view is about to perform a batch
        /// update, that is, add, remove or invalidate several rows at once.
        /// This must be followed by calling endUpdateBatch(), otherwise the tree
        /// will get out of sync.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void BeginUpdateBatch();
		
		/// <summary>
        /// Notify the tree that the view has completed a batch update.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void EndUpdateBatch();
		
		/// <summary>
        /// Called on a theme switch to flush out the tree's style and image caches.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void ClearStyleAndImageCaches();
	}
}
