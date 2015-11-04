﻿// Copyright (c) 2011 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using dnlib.DotNet;
using dnSpy;
using dnSpy.Images;
using dnSpy.NRefactory;
using ICSharpCode.Decompiler;

namespace ICSharpCode.ILSpy.TreeNodes.Analyzer {
	internal class AnalyzedAssemblyTreeNode : AnalyzerEntityTreeNode {
		private readonly ModuleDef analyzedAssembly;

		public AnalyzedAssemblyTreeNode(ModuleDef analyzedAssembly) {
			if (analyzedAssembly == null)
				throw new ArgumentNullException("analyzedAssembly");
			this.analyzedAssembly = analyzedAssembly;
			//this.LazyLoading = true;
		}

		public override object Icon {
			get { return ImageCache.Instance.GetImage(GetType().Assembly, "Assembly", BackgroundType.TreeNode); }
		}

		protected override void Write(ITextOutput output, Language language) {
			var isExe = analyzedAssembly.Assembly != null &&
				analyzedAssembly.IsManifestModule &&
				(analyzedAssembly.Characteristics & dnlib.PE.Characteristics.Dll) == 0;
			output.Write(UIUtils.CleanUpIdentifier(analyzedAssembly.Name), isExe ? TextTokenType.AssemblyExe : TextTokenType.Assembly);
		}

		protected override void LoadChildren() {
			//this.Children.Add(new AnalyzedAssemblyReferencedByTreeNode(analyzedAssembly));
		}

		public override IMemberRef Member {
			get { return null; }
		}

		public override IMDTokenProvider MDTokenProvider {
			get { return analyzedAssembly; }
		}
	}
}