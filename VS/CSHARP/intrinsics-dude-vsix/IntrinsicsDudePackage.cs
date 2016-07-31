using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;
using System.Text;

using EnvDTE;
using IntrinsicsDude.Tools;
using System.Diagnostics.CodeAnalysis;

namespace IntrinsicsDude {

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "0.2", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(IntrinsicsDudePackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class IntrinsicsDudePackage : Package {

        public const string PackageGuidString = "ede82d96-80b5-4f47-b68a-320d6e2342fd";
        internal const string IntrinsicsDudeContentType = "asm!";
        //internal const string IntrinsicsDudeContentType = "C/C++";


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
            /*
            StringBuilder sb = new StringBuilder();
            sb.Append("Welcome to Instrinsics Dude\n");
            //sb.Append(" _____           ____        _     \n");
            //sb.Append("|  _  |___ _____|    \\ _ _ _| |___\n");
            //sb.Append("|     |_ -|     |  |  | | | . | -_|\n");
            //sb.Append("|__|__|___|_|_|_|____/|___|___|___|\n");
            sb.Append("INFO: Loaded InstrinsicsDude version " + typeof(IntrinsicsDudePackage).Assembly.GetName().Version +" ("+ ApplicationInformation.CompileDate.ToString()+")\n");
            //sb.Append("INFO: Open source assembly extension. Making programming in assembler bearable.\n");
            sb.Append("INFO: More info at https://github.com/HJLebbink/instrinsics-dude \n");
            sb.Append("----------------------------------");
            IntrinsicsDudeToolsStatic.Output(sb.ToString());
            */
        }

        #endregion
    }
}
