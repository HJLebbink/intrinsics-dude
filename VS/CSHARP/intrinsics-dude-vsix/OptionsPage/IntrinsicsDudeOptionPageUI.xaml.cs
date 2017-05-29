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

namespace IntrinsicsDude.OptionsPage {
    /// <summary>
    /// Interaction logic for IntrinsicsDudeOptionsPageUI.xaml
    /// </summary>
    public partial class IntrinsicsDudeOptionsPageUI : UserControl {

        public IntrinsicsDudeOptionsPageUI() {
            InitializeComponent();
            this.version_UI.Content = "Intrinsics Dude v" + typeof(IntrinsicsDudePackage).Assembly.GetName().Version.ToString() + " (" + ApplicationInformation.CompileDate.ToUniversalTime().ToString()+")";
        }


        #region Syntax Highlighting

        public bool useSyntaxHighlighting {
            get { return this.useSyntaxHighlighting_UI.IsChecked ?? false; }
            set { this.useSyntaxHighlighting_UI.IsChecked = value; }
        }

        public System.Drawing.Color colorMnemonic {
            get {
                if (this.colorMnemonic_UI.SelectedColor.HasValue) {
                    return IntrinsicsDudeToolsStatic.ConvertColor(this.colorMnemonic_UI.SelectedColor.Value);
                } else {
                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPageUI.xaml: colorMnemonic_UI has no value, assuming BLUE");
                    return System.Drawing.Color.Blue;
                }
            }
            set { this.colorMnemonic_UI.SelectedColor = IntrinsicsDudeToolsStatic.ConvertColor(value); }
        }

