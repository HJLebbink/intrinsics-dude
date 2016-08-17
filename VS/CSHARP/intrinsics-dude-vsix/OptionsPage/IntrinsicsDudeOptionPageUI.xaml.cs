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
    /// Interaction logic for AsmDudeOptionPageUI.xaml
    /// </summary>
    public partial class AsmDudeOptionsPageUI : UserControl {

        public AsmDudeOptionsPageUI() {
            InitializeComponent();
            version_UI.Content = "Intrinsics Dude v" + typeof(IntrinsicsDudePackage).Assembly.GetName().Version.ToString() + " (" + ApplicationInformation.CompileDate.ToString()+")";
        }

        #region Asm Documentation
        public bool useAsmDoc {
            get { return (useAsmDoc_UI.IsChecked.HasValue) ? useAsmDoc_UI.IsChecked.Value : false; }
            set { useAsmDoc_UI.IsChecked = value; }
        }

        public string asmDocUrl {
            get { return asmDocUrl_UI.Text; }
            set { asmDocUrl_UI.Text = value; }
        }
        #endregion Asm Documentation

        #region Syntax Highlighting

        public bool useSyntaxHighlighting {
            get { return (useSyntaxHighlighting_UI.IsChecked.HasValue) ? useSyntaxHighlighting_UI.IsChecked.Value : false; }
            set { useSyntaxHighlighting_UI.IsChecked = value; }
        }

        public System.Drawing.Color colorMnemonic {
            get {
                if (colorMnemonic_UI.SelectedColor.HasValue) {
                    return IntrinsicsDudeToolsStatic.convertColor(colorMnemonic_UI.SelectedColor.Value);
                } else {
                    //IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPageUI.xaml: colorMnemonic_UI has no value, assuming BLUE");
                    return System.Drawing.Color.Blue;
                }
            }
            set { colorMnemonic_UI.SelectedColor = IntrinsicsDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorRegister {
            get {
                if (colorRegister_UI.SelectedColor.HasValue) {
                    return IntrinsicsDudeToolsStatic.convertColor(colorRegister_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.DarkRed;
                }
            }
            set { colorRegister_UI.SelectedColor = IntrinsicsDudeToolsStatic.convertColor(value); }
        }

        /*
        public System.Drawing.Color colorMisc {
            get {
                if (colorMisc_UI.SelectedColor.HasValue) {
                    return IntrinsicsDudeToolsStatic.convertColor(colorMisc_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.DarkOrange;
                }
            }
            set { colorMisc_UI.SelectedColor = IntrinsicsDudeToolsStatic.convertColor(value); }
        }
        */
        #endregion Syntax Highlighting

        #region Keyword Highlighting
        public System.Drawing.Color _backgroundColor { get; set; }
        #endregion

        #region Code Completion
        public bool useCodeCompletion {
            get { return (useCodeCompletion_UI.IsChecked.HasValue) ? useCodeCompletion_UI.IsChecked.Value : false; }
            set { useCodeCompletion_UI.IsChecked = value; }
        }
        public bool useSignatureHelp {
            get { return (useSignatureHelp_UI.IsChecked.HasValue) ? useSignatureHelp_UI.IsChecked.Value : false; }
            set { useSignatureHelp_UI.IsChecked = value; }
        }
        public bool useSvml {
            get { return (useSvml_UI.IsChecked.HasValue) ? useSvml_UI.IsChecked.Value : false; }
            set { useSvml_UI.IsChecked = value; }
        }

        public bool useArch_MMX {
            get { return (useArch_MMX_UI.IsChecked.HasValue) ? useArch_MMX_UI.IsChecked.Value : false; }
            set { useArch_MMX_UI.IsChecked = value; }
        }
        public bool useArch_SSE {
            get { return (useArch_SSE_UI.IsChecked.HasValue) ? useArch_SSE_UI.IsChecked.Value : false; }
            set { useArch_SSE_UI.IsChecked = value; }
        }
        public bool useArch_SSE2 {
            get { return (useArch_SSE2_UI.IsChecked.HasValue) ? useArch_SSE2_UI.IsChecked.Value : false; }
            set { useArch_SSE2_UI.IsChecked = value; }
        }
        public bool useArch_SSE3 {
            get { return (useArch_SSE3_UI.IsChecked.HasValue) ? useArch_SSE3_UI.IsChecked.Value : false; }
            set { useArch_SSE3_UI.IsChecked = value; }
        }
        public bool useArch_SSSE3 {
            get { return (useArch_SSSE3_UI.IsChecked.HasValue) ? useArch_SSSE3_UI.IsChecked.Value : false; }
            set { useArch_SSSE3_UI.IsChecked = value; }
        }
        public bool useArch_SSE41 {
            get { return (useArch_SSE41_UI.IsChecked.HasValue) ? useArch_SSE41_UI.IsChecked.Value : false; }
            set { useArch_SSE41_UI.IsChecked = value; }
        }
        public bool useArch_SSE42 {
            get { return (useArch_SSE42_UI.IsChecked.HasValue) ? useArch_SSE42_UI.IsChecked.Value : false; }
            set { useArch_SSE42_UI.IsChecked = value; }
        }
        public bool useArch_AVX {
            get { return (useArch_AVX_UI.IsChecked.HasValue) ? useArch_AVX_UI.IsChecked.Value : false; }
            set { useArch_AVX_UI.IsChecked = value; }
        }
        public bool useArch_AVX2 {
            get { return (useArch_AVX2_UI.IsChecked.HasValue) ? useArch_AVX2_UI.IsChecked.Value : false; }
            set { useArch_AVX2_UI.IsChecked = value; }
        }
        public bool useArch_AVX512VL {
            get { return (useArch_AVX512VL_UI.IsChecked.HasValue) ? useArch_AVX512VL_UI.IsChecked.Value : false; }
            set { useArch_AVX512VL_UI.IsChecked = value; }
        }
        public bool useArch_AVX512DQ {
            get { return (useArch_AVX512DQ_UI.IsChecked.HasValue) ? useArch_AVX512DQ_UI.IsChecked.Value : false; }
            set { useArch_AVX512DQ_UI.IsChecked = value; }
        }
        public bool useArch_AVX512BW {
            get { return (useArch_AVX512BW_UI.IsChecked.HasValue) ? useArch_AVX512BW_UI.IsChecked.Value : false; }
            set { useArch_AVX512BW_UI.IsChecked = value; }
        }
        public bool useArch_AVX512ER {
            get { return (useArch_AVX512ER_UI.IsChecked.HasValue) ? useArch_AVX512ER_UI.IsChecked.Value : false; }
            set { useArch_AVX512ER_UI.IsChecked = value; }
        }
        public bool useArch_AVX512F {
            get { return (useArch_AVX512F_UI.IsChecked.HasValue) ? useArch_AVX512F_UI.IsChecked.Value : false; }
            set { useArch_AVX512F_UI.IsChecked = value; }
        }
        public bool useArch_AVX512CD {
            get { return (useArch_AVX512CD_UI.IsChecked.HasValue) ? useArch_AVX512CD_UI.IsChecked.Value : false; }
            set { useArch_AVX512CD_UI.IsChecked = value; }
        }
        public bool useArch_AVX512PF
        {
            get { return (useArch_AVX512PF_UI.IsChecked.HasValue) ? useArch_AVX512PF_UI.IsChecked.Value : false; }
            set { useArch_AVX512PF_UI.IsChecked = value; }
        }
        public bool useArch_AVX512IFMA52
        {
            get { return (useArch_AVX512IFMA52_UI.IsChecked.HasValue) ? useArch_AVX512IFMA52_UI.IsChecked.Value : false; }
            set { useArch_AVX512IFMA52_UI.IsChecked = value; }
        }
        public bool useArch_AVX512VBMI
        {
            get { return (useArch_AVX512VBMI_UI.IsChecked.HasValue) ? useArch_AVX512VBMI_UI.IsChecked.Value : false; }
            set { useArch_AVX512VBMI_UI.IsChecked = value; }
        }




        public bool useArch_BMI1 {
            get { return (useArch_BMI1_UI.IsChecked.HasValue) ? useArch_BMI1_UI.IsChecked.Value : false; }
            set { useArch_BMI1_UI.IsChecked = value; }
        }
        public bool useArch_BMI2 {
            get { return (useArch_BMI2_UI.IsChecked.HasValue) ? useArch_BMI2_UI.IsChecked.Value : false; }
            set { useArch_BMI2_UI.IsChecked = value; }
        }
        public bool useArch_CLFLUSHOPT {
            get { return (useArch_CLFLUSHOPT_UI.IsChecked.HasValue) ? useArch_CLFLUSHOPT_UI.IsChecked.Value : false; }
            set { useArch_CLFLUSHOPT_UI.IsChecked = value; }
        }
        public bool useArch_FMA {
            get { return (useArch_FMA_UI.IsChecked.HasValue) ? useArch_FMA_UI.IsChecked.Value : false; }
            set { useArch_FMA_UI.IsChecked = value; }
        }
        public bool useArch_MPX {
            get { return (useArch_MPX_UI.IsChecked.HasValue) ? useArch_MPX_UI.IsChecked.Value : false; }
            set { useArch_MPX_UI.IsChecked = value; }
        }
        public bool useArch_ADX {
            get { return (useArch_ADX_UI.IsChecked.HasValue) ? useArch_ADX_UI.IsChecked.Value : false; }
            set { useArch_ADX_UI.IsChecked = value; }
        }
        public bool useArch_FP16C {
            get { return (useArch_FP16C_UI.IsChecked.HasValue) ? useArch_FP16C_UI.IsChecked.Value : false; }
            set { useArch_FP16C_UI.IsChecked = value; }
        }
        public bool useArch_PCLMULQDQ {
            get { return (useArch_PCLMULQDQ_UI.IsChecked.HasValue) ? useArch_PCLMULQDQ_UI.IsChecked.Value : false; }
            set { useArch_PCLMULQDQ_UI.IsChecked = value; }
        }
        public bool useArch_AES {
            get { return (useArch_AES_UI.IsChecked.HasValue) ? useArch_AES_UI.IsChecked.Value : false; }
            set { useArch_AES_UI.IsChecked = value; }
        }
        public bool useArch_FXSR {
            get { return (useArch_FXSR_UI.IsChecked.HasValue) ? useArch_FXSR_UI.IsChecked.Value : false; }
            set { useArch_FXSR_UI.IsChecked = value; }
        }
        public bool useArch_KNCNI {
            get { return (useArch_KNCNI_UI.IsChecked.HasValue) ? useArch_KNCNI_UI.IsChecked.Value : false; }
            set { useArch_KNCNI_UI.IsChecked = value; }
        }


        public bool useArch_LZCNT
        {
            get { return (useArch_LZCNT_UI.IsChecked.HasValue) ? useArch_LZCNT_UI.IsChecked.Value : false; }
            set { useArch_LZCNT_UI.IsChecked = value; }
        }
        public bool useArch_INVPCID
        {
            get { return (useArch_INVPCID_UI.IsChecked.HasValue) ? useArch_INVPCID_UI.IsChecked.Value : false; }
            set { useArch_INVPCID_UI.IsChecked = value; }
        }
        public bool useArch_MONITOR
        {
            get { return (useArch_MONITOR_UI.IsChecked.HasValue) ? useArch_MONITOR_UI.IsChecked.Value : false; }
            set { useArch_MONITOR_UI.IsChecked = value; }
        }
        public bool useArch_POPCNT
        {
            get { return (useArch_POPCNT_UI.IsChecked.HasValue) ? useArch_POPCNT_UI.IsChecked.Value : false; }
            set { useArch_POPCNT_UI.IsChecked = value; }
        }
        public bool useArch_RDRAND
        {
            get { return (useArch_RDRAND_UI.IsChecked.HasValue) ? useArch_RDRAND_UI.IsChecked.Value : false; }
            set { useArch_RDRAND_UI.IsChecked = value; }
        }
        public bool useArch_RDSEED
        {
            get { return (useArch_RDSEED_UI.IsChecked.HasValue) ? useArch_RDSEED_UI.IsChecked.Value : false; }
            set { useArch_RDSEED_UI.IsChecked = value; }
        }
        public bool useArch_TSC
        {
            get { return (useArch_TSC_UI.IsChecked.HasValue) ? useArch_TSC_UI.IsChecked.Value : false; }
            set { useArch_TSC_UI.IsChecked = value; }
        }
        public bool useArch_RDTSCP
        {
            get { return (useArch_RDTSCP_UI.IsChecked.HasValue) ? useArch_RDTSCP_UI.IsChecked.Value : false; }
            set { useArch_RDTSCP_UI.IsChecked = value; }
        }
        public bool useArch_FSGSBASE
        {
            get { return (useArch_FSGSBASE_UI.IsChecked.HasValue) ? useArch_FSGSBASE_UI.IsChecked.Value : false; }
            set { useArch_FSGSBASE_UI.IsChecked = value; }
        }
        public bool useArch_SHA
        {
            get { return (useArch_SHA_UI.IsChecked.HasValue) ? useArch_SHA_UI.IsChecked.Value : false; }
            set { useArch_SHA_UI.IsChecked = value; }
        }
        public bool useArch_RTM
        {
            get { return (useArch_RTM_UI.IsChecked.HasValue) ? useArch_RTM_UI.IsChecked.Value : false; }
            set { useArch_RTM_UI.IsChecked = value; }
        }
        public bool useArch_XSAVE
        {
            get { return (useArch_XSAVE_UI.IsChecked.HasValue) ? useArch_XSAVE_UI.IsChecked.Value : false; }
            set { useArch_XSAVE_UI.IsChecked = value; }
        }
        public bool useArch_XSAVEC
        {
            get { return (useArch_XSAVEC_UI.IsChecked.HasValue) ? useArch_XSAVEC_UI.IsChecked.Value : false; }
            set { useArch_XSAVEC_UI.IsChecked = value; }
        }
        public bool useArch_XSS
        {
            get { return (useArch_XSS_UI.IsChecked.HasValue) ? useArch_XSS_UI.IsChecked.Value : false; }
            set { useArch_XSS_UI.IsChecked = value; }
        }
        public bool useArch_XSAVEOPT
        {
            get { return (useArch_XSAVEOPT_UI.IsChecked.HasValue) ? useArch_XSAVEOPT_UI.IsChecked.Value : false; }
            set { useArch_XSAVEOPT_UI.IsChecked = value; }
        }
        public bool useArch_PREFETCHWT1
        {
            get { return (useArch_PREFETCHWT1_UI.IsChecked.HasValue) ? useArch_PREFETCHWT1_UI.IsChecked.Value : false; }
            set { useArch_PREFETCHWT1_UI.IsChecked = value; }
        }
        #endregion
    }
}
