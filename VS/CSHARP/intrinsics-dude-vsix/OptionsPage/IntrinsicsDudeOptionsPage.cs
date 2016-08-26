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
            this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType = Settings.Default.HideStatementCompletionIncompatibleReturnType_On;
            this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions = Settings.Default.DecorateIncompatibleStatementCompletions_On;

            this._intrinsicsDudeOptionsPageUI.useSignatureHelp = Settings.Default.SignatureHelp_On;

            this._intrinsicsDudeOptionsPageUI.useSvml = Settings.Default.USE_SVML;
            this._intrinsicsDudeOptionsPageUI.useSvml_UI.ToolTip = this.makeToolTip(CpuID.SVML);
            this._intrinsicsDudeOptionsPageUI.useArch_ADX = Settings.Default.ARCH_ADX;
            this._intrinsicsDudeOptionsPageUI.useArch_ADX_UI.ToolTip = this.makeToolTip(CpuID.ADX);
            this._intrinsicsDudeOptionsPageUI.useArch_AES = Settings.Default.ARCH_AES;
            this._intrinsicsDudeOptionsPageUI.useArch_AES_UI.ToolTip = this.makeToolTip(CpuID.AES);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX = Settings.Default.ARCH_AVX;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX_UI.ToolTip = this.makeToolTip(CpuID.AVX);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX2 = Settings.Default.ARCH_AVX2;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX2_UI.ToolTip = this.makeToolTip(CpuID.AVX2);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512F = Settings.Default.ARCH_AVX512F;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512F_UI.ToolTip = this.makeToolTip(CpuID.AVX512F);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512VL = Settings.Default.ARCH_AVX512VL;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512VL_UI.ToolTip = this.makeToolTip(CpuID.AVX512VL);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512DQ = Settings.Default.ARCH_AVX512DQ;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512DQ_UI.ToolTip = this.makeToolTip(CpuID.AVX512DQ);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512BW = Settings.Default.ARCH_AVX512BW;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512BW_UI.ToolTip = this.makeToolTip(CpuID.AVX512BW);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512ER = Settings.Default.ARCH_AVX512ER;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512ER_UI.ToolTip = this.makeToolTip(CpuID.AVX512ER);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512CD = Settings.Default.ARCH_AVX512CD;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512CD_UI.ToolTip = this.makeToolTip(CpuID.AVX512CD);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512PF = Settings.Default.ARCH_AVX512PF;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512PF_UI.ToolTip = this.makeToolTip(CpuID.AVX512PF);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512IFMA52 = Settings.Default.ARCH_AVX512IFMA52;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512IFMA52_UI.ToolTip = this.makeToolTip(CpuID.AVX512IFMA52);
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512VBMI = Settings.Default.ARCH_AVX512VBMI;
            this._intrinsicsDudeOptionsPageUI.useArch_AVX512VBMI_UI.ToolTip = this.makeToolTip(CpuID.AVX512VBMI);

            this._intrinsicsDudeOptionsPageUI.useArch_IA32 = Settings.Default.ARCH_IA32;
            this._intrinsicsDudeOptionsPageUI.useArch_IA32_UI.ToolTip = this.makeToolTip(CpuID.IA32);
            this._intrinsicsDudeOptionsPageUI.useArch_BMI1 = Settings.Default.ARCH_BMI1;
            this._intrinsicsDudeOptionsPageUI.useArch_BMI1_UI.ToolTip = this.makeToolTip(CpuID.BMI1);
            this._intrinsicsDudeOptionsPageUI.useArch_BMI2 = Settings.Default.ARCH_BMI2;
            this._intrinsicsDudeOptionsPageUI.useArch_BMI2_UI.ToolTip = this.makeToolTip(CpuID.BMI2);
            this._intrinsicsDudeOptionsPageUI.useArch_CLFLUSHOPT = Settings.Default.ARCH_CLFLUSHOPT;
            this._intrinsicsDudeOptionsPageUI.useArch_CLFLUSHOPT_UI.ToolTip = this.makeToolTip(CpuID.CLFLUSHOPT);
            this._intrinsicsDudeOptionsPageUI.useArch_FMA = Settings.Default.ARCH_FMA;
            this._intrinsicsDudeOptionsPageUI.useArch_FMA_UI.ToolTip = this.makeToolTip(CpuID.FMA);
            this._intrinsicsDudeOptionsPageUI.useArch_FP16C = Settings.Default.ARCH_FP16C;
            this._intrinsicsDudeOptionsPageUI.useArch_FP16C_UI.ToolTip = this.makeToolTip(CpuID.FP16C);
            this._intrinsicsDudeOptionsPageUI.useArch_FXSR = Settings.Default.ARCH_FXSR;
            this._intrinsicsDudeOptionsPageUI.useArch_FXSR_UI.ToolTip = this.makeToolTip(CpuID.FXSR);
            this._intrinsicsDudeOptionsPageUI.useArch_KNCNI = Settings.Default.ARCH_KNCNI;
            this._intrinsicsDudeOptionsPageUI.useArch_KNCNI_UI.ToolTip = this.makeToolTip(CpuID.KNCNI);
            this._intrinsicsDudeOptionsPageUI.useArch_MMX = Settings.Default.ARCH_MMX;
            this._intrinsicsDudeOptionsPageUI.useArch_MMX_UI.ToolTip = this.makeToolTip(CpuID.MMX);
            this._intrinsicsDudeOptionsPageUI.useArch_MPX = Settings.Default.ARCH_MPX;
            this._intrinsicsDudeOptionsPageUI.useArch_MPX_UI.ToolTip = this.makeToolTip(CpuID.MPX);
            this._intrinsicsDudeOptionsPageUI.useArch_PCLMULQDQ = Settings.Default.ARCH_PCLMULQDQ;
            this._intrinsicsDudeOptionsPageUI.useArch_PCLMULQDQ_UI.ToolTip = this.makeToolTip(CpuID.PCLMULQDQ);
            this._intrinsicsDudeOptionsPageUI.useArch_SSE = Settings.Default.ARCH_SSE;
            this._intrinsicsDudeOptionsPageUI.useArch_SSE_UI.ToolTip = this.makeToolTip(CpuID.SSE);
            this._intrinsicsDudeOptionsPageUI.useArch_SSE2 = Settings.Default.ARCH_SSE2;
            this._intrinsicsDudeOptionsPageUI.useArch_SSE2_UI.ToolTip = this.makeToolTip(CpuID.SSE2);
            this._intrinsicsDudeOptionsPageUI.useArch_SSE3 = Settings.Default.ARCH_SSE3;
            this._intrinsicsDudeOptionsPageUI.useArch_SSE3_UI.ToolTip = this.makeToolTip(CpuID.SSE3);
            this._intrinsicsDudeOptionsPageUI.useArch_SSSE3 = Settings.Default.ARCH_SSSE3;
            this._intrinsicsDudeOptionsPageUI.useArch_SSSE3_UI.ToolTip = this.makeToolTip(CpuID.SSSE3);
            this._intrinsicsDudeOptionsPageUI.useArch_SSE41 = Settings.Default.ARCH_SSE41;
            this._intrinsicsDudeOptionsPageUI.useArch_SSE41_UI.ToolTip = this.makeToolTip(CpuID.SSE4_1);
            this._intrinsicsDudeOptionsPageUI.useArch_SSE42 = Settings.Default.ARCH_SSE42;
            this._intrinsicsDudeOptionsPageUI.useArch_SSE42_UI.ToolTip = this.makeToolTip(CpuID.SSE4_2);

            this._intrinsicsDudeOptionsPageUI.useArch_LZCNT = Settings.Default.ARCH_LZCNT;
            this._intrinsicsDudeOptionsPageUI.useArch_LZCNT_UI.ToolTip = this.makeToolTip(CpuID.LZCNT);
            this._intrinsicsDudeOptionsPageUI.useArch_INVPCID = Settings.Default.ARCH_INVPCID;
            this._intrinsicsDudeOptionsPageUI.useArch_INVPCID_UI.ToolTip = this.makeToolTip(CpuID.INVPCID);
            this._intrinsicsDudeOptionsPageUI.useArch_MONITOR = Settings.Default.ARCH_MONITOR;
            this._intrinsicsDudeOptionsPageUI.useArch_MONITOR_UI.ToolTip = this.makeToolTip(CpuID.MONITOR);
            this._intrinsicsDudeOptionsPageUI.useArch_POPCNT = Settings.Default.ARCH_POPCNT;
            this._intrinsicsDudeOptionsPageUI.useArch_POPCNT_UI.ToolTip = this.makeToolTip(CpuID.POPCNT);
            this._intrinsicsDudeOptionsPageUI.useArch_RDRAND = Settings.Default.ARCH_RDRAND;
            this._intrinsicsDudeOptionsPageUI.useArch_RDRAND_UI.ToolTip = this.makeToolTip(CpuID.RDRAND);
            this._intrinsicsDudeOptionsPageUI.useArch_RDSEED = Settings.Default.ARCH_RDSEED;
            this._intrinsicsDudeOptionsPageUI.useArch_RDSEED_UI.ToolTip = this.makeToolTip(CpuID.RDSEED);
            this._intrinsicsDudeOptionsPageUI.useArch_TSC = Settings.Default.ARCH_TSC;
            this._intrinsicsDudeOptionsPageUI.useArch_TSC_UI.ToolTip = this.makeToolTip(CpuID.TSC);
            this._intrinsicsDudeOptionsPageUI.useArch_RDTSCP = Settings.Default.ARCH_RDTSCP;
            this._intrinsicsDudeOptionsPageUI.useArch_RDTSCP_UI.ToolTip = this.makeToolTip(CpuID.RDTSCP);
            this._intrinsicsDudeOptionsPageUI.useArch_FSGSBASE = Settings.Default.ARCH_FSGSBASE;
            this._intrinsicsDudeOptionsPageUI.useArch_FSGSBASE_UI.ToolTip = this.makeToolTip(CpuID.FSGSBASE);
            this._intrinsicsDudeOptionsPageUI.useArch_SHA = Settings.Default.ARCH_SHA;
            this._intrinsicsDudeOptionsPageUI.useArch_SHA_UI.ToolTip = this.makeToolTip(CpuID.SHA);
            this._intrinsicsDudeOptionsPageUI.useArch_RTM = Settings.Default.ARCH_RTM;
            this._intrinsicsDudeOptionsPageUI.useArch_RTM_UI.ToolTip = this.makeToolTip(CpuID.RTM);
            this._intrinsicsDudeOptionsPageUI.useArch_XSAVE = Settings.Default.ARCH_XSAVE;
            this._intrinsicsDudeOptionsPageUI.useArch_XSAVE_UI.ToolTip = this.makeToolTip(CpuID.XSAVE);
            this._intrinsicsDudeOptionsPageUI.useArch_XSAVEC = Settings.Default.ARCH_XSAVEC;
            this._intrinsicsDudeOptionsPageUI.useArch_XSAVEC_UI.ToolTip = this.makeToolTip(CpuID.XSAVEC);
            this._intrinsicsDudeOptionsPageUI.useArch_XSS = Settings.Default.ARCH_XSS;
            this._intrinsicsDudeOptionsPageUI.useArch_XSS_UI.ToolTip = this.makeToolTip(CpuID.XSS);
            this._intrinsicsDudeOptionsPageUI.useArch_XSAVEOPT = Settings.Default.ARCH_XSAVEOPT;
            this._intrinsicsDudeOptionsPageUI.useArch_XSAVEOPT_UI.ToolTip = this.makeToolTip(CpuID.XSAVEOPT);
            this._intrinsicsDudeOptionsPageUI.useArch_PREFETCHWT1 = Settings.Default.ARCH_PREFETCHWT1;
            this._intrinsicsDudeOptionsPageUI.useArch_PREFETCHWT1_UI.ToolTip = this.makeToolTip(CpuID.PREFETCHWT1);

            #endregion
        }

        private string makeToolTip(CpuID arch)
        {
            IntrinsicStore store = IntrinsicsDudeTools.Instance.intrinsicStore;
            SortedSet<Intrinsic> usedMnemonics = new SortedSet<Intrinsic>();

            StringBuilder sb = new StringBuilder();
            string docArch = IntrinsicTools.getCpuID_Documentation(arch);
            if (docArch.Length > 0)
            {
                sb.Append(docArch + ": ");
            }
            foreach (Intrinsic mnemonic in Enum.GetValues(typeof(Intrinsic)))
            {
                if (store.getCpuID(mnemonic).HasFlag(arch))
                {
                    sb.Append(mnemonic.ToString());
                    sb.Append(", ");
                }
            }
            if (sb.Length > 2) sb.Length -= 2; // get rid of last comma.
            return IntrinsicTools.linewrap(sb.ToString(), IntrinsicsDudePackage.maxNumberOfCharsInToolTips);
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

            #region Syntax Highlighting
            if (Settings.Default.SyntaxHighlighting_On != this._intrinsicsDudeOptionsPageUI.useSyntaxHighlighting)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useSyntaxHighlighting=" + this._intrinsicsDudeOptionsPageUI.useSyntaxHighlighting);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Intrinsic.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorMnemonic.ToArgb())
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: stored=" + Settings.Default.SyntaxHighlighting_Intrinsic + "; new colorMnemonic=" + this._intrinsicsDudeOptionsPageUI.colorMnemonic);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Register.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorRegister.ToArgb())
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: colorRegister=" + this._intrinsicsDudeOptionsPageUI.colorRegister);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Misc.ToArgb() != this._intrinsicsDudeOptionsPageUI.colorMisc.ToArgb())
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: colorMisc=" + this._intrinsicsDudeOptionsPageUI.colorMisc);
                changed = true;
            }
            #endregion

            #region Code Completion
            if (Settings.Default.StatementCompletion_On != this._intrinsicsDudeOptionsPageUI.useCodeCompletion)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useCodeCompletion=" + this._intrinsicsDudeOptionsPageUI.useCodeCompletion);
                changed = true;
            }

            if (Settings.Default.HideStatementCompletionIncompatibleReturnType_On != this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: hideStatementCompletionIncompatibleReturnType=" + this._intrinsicsDudeOptionsPageUI.hideStatementCompletionIncompatibleReturnType);
                changed = true;
            }
            if (Settings.Default.DecorateIncompatibleStatementCompletions_On != this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: decorateIncompatibleStatementCompletions=" + this._intrinsicsDudeOptionsPageUI.decorateIncompatibleStatementCompletions);
                changed = true;
            }

            if (Settings.Default.SignatureHelp_On != this._intrinsicsDudeOptionsPageUI.useSignatureHelp)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useSignatureHelp=" + this._intrinsicsDudeOptionsPageUI.useSignatureHelp);
                changed = true;
            }
            if (Settings.Default.USE_SVML != this._intrinsicsDudeOptionsPageUI.useSvml)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useSvml=" + this._intrinsicsDudeOptionsPageUI.useSvml);
                changed = true;
            }
            if (Settings.Default.ARCH_MMX != this._intrinsicsDudeOptionsPageUI.useArch_MMX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_MMX=" + this._intrinsicsDudeOptionsPageUI.useArch_MMX);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE != this._intrinsicsDudeOptionsPageUI.useArch_SSE)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_SSE=" + this._intrinsicsDudeOptionsPageUI.useArch_SSE);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE2 != this._intrinsicsDudeOptionsPageUI.useArch_SSE2)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_SSE2=" + this._intrinsicsDudeOptionsPageUI.useArch_SSE2);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE3 != this._intrinsicsDudeOptionsPageUI.useArch_SSE3)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_SSE3=" + this._intrinsicsDudeOptionsPageUI.useArch_SSE3);
                changed = true;
            }
            if (Settings.Default.ARCH_SSSE3 != this._intrinsicsDudeOptionsPageUI.useArch_SSSE3)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_SSSE3=" + this._intrinsicsDudeOptionsPageUI.useArch_SSSE3);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE41 != this._intrinsicsDudeOptionsPageUI.useArch_SSE41)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_SSE41=" + this._intrinsicsDudeOptionsPageUI.useArch_SSE41);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE42 != this._intrinsicsDudeOptionsPageUI.useArch_SSE42)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_SSE42=" + this._intrinsicsDudeOptionsPageUI.useArch_SSE42);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX != this._intrinsicsDudeOptionsPageUI.useArch_AVX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX2 != this._intrinsicsDudeOptionsPageUI.useArch_AVX2)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX2=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX2);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512VL != this._intrinsicsDudeOptionsPageUI.useArch_AVX512VL)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512VL=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512VL);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512DQ != this._intrinsicsDudeOptionsPageUI.useArch_AVX512DQ)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512DQ=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512DQ);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512BW != this._intrinsicsDudeOptionsPageUI.useArch_AVX512BW)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512BW=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512BW);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512ER != this._intrinsicsDudeOptionsPageUI.useArch_AVX512ER)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512ER=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512ER);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512F != this._intrinsicsDudeOptionsPageUI.useArch_AVX512F)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512PF=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512F);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512CD != this._intrinsicsDudeOptionsPageUI.useArch_AVX512CD)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512CD=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512CD);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512PF != this._intrinsicsDudeOptionsPageUI.useArch_AVX512PF)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512PF=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512PF);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512IFMA52 != this._intrinsicsDudeOptionsPageUI.useArch_AVX512IFMA52)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512IFMA52=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512IFMA52);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512VBMI != this._intrinsicsDudeOptionsPageUI.useArch_AVX512VBMI)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512VBMI=" + this._intrinsicsDudeOptionsPageUI.useArch_AVX512VBMI);
                changed = true;
            }

            if (Settings.Default.ARCH_IA32 != this._intrinsicsDudeOptionsPageUI.useArch_IA32) {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_IA32=" + this._intrinsicsDudeOptionsPageUI.useArch_IA32);
                changed = true;
            }
            if (Settings.Default.ARCH_BMI1 != this._intrinsicsDudeOptionsPageUI.useArch_BMI1)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_BMI1=" + this._intrinsicsDudeOptionsPageUI.useArch_BMI1);
                changed = true;
            }
            if (Settings.Default.ARCH_BMI2 != this._intrinsicsDudeOptionsPageUI.useArch_BMI2)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_BMI2=" + this._intrinsicsDudeOptionsPageUI.useArch_BMI2);
                changed = true;
            }
            if (Settings.Default.ARCH_FMA != this._intrinsicsDudeOptionsPageUI.useArch_FMA)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_FMA=" + this._intrinsicsDudeOptionsPageUI.useArch_FMA);
                changed = true;
            }
            if (Settings.Default.ARCH_MPX != this._intrinsicsDudeOptionsPageUI.useArch_MPX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_MPX=" + this._intrinsicsDudeOptionsPageUI.useArch_MPX);
                changed = true;
            }
            if (Settings.Default.ARCH_ADX != this._intrinsicsDudeOptionsPageUI.useArch_ADX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_ADX=" + this._intrinsicsDudeOptionsPageUI.useArch_ADX);
                changed = true;
            }
            if (Settings.Default.ARCH_FP16C != this._intrinsicsDudeOptionsPageUI.useArch_FP16C)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_F16C=" + this._intrinsicsDudeOptionsPageUI.useArch_FP16C);
                changed = true;
            }
            if (Settings.Default.ARCH_PCLMULQDQ != this._intrinsicsDudeOptionsPageUI.useArch_PCLMULQDQ)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_PCLMULQDQ=" + this._intrinsicsDudeOptionsPageUI.useArch_PCLMULQDQ);
                changed = true;
            }
            if (Settings.Default.ARCH_AES != this._intrinsicsDudeOptionsPageUI.useArch_AES)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_AES=" + this._intrinsicsDudeOptionsPageUI.useArch_AES);
                changed = true;
            }
            if (Settings.Default.ARCH_CLFLUSHOPT != this._intrinsicsDudeOptionsPageUI.useArch_CLFLUSHOPT)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_CLFLUSHOPT=" + this._intrinsicsDudeOptionsPageUI.useArch_CLFLUSHOPT);
                changed = true;
            }
            if (Settings.Default.ARCH_FXSR != this._intrinsicsDudeOptionsPageUI.useArch_FXSR)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_FXSR=" + this._intrinsicsDudeOptionsPageUI.useArch_FXSR);
                changed = true;
            }
            if (Settings.Default.ARCH_KNCNI != this._intrinsicsDudeOptionsPageUI.useArch_KNCNI)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_KNCNI=" + this._intrinsicsDudeOptionsPageUI.useArch_KNCNI);
                changed = true;
            }


            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.useArch_LZCNT)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_LZCNT=" + this._intrinsicsDudeOptionsPageUI.useArch_LZCNT);
                changed = true;
            }
            if (Settings.Default.ARCH_INVPCID != this._intrinsicsDudeOptionsPageUI.useArch_INVPCID)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_INVPCID=" + this._intrinsicsDudeOptionsPageUI.useArch_INVPCID);
                changed = true;
            }
            if (Settings.Default.ARCH_MONITOR != this._intrinsicsDudeOptionsPageUI.useArch_MONITOR)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_MONITOR=" + this._intrinsicsDudeOptionsPageUI.useArch_MONITOR);
                changed = true;
            }
            if (Settings.Default.ARCH_POPCNT != this._intrinsicsDudeOptionsPageUI.useArch_POPCNT)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_POPCNT=" + this._intrinsicsDudeOptionsPageUI.useArch_POPCNT);
                changed = true;
            }
            if (Settings.Default.ARCH_RDRAND != this._intrinsicsDudeOptionsPageUI.useArch_RDRAND)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_RDRAND=" + this._intrinsicsDudeOptionsPageUI.useArch_RDRAND);
                changed = true;
            }
            if (Settings.Default.ARCH_RDSEED != this._intrinsicsDudeOptionsPageUI.useArch_RDSEED)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_RDSEED=" + this._intrinsicsDudeOptionsPageUI.useArch_RDSEED);
                changed = true;
            }
            if (Settings.Default.ARCH_TSC != this._intrinsicsDudeOptionsPageUI.useArch_TSC)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_TSC=" + this._intrinsicsDudeOptionsPageUI.useArch_TSC);
                changed = true;
            }
            if (Settings.Default.ARCH_RDTSCP != this._intrinsicsDudeOptionsPageUI.useArch_RDTSCP)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_RDTSCP=" + this._intrinsicsDudeOptionsPageUI.useArch_RDTSCP);
                changed = true;
            }
            if (Settings.Default.ARCH_FSGSBASE != this._intrinsicsDudeOptionsPageUI.useArch_FSGSBASE)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_FSGSBASE=" + this._intrinsicsDudeOptionsPageUI.useArch_FSGSBASE);
                changed = true;
            }
            if (Settings.Default.ARCH_SHA != this._intrinsicsDudeOptionsPageUI.useArch_SHA)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_SHA=" + this._intrinsicsDudeOptionsPageUI.useArch_SHA);
                changed = true;
            }
            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.useArch_LZCNT)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_LZCNT=" + this._intrinsicsDudeOptionsPageUI.useArch_LZCNT);
                changed = true;
            }
            if (Settings.Default.ARCH_RTM != this._intrinsicsDudeOptionsPageUI.useArch_RTM)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_RTM=" + this._intrinsicsDudeOptionsPageUI.useArch_RTM);
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVE != this._intrinsicsDudeOptionsPageUI.useArch_XSAVE)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_XSAVE=" + this._intrinsicsDudeOptionsPageUI.useArch_XSAVE);
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEC != this._intrinsicsDudeOptionsPageUI.useArch_XSAVEC)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_XSAVEC=" + this._intrinsicsDudeOptionsPageUI.useArch_XSAVEC);
                changed = true;
            }
            if (Settings.Default.ARCH_XSS != this._intrinsicsDudeOptionsPageUI.useArch_XSS)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_XSS=" + this._intrinsicsDudeOptionsPageUI.useArch_XSS);
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEOPT != this._intrinsicsDudeOptionsPageUI.useArch_XSAVEOPT)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_XSAVEOPT=" + this._intrinsicsDudeOptionsPageUI.useArch_XSAVEOPT);
                changed = true;
            }
            if (Settings.Default.ARCH_PREFETCHWT1 != this._intrinsicsDudeOptionsPageUI.useArch_PREFETCHWT1)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeOptionsPage: OnDeactivate: change detected: useArch_PREFETCHWT1=" + this._intrinsicsDudeOptionsPageUI.useArch_PREFETCHWT1);
                changed = true;
            }


            #endregion

            if (changed)
            {
                string title = null;
                string message = "Unsaved changes exist. Would you like to save.";
                int result = VsShellUtilities.ShowMessageBox(Site, message, title, OLEMSGICON.OLEMSGICON_QUERY, OLEMSGBUTTON.OLEMSGBUTTON_OKCANCEL, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                if (result == (int)VSConstants.MessageBoxResult.IDOK)
                {
                    this.save();
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
            this.save();
            base.OnApply(e);
        }

        private void save()
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
            if (Settings.Default.ARCH_MMX != this._intrinsicsDudeOptionsPageUI.useArch_MMX)
            {
                Settings.Default.ARCH_MMX = this._intrinsicsDudeOptionsPageUI.useArch_MMX;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE != this._intrinsicsDudeOptionsPageUI.useArch_SSE)
            {
                Settings.Default.ARCH_SSE = this._intrinsicsDudeOptionsPageUI.useArch_SSE;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE2 != this._intrinsicsDudeOptionsPageUI.useArch_SSE2)
            {
                Settings.Default.ARCH_SSE2 = this._intrinsicsDudeOptionsPageUI.useArch_SSE2;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE3 != this._intrinsicsDudeOptionsPageUI.useArch_SSE3)
            {
                Settings.Default.ARCH_SSE3 = this._intrinsicsDudeOptionsPageUI.useArch_SSE3;
                changed = true;
            }
            if (Settings.Default.ARCH_SSSE3 != this._intrinsicsDudeOptionsPageUI.useArch_SSSE3)
            {
                Settings.Default.ARCH_SSSE3 = this._intrinsicsDudeOptionsPageUI.useArch_SSSE3;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE41 != this._intrinsicsDudeOptionsPageUI.useArch_SSE41)
            {
                Settings.Default.ARCH_SSE41 = this._intrinsicsDudeOptionsPageUI.useArch_SSE41;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE42 != this._intrinsicsDudeOptionsPageUI.useArch_SSE42)
            {
                Settings.Default.ARCH_SSE42 = this._intrinsicsDudeOptionsPageUI.useArch_SSE42;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX != this._intrinsicsDudeOptionsPageUI.useArch_AVX)
            {
                Settings.Default.ARCH_AVX = this._intrinsicsDudeOptionsPageUI.useArch_AVX;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX2 != this._intrinsicsDudeOptionsPageUI.useArch_AVX2)
            {
                Settings.Default.ARCH_AVX2 = this._intrinsicsDudeOptionsPageUI.useArch_AVX2;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512VL != this._intrinsicsDudeOptionsPageUI.useArch_AVX512VL)
            {
                Settings.Default.ARCH_AVX512VL = this._intrinsicsDudeOptionsPageUI.useArch_AVX512VL;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512DQ != this._intrinsicsDudeOptionsPageUI.useArch_AVX512DQ)
            {
                Settings.Default.ARCH_AVX512DQ = this._intrinsicsDudeOptionsPageUI.useArch_AVX512DQ;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512BW != this._intrinsicsDudeOptionsPageUI.useArch_AVX512BW)
            {
                Settings.Default.ARCH_AVX512BW = this._intrinsicsDudeOptionsPageUI.useArch_AVX512BW;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512ER != this._intrinsicsDudeOptionsPageUI.useArch_AVX512ER)
            {
                Settings.Default.ARCH_AVX512ER = this._intrinsicsDudeOptionsPageUI.useArch_AVX512ER;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512F != this._intrinsicsDudeOptionsPageUI.useArch_AVX512F)
            {
                Settings.Default.ARCH_AVX512F = this._intrinsicsDudeOptionsPageUI.useArch_AVX512F;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512CD != this._intrinsicsDudeOptionsPageUI.useArch_AVX512CD)
            {
                Settings.Default.ARCH_AVX512CD = this._intrinsicsDudeOptionsPageUI.useArch_AVX512CD;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512PF != this._intrinsicsDudeOptionsPageUI.useArch_AVX512PF)
            {
                Settings.Default.ARCH_AVX512PF = this._intrinsicsDudeOptionsPageUI.useArch_AVX512PF;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512IFMA52 != this._intrinsicsDudeOptionsPageUI.useArch_AVX512IFMA52)
            {
                Settings.Default.ARCH_AVX512IFMA52 = this._intrinsicsDudeOptionsPageUI.useArch_AVX512IFMA52;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512VBMI != this._intrinsicsDudeOptionsPageUI.useArch_AVX512VBMI)
            {
                Settings.Default.ARCH_AVX512VBMI = this._intrinsicsDudeOptionsPageUI.useArch_AVX512VBMI;
                changed = true;
            }



            if (Settings.Default.ARCH_IA32 != this._intrinsicsDudeOptionsPageUI.useArch_IA32) {
                Settings.Default.ARCH_IA32 = this._intrinsicsDudeOptionsPageUI.useArch_IA32;
                changed = true;
            }
            if (Settings.Default.ARCH_BMI1 != this._intrinsicsDudeOptionsPageUI.useArch_BMI1)
            {
                Settings.Default.ARCH_BMI1 = this._intrinsicsDudeOptionsPageUI.useArch_BMI1;
                changed = true;
            }
            if (Settings.Default.ARCH_BMI2 != this._intrinsicsDudeOptionsPageUI.useArch_BMI2)
            {
                Settings.Default.ARCH_BMI2 = this._intrinsicsDudeOptionsPageUI.useArch_BMI2;
                changed = true;
            }
            if (Settings.Default.ARCH_FMA != this._intrinsicsDudeOptionsPageUI.useArch_FMA)
            {
                Settings.Default.ARCH_FMA = this._intrinsicsDudeOptionsPageUI.useArch_FMA;
                changed = true;
            }
            if (Settings.Default.ARCH_MPX != this._intrinsicsDudeOptionsPageUI.useArch_MPX)
            {
                Settings.Default.ARCH_MPX = this._intrinsicsDudeOptionsPageUI.useArch_MPX;
                changed = true;
            }
            if (Settings.Default.ARCH_ADX != this._intrinsicsDudeOptionsPageUI.useArch_ADX)
            {
                Settings.Default.ARCH_ADX = this._intrinsicsDudeOptionsPageUI.useArch_ADX;
                changed = true;
            }
            if (Settings.Default.ARCH_FP16C != this._intrinsicsDudeOptionsPageUI.useArch_FP16C)
            {
                Settings.Default.ARCH_FP16C = this._intrinsicsDudeOptionsPageUI.useArch_FP16C;
                changed = true;
            }
            if (Settings.Default.ARCH_PCLMULQDQ != this._intrinsicsDudeOptionsPageUI.useArch_PCLMULQDQ)
            {
                Settings.Default.ARCH_PCLMULQDQ = this._intrinsicsDudeOptionsPageUI.useArch_PCLMULQDQ;
                changed = true;
            }
            if (Settings.Default.ARCH_AES != this._intrinsicsDudeOptionsPageUI.useArch_AES)
            {
                Settings.Default.ARCH_AES = this._intrinsicsDudeOptionsPageUI.useArch_AES;
                changed = true;
            }
            if (Settings.Default.ARCH_CLFLUSHOPT != this._intrinsicsDudeOptionsPageUI.useArch_CLFLUSHOPT)
            {
                Settings.Default.ARCH_CLFLUSHOPT = this._intrinsicsDudeOptionsPageUI.useArch_CLFLUSHOPT;
                changed = true;
            }
            if (Settings.Default.ARCH_FXSR != this._intrinsicsDudeOptionsPageUI.useArch_FXSR)
            {
                Settings.Default.ARCH_FXSR = this._intrinsicsDudeOptionsPageUI.useArch_FXSR;
                changed = true;
            }
            if (Settings.Default.ARCH_KNCNI != this._intrinsicsDudeOptionsPageUI.useArch_KNCNI)
            {
                Settings.Default.ARCH_KNCNI = this._intrinsicsDudeOptionsPageUI.useArch_KNCNI;
                changed = true;
            }


            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.useArch_LZCNT)
            {
                Settings.Default.ARCH_LZCNT = this._intrinsicsDudeOptionsPageUI.useArch_LZCNT;
                changed = true;
            }
            if (Settings.Default.ARCH_INVPCID != this._intrinsicsDudeOptionsPageUI.useArch_INVPCID)
            {
                Settings.Default.ARCH_INVPCID = this._intrinsicsDudeOptionsPageUI.useArch_INVPCID;
                changed = true;
            }
            if (Settings.Default.ARCH_MONITOR != this._intrinsicsDudeOptionsPageUI.useArch_MONITOR)
            {
                Settings.Default.ARCH_MONITOR = this._intrinsicsDudeOptionsPageUI.useArch_MONITOR;
                changed = true;
            }
            if (Settings.Default.ARCH_POPCNT != this._intrinsicsDudeOptionsPageUI.useArch_POPCNT)
            {
                Settings.Default.ARCH_POPCNT = this._intrinsicsDudeOptionsPageUI.useArch_POPCNT;
                changed = true;
            }
            if (Settings.Default.ARCH_RDRAND != this._intrinsicsDudeOptionsPageUI.useArch_RDRAND)
            {
                Settings.Default.ARCH_RDRAND = this._intrinsicsDudeOptionsPageUI.useArch_RDRAND;
                changed = true;
            }
            if (Settings.Default.ARCH_RDSEED != this._intrinsicsDudeOptionsPageUI.useArch_RDSEED)
            {
                Settings.Default.ARCH_RDSEED = this._intrinsicsDudeOptionsPageUI.useArch_RDSEED;
                changed = true;
            }
            if (Settings.Default.ARCH_TSC != this._intrinsicsDudeOptionsPageUI.useArch_TSC)
            {
                Settings.Default.ARCH_TSC = this._intrinsicsDudeOptionsPageUI.useArch_TSC;
                changed = true;
            }
            if (Settings.Default.ARCH_RDTSCP != this._intrinsicsDudeOptionsPageUI.useArch_RDTSCP)
            {
                Settings.Default.ARCH_RDTSCP = this._intrinsicsDudeOptionsPageUI.useArch_RDTSCP;
                changed = true;
            }
            if (Settings.Default.ARCH_FSGSBASE != this._intrinsicsDudeOptionsPageUI.useArch_FSGSBASE)
            {
                Settings.Default.ARCH_FSGSBASE = this._intrinsicsDudeOptionsPageUI.useArch_FSGSBASE;
                changed = true;
            }
            if (Settings.Default.ARCH_SHA != this._intrinsicsDudeOptionsPageUI.useArch_SHA)
            {
                Settings.Default.ARCH_SHA = this._intrinsicsDudeOptionsPageUI.useArch_SHA;
                changed = true;
            }
            if (Settings.Default.ARCH_LZCNT != this._intrinsicsDudeOptionsPageUI.useArch_LZCNT)
            {
                Settings.Default.ARCH_LZCNT = this._intrinsicsDudeOptionsPageUI.useArch_LZCNT;
                changed = true;
            }
            if (Settings.Default.ARCH_RTM != this._intrinsicsDudeOptionsPageUI.useArch_RTM)
            {
                Settings.Default.ARCH_RTM = this._intrinsicsDudeOptionsPageUI.useArch_RTM;
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVE != this._intrinsicsDudeOptionsPageUI.useArch_XSAVE)
            {
                Settings.Default.ARCH_XSAVE = this._intrinsicsDudeOptionsPageUI.useArch_XSAVE;
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEC != this._intrinsicsDudeOptionsPageUI.useArch_XSAVEC)
            {
                Settings.Default.ARCH_XSAVEC = this._intrinsicsDudeOptionsPageUI.useArch_XSAVEC;
                changed = true;
            }
            if (Settings.Default.ARCH_XSS != this._intrinsicsDudeOptionsPageUI.useArch_XSS)
            {
                Settings.Default.ARCH_XSS = this._intrinsicsDudeOptionsPageUI.useArch_XSS;
                changed = true;
            }
            if (Settings.Default.ARCH_XSAVEOPT != this._intrinsicsDudeOptionsPageUI.useArch_XSAVEOPT)
            {
                Settings.Default.ARCH_XSAVEOPT = this._intrinsicsDudeOptionsPageUI.useArch_XSAVEOPT;
                changed = true;
            }
            if (Settings.Default.ARCH_PREFETCHWT1 != this._intrinsicsDudeOptionsPageUI.useArch_PREFETCHWT1)
            {
                Settings.Default.ARCH_PREFETCHWT1 = this._intrinsicsDudeOptionsPageUI.useArch_PREFETCHWT1;
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
                int result = VsShellUtilities.ShowMessageBox(Site, message, title, OLEMSGICON.OLEMSGICON_QUERY, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
        }

        #endregion Event Handlers
    }
}
