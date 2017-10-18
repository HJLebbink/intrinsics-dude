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

using IntrinsicsDude.Tools;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.OptionsPage
{
    [Guid(Guids.GuidOptionsPageIntrinsicsDude)]
    public class IntrinsicsDudeOptionsPage : UIElementDialogPage
    {
        private const bool logInfo = false;

        private IntrinsicsDudeOptionsPageUI _intrinsicsDudeOptionsPageUI;

        public IntrinsicsDudeOptionsPage()
        {
            this._intrinsicsDudeOptionsPageUI = new IntrinsicsDudeOptionsPageUI();
        }

        protected override System.Windows.UIElement Child {
            get { return this._intrinsicsDudeOptionsPageUI; }
        }

        #region Event Handlers

        /// <summary>
        /// Handles "activate" messages from the Visual Studio environment.
        /// </summary>
        /// <devdoc>
        /// This method is called when Visual Studio wants to activate this page.  
        /// </devdoc>
        /// <remarks>If this handler sets e.Cancel to true, the activation will not occur.</remarks>
        protected override void OnActivate(CancelEventArgs e)
        {
            base.OnActivate(e);

            #region Syntax Highlighting
            this._intrinsicsDudeOptionsPageUI.useSyntaxHighlighting = Settings.Default.SyntaxHighlighting_On;
            this._intrinsicsDudeOptionsPageUI.colorMnemonic = Settings.Default.SyntaxHighlighting_Intrinsic;
            this._intrinsicsDudeOptionsPageUI.colorRegister = Settings.Default.SyntaxHighlighting_Register;
            this._intrinsicsDudeOptionsPageUI.colorMisc = Settings.Default.SyntaxHighlighting_Misc;
            #endregion

            #region Code Completion
            this._intrinsicsDudeOptionsPageUI.useCodeCompletion = Settings.Default.StatementCompletion_On;
            this._intrinsicsDudeOptionsPageUI.hideStatementCompletionMmxRegisters = Settings.Default.HideStatementCompletionMmxRegisters_On;
            this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType = Settings.Default.HideStatementCompletionIncompatibleReturnType_On;
            this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions = Settings.Default.DecorateIncompatibleStatementCompletions_On;

            this._intrinsicsDudeOptionsPageUI.useSignatureHelp = Settings.Default.SignatureHelp_On;

            this._intrinsicsDudeOptionsPageUI.useSvml = Settings.Default.USE_SVML;
            this._intrinsicsDudeOptionsPageUI.useSvml_UI.ToolTip = this.MakeToolTip(CpuID.SVML);
            this._intrinsicsDudeOptionsPageUI.UseArch_ADX = Settings.Default.ARCH_ADX;
            this._intrinsicsDudeOptionsPageUI.UseArch_ADX_UI.ToolTip = this.MakeToolTip(CpuID.ADX);
            this._intrinsicsDudeOptionsPageUI.UseArch_AES = Settings.Default.ARCH_AES;
            this._intrinsicsDudeOptionsPageUI.UseArch_AES_UI.ToolTip = this.MakeToolTip(CpuID.AES);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX = Settings.Default.ARCH_AVX;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX_UI.ToolTip = this.MakeToolTip(CpuID.AVX);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX2 = Settings.Default.ARCH_AVX2;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX2_UI.ToolTip = this.MakeToolTip(CpuID.AVX2);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_F = Settings.Default.ARCH_AVX512_F;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_F_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_F);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VL = Settings.Default.ARCH_AVX512_VL;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VL_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_VL);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_DQ = Settings.Default.ARCH_AVX512_DQ;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_DQ_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_DQ);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_BW = Settings.Default.ARCH_AVX512_BW;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_BW_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_BW);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_ER = Settings.Default.ARCH_AVX512_ER;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_ER_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_ER);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_CD = Settings.Default.ARCH_AVX512_CD;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_CD_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_CD);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_PF = Settings.Default.ARCH_AVX512_PF;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_PF_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_PF);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_IFMA52 = Settings.Default.ARCH_AVX512_IFMA52;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_IFMA_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_IFMA52);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VBMI = Settings.Default.ARCH_AVX512_VBMI;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VBMI_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_VBMI);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VPOPCNTDQ = Settings.Default.ARCH_AVX512_VPOPCNTDQ;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VPOPCNTDQ_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_VPOPCNTDQ);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4VNNIW = Settings.Default.ARCH_AVX512_4VNNIW;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4VNNIW_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_4VNNIW);
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4FMAPS = Settings.Default.ARCH_AVX512_4FMAPS;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4FMAPS_UI.ToolTip = this.MakeToolTip(CpuID.AVX512_4FMAPS);

            this._intrinsicsDudeOptionsPageUI.UseArch_IA32 = Settings.Default.ARCH_IA32;
            this._intrinsicsDudeOptionsPageUI.UseArch_IA32_UI.ToolTip = this.MakeToolTip(CpuID.IA32);
            this._intrinsicsDudeOptionsPageUI.UseArch_BMI1 = Settings.Default.ARCH_BMI1;
            this._intrinsicsDudeOptionsPageUI.UseArch_BMI1_UI.ToolTip = this.MakeToolTip(CpuID.BMI1);
            this._intrinsicsDudeOptionsPageUI.UseArch_BMI2 = Settings.Default.ARCH_BMI2;
            this._intrinsicsDudeOptionsPageUI.UseArch_BMI2_UI.ToolTip = this.MakeToolTip(CpuID.BMI2);
            this._intrinsicsDudeOptionsPageUI.UseArch_CLFLUSHOPT = Settings.Default.ARCH_CLFLUSHOPT;
            this._intrinsicsDudeOptionsPageUI.UseArch_CLFLUSHOPT_UI.ToolTip = this.MakeToolTip(CpuID.CLFLUSHOPT);
            this._intrinsicsDudeOptionsPageUI.UseArch_FMA = Settings.Default.ARCH_FMA;
            this._intrinsicsDudeOptionsPageUI.UseArch_FMA_UI.ToolTip = this.MakeToolTip(CpuID.FMA);
            this._intrinsicsDudeOptionsPageUI.UseArch_FP16C = Settings.Default.ARCH_FP16C;
            this._intrinsicsDudeOptionsPageUI.UseArch_FP16C_UI.ToolTip = this.MakeToolTip(CpuID.FP16C);
            this._intrinsicsDudeOptionsPageUI.UseArch_FXSR = Settings.Default.ARCH_FXSR;
            this._intrinsicsDudeOptionsPageUI.UseArch_FXSR_UI.ToolTip = this.MakeToolTip(CpuID.FXSR);
            this._intrinsicsDudeOptionsPageUI.UseArch_KNCNI = Settings.Default.ARCH_KNCNI;
            this._intrinsicsDudeOptionsPageUI.UseArch_KNCNI_UI.ToolTip = this.MakeToolTip(CpuID.KNCNI);
            this._intrinsicsDudeOptionsPageUI.UseArch_MMX = Settings.Default.ARCH_MMX;
            this._intrinsicsDudeOptionsPageUI.UseArch_MMX_UI.ToolTip = this.MakeToolTip(CpuID.MMX);
            this._intrinsicsDudeOptionsPageUI.UseArch_MPX = Settings.Default.ARCH_MPX;
            this._intrinsicsDudeOptionsPageUI.UseArch_MPX_UI.ToolTip = this.MakeToolTip(CpuID.MPX);
            this._intrinsicsDudeOptionsPageUI.UseArch_PCLMULQDQ = Settings.Default.ARCH_PCLMULQDQ;
            this._intrinsicsDudeOptionsPageUI.UseArch_PCLMULQDQ_UI.ToolTip = this.MakeToolTip(CpuID.PCLMULQDQ);
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE = Settings.Default.ARCH_SSE;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE_UI.ToolTip = this.MakeToolTip(CpuID.SSE);
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE2 = Settings.Default.ARCH_SSE2;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE2_UI.ToolTip = this.MakeToolTip(CpuID.SSE2);
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE3 = Settings.Default.ARCH_SSE3;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE3_UI.ToolTip = this.MakeToolTip(CpuID.SSE3);
            this._intrinsicsDudeOptionsPageUI.UseArch_SSSE3 = Settings.Default.ARCH_SSSE3;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSSE3_UI.ToolTip = this.MakeToolTip(CpuID.SSSE3);
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE41 = Settings.Default.ARCH_SSE41;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE41_UI.ToolTip = this.MakeToolTip(CpuID.SSE4_1);
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE42 = Settings.Default.ARCH_SSE42;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE42_UI.ToolTip = this.MakeToolTip(CpuID.SSE4_2);

            this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT = Settings.Default.ARCH_LZCNT;
            this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT_UI.ToolTip = this.MakeToolTip(CpuID.LZCNT);
            this._intrinsicsDudeOptionsPageUI.UseArch_INVPCID = Settings.Default.ARCH_INVPCID;
            this._intrinsicsDudeOptionsPageUI.UseArch_INVPCID_UI.ToolTip = this.MakeToolTip(CpuID.INVPCID);
            this._intrinsicsDudeOptionsPageUI.UseArch_MONITOR = Settings.Default.ARCH_MONITOR;
            this._intrinsicsDudeOptionsPageUI.UseArch_MONITOR_UI.ToolTip = this.MakeToolTip(CpuID.MONITOR);
            this._intrinsicsDudeOptionsPageUI.UseArch_POPCNT = Settings.Default.ARCH_POPCNT;
            this._intrinsicsDudeOptionsPageUI.UseArch_POPCNT_UI.ToolTip = this.MakeToolTip(CpuID.POPCNT);
            this._intrinsicsDudeOptionsPageUI.UseArch_RDRAND = Settings.Default.ARCH_RDRAND;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDRAND_UI.ToolTip = this.MakeToolTip(CpuID.RDRAND);
            this._intrinsicsDudeOptionsPageUI.UseArch_RDSEED = Settings.Default.ARCH_RDSEED;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDSEED_UI.ToolTip = this.MakeToolTip(CpuID.RDSEED);
            this._intrinsicsDudeOptionsPageUI.UseArch_TSC = Settings.Default.ARCH_TSC;
            this._intrinsicsDudeOptionsPageUI.UseArch_TSC_UI.ToolTip = this.MakeToolTip(CpuID.TSC);
            this._intrinsicsDudeOptionsPageUI.UseArch_RDTSCP = Settings.Default.ARCH_RDTSCP;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDTSCP_UI.ToolTip = this.MakeToolTip(CpuID.RDTSCP);
            this._intrinsicsDudeOptionsPageUI.UseArch_FSGSBASE = Settings.Default.ARCH_FSGSBASE;
            this._intrinsicsDudeOptionsPageUI.UseArch_FSGSBASE_UI.ToolTip = this.MakeToolTip(CpuID.FSGSBASE);
            this._intrinsicsDudeOptionsPageUI.UseArch_SHA = Settings.Default.ARCH_SHA;
            this._intrinsicsDudeOptionsPageUI.UseArch_SHA_UI.ToolTip = this.MakeToolTip(CpuID.SHA);
            this._intrinsicsDudeOptionsPageUI.UseArch_RTM = Settings.Default.ARCH_RTM;
            this._intrinsicsDudeOptionsPageUI.UseArch_RTM_UI.ToolTip = this.MakeToolTip(CpuID.RTM);
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVE = Settings.Default.ARCH_XSAVE;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVE_UI.ToolTip = this.MakeToolTip(CpuID.XSAVE);
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEC = Settings.Default.ARCH_XSAVEC;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEC_UI.ToolTip = this.MakeToolTip(CpuID.XSAVEC);
            this._intrinsicsDudeOptionsPageUI.UseArch_XSS = Settings.Default.ARCH_XSS;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSS_UI.ToolTip = this.MakeToolTip(CpuID.XSS);
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEOPT = Settings.Default.ARCH_XSAVEOPT;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEOPT_UI.ToolTip = this.MakeToolTip(CpuID.XSAVEOPT);
            this._intrinsicsDudeOptionsPageUI.UseArch_PREFETCHWT1 = Settings.Default.ARCH_PREFETCHWT1;
            this._intrinsicsDudeOptionsPageUI.UseArch_PREFETCHWT1_UI.ToolTip = this.MakeToolTip(CpuID.PREFETCHWT1);

            this._intrinsicsDudeOptionsPageUI.UseArch_RDPID = Settings.Default.ARCH_RDPID;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDPID_UI.ToolTip = this.MakeToolTip(CpuID.RDPID);
            this._intrinsicsDudeOptionsPageUI.UseArch_CLWB = Settings.Default.ARCH_CLWB;
            this._intrinsicsDudeOptionsPageUI.UseArch_CLWB_UI.ToolTip = this.MakeToolTip(CpuID.CLWB);
            #endregion
        }

        private string MakeToolTip(CpuID arch)
        {
            IntrinsicStore store = IntrinsicsDudeTools.Instance.IntrinsicStore;
            SortedSet<Intrinsic> usedMnemonics = new SortedSet<Intrinsic>();

            StringBuilder sb = new StringBuilder();
            string docArch = IntrinsicTools.GetCpuID_Documentation(arch);
            if (docArch.Length > 0)
            {
                sb.Append(docArch + ": ");
            }
            foreach (Intrinsic mnemonic in Enum.GetValues(typeof(Intrinsic)))
            {
                if (store.GetCpuID(mnemonic).HasFlag(arch))
                {
                    sb.Append(mnemonic.ToString());
                    sb.Append(", ");
                }
            }
            if (sb.Length > 2) sb.Length -= 2; // get rid of last comma.
            return IntrinsicTools.Linewrap(sb.ToString(), IntrinsicsDudePackage.maxNumberOfCharsInToolTips);
        }

        /// <summary>
        /// Handles "close" messages from the Visual Studio environment.
        /// </summary>
        /// <devdoc>
        /// This event is raised when the page is closed.
        /// </devdoc>
        protected override void OnClosed(EventArgs e) { }

        /// <summary>
        /// Handles "deactivate" messages from the Visual Studio environment.
        /// </summary>
        /// <devdoc>
        /// This method is called when VS wants to deactivate this
        /// page.  If this handler sets e.Cancel, the deactivation will not occur.
        /// </devdoc>
        /// <remarks>
        /// A "deactivate" message is sent when focus changes to a different page in
        /// the dialog.
        /// </remarks>
        protected override void OnDeactivate(CancelEventArgs e)
        {
            bool changed = false;
            StringBuilder sb = new StringBuilder();

            #region Syntax Highlighting
            if (Settings.Default.SyntaxHighlighting_On != this._intrinsicsDudeOptionsPageUI.useSyntaxHighlighting)
            {
                sb.AppendLine("useSyntaxHighlighting=" + this._intrinsicsDudeOptionsPageUI.useSyntaxHighlighting);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Intrinsic.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorMnemonic.ToArgb())
            {
                sb.AppendLine("stored=" + Settings.Default.SyntaxHighlighting_Intrinsic + "; new colorMnemonic=" + this._intrinsicsDudeOptionsPageUI.colorMnemonic);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Register.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorRegister.ToArgb())
            {
                sb.AppendLine("colorRegister=" + this._intrinsicsDudeOptionsPageUI.colorRegister);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Misc.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorMisc.ToArgb())
            {
                sb.AppendLine("colorMisc=" + this._intrinsicsDudeOptionsPageUI.colorMisc);
                changed = true;
            }
            #endregion

            #region Code Completion
            if (Settings.Default.StatementCompletion_On != this._intrinsicsDudeOptionsPageUI.useCodeCompletion)
            {
                sb.AppendLine("useCodeCompletion=" + this._intrinsicsDudeOptionsPageUI.useCodeCompletion);
                changed = true;
            }
            
            if (Settings.Default.HideStatementCompletionMmxRegisters_On != this._intrinsicsDudeOptionsPageUI.hideStatementCompletionMmxRegisters)
            {
                sb.AppendLine("hideStatementCompletionMmxRegisters=" + this._intrinsicsDudeOptionsPageUI.hideStatementCompletionMmxRegisters);
                changed = true;
            }
            if (Settings.Default.HideStatementCompletionIncompatibleReturnType_On != this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType)
            {
                sb.AppendLine("hideStatementCompletionIncompatibleReturnType=" + this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType);
                changed = true;
            }
            if (Settings.Default.DecorateIncompatibleStatementCompletions_On != this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions)
            {
                sb.AppendLine("decorateIncompatibleStatementCompletions=" + this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions);
                changed = true;
            }

            if (Settings.Default.SignatureHelp_On != this._intrinsicsDudeOptionsPageUI.useSignatureHelp)
            {
                sb.AppendLine("useSignatureHelp=" + this._intrinsicsDudeOptionsPageUI.useSignatureHelp);
                changed = true;
            }
            if (Settings.Default.USE_SVML != this._intrinsicsDudeOptionsPageUI.useSvml)
            {
                sb.AppendLine("useSvml=" + this._intrinsicsDudeOptionsPageUI.useSvml);
                changed = true;
            }
            if (Settings.Default.ARCH_MMX != this._intrinsicsDudeOptionsPageUI.UseArch_MMX)
            {
                sb.AppendLine("UseArch_MMX=" + this._intrinsicsDudeOptionsPageUI.UseArch_MMX);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE != this._intrinsicsDudeOptionsPageUI.UseArch_SSE)
            {
                sb.AppendLine("UseArch_SSE=" + this._intrinsicsDudeOptionsPageUI.UseArch_SSE);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE2 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE2)
            {
                sb.AppendLine("UseArch_SSE2=" + this._intrinsicsDudeOptionsPageUI.UseArch_SSE2);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE3 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE3)
            {
                sb.AppendLine("UseArch_SSE3=" + this._intrinsicsDudeOptionsPageUI.UseArch_SSE3);
                changed = true;
            }
            if (Settings.Default.ARCH_SSSE3 != this._intrinsicsDudeOptionsPageUI.UseArch_SSSE3)
            {
                sb.AppendLine("UseArch_SSSE3=" + this._intrinsicsDudeOptionsPageUI.UseArch_SSSE3);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE41 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE41)
            {
                sb.AppendLine("UseArch_SSE41=" + this._intrinsicsDudeOptionsPageUI.UseArch_SSE41);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE42 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE42)
            {
                sb.AppendLine("UseArch_SSE42=" + this._intrinsicsDudeOptionsPageUI.UseArch_SSE42);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX != this._intrinsicsDudeOptionsPageUI.UseArch_AVX)
            {
                sb.AppendLine("UseArch_AVX=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX2 != this._intrinsicsDudeOptionsPageUI.UseArch_AVX2)
            {
                sb.AppendLine("UseArch_AVX2=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX2);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_VL != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VL)
            {
                sb.AppendLine("UseArch_AVX512_VL=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VL);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_DQ != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_DQ)
            {
                sb.AppendLine("UseArch_AVX512_DQ=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_DQ);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_BW != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_BW)
            {
                sb.AppendLine("UseArch_AVX512_BW=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_BW);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_ER != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_ER)
            {
                sb.AppendLine("UseArch_AVX512_ER=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_ER);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_F != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_F)
            {
                sb.AppendLine("UseArch_AVX512_F=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_F);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_CD != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_CD)
            {
                sb.AppendLine("UseArch_AVX512_CD=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_CD);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_PF != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_PF)
            {
                sb.AppendLine("UseArch_AVX512_PF=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_PF);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_IFMA52 != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_IFMA52)
            {
                sb.AppendLine("UseArch_AVX512_IFMA52=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_IFMA52);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_VBMI != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VBMI)
            {
                sb.AppendLine("UseArch_AVX512_VBMI=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VBMI);
                changed = true;
            }

            if (Settings.Default.ARCH_AVX512_VPOPCNTDQ != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VPOPCNTDQ)
            {
                sb.AppendLine("UseArch_AVX512_VPOPCNTDQ=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VPOPCNTDQ);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_4VNNIW != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4VNNIW)
            {
                sb.AppendLine("UseArch_AVX512_4VNNIW=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4VNNIW);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_4FMAPS != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4FMAPS)
            {
                sb.AppendLine("UseArch_AVX512_4FMAPS=" + this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4FMAPS);
                changed = true;
            }



            if (Settings.Default.ARCH_IA32 != this._intrinsicsDudeOptionsPageUI.UseArch_IA32) {
                sb.AppendLine("UseArch_IA32=" + this._intrinsicsDudeOptionsPageUI.UseArch_IA32);
                changed = true;
            }
            if (Settings.Default.ARCH_BMI1 != this._intrinsicsDudeOptionsPageUI.UseArch_BMI1)
            {
                sb.AppendLine("UseArch_BMI1=" + this._intrinsicsDudeOptionsPageUI.UseArch_BMI1);
                changed = true;
            }
            if (Settings.Default.ARCH_BMI2 != this._intrinsicsDudeOptionsPageUI.UseArch_BMI2)
            {
                sb.AppendLine("UseArch_BMI2=" + this._intrinsicsDudeOptionsPageUI.UseArch_BMI2);
                changed = true;
            }
            if (Settings.Default.ARCH_FMA != this._intrinsicsDudeOptionsPageUI.UseArch_FMA)
            {
                sb.AppendLine("UseArch_FMA=" + this._intrinsicsDudeOptionsPageUI.UseArch_FMA);
                changed = true;
            }
            if (Settings.Default.ARCH_MPX != this._intrinsicsDudeOptionsPageUI.UseArch_MPX)
            {
                sb.AppendLine("UseArch_MPX=" + this._intrinsicsDudeOptionsPageUI.UseArch_MPX);
                changed = true;
            }
            if (Settings.Default.ARCH_ADX != this._intrinsicsDudeOptionsPageUI.UseArch_ADX)
            {
                sb.AppendLine("UseArch_ADX=" + this._intrinsicsDudeOptionsPageUI.UseArch_ADX);
                changed = true;
            }
            if (Settings.Default.ARCH_FP16C != this._intrinsicsDudeOptionsPageUI.UseArch_FP16C)
            {
                sb.AppendLine("UseArch_F16C=" + this._intrinsicsDudeOptionsPageUI.UseArch_FP16C);
                changed = true;
            }
            if (Settings.Default.ARCH_PCLMULQDQ != this._intrinsicsDudeOptionsPageUI.UseArch_PCLMULQDQ)
            {
                sb.AppendLine("UseArch_PCLMULQDQ=" + this._intrinsicsDudeOptionsPageUI.UseArch_PCLMULQDQ);
                changed = true;
            }
            if (Settings.Default.ARCH_AES != this._intrinsicsDudeOptionsPageUI.UseArch_AES)
            {
                sb.AppendLine("UseArch_AES=" + this._intrinsicsDudeOptionsPageUI.UseArch_AES);
                changed = true;
            }
            if (Settings.Default.ARCH_CLFLUSHOPT != this._intrinsicsDudeOptionsPageUI.UseArch_CLFLUSHOPT)
            {
                sb.AppendLine("UseArch_CLFLUSHOPT=" + this._intrinsicsDudeOptionsPageUI.UseArch_CLFLUSHOPT);
                changed = true;
            }
            if (Settings.Default.ARCH_FXSR != this._intrinsicsDudeOptionsPageUI.UseArch_FXSR)
            {
                sb.AppendLine("UseArch_FXSR=" + this._intrinsicsDudeOptionsPageUI.UseArch_FXSR);
                changed = true;
            }
            if (Settings.Default.ARCH_KNCNI != this._intrinsicsDudeOptionsPageUI.UseArch_KNCNI)
            {
                sb.AppendLine("UseArch_KNCNI=" + this._intrinsicsDudeOptionsPageUI.UseArch_KNCNI);
                changed = true;
            }


            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT)
            {
                sb.AppendLine("UseArch_LZCNT=" + this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT);
                changed = true;
            }
            if (Settings.Default.ARCH_INVPCID != this._intrinsicsDudeOptionsPageUI.UseArch_INVPCID)
            {
                sb.AppendLine("UseArch_INVPCID=" + this._intrinsicsDudeOptionsPageUI.UseArch_INVPCID);
                changed = true;
            }
            if (Settings.Default.ARCH_MONITOR != this._intrinsicsDudeOptionsPageUI.UseArch_MONITOR)
            {
                sb.AppendLine("UseArch_MONITOR=" + this._intrinsicsDudeOptionsPageUI.UseArch_MONITOR);
                changed = true;
            }
            if (Settings.Default.ARCH_POPCNT != this._intrinsicsDudeOptionsPageUI.UseArch_POPCNT)
            {
                sb.AppendLine("UseArch_POPCNT=" + this._intrinsicsDudeOptionsPageUI.UseArch_POPCNT);
                changed = true;
            }
            if (Settings.Default.ARCH_RDRAND != this._intrinsicsDudeOptionsPageUI.UseArch_RDRAND)
            {
                sb.AppendLine("UseArch_RDRAND=" + this._intrinsicsDudeOptionsPageUI.UseArch_RDRAND);
                changed = true;
            }
            if (Settings.Default.ARCH_RDSEED != this._intrinsicsDudeOptionsPageUI.UseArch_RDSEED)
            {
                sb.AppendLine("UseArch_RDSEED=" + this._intrinsicsDudeOptionsPageUI.UseArch_RDSEED);
                changed = true;
            }
            if (Settings.Default.ARCH_TSC != this._intrinsicsDudeOptionsPageUI.UseArch_TSC)
            {
                sb.AppendLine("UseArch_TSC=" + this._intrinsicsDudeOptionsPageUI.UseArch_TSC);
                changed = true;
            }
            if (Settings.Default.ARCH_RDTSCP != this._intrinsicsDudeOptionsPageUI.UseArch_RDTSCP)
            {
                sb.AppendLine("UseArch_RDTSCP=" + this._intrinsicsDudeOptionsPageUI.UseArch_RDTSCP);
                changed = true;
            }
            if (Settings.Default.ARCH_FSGSBASE != this._intrinsicsDudeOptionsPageUI.UseArch_FSGSBASE)
            {
                sb.AppendLine("UseArch_FSGSBASE=" + this._intrinsicsDudeOptionsPageUI.UseArch_FSGSBASE);
                changed = true;
            }
            if (Settings.Default.ARCH_SHA != this._intrinsicsDudeOptionsPageUI.UseArch_SHA)
            {
                sb.AppendLine("UseArch_SHA=" + this._intrinsicsDudeOptionsPageUI.UseArch_SHA);
                changed = true;
            }
            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT)
            {
                sb.AppendLine("UseArch_LZCNT=" + this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT);
                changed = true;
            }
            if (Settings.Default.ARCH_RTM != this._intrinsicsDudeOptionsPageUI.UseArch_RTM)
            {
                sb.AppendLine("UseArch_RTM=" + this._intrinsicsDudeOptionsPageUI.UseArch_RTM);
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVE != this._intrinsicsDudeOptionsPageUI.UseArch_XSAVE)
            {
                sb.AppendLine("UseArch_XSAVE=" + this._intrinsicsDudeOptionsPageUI.UseArch_XSAVE);
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEC != this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEC)
            {
                sb.AppendLine("UseArch_XSAVEC=" + this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEC);
                changed = true;
            }
            if (Settings.Default.ARCH_XSS != this._intrinsicsDudeOptionsPageUI.UseArch_XSS)
            {
                sb.AppendLine("UseArch_XSS=" + this._intrinsicsDudeOptionsPageUI.UseArch_XSS);
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEOPT != this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEOPT)
            {
                sb.AppendLine("UseArch_XSAVEOPT=" + this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEOPT);
                changed = true;
            }
            if (Settings.Default.ARCH_PREFETCHWT1 != this._intrinsicsDudeOptionsPageUI.UseArch_PREFETCHWT1)
            {
                sb.AppendLine("UseArch_PREFETCHWT1=" + this._intrinsicsDudeOptionsPageUI.UseArch_PREFETCHWT1);
                changed = true;
            }


            #endregion

            if (changed)
            {
                string title = null;
                string message = "Unsaved changes exist.\n\n" + sb.ToString() + "\nWould you like to save?";
                int result = VsShellUtilities.ShowMessageBox(this.Site, message, title, OLEMSGICON.OLEMSGICON_QUERY, OLEMSGBUTTON.OLEMSGBUTTON_OKCANCEL, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                if (result == (int)VSConstants.MessageBoxResult.IDOK)
                {
                    this.Save();
                }
                else if (result == (int)VSConstants.MessageBoxResult.IDCANCEL)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Handles "apply" messages from the Visual Studio environment.
        /// </summary>
        /// <devdoc>
        /// This method is called when VS wants to save the user's 
        /// changes (for example, when the user clicks OK in the dialog).
        /// </devdoc>
        protected override void OnApply(PageApplyEventArgs e)
        {
            this.Save();
            base.OnApply(e);
        }

        private void Save()
        {
            //Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "INFO:{0}:save", this.ToString()));
            bool changed = false;
            bool restartNeeded = false;

            #region Syntax Highlighting
            if (Settings.Default.SyntaxHighlighting_On != this._intrinsicsDudeOptionsPageUI.useSyntaxHighlighting)
            {
                Settings.Default.SyntaxHighlighting_On = this._intrinsicsDudeOptionsPageUI.useSyntaxHighlighting;
                changed = true;
                restartNeeded = true;
            }
            if (Settings.Default.SyntaxHighlighting_Intrinsic.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorMnemonic.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Intrinsic = this._intrinsicsDudeOptionsPageUI.colorMnemonic;
                changed = true;
                restartNeeded = true;
            }
            if (Settings.Default.SyntaxHighlighting_Register.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorRegister.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Register = this._intrinsicsDudeOptionsPageUI.colorRegister;
                changed = true;
                restartNeeded = true;
            }
            if (Settings.Default.SyntaxHighlighting_Misc.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorMisc.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Misc = this._intrinsicsDudeOptionsPageUI.colorMisc;
                changed = true;
                restartNeeded = true;
            }
            #endregion

            #region Code Completion
            if (Settings.Default.StatementCompletion_On != this._intrinsicsDudeOptionsPageUI.useCodeCompletion)
            {
                Settings.Default.StatementCompletion_On = this._intrinsicsDudeOptionsPageUI.useCodeCompletion;
                changed = true;
            }
            if (Settings.Default.HideStatementCompletionMmxRegisters_On != this._intrinsicsDudeOptionsPageUI.hideStatementCompletionMmxRegisters)
            {
                Settings.Default.HideStatementCompletionMmxRegisters_On = this._intrinsicsDudeOptionsPageUI.hideStatementCompletionMmxRegisters;
                changed = true;
            }
            if (Settings.Default.HideStatementCompletionIncompatibleReturnType_On != this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType)
            {
                Settings.Default.HideStatementCompletionIncompatibleReturnType_On = this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType;
                changed = true;
            }
            if (Settings.Default.DecorateIncompatibleStatementCompletions_On != this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions)
            {
                Settings.Default.DecorateIncompatibleStatementCompletions_On = this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions;
                changed = true;
            }

            if (Settings.Default.SignatureHelp_On != this._intrinsicsDudeOptionsPageUI.useSignatureHelp)
            {
                Settings.Default.SignatureHelp_On = this._intrinsicsDudeOptionsPageUI.useSignatureHelp;
                changed = true;
            }
            if (Settings.Default.USE_SVML != this._intrinsicsDudeOptionsPageUI.useSvml)
            {
                Settings.Default.USE_SVML = this._intrinsicsDudeOptionsPageUI.useSvml;
                changed = true;
            }
            if (Settings.Default.ARCH_MMX != this._intrinsicsDudeOptionsPageUI.UseArch_MMX)
            {
                Settings.Default.ARCH_MMX = this._intrinsicsDudeOptionsPageUI.UseArch_MMX;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE != this._intrinsicsDudeOptionsPageUI.UseArch_SSE)
            {
                Settings.Default.ARCH_SSE = this._intrinsicsDudeOptionsPageUI.UseArch_SSE;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE2 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE2)
            {
                Settings.Default.ARCH_SSE2 = this._intrinsicsDudeOptionsPageUI.UseArch_SSE2;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE3 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE3)
            {
                Settings.Default.ARCH_SSE3 = this._intrinsicsDudeOptionsPageUI.UseArch_SSE3;
                changed = true;
            }
            if (Settings.Default.ARCH_SSSE3 != this._intrinsicsDudeOptionsPageUI.UseArch_SSSE3)
            {
                Settings.Default.ARCH_SSSE3 = this._intrinsicsDudeOptionsPageUI.UseArch_SSSE3;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE41 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE41)
            {
                Settings.Default.ARCH_SSE41 = this._intrinsicsDudeOptionsPageUI.UseArch_SSE41;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE42 != this._intrinsicsDudeOptionsPageUI.UseArch_SSE42)
            {
                Settings.Default.ARCH_SSE42 = this._intrinsicsDudeOptionsPageUI.UseArch_SSE42;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX != this._intrinsicsDudeOptionsPageUI.UseArch_AVX)
            {
                Settings.Default.ARCH_AVX = this._intrinsicsDudeOptionsPageUI.UseArch_AVX;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX2 != this._intrinsicsDudeOptionsPageUI.UseArch_AVX2)
            {
                Settings.Default.ARCH_AVX2 = this._intrinsicsDudeOptionsPageUI.UseArch_AVX2;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_VL != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VL)
            {
                Settings.Default.ARCH_AVX512_VL = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VL;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_DQ != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_DQ)
            {
                Settings.Default.ARCH_AVX512_DQ = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_DQ;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_BW != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_BW)
            {
                Settings.Default.ARCH_AVX512_BW = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_BW;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_ER != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_ER)
            {
                Settings.Default.ARCH_AVX512_ER = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_ER;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_F != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_F)
            {
                Settings.Default.ARCH_AVX512_F = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_F;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_CD != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_CD)
            {
                Settings.Default.ARCH_AVX512_CD = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_CD;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_PF != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_PF)
            {
                Settings.Default.ARCH_AVX512_PF = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_PF;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_IFMA52 != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_IFMA52)
            {
                Settings.Default.ARCH_AVX512_IFMA52 = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_IFMA52;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_VBMI != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VBMI)
            {
                Settings.Default.ARCH_AVX512_VBMI = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VBMI;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_VPOPCNTDQ != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VPOPCNTDQ)
            {
                Settings.Default.ARCH_AVX512_VPOPCNTDQ = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VPOPCNTDQ;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_4VNNIW != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4VNNIW)
            {
                Settings.Default.ARCH_AVX512_4VNNIW = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4VNNIW;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512_4FMAPS != this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4FMAPS)
            {
                Settings.Default.ARCH_AVX512_4FMAPS = this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4FMAPS;
                changed = true;
            }

            if (Settings.Default.ARCH_IA32 != this._intrinsicsDudeOptionsPageUI.UseArch_IA32) {
                Settings.Default.ARCH_IA32 = this._intrinsicsDudeOptionsPageUI.UseArch_IA32;
                changed = true;
            }
            if (Settings.Default.ARCH_BMI1 != this._intrinsicsDudeOptionsPageUI.UseArch_BMI1)
            {
                Settings.Default.ARCH_BMI1 = this._intrinsicsDudeOptionsPageUI.UseArch_BMI1;
                changed = true;
            }
            if (Settings.Default.ARCH_BMI2 != this._intrinsicsDudeOptionsPageUI.UseArch_BMI2)
            {
                Settings.Default.ARCH_BMI2 = this._intrinsicsDudeOptionsPageUI.UseArch_BMI2;
                changed = true;
            }
            if (Settings.Default.ARCH_FMA != this._intrinsicsDudeOptionsPageUI.UseArch_FMA)
            {
                Settings.Default.ARCH_FMA = this._intrinsicsDudeOptionsPageUI.UseArch_FMA;
                changed = true;
            }
            if (Settings.Default.ARCH_MPX != this._intrinsicsDudeOptionsPageUI.UseArch_MPX)
            {
                Settings.Default.ARCH_MPX = this._intrinsicsDudeOptionsPageUI.UseArch_MPX;
                changed = true;
            }
            if (Settings.Default.ARCH_ADX != this._intrinsicsDudeOptionsPageUI.UseArch_ADX)
            {
                Settings.Default.ARCH_ADX = this._intrinsicsDudeOptionsPageUI.UseArch_ADX;
                changed = true;
            }
            if (Settings.Default.ARCH_FP16C != this._intrinsicsDudeOptionsPageUI.UseArch_FP16C)
            {
                Settings.Default.ARCH_FP16C = this._intrinsicsDudeOptionsPageUI.UseArch_FP16C;
                changed = true;
            }
            if (Settings.Default.ARCH_PCLMULQDQ != this._intrinsicsDudeOptionsPageUI.UseArch_PCLMULQDQ)
            {
                Settings.Default.ARCH_PCLMULQDQ = this._intrinsicsDudeOptionsPageUI.UseArch_PCLMULQDQ;
                changed = true;
            }
            if (Settings.Default.ARCH_AES != this._intrinsicsDudeOptionsPageUI.UseArch_AES)
            {
                Settings.Default.ARCH_AES = this._intrinsicsDudeOptionsPageUI.UseArch_AES;
                changed = true;
            }
            if (Settings.Default.ARCH_CLFLUSHOPT != this._intrinsicsDudeOptionsPageUI.UseArch_CLFLUSHOPT)
            {
                Settings.Default.ARCH_CLFLUSHOPT = this._intrinsicsDudeOptionsPageUI.UseArch_CLFLUSHOPT;
                changed = true;
            }
            if (Settings.Default.ARCH_FXSR != this._intrinsicsDudeOptionsPageUI.UseArch_FXSR)
            {
                Settings.Default.ARCH_FXSR = this._intrinsicsDudeOptionsPageUI.UseArch_FXSR;
                changed = true;
            }
            if (Settings.Default.ARCH_KNCNI != this._intrinsicsDudeOptionsPageUI.UseArch_KNCNI)
            {
                Settings.Default.ARCH_KNCNI = this._intrinsicsDudeOptionsPageUI.UseArch_KNCNI;
                changed = true;
            }


            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT)
            {
                Settings.Default.ARCH_LZCNT = this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT;
                changed = true;
            }
            if (Settings.Default.ARCH_INVPCID != this._intrinsicsDudeOptionsPageUI.UseArch_INVPCID)
            {
                Settings.Default.ARCH_INVPCID = this._intrinsicsDudeOptionsPageUI.UseArch_INVPCID;
                changed = true;
            }
            if (Settings.Default.ARCH_MONITOR != this._intrinsicsDudeOptionsPageUI.UseArch_MONITOR)
            {
                Settings.Default.ARCH_MONITOR = this._intrinsicsDudeOptionsPageUI.UseArch_MONITOR;
                changed = true;
            }
            if (Settings.Default.ARCH_POPCNT != this._intrinsicsDudeOptionsPageUI.UseArch_POPCNT)
            {
                Settings.Default.ARCH_POPCNT = this._intrinsicsDudeOptionsPageUI.UseArch_POPCNT;
                changed = true;
            }
            if (Settings.Default.ARCH_RDRAND != this._intrinsicsDudeOptionsPageUI.UseArch_RDRAND)
            {
                Settings.Default.ARCH_RDRAND = this._intrinsicsDudeOptionsPageUI.UseArch_RDRAND;
                changed = true;
            }
            if (Settings.Default.ARCH_RDSEED != this._intrinsicsDudeOptionsPageUI.UseArch_RDSEED)
            {
                Settings.Default.ARCH_RDSEED = this._intrinsicsDudeOptionsPageUI.UseArch_RDSEED;
                changed = true;
            }
            if (Settings.Default.ARCH_TSC != this._intrinsicsDudeOptionsPageUI.UseArch_TSC)
            {
                Settings.Default.ARCH_TSC = this._intrinsicsDudeOptionsPageUI.UseArch_TSC;
                changed = true;
            }
            if (Settings.Default.ARCH_RDTSCP != this._intrinsicsDudeOptionsPageUI.UseArch_RDTSCP)
            {
                Settings.Default.ARCH_RDTSCP = this._intrinsicsDudeOptionsPageUI.UseArch_RDTSCP;
                changed = true;
            }
            if (Settings.Default.ARCH_FSGSBASE != this._intrinsicsDudeOptionsPageUI.UseArch_FSGSBASE)
            {
                Settings.Default.ARCH_FSGSBASE = this._intrinsicsDudeOptionsPageUI.UseArch_FSGSBASE;
                changed = true;
            }
            if (Settings.Default.ARCH_SHA != this._intrinsicsDudeOptionsPageUI.UseArch_SHA)
            {
                Settings.Default.ARCH_SHA = this._intrinsicsDudeOptionsPageUI.UseArch_SHA;
                changed = true;
            }
            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT)
            {
                Settings.Default.ARCH_LZCNT = this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT;
                changed = true;
            }
            if (Settings.Default.ARCH_RTM != this._intrinsicsDudeOptionsPageUI.UseArch_RTM)
            {
                Settings.Default.ARCH_RTM = this._intrinsicsDudeOptionsPageUI.UseArch_RTM;
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVE != this._intrinsicsDudeOptionsPageUI.UseArch_XSAVE)
            {
                Settings.Default.ARCH_XSAVE = this._intrinsicsDudeOptionsPageUI.UseArch_XSAVE;
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEC != this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEC)
            {
                Settings.Default.ARCH_XSAVEC = this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEC;
                changed = true;
            }
            if (Settings.Default.ARCH_XSS != this._intrinsicsDudeOptionsPageUI.UseArch_XSS)
            {
                Settings.Default.ARCH_XSS = this._intrinsicsDudeOptionsPageUI.UseArch_XSS;
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEOPT != this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEOPT)
            {
                Settings.Default.ARCH_XSAVEOPT = this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEOPT;
                changed = true;
            }
            if (Settings.Default.ARCH_PREFETCHWT1 != this._intrinsicsDudeOptionsPageUI.UseArch_PREFETCHWT1)
            {
                Settings.Default.ARCH_PREFETCHWT1 = this._intrinsicsDudeOptionsPageUI.UseArch_PREFETCHWT1;
                changed = true;
            }

            #endregion

            if (changed)
            {
                Settings.Default.Save();
            }
            if (restartNeeded)
            {
                string title = null;
                string message = "You may need to restart visual studio for the changes to take effect.";
                int result = VsShellUtilities.ShowMessageBox(this.Site, message, title, OLEMSGICON.OLEMSGICON_QUERY, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
        }

        #endregion Event Handlers
    }
}
