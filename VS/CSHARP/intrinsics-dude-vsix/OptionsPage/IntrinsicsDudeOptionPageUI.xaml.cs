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

using IntrinsicsDude.Tools;
using System.Windows.Controls;

namespace IntrinsicsDude.OptionsPage
{
    /// <summary>
    /// Interaction logic for IntrinsicsDudeOptionsPageUI.xaml
    /// </summary>
    public partial class IntrinsicsDudeOptionsPageUI : UserControl
    {
        public IntrinsicsDudeOptionsPageUI()
        {
            this.InitializeComponent();
            this.version_UI.Content = "Intrinsics Dude v" + typeof(IntrinsicsDudePackage).Assembly.GetName().Version.ToString() + " (" + ApplicationInformation.CompileDate.ToUniversalTime().ToString() + ")";
        }

        #region Syntax Highlighting

        public bool UseSyntaxHighlighting
        {
            get { return this.useSyntaxHighlighting_UI.IsChecked ?? false; }
            set { this.useSyntaxHighlighting_UI.IsChecked = value; }
        }

        public System.Drawing.Color ColorMnemonic
        {
            get
            {
                if (this.colorMnemonic_UI.SelectedColor.HasValue)
                {
                    return IntrinsicsDudeToolsStatic.ConvertColor(this.colorMnemonic_UI.SelectedColor.Value);
                }
                else
                {
                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPageUI.xaml: colorMnemonic_UI has no value, assuming BLUE");
                    return System.Drawing.Color.Blue;
                }
            }

            set { this.colorMnemonic_UI.SelectedColor = IntrinsicsDudeToolsStatic.ConvertColor(value); }
        }

        public System.Drawing.Color ColorRegister
        {
            get
            {
                if (this.colorRegister_UI.SelectedColor.HasValue)
                {
                    return IntrinsicsDudeToolsStatic.ConvertColor(this.colorRegister_UI.SelectedColor.Value);
                }
                else
                {
                    return System.Drawing.Color.DarkRed;
                }
            }

            set { this.colorRegister_UI.SelectedColor = IntrinsicsDudeToolsStatic.ConvertColor(value); }
        }

        public System.Drawing.Color ColorMisc
        {
            get
            {
                if (this.colorMisc_UI.SelectedColor.HasValue)
                {
                    return IntrinsicsDudeToolsStatic.ConvertColor(this.colorMisc_UI.SelectedColor.Value);
                }
                else
                {
                    return System.Drawing.Color.DarkOrange;
                }
            }

            set { this.colorMisc_UI.SelectedColor = IntrinsicsDudeToolsStatic.ConvertColor(value); }
        }
        #endregion Syntax Highlighting

        #region Code Completion
        public bool UseCodeCompletion
        {
            get { return this.useCodeCompletion_UI.IsChecked ?? false; }
            set { this.useCodeCompletion_UI.IsChecked = value; }
        }

        public bool HideStatementCompletionMmxRegisters
        {
            get { return this.hideStatementCompletionMmxRegisters_UI.IsChecked ?? false; }
            set { this.hideStatementCompletionMmxRegisters_UI.IsChecked = value; }
        }

        public bool HideStatementCompletionIncompatibleReturnType
        {
            get { return this.hideStatementCompletionIncompatibleReturnType_UI.IsChecked ?? false; }
            set { this.hideStatementCompletionIncompatibleReturnType_UI.IsChecked = value; }
        }

        public bool DecorateIncompatibleStatementCompletions
        {
            get { return this.decorateIncompatibleStatementCompletions_UI.IsChecked ?? false; }
            set { this.decorateIncompatibleStatementCompletions_UI.IsChecked = value; }
        }

        public bool UseSignatureHelp
        {
            get { return this.useSignatureHelp_UI.IsChecked ?? false; }
            set { this.useSignatureHelp_UI.IsChecked = value; }
        }

        public bool UseSvml
        {
            get { return this.useSvml_UI.IsChecked ?? false; }
            set { this.useSvml_UI.IsChecked = value; }
        }

        public bool UseArch_MMX
        {
            get { return this.UseArch_MMX_UI.IsChecked ?? false; }
            set { this.UseArch_MMX_UI.IsChecked = value; }
        }

        public bool UseArch_SSE
        {
            get { return this.UseArch_SSE_UI.IsChecked ?? false; }
            set { this.UseArch_SSE_UI.IsChecked = value; }
        }

