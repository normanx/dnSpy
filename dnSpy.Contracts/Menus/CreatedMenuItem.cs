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

namespace dnSpy.Contracts.Menus {
	/// <summary>
	/// <see cref="MenuItem"/> info
	/// </summary>
	public struct CreatedMenuItem {
		/// <summary>
		/// Metadata, eg. an <see cref="ExportMenuItemAttribute"/> instance
		/// </summary>
		public IMenuItemMetadata Metadata { get; private set; }

		/// <summary>
		/// Menu item
		/// </summary>
		public IMenuItem MenuItem { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="md">Metadata, eg. an <see cref="ExportMenuItemAttribute"/> instance</param>
		/// <param name="menuItem">Menu item</param>
		public CreatedMenuItem(IMenuItemMetadata md, IMenuItem menuItem) {
			this.Metadata = md;
			this.MenuItem = menuItem;
		}
	}
}