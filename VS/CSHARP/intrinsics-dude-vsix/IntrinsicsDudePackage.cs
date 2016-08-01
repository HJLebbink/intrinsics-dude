// The MIT License (MIT)
//
// Copyright (c) 2016 Henk-Jan Lebbink
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Shell.Interop;
using System.Text;
using IntrinsicsDude.Tools;

namespace IntrinsicsDude {

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0.1.A", IconResourceID = 400)] // Info on this package for Help/About

    [ProvideAutoLoad(UIContextGuids.NoSolution)] //load this package once visual studio starts.
    [Guid("F5281774-B3EE-41D0-BA5A-E05C3D73BBCD")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]

    [ComVisible(false)]

    public sealed class IntrinsicsDudePackage : Package {

        #region Global Constants
        internal const string IntrinsicsDudeContentType = "asm!";
        //internal const string IntrinsicsDudeContentType = "C/C++";

        #endregion Global Constants

        public IntrinsicsDudePackage() {
            Debug.WriteLine("=========================================\nINFO: IntrinsicsDudePackage: Entering constructor\n=========================================\n");
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudePackage: Entering constructor");
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package. This is where you should put all initialization
        /// code that depends on VS services.
        /// </summary>
        protected override void Initialize() {
            base.Initialize();
            Debug.WriteLine("=========================================\nINFO: IntrinsicsDudePackage: Entering Initialize\n=========================================\n");

            StringBuilder sb = new StringBuilder();
            sb.Append("Welcome to Instrinsics Dude\n");
            //sb.Append(" _____           ____        _     \n");
            //sb.Append("|  _  |___ _____|    \\ _ _ _| |___\n");
            //sb.Append("|     |_ -|     |  |  | | | . | -_|\n");
            //sb.Append("|__|__|___|_|_|_|____/|___|___|___|\n");
            sb.Append("INFO: Loaded InstrinsicsDude version " + typeof(IntrinsicsDudePackage).Assembly.GetName().Version +" ("+ ApplicationInformation.CompileDate.ToString()+")\n");
            sb.Append("INFO: More info at https://github.com/HJLebbink/instrinsics-dude \n");
            sb.Append("----------------------------------");
            IntrinsicsDudeToolsStatic.Output(sb.ToString());
        }

        #endregion
    }
}
