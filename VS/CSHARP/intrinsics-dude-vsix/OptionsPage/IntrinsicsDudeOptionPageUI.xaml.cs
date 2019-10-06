// The MIT License (MIT)
//
// Copyright (c) 2019 Henk-Jan Lebbink
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

namespace IntrinsicsDude.OptionsPage
{
    using System;
    using System.Windows.Controls;
    using IntrinsicsDude.Tools;

    /// <summary>
    /// Interaction logic for IntrinsicsDudeOptionsPageUI.xaml
    /// </summary>
    public partial class IntrinsicsDudeOptionsPageUI : UserControl
    {
        public IntrinsicsDudeOptionsPageUI()
        {
            this.InitializeComponent();
            this.version_UI.Content = "Intrinsics Dude v" + typeof(IntrinsicsDudePackage).Assembly.GetName().Version.ToString() + " (" + ApplicationInformation.CompileDate.ToUniversalTime().ToString() + ")";

            #region setup handlers
            this.useSyntaxHighlighting_UI.Click += (o, i) => { this.SyntaxHighlighting_Update(this.SyntaxHighlighting_On); };
            this.SyntaxHighlighting_Update(Settings.Default.SyntaxHighlighting_On);

            this.useCodeCompletion_UI.Click += (o, i) => { this.CodeCompletion_Update(this.StatementCompletion_On); };
            this.CodeCompletion_Update(Settings.Default.StatementCompletion_On);
            #endregion
        }

        #region Syntax Highlighting

        public object GetPropValue(string propName)
        {
            try
            {
                return this.GetType().GetProperty(propName).GetValue(this, null);
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR("Could not find property " + propName + "; " + e);
                return "ERROR";
            }
        }

        public void SetPropValue(string propName, object o)
        {
            if (o != null)
            {
                try
                {
                    //AsmDudeToolsStatic.Output_INFO(string.Format("{0}:SetPropValue: propName={1}; o={2}", this.ToString(), propName, o.ToString()));
                    this.GetType().GetProperty(propName).SetValue(this, o);
                }
                catch (Exception e)
                {
                    IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:SetPropValue: Could not find property={1}; o={2}", this.ToString(), propName, o.ToString()));
                }
            }
        }


        #region Event Handlers to disable options

        private void SyntaxHighlighting_Update(bool value)
        {
            this.colorMnemonic_UI.IsEnabled = value;
            this.colorRegister_UI.IsEnabled = value;
        }

        private void CodeCompletion_Update(bool value)
        {
            this.hideStatementCompletionMmxRegisters_UI.IsEnabled = value;
            this.hideStatementCompletionIncompatibleReturnType_UI.IsEnabled = value;
            this.decorateIncompatibleStatementCompletions_UI.IsEnabled = value;
        }
        #endregion

        public bool SyntaxHighlighting_On
        {
            get { return this.useSyntaxHighlighting_UI.IsChecked ?? false; }
            set { this.useSyntaxHighlighting_UI.IsChecked = value; }
        }

        public System.Drawing.Color SyntaxHighlighting_Intrinsic
        {
            get
            {
                if (this.colorMnemonic_UI.SelectedColor.HasValue)
                {
                    return IntrinsicsDudeToolsStatic.ConvertColor(this.colorMnemonic_UI.SelectedColor.Value);
                }
                else
                {
                    //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicsDudeOptionsPageUI.xaml: colorMnemonic_UI has no value, assuming BLUE");
                    return System.Drawing.Color.Blue;
                }
            }

            set { this.colorMnemonic_UI.SelectedColor = IntrinsicsDudeToolsStatic.ConvertColor(value); }
        }

        public System.Drawing.Color SyntaxHighlighting_Register
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

        public System.Drawing.Color SyntaxHighlighting_Misc
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
        public bool StatementCompletion_On
        {
            get { return this.useCodeCompletion_UI.IsChecked ?? false; }
            set { this.useCodeCompletion_UI.IsChecked = value; }
        }

        public bool HideStatementCompletionMmxRegisters_On
        {
            get { return this.hideStatementCompletionMmxRegisters_UI.IsChecked ?? false; }
            set { this.hideStatementCompletionMmxRegisters_UI.IsChecked = value; }
        }

        public bool HideStatementCompletionIncompatibleReturnType_On
        {
            get { return this.hideStatementCompletionIncompatibleReturnType_UI.IsChecked ?? false; }
            set { this.hideStatementCompletionIncompatibleReturnType_UI.IsChecked = value; }
        }

        public bool DecorateIncompatibleStatementCompletions_On
        {
            get { return this.decorateIncompatibleStatementCompletions_UI.IsChecked ?? false; }
            set { this.decorateIncompatibleStatementCompletions_UI.IsChecked = value; }
        }

        public bool SignatureHelp_On
        {
            get { return this.useSignatureHelp_UI.IsChecked ?? false; }
            set { this.useSignatureHelp_UI.IsChecked = value; }
        }

