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

using IntrinsicsDude.ErrorSquiggles;
using IntrinsicsDude.SyntaxHighlighting;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.Tools
{
    public static class IntrinsicsDudeToolsStatic
    {
        public static ITagAggregator<IntrinsicTokenTag> getAggregator(
            ITextBuffer buffer,
            IBufferTagAggregatorFactoryService aggregatorFactory)
        {

            Func<ITagAggregator<IntrinsicTokenTag>> sc = delegate ()
            {
                return aggregatorFactory.CreateTagAggregator<IntrinsicTokenTag>(buffer);
            };
            return buffer.Properties.GetOrCreateSingletonProperty(sc);
        }

        public static void printSpeedWarning(DateTime startTime, string component)
        {
            double elapsedSec = (double)(DateTime.Now.Ticks - startTime.Ticks) / 10000000;
            if (elapsedSec > IntrinsicsDudePackage.slowWarningThresholdSec)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("WARNING: SLOW: took {0} {1:F3} seconds to finish", component, elapsedSec));
            }
        }

        /// <summary>
        /// get the full filename (with path) for the provided buffer
        /// </summary>
        public static string GetFileName(ITextBuffer buffer)
        {
            Microsoft.VisualStudio.TextManager.Interop.IVsTextBuffer bufferAdapter;
            buffer.Properties.TryGetProperty(typeof(Microsoft.VisualStudio.TextManager.Interop.IVsTextBuffer), out bufferAdapter);
            if (bufferAdapter != null)
            {
                IPersistFileFormat persistFileFormat = bufferAdapter as IPersistFileFormat;

                string filename = null;
                uint dummyInteger;
                if (persistFileFormat != null)
                {
                    persistFileFormat.GetCurFile(out filename, out dummyInteger);
                }
                return filename;
            }
            else
            {
                return null;
            }
        }

        public static int getFontSize()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            EnvDTE.Properties propertiesList = dte.get_Properties("FontsAndColors", "TextEditor");
            Property prop = propertiesList.Item("FontSize");
            int fontSize = (System.Int16)prop.Value;
            return fontSize;
        }

        public static FontFamily getFontType()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            EnvDTE.Properties propertiesList = dte.get_Properties("FontsAndColors", "TextEditor");
            Property prop = propertiesList.Item("FontFamily");
            string font = (string)prop.Value;
            //IntrinsicsDudeToolsStatic.Output(string.Format(CultureInfo.CurrentCulture, "ERROR: IntrinsicsDudeToolsStatic:getFontType {0}", font));
            return new FontFamily(font);
        }

        /// <summary>
        /// Get the path where this visual studio extension is installed.
        /// </summary>
        public static string getInstallPath()
        {
            try
            {
                string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string filenameDll = "IntrinsicsDude.dll";
                return fullPath.Substring(0, fullPath.Length - filenameDll.Length);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static System.Windows.Media.Color convertColor(System.Drawing.Color drawingColor)
        {
            return System.Windows.Media.Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
        }

        public static System.Drawing.Color convertColor(System.Windows.Media.Color mediaColor)
        {
            return System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
        }

        public static ImageSource bitmapFromUri(Uri bitmapUri)
        {
            var bitmap = new BitmapImage();
            try
            {
                bitmap.BeginInit();
                bitmap.UriSource = bitmapUri;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("WARNING: bitmapFromUri: could not read icon from uri " + bitmapUri.ToString() + "; " + e.Message);
            }
            return bitmap;
        }

        /// <summary>
        /// Cleans the provided line by removing multiple white spaces and cropping if the line is too long
        /// </summary>
        public static string cleanup(string line, int maxNumOfChars)
        {
            string cleanedString = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
            if (cleanedString.Length > maxNumOfChars)
            {
                return cleanedString.Substring(0, maxNumOfChars - 3) + "...";
            }
            else
            {
                return cleanedString;
            }
        }
        /// <summary>
        /// Output message to the AsmDude window
        /// </summary>
        public static void Output(string msg)
        {
            IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            string msg2 = string.Format(CultureInfo.CurrentCulture, "{0}", msg.Trim() + Environment.NewLine);
            if (outputWindow == null)
            {
                Debug.Write(msg2);
            }
            else
            {
                //Guid paneGuid = Microsoft.VisualStudio.VSConstants.OutputWindowPaneGuid.GeneralPane_guid;
                Guid paneGuid = new Guid("A9F2F5E5-C21D-4BB3-B4A7-FEE69DC0E03A");
                IVsOutputWindowPane pane;
                outputWindow.CreatePane(paneGuid, "Intrinsics Dude", 1, 0);
                outputWindow.GetPane(paneGuid, out pane);
                pane.OutputString(msg2);
                pane.Activate();
            }
        }

        public static bool isAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static CpuID getCpuIDSwithedOn()
        {
            CpuID cpuID = CpuID.NONE;
            foreach (CpuID value in Enum.GetValues(typeof(CpuID)))
            {
                if (isArchSwitchedOn(value))
                {
                    cpuID |= value;
                }
            }
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeToolsStatic:getCpuIDSwithedOn: returns " + IntrinsicTools.ToString(cpuID));
            return cpuID;
        }

        public static bool isArchSwitchedOn(CpuID arch)
        {
            switch (arch)
            {
                case CpuID.NONE: return false;
                case CpuID.ADX: return Settings.Default.ARCH_ADX;
                case CpuID.AES: return Settings.Default.ARCH_AES;
                case CpuID.AVX: return Settings.Default.ARCH_AVX;
                case CpuID.AVX2: return Settings.Default.ARCH_AVX2;
                case CpuID.AVX512F: return Settings.Default.ARCH_AVX512F;
                case CpuID.AVX512CD: return Settings.Default.ARCH_AVX512CD;
                case CpuID.AVX512ER: return Settings.Default.ARCH_AVX512ER;
                case CpuID.AVX512VL: return Settings.Default.ARCH_AVX512VL;
                case CpuID.AVX512DQ: return Settings.Default.ARCH_AVX512DQ;
                case CpuID.AVX512PF: return Settings.Default.ARCH_AVX512PF;
                case CpuID.AVX512BW: return Settings.Default.ARCH_AVX512BW;
                case CpuID.AVX512IFMA52: return Settings.Default.ARCH_AVX512IFMA52;
                case CpuID.AVX512VBMI: return Settings.Default.ARCH_AVX512VBMI;

                case CpuID.BMI1: return Settings.Default.ARCH_BMI1;
                case CpuID.BMI2: return Settings.Default.ARCH_BMI2;
                case CpuID.CLFLUSHOPT: return Settings.Default.ARCH_CLFLUSHOPT;
                case CpuID.FMA: return Settings.Default.ARCH_FMA;
                case CpuID.FP16C: return Settings.Default.ARCH_FP16C;
                case CpuID.FXSR: return Settings.Default.ARCH_FXSR;
                case CpuID.KNCNI: return Settings.Default.ARCH_KNCNI;
                case CpuID.MMX: return Settings.Default.ARCH_MMX;
                case CpuID.MPX: return Settings.Default.ARCH_MPX;
                case CpuID.PCLMULQDQ: return Settings.Default.ARCH_PCLMULQDQ;
                case CpuID.SSE: return Settings.Default.ARCH_SSE;
                case CpuID.SSE2: return Settings.Default.ARCH_SSE2;
                case CpuID.SSE3: return Settings.Default.ARCH_SSE3;
                case CpuID.SSE4_1: return Settings.Default.ARCH_SSE41;
                case CpuID.SSE4_2: return Settings.Default.ARCH_SSE42;
                case CpuID.SSSE3: return Settings.Default.ARCH_SSSE3;

                case CpuID.LZCNT: return Settings.Default.ARCH_LZCNT;
                case CpuID.INVPCID: return Settings.Default.ARCH_INVPCID;
                case CpuID.MONITOR: return Settings.Default.ARCH_MONITOR;
                case CpuID.POPCNT: return Settings.Default.ARCH_POPCNT;
                case CpuID.RDRAND: return Settings.Default.ARCH_RDRAND;
                case CpuID.RDSEED: return Settings.Default.ARCH_RDSEED;
                case CpuID.TSC: return Settings.Default.ARCH_TSC;
                case CpuID.RDTSCP: return Settings.Default.ARCH_RDTSCP;
                case CpuID.FSGSBASE: return Settings.Default.ARCH_FSGSBASE;
                case CpuID.SHA: return Settings.Default.ARCH_SHA;
                case CpuID.RTM: return Settings.Default.ARCH_RTM;
                case CpuID.XSAVE: return Settings.Default.ARCH_XSAVE;
                case CpuID.XSAVEC: return Settings.Default.ARCH_XSAVEC;
                case CpuID.XSS: return Settings.Default.ARCH_XSS;
                case CpuID.XSAVEOPT: return Settings.Default.ARCH_XSAVEOPT;
                case CpuID.PREFETCHWT1: return Settings.Default.ARCH_PREFETCHWT1;

                case CpuID.SVML: return Settings.Default.USE_SVML;
                case CpuID.DEFAULT: return true;
                case CpuID.UNKNOWN: return false;

                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicsDudeToolsStatic: isArchSwitchedOn; unsupported arch "+ arch);
                    return false;
            }
        }
    }
}
