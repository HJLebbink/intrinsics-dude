using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;
using System.Text;

using EnvDTE;
using IntrinsicsDude.Tools;

namespace IntrinsicsDude {

    /// <summary>
    /// This class implements a Visual Studio package that is registered for the Visual Studio IDE.
    /// The package class uses a number of registration attributes to specify integration parameters.
    /// </summary>

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("IntrinsicsDude", "Intrinsics-Dude", "0.1")] // for the help about information

    [ProvideMenuResource("Menus.ctmenu", 1)] // needed when showing menus
    [ProvideAutoLoad(UIContextGuids.NoSolution)]
    [Guid(Guids.GuidPackage_str)]
    [ComVisible(false)]
    
    //[ProvideOptionPage(typeof(AsmDudeOptionsPage), "AsmDude", "General", 0, 0, true)]
    //[ProvideProfile(typeof(AsmDudeOptionsPage), "AsmDude", "General", 100, 104, isToolsOptionPage: false, DescriptionResourceID = 100)]

    public sealed class IntrinsicsDudePackage : Package {

        #region Global Constants

        internal const string IntrinsicsDudeContentType = "C/C++";
        internal const double slowWarningThresholdSec = 0.4; // threshold to warn that actions are considered slow
        internal const double slowShutdownThresholdSec = 4.0; // threshold to switch of components
        internal const int maxNumberOfCharsInToolTips = 150;
        internal const int msSleepBeforeAsyncExecution = 1000;

        #endregion Global Constants

        public IntrinsicsDudePackage() {
            Debug.WriteLine("=========================================\nINFO: IntrinsicsDudePackage: Entering constructor\n=========================================\n");
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudePackage: Entering constructor");
        }

        /// <summary>
        /// Initialization of the package. This is where you should put all initialization
        /// code that depends on VS services.
        /// </summary>
        protected override void Initialize() {
            base.Initialize();

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
        }
    }
}