        public bool ARCH_SVML
        {
            get { return this.useSvml_UI.IsChecked ?? false; }
            set { this.useSvml_UI.IsChecked = value; }
        }

        #endregion

        #region ARCH

        public bool ARCH_MMX
        {
            get { return this.UseArch_MMX_UI.IsChecked ?? false; }
            set { this.UseArch_MMX_UI.IsChecked = value; }
        }

        public bool ARCH_SSE
        {
            get { return this.UseArch_SSE_UI.IsChecked ?? false; }
            set { this.UseArch_SSE_UI.IsChecked = value; }
        }

        public bool ARCH_SSE2
        {
            get { return this.UseArch_SSE2_UI.IsChecked ?? false; }
            set { this.UseArch_SSE2_UI.IsChecked = value; }
        }

        public bool ARCH_SSE3
        {
            get { return this.UseArch_SSE3_UI.IsChecked ?? false; }
            set { this.UseArch_SSE3_UI.IsChecked = value; }
        }

        public bool ARCH_SSSE3
        {
            get { return this.UseArch_SSSE3_UI.IsChecked ?? false; }
            set { this.UseArch_SSSE3_UI.IsChecked = value; }
        }

        public bool ARCH_SSE41
        {
            get { return this.UseArch_SSE41_UI.IsChecked ?? false; }
            set { this.UseArch_SSE41_UI.IsChecked = value; }
        }

        public bool ARCH_SSE42
        {
            get { return this.UseArch_SSE42_UI.IsChecked ?? false; }
            set { this.UseArch_SSE42_UI.IsChecked = value; }
        }

        public bool ARCH_AVX
        {
            get { return this.UseArch_AVX_UI.IsChecked ?? false; }
            set { this.UseArch_AVX_UI.IsChecked = value; }
        }

