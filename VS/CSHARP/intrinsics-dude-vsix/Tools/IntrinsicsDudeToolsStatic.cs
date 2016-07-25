// The MIT License (MIT)
//
// Copyright (c) 2016 H.J. Lebbink
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
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Diagnostics;
using System.Globalization;

namespace IntrinsicsDude.Tools {

    public static class IntrinsicsDudeToolsStatic {

        #region Singleton Factories
        
        public static void printSpeedWarning(DateTime startTime, string component) {
            double elapsedSec = (double)(DateTime.Now.Ticks - startTime.Ticks) / 10000000;
            if (elapsedSec > IntrinsicsDudePackage.slowWarningThresholdSec) {
                IntrinsicsDudeToolsStatic.Output(string.Format("WARNING: SLOW: took {0} {1:F3} seconds to finish", component, elapsedSec));
            }
        }

        #endregion Singleton Factories

        /// <summary>
        /// get the full filename (with path) for the provided buffer
        /// </summary>
        public static string GetFileName(ITextBuffer buffer) {
            Microsoft.VisualStudio.TextManager.Interop.IVsTextBuffer bufferAdapter;
            buffer.Properties.TryGetProperty(typeof(Microsoft.VisualStudio.TextManager.Interop.IVsTextBuffer), out bufferAdapter);
            if (bufferAdapter != null) {
                IPersistFileFormat persistFileFormat = bufferAdapter as IPersistFileFormat;

                string filename = null;
                uint dummyInteger;
                if (persistFileFormat != null) {
                    persistFileFormat.GetCurFile(out filename, out dummyInteger);
                }
                return filename;
            } else {
                return null;
            }
        }
        /// <summary>
        /// Get the path where this visual studio extension is installed.
        /// </summary>
        public static string getInstallPath() {
            try {
                string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string filenameDll = "IntrinsicsDude.dll";
                return fullPath.Substring(0, fullPath.Length - filenameDll.Length);
            } catch (Exception) {
                return "";
            }
        }

        /// <summary>
        /// Cleans the provided line by removing multiple white spaces and cropping if the line is too long
        /// </summary>
        public static string cleanup(string line) {
            string cleanedString = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
            if (cleanedString.Length > IntrinsicsDudePackage.maxNumberOfCharsInToolTips) {
                return cleanedString.Substring(0, IntrinsicsDudePackage.maxNumberOfCharsInToolTips - 3) + "...";
            } else {
                return cleanedString;
            }
        }
        /// <summary>
        /// Output message to the AsmDude window
        /// </summary>
        public static void Output(string msg) {
            /*
            IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            string msg2 = string.Format(CultureInfo.CurrentCulture, "{0}", msg.Trim() + Environment.NewLine);
            if (outputWindow == null) {
                Debug.Write(msg2);
            } else {
                Guid paneGuid = Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.GeneralPane_guid;
                IVsOutputWindowPane pane;
                outputWindow.CreatePane(paneGuid, "IntrinsicsDude", 1, 0);
                outputWindow.GetPane(paneGuid, out pane);
                pane.OutputString(msg2);
                pane.Activate();
            }
            */
        }
    }
}
