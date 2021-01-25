// The MIT License (MIT)
//
// Copyright (c) 2021 Henk-Jan Lebbink
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace IntrinsicsDude.Tools
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using EnvDTE;
    using IntrinsicsDude.SyntaxHighlighting;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Tagging;
    using static IntrinsicsDude.Tools.IntrinsicTools;

    public static class IntrinsicsDudeToolsStatic
    {
        private static bool first_log_message = true;

        public static ITagAggregator<IntrinsicTokenTag> GetAggregator(
            ITextBuffer buffer,
            IBufferTagAggregatorFactoryService aggregatorFactory)
        {
            ITagAggregator<IntrinsicTokenTag> sc()
            {
                return aggregatorFactory.CreateTagAggregator<IntrinsicTokenTag>(buffer);
            }

            return buffer.Properties.GetOrCreateSingletonProperty(sc);
        }

        public static void PrintSpeedWarning(DateTime startTime, string component)
        {
            double elapsedSec = (double)(DateTime.Now.Ticks - startTime.Ticks) / 10000000;
            if (elapsedSec > IntrinsicsDudePackage.slowWarningThresholdSec)
            {
                Output_WARNING(string.Format("SLOW: took {0} {1:F3} seconds to finish", component, elapsedSec));
            }
        }

        /// <summary>
        /// get the full filename (with path) of the provided buffer; returns null if such name does not exist
        /// </summary>
        public static async Task<string> Get_Filename_Async(ITextBuffer buffer)
        {
            if (!ThreadHelper.CheckAccess())
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            }

            buffer.Properties.TryGetProperty(typeof(ITextDocument), out ITextDocument document);
            string filename = document?.FilePath;
            //AsmDudeToolsStatic.Output_INFO(string.Format("{0}:Get_Filename_Async: retrieving filename {1}", typeof(AsmDudeToolsStatic), filename));
            return filename;
        }

        public static async Task<int> Get_Font_Size_Async()
        {
            if (!ThreadHelper.CheckAccess())
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            }

            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            Properties propertiesList = dte.get_Properties("FontsAndColors", "TextEditor");
            Property prop = propertiesList.Item("FontSize");
            int fontSize = (short)prop.Value;
            return fontSize;
        }

        public static async Task<Brush> Get_Font_Color_Async()
        {
            if (!ThreadHelper.CheckAccess())
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            }

            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            Properties propertiesList = dte.get_Properties("FontsAndColors", "TextEditor");
            Property prop = propertiesList.Item("FontsAndColorsItems");

            FontsAndColorsItems fci = (FontsAndColorsItems)prop.Object;

            for (int i = 1; i < fci.Count; ++i)
            {
                ColorableItems ci = fci.Item(i);
                if (ci.Name.Equals("PLAIN TEXT", StringComparison.OrdinalIgnoreCase))
                {
                    return new SolidColorBrush(ConvertColor(System.Drawing.ColorTranslator.FromOle((int)ci.Foreground)));
                }
            }

            Output_WARNING("IntrinsicsDudeToolsStatic:Get_Font_Color: could not retrieve text color");
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
                return string.Empty;
            }
        }

        public static Color ConvertColor(System.Drawing.Color drawingColor)
        {
            return Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
        }

        public static System.Drawing.Color ConvertColor(Color mediaColor)
        {
            return System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
        }

        public static ImageSource BitmapFromUri(Uri bitmapUri)
        {
            if (bitmapUri is null)
            {
                throw new ArgumentNullException(nameof(bitmapUri));
            }

            BitmapImage bitmap = new BitmapImage();
            try
            {
                bitmap.BeginInit();
                bitmap.UriSource = bitmapUri;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            catch (Exception e)
            {
                Output_WARNING("bitmapFromUri: could not read icon from uri " + bitmapUri.ToString() + "; " + e.Message);
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

        /// <summary>Output message to the AsmDude window</summary>
        public static void Output_INFO(string msg)
        {
#           if DEBUG
            OutputAsync("INFO: " + msg).ConfigureAwait(false);
#           endif
        }

        /// <summary>Output message to the AsmDude window</summary>
        public static void Output_WARNING(string msg)
        {
            OutputAsync("WARNING: " + msg).ConfigureAwait(false);
        }

        /// <summary>Output message to the AsmDude window</summary>
        public static void Output_ERROR(string msg)
        {
            OutputAsync("ERROR: " + msg).ConfigureAwait(false);
        }

        /// <summary>
        /// Output message to the AsmSim window
        /// </summary>
        public static async System.Threading.Tasks.Task OutputAsync(string msg)
        {
            if (!ThreadHelper.CheckAccess())
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            }

            IVsOutputWindowPane outputPane = await GetOutputPaneAsync();
            string msg2 = string.Format(CultureInfo.CurrentCulture, "{0}", msg.Trim() + Environment.NewLine);

            if (first_log_message)
            {
                first_log_message = false;

                StringBuilder sb = new StringBuilder();
                sb.Append("Welcome to\n");
                sb.Append(" ____     _       _         _           ____        _     \n");
                sb.Append("|    |___| |_ ___|_|___ ___|_|___ ___  |    \\ _ _ _| |___ \n");
                sb.Append("|-  -|   |  _|  _| |   |_ -| |  _|_ -| |  |  | | | . | -_|\n");
                sb.Append("|____|_|_|_| |_| |_|_|_|___|_|___|___| |____/|___|___|___|\n");
                sb.Append("INFO: Loaded IntrinsicsDude version " + typeof(IntrinsicsDudePackage).Assembly.GetName().Version + " (" + ApplicationInformation.CompileDate.ToString() + ")\n");
                sb.Append("INFO: More info at https://github.com/HJLebbink/intrinsics-dude \n");
                sb.Append("----------------------------------\n");
                msg2 = sb.ToString() + msg2;
            }

            if (outputPane == null)
            {
                Debug.Write(msg2);
            }
            else
            {
                outputPane.OutputString(msg2);
                outputPane.Activate();
            }
        }

        public static async Task<IVsOutputWindowPane> GetOutputPaneAsync()
        {
            if (!ThreadHelper.CheckAccess())
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            }

            IVsOutputWindow outputWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            if (outputWindow == null)
            {
                return null;
            }
            else
            {
                Guid paneGuid = new Guid("A9F2F5E5-C21D-4BB3-B4A7-FEE69DC0E03A");
                outputWindow.CreatePane(paneGuid, "Intrinsics Dude", 1, 0);
                outputWindow.GetPane(paneGuid, out IVsOutputWindowPane pane);
                return pane;
            }
        }

        public static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && !char.IsUpper(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static CpuID GetCpuIDSwithedOn()
        {
            CpuID cpuID = CpuID.ARCH_NONE;
            foreach (CpuID value in Enum.GetValues(typeof(CpuID)))
            {
                if (IsArchSwitchedOn(value))
                {
                    cpuID |= value;
                }
            }

            //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicsDudeToolsStatic:getCpuIDSwithedOn: returns " + IntrinsicTools.ToString(cpuID));
            return cpuID;
        }

        public static bool IsArchSwitchedOn(CpuID arch)
        {
            switch (arch)
            {
                case CpuID.ARCH_NONE: return false;
                case CpuID.ARCH_ADX: return Settings.Default.ARCH_ADX;
                case CpuID.ARCH_AES: return Settings.Default.ARCH_AES;
                case CpuID.ARCH_AVX: return Settings.Default.ARCH_AVX;
                case CpuID.ARCH_AVX2: return Settings.Default.ARCH_AVX2;
                case CpuID.ARCH_AVX512_F: return Settings.Default.ARCH_AVX512_F;
                case CpuID.ARCH_AVX512_CD: return Settings.Default.ARCH_AVX512_CD;
                case CpuID.ARCH_AVX512_ER: return Settings.Default.ARCH_AVX512_ER;
                case CpuID.ARCH_AVX512_VL: return Settings.Default.ARCH_AVX512_VL;
                case CpuID.ARCH_AVX512_DQ: return Settings.Default.ARCH_AVX512_DQ;
                case CpuID.ARCH_AVX512_PF: return Settings.Default.ARCH_AVX512_PF;
                case CpuID.ARCH_AVX512_BW: return Settings.Default.ARCH_AVX512_BW;
                case CpuID.ARCH_AVX512_IFMA: return Settings.Default.ARCH_AVX512_IFMA;
                case CpuID.ARCH_AVX512_VBMI: return Settings.Default.ARCH_AVX512_VBMI;
                case CpuID.ARCH_AVX512_VPOPCNTDQ: return Settings.Default.ARCH_AVX512_VPOPCNTDQ;
                case CpuID.ARCH_AVX512_4VNNIW: return Settings.Default.ARCH_AVX512_4VNNIW;
                case CpuID.ARCH_AVX512_4FMAPS: return Settings.Default.ARCH_AVX512_4FMAPS;

                case CpuID.ARCH_AVX512_VBMI2: return Settings.Default.ARCH_AVX512_VBMI2;
                case CpuID.ARCH_AVX512_VNNI: return Settings.Default.ARCH_AVX512_VNNI;
                case CpuID.ARCH_AVX512_BITALG: return Settings.Default.ARCH_AVX512_BITALG;
                case CpuID.ARCH_AVX512_GFNI: return Settings.Default.ARCH_AVX512_GFNI;
                case CpuID.ARCH_AVX512_VAES: return Settings.Default.ARCH_AVX512_VAES;
                case CpuID.ARCH_AVX512_VPCLMULQDQ: return Settings.Default.ARCH_AVX512_VPCLMULQDQ;
                case CpuID.ARCH_AVX512_BF16: return Settings.Default.ARCH_AVX512_BF16;
                case CpuID.ARCH_AVX512_VP2INTERSECT: return Settings.Default.ARCH_AVX512_VP2INTERSECT;

                case CpuID.ARCH_BMI1: return Settings.Default.ARCH_BMI1;
                case CpuID.ARCH_BMI2: return Settings.Default.ARCH_BMI2;
                case CpuID.ARCH_CLFLUSHOPT: return Settings.Default.ARCH_CLFLUSHOPT;
                case CpuID.ARCH_FMA: return Settings.Default.ARCH_FMA;
                case CpuID.ARCH_FP16C: return Settings.Default.ARCH_FP16C;
                case CpuID.ARCH_FXSR: return Settings.Default.ARCH_FXSR;
                case CpuID.ARCH_KNCNI: return Settings.Default.ARCH_KNCNI;
                case CpuID.ARCH_MMX: return Settings.Default.ARCH_MMX;
                case CpuID.ARCH_MPX: return Settings.Default.ARCH_MPX;
                case CpuID.ARCH_PCLMULQDQ: return Settings.Default.ARCH_PCLMULQDQ;
                case CpuID.ARCH_SSE: return Settings.Default.ARCH_SSE;
                case CpuID.ARCH_SSE2: return Settings.Default.ARCH_SSE2;
                case CpuID.ARCH_SSE3: return Settings.Default.ARCH_SSE3;
                case CpuID.ARCH_SSE41: return Settings.Default.ARCH_SSE41;
                case CpuID.ARCH_SSE42: return Settings.Default.ARCH_SSE42;
                case CpuID.ARCH_SSSE3: return Settings.Default.ARCH_SSSE3;

                case CpuID.ARCH_LZCNT: return Settings.Default.ARCH_LZCNT;
                case CpuID.ARCH_INVPCID: return Settings.Default.ARCH_INVPCID;
                case CpuID.ARCH_MONITOR: return Settings.Default.ARCH_MONITOR;
                case CpuID.ARCH_POPCNT: return Settings.Default.ARCH_POPCNT;
                case CpuID.ARCH_RDRAND: return Settings.Default.ARCH_RDRAND;
                case CpuID.ARCH_RDSEED: return Settings.Default.ARCH_RDSEED;
                case CpuID.ARCH_TSC: return Settings.Default.ARCH_TSC;
                case CpuID.ARCH_RDTSCP: return Settings.Default.ARCH_RDTSCP;
                case CpuID.ARCH_FSGSBASE: return Settings.Default.ARCH_FSGSBASE;
                case CpuID.ARCH_SHA: return Settings.Default.ARCH_SHA;
                case CpuID.ARCH_RTM: return Settings.Default.ARCH_RTM;
                case CpuID.ARCH_XSAVE: return Settings.Default.ARCH_XSAVE;
                case CpuID.ARCH_XSAVEC: return Settings.Default.ARCH_XSAVEC;
                case CpuID.ARCH_XSS: return Settings.Default.ARCH_XSS;
                case CpuID.ARCH_XSAVEOPT: return Settings.Default.ARCH_XSAVEOPT;
                case CpuID.ARCH_PREFETCHWT1: return Settings.Default.ARCH_PREFETCHWT1;

                case CpuID.ARCH_SVML: return Settings.Default.ARCH_SVML;
                case CpuID.ARCH_IA32: return Settings.Default.ARCH_IA32;

                case CpuID.ARCH_RDPID: return Settings.Default.ARCH_RDPID;
                case CpuID.ARCH_CLWB: return Settings.Default.ARCH_CLWB;

                case CpuID.ARCH_UNKNOWN: return false;

                default:
                    Output_WARNING("IntrinsicsDudeToolsStatic: isArchSwitchedOn; unsupported arch " + arch);
                    return false;
            }
        }
    }
}