        public bool ARCH_AVX2
        {
            get { return this.UseArch_AVX2_UI.IsChecked ?? false; }
            set { this.UseArch_AVX2_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_F
        {
            get { return this.UseArch_AVX512_F_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_F_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_CD
        {
            get { return this.UseArch_AVX512_CD_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_CD_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_ER
        {
            get { return this.UseArch_AVX512_ER_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_ER_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_PF
        {
            get { return this.UseArch_AVX512_PF_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_PF_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_BW
        {
            get { return this.UseArch_AVX512_BW_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_BW_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_DQ
        {
            get { return this.UseArch_AVX512_DQ_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_DQ_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_VL
        {
            get { return this.UseArch_AVX512_VL_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_VL_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_IFMA
        {
            get { return this.UseArch_AVX512_IFMA_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_IFMA_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_VBMI
        {
            get { return this.UseArch_AVX512_VBMI_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_VBMI_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_VPOPCNTDQ
        {
            get { return this.UseArch_AVX512_VPOPCNTDQ_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_VPOPCNTDQ_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_4VNNIW
        {
            get { return this.UseArch_AVX512_4VNNIW_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_4VNNIW_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_4FMAPS
        {
            get { return this.UseArch_AVX512_4FMAPS_UI.IsChecked ?? false; }
            set { this.UseArch_AVX512_4FMAPS_UI.IsChecked = value; }
        }

        public bool ARCH_AVX512_VBMI2
        {
            get { return false; }
            set { }
        }

        public bool ARCH_AVX512_VNNI
        {
            get { return false; }
            set { }
        }
        public bool ARCH_AVX512_BITALG
        {
            get { return false; }
            set { }
        }
        public bool ARCH_AVX512_GFNI
        {
            get { return false; }
            set { }
        }
        public bool ARCH_AVX512_VAES
        {
            get { return false; }
            set { }
        }
        public bool ARCH_AVX512_VPCLMULQDQ
        {
            get { return false; }
            set { }
        }
        public bool ARCH_AVX512_BF16
        {
            get { return false; }
            set { }
        }
        public bool ARCH_AVX512_VP2INTERSECT
        {
            get { return false; }
            set { }
        }

        public bool ARCH_KNCNI
        {
            get { return this.UseArch_KNCNI_UI.IsChecked ?? false; }
            set { this.UseArch_KNCNI_UI.IsChecked = value; }
        }

        public bool ARCH_IA32
        {
            get { return this.UseArch_IA32_UI.IsChecked ?? false; }
            set { this.UseArch_IA32_UI.IsChecked = value; }
        }

        public bool ARCH_BMI1
        {
            get { return this.UseArch_BMI1_UI.IsChecked ?? false; }
            set { this.UseArch_BMI1_UI.IsChecked = value; }
        }

        public bool ARCH_BMI2
        {
            get { return this.UseArch_BMI2_UI.IsChecked ?? false; }
            set { this.UseArch_BMI2_UI.IsChecked = value; }
        }

        public bool ARCH_CLFLUSHOPT
        {
            get { return this.UseArch_CLFLUSHOPT_UI.IsChecked ?? false; }
            set { this.UseArch_CLFLUSHOPT_UI.IsChecked = value; }
        }

        public bool ARCH_FMA
        {
            get { return this.UseArch_FMA_UI.IsChecked ?? false; }
            set { this.UseArch_FMA_UI.IsChecked = value; }
        }

        public bool ARCH_MPX
        {
            get { return this.UseArch_MPX_UI.IsChecked ?? false; }
            set { this.UseArch_MPX_UI.IsChecked = value; }
        }

        public bool ARCH_ADX
        {
            get { return this.UseArch_ADX_UI.IsChecked ?? false; }
            set { this.UseArch_ADX_UI.IsChecked = value; }
        }

        public bool ARCH_FP16C
        {
            get { return this.UseArch_FP16C_UI.IsChecked ?? false; }
            set { this.UseArch_FP16C_UI.IsChecked = value; }
        }

        public bool ARCH_PCLMULQDQ
        {
            get { return this.UseArch_PCLMULQDQ_UI.IsChecked ?? false; }
            set { this.UseArch_PCLMULQDQ_UI.IsChecked = value; }
        }

        public bool ARCH_AES
        {
            get { return this.UseArch_AES_UI.IsChecked ?? false; }
            set { this.UseArch_AES_UI.IsChecked = value; }
        }

        public bool ARCH_FXSR
        {
            get { return this.UseArch_FXSR_UI.IsChecked ?? false; }
            set { this.UseArch_FXSR_UI.IsChecked = value; }
        }

        public bool ARCH_LZCNT
        {
            get { return this.UseArch_LZCNT_UI.IsChecked ?? false; }
            set { this.UseArch_LZCNT_UI.IsChecked = value; }
        }

        public bool ARCH_INVPCID
        {
            get { return this.UseArch_INVPCID_UI.IsChecked ?? false; }
            set { this.UseArch_INVPCID_UI.IsChecked = value; }
        }

        public bool ARCH_MONITOR
        {
            get { return this.UseArch_MONITOR_UI.IsChecked ?? false; }
            set { this.UseArch_MONITOR_UI.IsChecked = value; }
        }

        public bool ARCH_POPCNT
        {
            get { return this.UseArch_POPCNT_UI.IsChecked ?? false; }
            set { this.UseArch_POPCNT_UI.IsChecked = value; }
        }

        public bool ARCH_RDRAND
        {
            get { return this.UseArch_RDRAND_UI.IsChecked ?? false; }
            set { this.UseArch_RDRAND_UI.IsChecked = value; }
        }

        public bool ARCH_RDSEED
        {
            get { return this.UseArch_RDSEED_UI.IsChecked ?? false; }
            set { this.UseArch_RDSEED_UI.IsChecked = value; }
        }

        public bool ARCH_TSC
        {
            get { return this.UseArch_TSC_UI.IsChecked ?? false; }
            set { this.UseArch_TSC_UI.IsChecked = value; }
        }

        public bool ARCH_RDTSCP
        {
            get { return this.UseArch_RDTSCP_UI.IsChecked ?? false; }
            set { this.UseArch_RDTSCP_UI.IsChecked = value; }
        }

        public bool ARCH_FSGSBASE
        {
            get { return this.UseArch_FSGSBASE_UI.IsChecked ?? false; }
            set { this.UseArch_FSGSBASE_UI.IsChecked = value; }
        }

        public bool ARCH_SHA
        {
            get { return this.UseArch_SHA_UI.IsChecked ?? false; }
            set { this.UseArch_SHA_UI.IsChecked = value; }
        }

        public bool ARCH_RTM
        {
            get { return this.UseArch_RTM_UI.IsChecked ?? false; }
            set { this.UseArch_RTM_UI.IsChecked = value; }
        }

        public bool ARCH_XSAVE
        {
            get { return this.UseArch_XSAVE_UI.IsChecked ?? false; }
            set { this.UseArch_XSAVE_UI.IsChecked = value; }
        }

        public bool ARCH_XSAVEC
        {
            get { return this.UseArch_XSAVEC_UI.IsChecked ?? false; }
            set { this.UseArch_XSAVEC_UI.IsChecked = value; }
        }

        public bool ARCH_XSS
        {
            get { return this.UseArch_XSS_UI.IsChecked ?? false; }
            set { this.UseArch_XSS_UI.IsChecked = value; }
        }

        public bool ARCH_XSAVEOPT
        {
            get { return this.UseArch_XSAVEOPT_UI.IsChecked ?? false; }
            set { this.UseArch_XSAVEOPT_UI.IsChecked = value; }
        }

        public bool ARCH_PREFETCHWT1
        {
            get { return this.UseArch_PREFETCHWT1_UI.IsChecked ?? false; }
            set { this.UseArch_PREFETCHWT1_UI.IsChecked = value; }
        }

        public bool ARCH_RDPID
        {
            get { return this.UseArch_RDPID_UI.IsChecked ?? false; }
            set { this.UseArch_RDPID_UI.IsChecked = value; }
        }

        public bool ARCH_CLWB
        {
            get { return this.UseArch_CLWB_UI.IsChecked ?? false; }
            set { this.UseArch_CLWB_UI.IsChecked = value; }
        }
        #endregion
    }
}