        public bool UseArch_SSE2
        {
            get { return this.UseArch_SSE2_UI.IsChecked ?? false; }
            set { this.UseArch_SSE2_UI.IsChecked = value; }
        }

        public bool UseArch_SSE3
        {
            get { return this.UseArch_SSE3_UI.IsChecked ?? false; }
            set { this.UseArch_SSE3_UI.IsChecked = value; }
        }

        public bool UseArch_SSSE3
        {
            get { return this.UseArch_SSSE3_UI.IsChecked ?? false; }
            set { this.UseArch_SSSE3_UI.IsChecked = value; }
        }

        public bool UseArch_SSE41
        {
            get { return this.UseArch_SSE41_UI.IsChecked ?? false; }
            set { this.UseArch_SSE41_UI.IsChecked = value; }
        }

        public bool UseArch_SSE42
        {
            get { return this.UseArch_SSE42_UI.IsChecked ?? false; }
            set { this.UseArch_SSE42_UI.IsChecked = value; }
        }

        public bool UseArch_AVX
        {
            get { return this.UseArch_AVX_UI.IsChecked ?? false; }
            set { this.UseArch_AVX_UI.IsChecked = value; }
        }

        public bool UseArch_AVX2
        {
            get { return this.UseArch_AVX2_UI.IsChecked ?? false; }
            set { this.UseArch_AVX2_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_F
        {
            get { return this.UseArch_AVX512_F_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_F_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_CD
        {
            get { return this.UseArch_AVX512_CD_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_CD_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_ER
        {
            get { return this.UseArch_AVX512_ER_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_ER_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_PF
        {
            get { return this.UseArch_AVX512_PF_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_PF_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_BW
        {
            get { return this.UseArch_AVX512_BW_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_BW_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_DQ
        {
            get { return this.UseArch_AVX512_DQ_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_DQ_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_VL
        {
            get { return this.UseArch_AVX512_VL_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_VL_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_IFMA52
        {
            get { return this.UseArch_AVX512_IFMA_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_IFMA_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_VBMI
        {
            get { return this.UseArch_AVX512_VBMI_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_VBMI_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_VPOPCNTDQ
        {
            get { return this.UseArch_AVX512_VPOPCNTDQ_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_VPOPCNTDQ_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_4VNNIW
        {
            get { return this.UseArch_AVX512_4VNNIW_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_4VNNIW_UI.IsChecked = value; }
        }

        public bool UseArch_AVX512_4FMAPS
        {
            get { return this.UseArch_AVX512_4FMAPS_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_4FMAPS_UI.IsChecked = value; }
        }

        public bool UseArch_KNCNI
        {
            get { return this.UseArch_KNCNI_UI.IsChecked ?? false; }
            set { this.UseArch_KNCNI_UI.IsChecked = value; }
        }

        public bool UseArch_IA32
        {
            get { return this.UseArch_IA32_UI.IsChecked ?? false; }
            set { this.UseArch_IA32_UI.IsChecked = value; }
        }

        public bool UseArch_BMI1
        {
            get { return this.UseArch_BMI1_UI.IsChecked ?? false; }
            set { this.UseArch_BMI1_UI.IsChecked = value; }
        }

        public bool UseArch_BMI2
        {
            get { return this.UseArch_BMI2_UI.IsChecked ?? false; }
            set { this.UseArch_BMI2_UI.IsChecked = value; }
        }

        public bool UseArch_CLFLUSHOPT
        {
            get { return this.UseArch_CLFLUSHOPT_UI.IsChecked ?? false; }
            set { this.UseArch_CLFLUSHOPT_UI.IsChecked = value; }
        }

        public bool UseArch_FMA
        {
            get { return this.UseArch_FMA_UI.IsChecked ?? false; }
            set { this.UseArch_FMA_UI.IsChecked = value; }
        }

        public bool UseArch_MPX
        {
            get { return this.UseArch_MPX_UI.IsChecked ?? false; }
            set { this.UseArch_MPX_UI.IsChecked = value; }
        }

        public bool UseArch_ADX
        {
            get { return this.UseArch_ADX_UI.IsChecked ?? false; }
            set { this.UseArch_ADX_UI.IsChecked = value; }
        }

        public bool UseArch_FP16C
        {
            get { return this.UseArch_FP16C_UI.IsChecked ?? false; }
            set { this.UseArch_FP16C_UI.IsChecked = value; }
        }

        public bool UseArch_PCLMULQDQ
        {
            get { return this.UseArch_PCLMULQDQ_UI.IsChecked ?? false; }
            set { this.UseArch_PCLMULQDQ_UI.IsChecked = value; }
        }

        public bool UseArch_AES
        {
            get { return this.UseArch_AES_UI.IsChecked ?? false; }
            set { this.UseArch_AES_UI.IsChecked = value; }
        }

        public bool UseArch_FXSR
        {
            get { return this.UseArch_FXSR_UI.IsChecked ?? false; }
            set { this.UseArch_FXSR_UI.IsChecked = value; }
        }

        public bool UseArch_LZCNT
        {
            get { return this.UseArch_LZCNT_UI.IsChecked ?? false; }
            set { this.UseArch_LZCNT_UI.IsChecked = value; }
        }

        public bool UseArch_INVPCID
        {
            get { return this.UseArch_INVPCID_UI.IsChecked ?? false; }
            set { this.UseArch_INVPCID_UI.IsChecked = value; }
        }

        public bool UseArch_MONITOR
        {
            get { return this.UseArch_MONITOR_UI.IsChecked ?? false; }
            set { this.UseArch_MONITOR_UI.IsChecked = value; }
        }

        public bool UseArch_POPCNT
        {
            get { return this.UseArch_POPCNT_UI.IsChecked ?? false; }
            set { this.UseArch_POPCNT_UI.IsChecked = value; }
        }

        public bool UseArch_RDRAND
        {
            get { return this.UseArch_RDRAND_UI.IsChecked ?? false; }
            set { this.UseArch_RDRAND_UI.IsChecked = value; }
        }

        public bool UseArch_RDSEED
        {
            get { return this.UseArch_RDSEED_UI.IsChecked ?? false; }
            set { this.UseArch_RDSEED_UI.IsChecked = value; }
        }

        public bool UseArch_TSC
        {
            get { return this.UseArch_TSC_UI.IsChecked ?? false; }
            set { this.UseArch_TSC_UI.IsChecked = value; }
        }

        public bool UseArch_RDTSCP
        {
            get { return this.UseArch_RDTSCP_UI.IsChecked ?? false; }
            set { this.UseArch_RDTSCP_UI.IsChecked = value; }
        }

        public bool UseArch_FSGSBASE
        {
            get { return this.UseArch_FSGSBASE_UI.IsChecked ?? false; }
            set { this.UseArch_FSGSBASE_UI.IsChecked = value; }
        }

        public bool UseArch_SHA
        {
            get { return this.UseArch_SHA_UI.IsChecked ?? false; }
            set { this.UseArch_SHA_UI.IsChecked = value; }
        }

        public bool UseArch_RTM
        {
            get { return this.UseArch_RTM_UI.IsChecked ?? false; }
            set { this.UseArch_RTM_UI.IsChecked = value; }
        }

        public bool UseArch_XSAVE
        {
            get { return this.UseArch_XSAVE_UI.IsChecked ?? false; }
            set { this.UseArch_XSAVE_UI.IsChecked = value; }
        }

        public bool UseArch_XSAVEC
        {
            get { return this.UseArch_XSAVEC_UI.IsChecked ?? false; }
            set { this.UseArch_XSAVEC_UI.IsChecked = value; }
        }

        public bool UseArch_XSS
        {
            get { return this.UseArch_XSS_UI.IsChecked ?? false; }
            set { this.UseArch_XSS_UI.IsChecked = value; }
        }

        public bool UseArch_XSAVEOPT
        {
            get { return this.UseArch_XSAVEOPT_UI.IsChecked ?? false; }
            set { this.UseArch_XSAVEOPT_UI.IsChecked = value; }
        }

        public bool UseArch_PREFETCHWT1
        {
            get { return this.UseArch_PREFETCHWT1_UI.IsChecked ?? false; }
            set { this.UseArch_PREFETCHWT1_UI.IsChecked = value; }
        }

        public bool UseArch_RDPID
        {
            get { return this.UseArch_RDPID_UI.IsChecked ?? false; }
            set { this.UseArch_RDPID_UI.IsChecked = value; }
        }

        public bool UseArch_CLWB
        {
            get { return this.UseArch_CLWB_UI.IsChecked ?? false; }
            set { this.UseArch_CLWB_UI.IsChecked = value; }
        }
        #endregion
    }
}
