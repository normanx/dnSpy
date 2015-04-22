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

using dnlib.DotNet;

namespace ICSharpCode.ILSpy.TreeNodes.Filters
{
	sealed class FlagsTreeViewNodeFilter : TreeViewNodeFilterBase
	{
		readonly VisibleMembersFlags flags;

		public override string Text {
			get { return flags.GetListString(); }
		}

		public FlagsTreeViewNodeFilter(VisibleMembersFlags flags)
		{
			this.flags = flags;
		}

		public override TreeViewNodeFilterResult GetFilterResult(AssemblyRef asmRef)
		{
			bool isMatch = (flags & VisibleMembersFlags.AssemblyRef) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(LoadedAssembly asm, AssemblyFilterType type)
		{
			VisibleMembersFlags thisFlag, visibleFlags;
			switch (type) {
			case AssemblyFilterType.Assembly:
				thisFlag = VisibleMembersFlags.AssemblyDef;
				visibleFlags = thisFlag | VisibleMembersFlags.ModuleDef |
						VisibleMembersFlags.Namespace | VisibleMembersFlags.AnyTypeDef |
						VisibleMembersFlags.FieldDef | VisibleMembersFlags.MethodDef |
						VisibleMembersFlags.PropertyDef | VisibleMembersFlags.EventDef |
						VisibleMembersFlags.AssemblyRef | VisibleMembersFlags.BaseTypes |
						VisibleMembersFlags.DerivedTypes | VisibleMembersFlags.ModuleRef |
						VisibleMembersFlags.ResourceList | VisibleMembersFlags.MethodBody |
						VisibleMembersFlags.ParamDef;
				break;

			case AssemblyFilterType.NetModule:
				thisFlag = VisibleMembersFlags.ModuleDef;
				visibleFlags = thisFlag |
						VisibleMembersFlags.Namespace | VisibleMembersFlags.AnyTypeDef |
						VisibleMembersFlags.FieldDef | VisibleMembersFlags.MethodDef |
						VisibleMembersFlags.PropertyDef | VisibleMembersFlags.EventDef |
						VisibleMembersFlags.AssemblyRef | VisibleMembersFlags.BaseTypes |
						VisibleMembersFlags.DerivedTypes | VisibleMembersFlags.ModuleRef |
						VisibleMembersFlags.ResourceList | VisibleMembersFlags.MethodBody |
						VisibleMembersFlags.ParamDef;
				break;

			case AssemblyFilterType.NonNetFile:
			default:
				thisFlag = VisibleMembersFlags.NonNetFile;
				visibleFlags = thisFlag;
				break;
			}
			bool isMatch = (flags & thisFlag) != 0;
			if ((flags & visibleFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);

			if (isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Match, isMatch);	// Make sure it's not hidden

			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(BaseTypesTreeNode node)
		{
			bool isMatch = (flags & VisibleMembersFlags.BaseTypes) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(DerivedTypesTreeNode node)
		{
			bool isMatch = (flags & VisibleMembersFlags.DerivedTypes) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(EventDef evt)
		{
			var visibleFlags = VisibleMembersFlags.EventDef | VisibleMembersFlags.MethodDef |
								VisibleMembersFlags.MethodBody | VisibleMembersFlags.ParamDef;
			bool isMatch = (flags & VisibleMembersFlags.EventDef) != 0;
			if ((flags & visibleFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(FieldDef field)
		{
			bool isMatch = (flags & VisibleMembersFlags.FieldDef) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(MethodDef method)
		{
			var visibleFlags = VisibleMembersFlags.MethodDef | VisibleMembersFlags.MethodBody |
								VisibleMembersFlags.ParamDef;
			bool isMatch = (flags & VisibleMembersFlags.MethodDef) != 0;
			if ((flags & visibleFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(ModuleRef modRef)
		{
			bool isMatch = (flags & VisibleMembersFlags.ModuleRef) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(string ns)
		{
			var visibleFlags = VisibleMembersFlags.Namespace | VisibleMembersFlags.AnyTypeDef |
					VisibleMembersFlags.FieldDef | VisibleMembersFlags.MethodDef |
					VisibleMembersFlags.PropertyDef | VisibleMembersFlags.EventDef |
					VisibleMembersFlags.BaseTypes | VisibleMembersFlags.DerivedTypes |
					VisibleMembersFlags.MethodBody | VisibleMembersFlags.ParamDef;
			bool isMatch = (flags & VisibleMembersFlags.Namespace) != 0;
			if ((flags & visibleFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			if (isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Match, isMatch);	// Make sure it's not hidden
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(PropertyDef prop)
		{
			var visibleFlags = VisibleMembersFlags.PropertyDef | VisibleMembersFlags.MethodDef |
								VisibleMembersFlags.MethodBody | VisibleMembersFlags.ParamDef;
			bool isMatch = (flags & VisibleMembersFlags.PropertyDef) != 0;
			if ((flags & visibleFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(ReferenceFolderTreeNode node)
		{
			var visibleFlags = VisibleMembersFlags.AssemblyRef | VisibleMembersFlags.ModuleRef;
			bool isMatch = false;
			if ((flags & visibleFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(ResourceListTreeNode node)
		{
			bool isMatch = (flags & VisibleMembersFlags.ResourceList) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			if (isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Match, isMatch);	// Make sure it's not hidden
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResult(TypeDef type)
		{
			var childrenFlags = VisibleMembersFlags.FieldDef | VisibleMembersFlags.MethodDef |
					VisibleMembersFlags.PropertyDef | VisibleMembersFlags.EventDef |
					VisibleMembersFlags.BaseTypes | VisibleMembersFlags.DerivedTypes |
					VisibleMembersFlags.MethodBody | VisibleMembersFlags.ParamDef;
			var visibleFlags = VisibleMembersFlags.AnyTypeDef | childrenFlags;
			if ((flags & visibleFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, false);
			if ((flags & VisibleMembersFlags.GenericTypeDef) != 0 && type.GenericParameters.Count > 0)
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & VisibleMembersFlags.NonGenericTypeDef) != 0 && type.GenericParameters.Count == 0)
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & VisibleMembersFlags.EnumTypeDef) != 0 && type.IsEnum)
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & VisibleMembersFlags.InterfaceTypeDef) != 0 && type.IsInterface)
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & VisibleMembersFlags.ClassTypeDef) != 0 && !type.IsValueType)
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & VisibleMembersFlags.ValueTypeDef) != 0 && type.IsValueType)
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & VisibleMembersFlags.DelegateTypeDef) != 0 && TypeTreeNode.IsDelegate(type))
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & VisibleMembersFlags.TypeDef) != 0)
				return new TreeViewNodeFilterResult(FilterResult.Match, true);
			else if ((flags & childrenFlags) == 0)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, false);
			return new TreeViewNodeFilterResult(null, false);
		}

		public override TreeViewNodeFilterResult GetFilterResultBody(MethodDef method)
		{
			bool isMatch = (flags & VisibleMembersFlags.MethodBody) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}

		public override TreeViewNodeFilterResult GetFilterResultParamDef(MethodDef method)
		{
			bool isMatch = (flags & VisibleMembersFlags.ParamDef) != 0;
			if (!isMatch)
				return new TreeViewNodeFilterResult(FilterResult.Hidden, isMatch);
			return new TreeViewNodeFilterResult(null, isMatch);
		}
	}
}