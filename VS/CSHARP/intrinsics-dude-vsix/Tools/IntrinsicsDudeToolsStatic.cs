// The MIT License (MIT)
//
// Copyright (c) 2017 Henk-Jan Lebbink
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

using IntrinsicsDude.SyntaxHighlighting;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static IntrinsicsDude.Tools.IntrinsicTools;
//using System.Drawing;

namespace IntrinsicsDude.Tools
{
    public static class IntrinsicsDudeToolsStatic
    {
        public static ITagAggregator<IntrinsicTokenTag> GetAggregator(
            ITextBuffer buffer,
            IBufferTagAggregatorFactoryService aggregatorFactory)
        {

            Func<ITagAggregator<IntrinsicTokenTag>> sc = delegate ()
            {
                return aggregatorFactory.CreateTagAggregator<IntrinsicTokenTag>(buffer);
            };
            return buffer.Properties.GetOrCreateSingletonProperty(sc);
        }

        public static void PrintSpeedWarning(DateTime startTime, string component)
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
            buffer.Properties.TryGetProperty(typeof(Microsoft.VisualStudio.TextManager.Interop.IVsTextBuffer), out IVsTextBuffer bufferAdapter);
            if (bufferAdapter != null)
            {
                IPersistFileFormat persistFileFormat = bufferAdapter as IPersistFileFormat;

                string filename = null;
                if (persistFileFormat != null)
                {
                    persistFileFormat.GetCurFile(out filename, out uint dummyInteger);
                }
                return filename;
            }
            else
            {
                return null;
            }
        }

        public static int GetFontSize()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            EnvDTE.Properties propertiesList = dte.get_Properties("FontsAndColors", "TextEditor");
            Property prop = propertiesList.Item("FontSize");
            int fontSize = (System.Int16)prop.Value;
            return fontSize;
        }

        public static FontFamily GetFontType()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            EnvDTE.Properties propertiesList = dte.get_Properties("FontsAndColors", "TextEditor");
            Property prop = propertiesList.Item("FontFamily");
            string font = (string)prop.Value;
            //IntrinsicsDudeToolsStatic.Output(string.Format(CultureInfo.CurrentCulture, "ERROR: IntrinsicsDudeToolsStatic:getFontType {0}", font));
            return new FontFamily(font);
        }

        public static Brush GetFontColor() {
            try {
                DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
                EnvDTE.Properties propertiesList = dte.get_Properties("FontsAndColors", "TextEditor");
                Property prop = propertiesList.Item("FontsAndColorsItems");

                FontsAndColorsItems fci = (FontsAndColorsItems)prop.Object;

                for (int i = 1; i<fci.Count; ++i) {
                    ColorableItems ci = fci.Item(i);
                    if (ci.Name.Equals("PLAIN TEXT", StringComparison.OrdinalIgnoreCase))
                    {
                        //IntrinsicsDudeToolsStatic.Output("INFO:GetFontColor: i=" + i + ": " + ci.Name + "; " + ci.Foreground);
                        return new SolidColorBrush(ConvertColor(System.Drawing.ColorTranslator.FromOle((int)ci.Foreground)));
                    }
                }
            } catch (Exception e) {
                IntrinsicsDudeToolsStatic.Output(string.Format(CultureInfo.CurrentCulture, "ERROR: IntrinsicsDudeToolsStatic:GetFontColor {0}", e.Message));
            }
            IntrinsicsDudeToolsStatic.Output(string.Format(CultureInfo.CurrentCulture, "WARNING: IntrinsicsDudeToolsStatic:GetFontColor: could not retrieve text color"));
            return new SolidColorBrush(Colors.Gray);
        }

        /// <summary>
        /// Get the path where this visual studio extension is installed.
        /// </summary>
        public static string GetInstallPath()
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

        public static System.Windows.Media.Color ConvertColor(System.Drawing.Color drawingColor)
        {
            return System.Windows.Media.Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
        }

        public static System.Drawing.Color ConvertColor(System.Windows.Media.Color mediaColor)
        {
            return System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
        }

        public static ImageSource BitmapFromUri(Uri bitmapUri)
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
        public static string Cleanup(string line, int maxNumOfChars)
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
        /// Output message to the IntrinsicsDude window
        /// </summary>
        public static void Output(string msg)
        {
            //IntrinsicsDudeTools.Instance.threadPool.QueueWorkItem(IntrinsicsDudeToolsStatic.Output_Sync, msg);
            IntrinsicsDudeToolsStatic.Output_Sync(msg);
        }

        /// <summary>
        /// Output message to the IntrinsicsDude window
        /// </summary>
        public static void Output_Sync(string msg)
        {
            IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            string msg2 = string.Format(CultureInfo.CurrentCulture, "{0}", msg.Trim() + Environment.NewLine);
            if (outputWindow == null)
            {
                Debug.Write(msg2);
            }
            else
            {
                Guid paneGuid = new Guid("A9F2F5E5-C21D-4BB3-B4A7-FEE69DC0E03A");
                outputWindow.CreatePane(paneGuid, "Intrinsics Dude", 1, 0);
                outputWindow.GetPane(paneGuid, out var pane);
                pane.OutputString(msg2);
                pane.FlushToTaskList();
                pane.Activate();
            }
        }

        public static bool IsAllUpper(string input)
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

        public static CpuID GetCpuIDSwithedOn()
        {
            CpuID cpuID = CpuID.NONE;
            foreach (CpuID value in Enum.GetValues(typeof(CpuID)))
            {
                if (IsArchSwitchedOn(value))
                {
                    cpuID |= value;
                }
            }
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeToolsStatic:getCpuIDSwithedOn: returns " + IntrinsicTools.ToString(cpuID));
            return cpuID;
        }

        public static bool IsArchSwitchedOn(CpuID arch)
        {
            switch (arch)
            {
                case CpuID.NONE: return false;
                case CpuID.ADX: return Settings.Default.ARCH_ADX;
                case CpuID.AES: return Settings.Default.ARCH_AES;
                case CpuID.AVX: return Settings.Default.ARCH_AVX;
                case CpuID.AVX2: return Settings.Default.ARCH_AVX2;
                case CpuID.AVX512_F: return Settings.Default.ARCH_AVX512_F;
                case CpuID.AVX512_CD: return Settings.Default.ARCH_AVX512_CD;
                case CpuID.AVX512_ER: return Settings.Default.ARCH_AVX512_ER;
                case CpuID.AVX512_VL: return Settings.Default.ARCH_AVX512_VL;
                case CpuID.AVX512_DQ: return Settings.Default.ARCH_AVX512_DQ;
                case CpuID.AVX512_PF: return Settings.Default.ARCH_AVX512_PF;
                case CpuID.AVX512_BW: return Settings.Default.ARCH_AVX512_BW;
                case CpuID.AVX512_IFMA52: return Settings.Default.ARCH_AVX512_IFMA52;
                case CpuID.AVX512_VBMI: return Settings.Default.ARCH_AVX512_VBMI;

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
                case CpuID.IA32: return Settings.Default.ARCH_IA32;

                case CpuID.RDPID: return Settings.Default.ARCH_RDPID;
                case CpuID.CLWB: return Settings.Default.ARCH_CLWB;

                case CpuID.UNKNOWN: return false;

                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicsDudeToolsStatic: isArchSwitchedOn; unsupported arch "+ arch);
                    return false;
            }
        }
    }
}