        public System.Drawing.Color colorRegister {
            get {
                if (this.colorRegister_UI.SelectedColor.HasValue) {
                    return IntrinsicsDudeToolsStatic.ConvertColor(this.colorRegister_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.DarkRed;
                }
            }
            set { this.colorRegister_UI.SelectedColor = IntrinsicsDudeToolsStatic.ConvertColor(value); }
        }

        public System.Drawing.Color colorMisc {
            get {
                if (this.colorMisc_UI.SelectedColor.HasValue) {
                    return IntrinsicsDudeToolsStatic.ConvertColor(this.colorMisc_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.DarkOrange;
                }
            }
            set { this.colorMisc_UI.SelectedColor = IntrinsicsDudeToolsStatic.ConvertColor(value); }
        }
        #endregion Syntax Highlighting

        #region Code Completion
        public bool useCodeCompletion {
            get { return this.useCodeCompletion_UI.IsChecked ?? false; }
            set { this.useCodeCompletion_UI.IsChecked = value; }
        }

        public bool hideStatementCompletionMmxRegisters {
            get { return this.hideStatementCompletionMmxRegisters_UI.IsChecked ?? false; }
            set { this.hideStatementCompletionMmxRegisters_UI.IsChecked = value; }
        }
        public bool hideStatementCompletionIncompatibleReturnType {
            get { return this.hideStatementCompletionIncompatibleReturnType_UI.IsChecked ?? false; }
            set { this.hideStatementCompletionIncompatibleReturnType_UI.IsChecked = value; }
        }
        public bool decorateIncompatibleStatementCompletions {
            get { return this.decorateIncompatibleStatementCompletions_UI.IsChecked ?? false; }
            set { this.decorateIncompatibleStatementCompletions_UI.IsChecked = value; }
        }

        public bool useSignatureHelp {
            get { return this.useSignatureHelp_UI.IsChecked ?? false; }
            set { this.useSignatureHelp_UI.IsChecked = value; }
        }
        public bool useSvml {
            get { return this.useSvml_UI.IsChecked ?? false; }
            set { this.useSvml_UI.IsChecked = value; }
        }

        public bool useArch_MMX {
            get { return this.useArch_MMX_UI.IsChecked ?? false; }
            set { this.useArch_MMX_UI.IsChecked = value; }
        }
        public bool useArch_SSE {
            get { return this.useArch_SSE_UI.IsChecked ?? false; }
            set { this.useArch_SSE_UI.IsChecked = value; }
        }
        public bool useArch_SSE2 {
            get { return this.useArch_SSE2_UI.IsChecked ?? false; }
            set { this.useArch_SSE2_UI.IsChecked = value; }
        }
        public bool useArch_SSE3 {
            get { return this.useArch_SSE3_UI.IsChecked ?? false; }
            set { this.useArch_SSE3_UI.IsChecked = value; }
        }
        public bool useArch_SSSE3 {
            get { return this.useArch_SSSE3_UI.IsChecked ?? false; }
            set { this.useArch_SSSE3_UI.IsChecked = value; }
        }
        public bool useArch_SSE41 {
            get { return this.useArch_SSE41_UI.IsChecked ?? false; }
            set { this.useArch_SSE41_UI.IsChecked = value; }
        }
        public bool useArch_SSE42 {
            get { return this.useArch_SSE42_UI.IsChecked ?? false; }
            set { this.useArch_SSE42_UI.IsChecked = value; }
        }
        public bool useArch_AVX {
            get { return this.useArch_AVX_UI.IsChecked ?? false; }
            set { this.useArch_AVX_UI.IsChecked = value; }
        }
        public bool useArch_AVX2 {
            get { return this.useArch_AVX2_UI.IsChecked ?? false; }
            set { this.useArch_AVX2_UI.IsChecked = value; }
        }
        public bool useArch_AVX512VL {
            get { return this.useArch_AVX512VL_UI.IsChecked ?? false; }
            set { this.useArch_AVX512VL_UI.IsChecked = value; }
        }
        public bool useArch_AVX512DQ {
            get { return this.useArch_AVX512DQ_UI.IsChecked ?? false; }
            set { this.useArch_AVX512DQ_UI.IsChecked = value; }
        }
        public bool useArch_AVX512BW {
            get { return this.useArch_AVX512BW_UI.IsChecked ?? false; }
            set { this.useArch_AVX512BW_UI.IsChecked = value; }
        }
        public bool useArch_AVX512ER {
            get { return this.useArch_AVX512ER_UI.IsChecked ?? false; }
            set { this.useArch_AVX512ER_UI.IsChecked = value; }
        }
        public bool useArch_AVX512F {
            get { return this.useArch_AVX512F_UI.IsChecked ?? false; }
            set { this.useArch_AVX512F_UI.IsChecked = value; }
        }
        public bool useArch_AVX512CD {
            get { return this.useArch_AVX512CD_UI.IsChecked ?? false; }
            set { this.useArch_AVX512CD_UI.IsChecked = value; }
        }
        public bool useArch_AVX512PF
        {
            get { return this.useArch_AVX512PF_UI.IsChecked ?? false; }
            set { this.useArch_AVX512PF_UI.IsChecked = value; }
        }
        public bool useArch_AVX512IFMA52
        {
            get { return this.useArch_AVX512IFMA52_UI.IsChecked ?? false; }
            set { this.useArch_AVX512IFMA52_UI.IsChecked = value; }
        }
        public bool useArch_AVX512VBMI
        {
            get { return this.useArch_AVX512VBMI_UI.IsChecked ?? false; }
            set { this.useArch_AVX512VBMI_UI.IsChecked = value; }
        }


        public bool useArch_IA32 {
            get { return this.useArch_IA32_UI.IsChecked ?? false; }
            set { this.useArch_IA32_UI.IsChecked = value; }
        }
        public bool useArch_BMI1 {
            get { return this.useArch_BMI1_UI.IsChecked ?? false; }
            set { this.useArch_BMI1_UI.IsChecked = value; }
        }
        public bool useArch_BMI2 {
            get { return this.useArch_BMI2_UI.IsChecked ?? false; }
            set { this.useArch_BMI2_UI.IsChecked = value; }
        }
        public bool useArch_CLFLUSHOPT {
            get { return this.useArch_CLFLUSHOPT_UI.IsChecked ?? false; }
            set { this.useArch_CLFLUSHOPT_UI.IsChecked = value; }
        }
        public bool useArch_FMA {
            get { return this.useArch_FMA_UI.IsChecked ?? false; }
            set { this.useArch_FMA_UI.IsChecked = value; }
        }
        public bool useArch_MPX {
            get { return this.useArch_MPX_UI.IsChecked ?? false; }
            set { this.useArch_MPX_UI.IsChecked = value; }
        }
        public bool useArch_ADX {
            get { return this.useArch_ADX_UI.IsChecked ?? false; }
            set { this.useArch_ADX_UI.IsChecked = value; }
        }
        public bool useArch_FP16C {
            get { return this.useArch_FP16C_UI.IsChecked ?? false; }
            set { this.useArch_FP16C_UI.IsChecked = value; }
        }
        public bool useArch_PCLMULQDQ {
            get { return this.useArch_PCLMULQDQ_UI.IsChecked ?? false; }
            set { this.useArch_PCLMULQDQ_UI.IsChecked = value; }
        }
        public bool useArch_AES {
            get { return this.useArch_AES_UI.IsChecked ?? false; }
            set { this.useArch_AES_UI.IsChecked = value; }
        }
        public bool useArch_FXSR {
            get { return this.useArch_FXSR_UI.IsChecked ?? false; }
            set { this.useArch_FXSR_UI.IsChecked = value; }
        }
        public bool useArch_KNCNI {
            get { return this.useArch_KNCNI_UI.IsChecked ?? false; }
            set { this.useArch_KNCNI_UI.IsChecked = value; }
        }


        public bool useArch_LZCNT
        {
            get { return this.useArch_LZCNT_UI.IsChecked ?? false; }
            set { this.useArch_LZCNT_UI.IsChecked = value; }
        }
        public bool useArch_INVPCID
        {
            get { return this.useArch_INVPCID_UI.IsChecked ?? false; }
            set { this.useArch_INVPCID_UI.IsChecked = value; }
        }
        public bool useArch_MONITOR
        {
            get { return this.useArch_MONITOR_UI.IsChecked ?? false; }
            set { this.useArch_MONITOR_UI.IsChecked = value; }
        }
        public bool useArch_POPCNT
        {
            get { return this.useArch_POPCNT_UI.IsChecked ?? false; }
            set { this.useArch_POPCNT_UI.IsChecked = value; }
        }
        public bool useArch_RDRAND
        {
            get { return this.useArch_RDRAND_UI.IsChecked ?? false; }
            set { this.useArch_RDRAND_UI.IsChecked = value; }
        }
        public bool useArch_RDSEED
        {
            get { return this.useArch_RDSEED_UI.IsChecked ?? false; }
            set { this.useArch_RDSEED_UI.IsChecked = value; }
        }
        public bool useArch_TSC
        {
            get { return this.useArch_TSC_UI.IsChecked ?? false; }
            set { this.useArch_TSC_UI.IsChecked = value; }
        }
        public bool useArch_RDTSCP
        {
            get { return this.useArch_RDTSCP_UI.IsChecked ?? false; }
            set { this.useArch_RDTSCP_UI.IsChecked = value; }
        }
        public bool useArch_FSGSBASE
        {
            get { return this.useArch_FSGSBASE_UI.IsChecked ?? false; }
            set { this.useArch_FSGSBASE_UI.IsChecked = value; }
        }
        public bool useArch_SHA
        {
            get { return this.useArch_SHA_UI.IsChecked ?? false; }
            set { this.useArch_SHA_UI.IsChecked = value; }
        }
        public bool useArch_RTM
        {
            get { return this.useArch_RTM_UI.IsChecked ?? false; }
            set { this.useArch_RTM_UI.IsChecked = value; }
        }
        public bool useArch_XSAVE
        {
            get { return this.useArch_XSAVE_UI.IsChecked ?? false; }
            set { this.useArch_XSAVE_UI.IsChecked = value; }
        }
        public bool useArch_XSAVEC
        {
            get { return this.useArch_XSAVEC_UI.IsChecked ?? false; }
            set { this.useArch_XSAVEC_UI.IsChecked = value; }
        }
        public bool useArch_XSS
        {
            get { return this.useArch_XSS_UI.IsChecked ?? false; }
            set { this.useArch_XSS_UI.IsChecked = value; }
        }
        public bool useArch_XSAVEOPT
        {
            get { return this.useArch_XSAVEOPT_UI.IsChecked ?? false; }
            set { this.useArch_XSAVEOPT_UI.IsChecked = value; }
        }
        public bool useArch_PREFETCHWT1
        {
            get { return this.useArch_PREFETCHWT1_UI.IsChecked ?? false; }
            set { this.useArch_PREFETCHWT1_UI.IsChecked = value; }
        }
        public bool useArch_RDPID
        {
            get { return this.useArch_RDPID_UI.IsChecked ?? false; }
            set { this.useArch_RDPID_UI.IsChecked = value; }
        }
        public bool useArch_CLWB
        {
            get { return this.useArch_CLWB_UI.IsChecked ?? false; }
            set { this.useArch_CLWB_UI.IsChecked = value; }
        }
        #endregion
    }
}
