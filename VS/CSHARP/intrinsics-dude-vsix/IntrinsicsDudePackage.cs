// The MIT License (MIT)
//
// Copyright (c) 2018 Henk-Jan Lebbink
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

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using IntrinsicsDude.OptionsPage;
using System.Text;
using IntrinsicsDude.Tools;
using System.Threading;

namespace IntrinsicsDude
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)] // Info on this package for Help/About
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ComVisible(false)]
    [ProvideOptionPage(typeof(IntrinsicsDudeOptionsPage), "Intrinsics Dude", "General", 0, 0, true)]

    public sealed class IntrinsicsDudePackage : AsyncPackage
    {
        #region Global Constants
        public const string PackageGuidString = "00389BEF-8EAC-4E4E-8BC7-03151131B73E";

        internal const string IntrinsicsDudeContentType = "C/C++";
        internal const double slowWarningThresholdSec = 0.3; // threshold to warn that actions are considered slow
        //internal const double slowShutdownThresholdSec = 4.0; // threshold to switch off components
        internal const int maxNumberOfCharsInToolTips = 130;
        internal const int maxNumberOfCharsInCompletions = 80;
        //internal const int msSleepBeforeAsyncExecution = 1000;

        #endregion Global Constants

        public IntrinsicsDudePackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "=========================================\nINFO: IntrinsicsDudePackage: Entering constructor"));
            IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicsDudePackage: Entering constructor");
        }

        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);

            StringBuilder sb = new StringBuilder();
            sb.Append("Welcome to\n");
            sb.Append(" ____     _       _         _           ____        _     \n");
            sb.Append("|    |___| |_ ___|_|___ ___|_|___ ___  |    \\ _ _ _| |___ \n");
            sb.Append("|-  -|   |  _|  _| |   |_ -| |  _|_ -| |  |  | | | . | -_|\n");
            sb.Append("|____|_|_|_| |_| |_|_|_|___|_|___|___| |____/|___|___|___|\n");
            sb.Append("INFO: Loaded IntrinsicsDude version " + typeof(IntrinsicsDudePackage).Assembly.GetName().Version + " (" + ApplicationInformation.CompileDate.ToString() + ")\n");
            sb.Append("INFO: More info at https://github.com/HJLebbink/intrinsics-dude \n");
            sb.Append("----------------------------------");
            await IntrinsicsDudeToolsStatic.OutputAsync(sb.ToString());
        }
    }
}
