﻿/*
    Copyright (C) 2014-2015 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using dnlib.DotNet;
using dnSpy.Contracts.Controls;
using dnSpy.Contracts.Images;
using dnSpy.Contracts.TreeView;

namespace dnSpy.Contracts.Files.TreeView {
	/// <summary>
	/// File tree view
	/// </summary>
	public interface IFileTreeView : IFileTreeNodeCreator {
		/// <summary>
		/// Gets the <see cref="IFileManager"/> instance
		/// </summary>
		IFileManager FileManager { get; }

		/// <summary>
		/// Gets the <see cref="ITreeView"/> instance
		/// </summary>
		ITreeView TreeView { get; }

		/// <summary>
		/// Gets the <see cref="IDotNetImageManager"/> instance
		/// </summary>
		IDotNetImageManager DotNetImageManager { get; }

		/// <summary>
		/// Gets the <see cref="IWpfCommands"/> instance
		/// </summary>
		IWpfCommands WpfCommands { get; }

		/// <summary>
		/// Notified when the collection gets changed
		/// </summary>
		event EventHandler<NotifyFileTreeViewCollectionChangedEventArgs> CollectionChanged;

		/// <summary>
		/// Notified when the node's text has changed
		/// </summary>
		event EventHandler<EventArgs> NodesTextChanged;

		/// <summary>
		/// Creates a new <see cref="IDnSpyFileNode"/> instance. This will internally call all
		/// <see cref="IDnSpyFileNodeCreator"/>s it can find.
		/// </summary>
		/// <param name="owner">Owner node or null if owner is the root node</param>
		/// <param name="file">New file</param>
		/// <returns></returns>
		IDnSpyFileNode CreateNode(IDnSpyFileNode owner, IDnSpyFile file);

		/// <summary>
		/// Returns a node or null if none could be found
		/// </summary>
		/// <param name="ref">Reference, eg. a <see cref="IMemberRef"/></param>
		/// <returns></returns>
		IFileTreeNodeData FindNode(object @ref);

		/// <summary>
		/// Returns a <see cref="IDnSpyFileNode"/> node or null if none could be found
		/// </summary>
		/// <param name="file">File</param>
		/// <returns></returns>
		IDnSpyFileNode FindNode(IDnSpyFile file);

		/// <summary>
		/// Returns a <see cref="IAssemblyFileNode"/> node or null if none could be found
		/// </summary>
		/// <param name="assembly">Assembly</param>
		/// <returns></returns>
		IAssemblyFileNode FindNode(AssemblyDef assembly);

		/// <summary>
		/// Returns a <see cref="IModuleFileNode"/> node or null if none could be found
		/// </summary>
		/// <param name="module">Module</param>
		/// <returns></returns>
		IModuleFileNode FindNode(ModuleDef module);

		/// <summary>
		/// Returns a <see cref="ITypeNode"/> node or null if none could be found
		/// </summary>
		/// <param name="type">Type</param>
		/// <returns></returns>
		ITypeNode FindNode(TypeDef type);

		/// <summary>
		/// Returns a <see cref="IMethodNode"/> node or null if none could be found
		/// </summary>
		/// <param name="method">Method</param>
		/// <returns></returns>
		IMethodNode FindNode(MethodDef method);

		/// <summary>
		/// Returns a <see cref="IFieldNode"/> node or null if none could be found
		/// </summary>
		/// <param name="field">Field</param>
		/// <returns></returns>
		IFieldNode FindNode(FieldDef field);

		/// <summary>
		/// Returns a <see cref="IPropertyNode"/> node or null if none could be found
		/// </summary>
		/// <param name="property">Property</param>
		/// <returns></returns>
		IPropertyNode FindNode(PropertyDef property);

		/// <summary>
		/// Returns a <see cref="IEventNode"/> node or null if none could be found
		/// </summary>
		/// <param name="event">Event</param>
		/// <returns></returns>
		IEventNode FindNode(EventDef @event);

		/// <summary>
		/// Gets the <see cref="IFileTreeNodeGroups"/> instance
		/// </summary>
		IFileTreeNodeGroups FileTreeNodeGroups { get; }
	}
}