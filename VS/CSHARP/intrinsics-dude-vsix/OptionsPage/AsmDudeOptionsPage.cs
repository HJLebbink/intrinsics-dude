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
using AsmTools;
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
    [Guid(Guids.GuidOptionsPageAsmDude)]
    public class AsmDudeOptionsPage : UIElementDialogPage
    {
        private const bool logInfo = true;

        private AsmDudeOptionsPageUI _asmDudeOptionsPageUI;

        public AsmDudeOptionsPage()
        {
            this._asmDudeOptionsPageUI = new AsmDudeOptionsPageUI();
        }

        protected override System.Windows.UIElement Child {
            get { return this._asmDudeOptionsPageUI; }
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

            #region AsmDoc
            this._asmDudeOptionsPageUI.useAsmDoc = Settings.Default.AsmDoc_On;
            this._asmDudeOptionsPageUI.asmDocUrl = Settings.Default.AsmDoc_url;
            #endregion

            #region Syntax Highlighting
            this._asmDudeOptionsPageUI.useSyntaxHighlighting = Settings.Default.SyntaxHighlighting_On;
            this._asmDudeOptionsPageUI.colorMnemonic = Settings.Default.SyntaxHighlighting_Opcode;
            this._asmDudeOptionsPageUI.colorRegister = Settings.Default.SyntaxHighlighting_Register;
            this._asmDudeOptionsPageUI.colorMisc = Settings.Default.SyntaxHighlighting_Misc;
            #endregion

            #region Code Completion
            this._asmDudeOptionsPageUI.useCodeCompletion = Settings.Default.CodeCompletion_On;
            this._asmDudeOptionsPageUI.useSignatureHelp = Settings.Default.SignatureHelp_On;
            this._asmDudeOptionsPageUI.useSvml = Settings.Default.USE_SVML;

            this._asmDudeOptionsPageUI.useArch_ADX = Settings.Default.ARCH_ADX;
            this._asmDudeOptionsPageUI.useArch_ADX_UI.ToolTip = this.makeToolTip(CpuID.ADX);
            this._asmDudeOptionsPageUI.useArch_AES = Settings.Default.ARCH_AES;
            this._asmDudeOptionsPageUI.useArch_AES_UI.ToolTip = this.makeToolTip(CpuID.AES);
            this._asmDudeOptionsPageUI.useArch_AVX = Settings.Default.ARCH_AVX;
            this._asmDudeOptionsPageUI.useArch_AVX_UI.ToolTip = this.makeToolTip(CpuID.AVX);
            this._asmDudeOptionsPageUI.useArch_AVX2 = Settings.Default.ARCH_AVX2;
            this._asmDudeOptionsPageUI.useArch_AVX2_UI.ToolTip = this.makeToolTip(CpuID.AVX2);
            this._asmDudeOptionsPageUI.useArch_AVX512F = Settings.Default.ARCH_AVX512F;
            this._asmDudeOptionsPageUI.useArch_AVX512F_UI.ToolTip = this.makeToolTip(CpuID.AVX512F);
            this._asmDudeOptionsPageUI.useArch_AVX512VL = Settings.Default.ARCH_AVX512VL;
            this._asmDudeOptionsPageUI.useArch_AVX512VL_UI.ToolTip = this.makeToolTip(CpuID.AVX512VL);
            this._asmDudeOptionsPageUI.useArch_AVX512DQ = Settings.Default.ARCH_AVX512DQ;
            this._asmDudeOptionsPageUI.useArch_AVX512DQ_UI.ToolTip = this.makeToolTip(CpuID.AVX512DQ);
            this._asmDudeOptionsPageUI.useArch_AVX512BW = Settings.Default.ARCH_AVX512BW;
            this._asmDudeOptionsPageUI.useArch_AVX512BW_UI.ToolTip = this.makeToolTip(CpuID.AVX512BW);
            this._asmDudeOptionsPageUI.useArch_AVX512ER = Settings.Default.ARCH_AVX512ER;
            this._asmDudeOptionsPageUI.useArch_AVX512ER_UI.ToolTip = this.makeToolTip(CpuID.AVX512ER);
            this._asmDudeOptionsPageUI.useArch_AVX512CD = Settings.Default.ARCH_AVX512CD;
            this._asmDudeOptionsPageUI.useArch_AVX512CD_UI.ToolTip = this.makeToolTip(CpuID.AVX512CD);
            this._asmDudeOptionsPageUI.useArch_BMI1 = Settings.Default.ARCH_BMI1;
            this._asmDudeOptionsPageUI.useArch_BMI1_UI.ToolTip = this.makeToolTip(CpuID.BMI1);
            this._asmDudeOptionsPageUI.useArch_BMI2 = Settings.Default.ARCH_BMI2;
            this._asmDudeOptionsPageUI.useArch_BMI2_UI.ToolTip = this.makeToolTip(CpuID.BMI2);
            this._asmDudeOptionsPageUI.useArch_CLFLUSHOPT = Settings.Default.ARCH_CLFLUSHOPT;
            this._asmDudeOptionsPageUI.useArch_CLFLUSHOPT_UI.ToolTip = this.makeToolTip(CpuID.CLFLUSHOPT);
            this._asmDudeOptionsPageUI.useArch_FMA = Settings.Default.ARCH_FMA;
            this._asmDudeOptionsPageUI.useArch_FMA_UI.ToolTip = this.makeToolTip(CpuID.FMA);
            this._asmDudeOptionsPageUI.useArch_FP16C = Settings.Default.ARCH_FP16C;
            this._asmDudeOptionsPageUI.useArch_FP16C_UI.ToolTip = this.makeToolTip(CpuID.FP16C);
            this._asmDudeOptionsPageUI.useArch_FXSR = Settings.Default.ARCH_FXSR;
            this._asmDudeOptionsPageUI.useArch_FXSR_UI.ToolTip = this.makeToolTip(CpuID.FXSR);
            this._asmDudeOptionsPageUI.useArch_KNCNI = Settings.Default.ARCH_KNCNI;
            this._asmDudeOptionsPageUI.useArch_KNCNI_UI.ToolTip = this.makeToolTip(CpuID.KNCNI);
            this._asmDudeOptionsPageUI.useArch_MMX = Settings.Default.ARCH_MMX;
            this._asmDudeOptionsPageUI.useArch_MMX_UI.ToolTip = this.makeToolTip(CpuID.MMX);
            this._asmDudeOptionsPageUI.useArch_MPX = Settings.Default.ARCH_MPX;
            this._asmDudeOptionsPageUI.useArch_MPX_UI.ToolTip = this.makeToolTip(CpuID.MPX);
            this._asmDudeOptionsPageUI.useArch_PCLMULQDQ = Settings.Default.ARCH_PCLMULQDQ;
            this._asmDudeOptionsPageUI.useArch_PCLMULQDQ_UI.ToolTip = this.makeToolTip(CpuID.PCLMULQDQ);
            this._asmDudeOptionsPageUI.useArch_SSE = Settings.Default.ARCH_SSE;
            this._asmDudeOptionsPageUI.useArch_SSE_UI.ToolTip = this.makeToolTip(CpuID.SSE);
            this._asmDudeOptionsPageUI.useArch_SSE2 = Settings.Default.ARCH_SSE2;
            this._asmDudeOptionsPageUI.useArch_SSE2_UI.ToolTip = this.makeToolTip(CpuID.SSE2);
            this._asmDudeOptionsPageUI.useArch_SSE3 = Settings.Default.ARCH_SSE3;
            this._asmDudeOptionsPageUI.useArch_SSE3_UI.ToolTip = this.makeToolTip(CpuID.SSE3);
            this._asmDudeOptionsPageUI.useArch_SSSE3 = Settings.Default.ARCH_SSSE3;
            this._asmDudeOptionsPageUI.useArch_SSSE3_UI.ToolTip = this.makeToolTip(CpuID.SSSE3);
            this._asmDudeOptionsPageUI.useArch_SSE41 = Settings.Default.ARCH_SSE41;
            this._asmDudeOptionsPageUI.useArch_SSE41_UI.ToolTip = this.makeToolTip(CpuID.SSE4_1);
            this._asmDudeOptionsPageUI.useArch_SSE42 = Settings.Default.ARCH_SSE42;
            this._asmDudeOptionsPageUI.useArch_SSE42_UI.ToolTip = this.makeToolTip(CpuID.SSE4_2);
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
            return AsmSourceTools.linewrap(sb.ToString(), IntrinsicsDudePackage.maxNumberOfCharsInToolTips);
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

            #region AsmDoc
            if (Settings.Default.AsmDoc_On != this._asmDudeOptionsPageUI.useAsmDoc)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useAsmDoc=" + this._asmDudeOptionsPageUI.useAsmDoc);
                changed = true;
            }
            if (Settings.Default.AsmDoc_url != this._asmDudeOptionsPageUI.asmDocUrl)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: asmDocUrl=" + this._asmDudeOptionsPageUI.asmDocUrl);
                changed = true;
            }
            #endregion

            #region Syntax Highlighting
            if (Settings.Default.SyntaxHighlighting_On != this._asmDudeOptionsPageUI.useSyntaxHighlighting)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useSyntaxHighlighting=" + this._asmDudeOptionsPageUI.useSyntaxHighlighting);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Opcode.ToArgb() != this._asmDudeOptionsPageUI.colorMnemonic.ToArgb())
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: stored=" + Settings.Default.SyntaxHighlighting_Opcode + "; new colorMnemonic=" + this._asmDudeOptionsPageUI.colorMnemonic);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Register.ToArgb() != this._asmDudeOptionsPageUI.colorRegister.ToArgb())
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: colorRegister=" + this._asmDudeOptionsPageUI.colorRegister);
                changed = true;
            }
            if (Settings.Default.SyntaxHighlighting_Misc.ToArgb() != this._asmDudeOptionsPageUI.colorMisc.ToArgb())
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: colorMisc=" + this._asmDudeOptionsPageUI.colorMisc);
                changed = true;
            }
            #endregion

            #region Code Completion
            if (Settings.Default.CodeCompletion_On != this._asmDudeOptionsPageUI.useCodeCompletion)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useCodeCompletion=" + this._asmDudeOptionsPageUI.useCodeCompletion);
                changed = true;
            }
            if (Settings.Default.SignatureHelp_On != this._asmDudeOptionsPageUI.useSignatureHelp)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useSignatureHelp=" + this._asmDudeOptionsPageUI.useSignatureHelp);
                changed = true;
            }
            if (Settings.Default.USE_SVML != this._asmDudeOptionsPageUI.useSvml)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useSvml=" + this._asmDudeOptionsPageUI.useSvml);
                changed = true;
            }
            if (Settings.Default.ARCH_MMX != this._asmDudeOptionsPageUI.useArch_MMX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_MMX=" + this._asmDudeOptionsPageUI.useArch_MMX);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE != this._asmDudeOptionsPageUI.useArch_SSE)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_SSE=" + this._asmDudeOptionsPageUI.useArch_SSE);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE2 != this._asmDudeOptionsPageUI.useArch_SSE2)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_SSE2=" + this._asmDudeOptionsPageUI.useArch_SSE2);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE3 != this._asmDudeOptionsPageUI.useArch_SSE3)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_SSE3=" + this._asmDudeOptionsPageUI.useArch_SSE3);
                changed = true;
            }
            if (Settings.Default.ARCH_SSSE3 != this._asmDudeOptionsPageUI.useArch_SSSE3)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_SSSE3=" + this._asmDudeOptionsPageUI.useArch_SSSE3);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE41 != this._asmDudeOptionsPageUI.useArch_SSE41)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_SSE41=" + this._asmDudeOptionsPageUI.useArch_SSE41);
                changed = true;
            }
            if (Settings.Default.ARCH_SSE42 != this._asmDudeOptionsPageUI.useArch_SSE42)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_SSE42=" + this._asmDudeOptionsPageUI.useArch_SSE42);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX != this._asmDudeOptionsPageUI.useArch_AVX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX=" + this._asmDudeOptionsPageUI.useArch_AVX);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX2 != this._asmDudeOptionsPageUI.useArch_AVX2)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX2=" + this._asmDudeOptionsPageUI.useArch_AVX2);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512VL != this._asmDudeOptionsPageUI.useArch_AVX512VL)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512VL=" + this._asmDudeOptionsPageUI.useArch_AVX512VL);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512DQ != this._asmDudeOptionsPageUI.useArch_AVX512DQ)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512DQ=" + this._asmDudeOptionsPageUI.useArch_AVX512DQ);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512BW != this._asmDudeOptionsPageUI.useArch_AVX512BW)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512BW=" + this._asmDudeOptionsPageUI.useArch_AVX512BW);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512ER != this._asmDudeOptionsPageUI.useArch_AVX512ER)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512ER=" + this._asmDudeOptionsPageUI.useArch_AVX512ER);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512F != this._asmDudeOptionsPageUI.useArch_AVX512F)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512PF=" + this._asmDudeOptionsPageUI.useArch_AVX512F);
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512CD != this._asmDudeOptionsPageUI.useArch_AVX512CD)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AVX512CD=" + this._asmDudeOptionsPageUI.useArch_AVX512CD);
                changed = true;
            }
            if (Settings.Default.ARCH_BMI1 != this._asmDudeOptionsPageUI.useArch_BMI1)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_BMI1=" + this._asmDudeOptionsPageUI.useArch_BMI1);
                changed = true;
            }
            if (Settings.Default.ARCH_BMI2 != this._asmDudeOptionsPageUI.useArch_BMI2)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_BMI2=" + this._asmDudeOptionsPageUI.useArch_BMI2);
                changed = true;
            }
            if (Settings.Default.ARCH_FMA != this._asmDudeOptionsPageUI.useArch_FMA)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_FMA=" + this._asmDudeOptionsPageUI.useArch_FMA);
                changed = true;
            }
            if (Settings.Default.ARCH_MPX != this._asmDudeOptionsPageUI.useArch_MPX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_MPX=" + this._asmDudeOptionsPageUI.useArch_MPX);
                changed = true;
            }
            if (Settings.Default.ARCH_ADX != this._asmDudeOptionsPageUI.useArch_ADX)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_ADX=" + this._asmDudeOptionsPageUI.useArch_ADX);
                changed = true;
            }
            if (Settings.Default.ARCH_FP16C != this._asmDudeOptionsPageUI.useArch_FP16C)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_F16C=" + this._asmDudeOptionsPageUI.useArch_FP16C);
                changed = true;
            }
            if (Settings.Default.ARCH_PCLMULQDQ != this._asmDudeOptionsPageUI.useArch_PCLMULQDQ)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_PCLMULQDQ=" + this._asmDudeOptionsPageUI.useArch_PCLMULQDQ);
                changed = true;
            }
            if (Settings.Default.ARCH_AES != this._asmDudeOptionsPageUI.useArch_AES)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_AES=" + this._asmDudeOptionsPageUI.useArch_AES);
                changed = true;
            }
            if (Settings.Default.ARCH_CLFLUSHOPT != this._asmDudeOptionsPageUI.useArch_CLFLUSHOPT)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_CLFLUSHOPT=" + this._asmDudeOptionsPageUI.useArch_CLFLUSHOPT);
                changed = true;
            }
            if (Settings.Default.ARCH_FXSR != this._asmDudeOptionsPageUI.useArch_FXSR)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_FXSR=" + this._asmDudeOptionsPageUI.useArch_FXSR);
                changed = true;
            }
            if (Settings.Default.ARCH_KNCNI != this._asmDudeOptionsPageUI.useArch_KNCNI)
            {
                if (logInfo) IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeOptionsPage: OnDeactivate: change detected: useArch_KNCNI=" + this._asmDudeOptionsPageUI.useArch_KNCNI);
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
            #region AsmDoc
            if (Settings.Default.AsmDoc_On != this._asmDudeOptionsPageUI.useAsmDoc)
            {
                Settings.Default.AsmDoc_On = this._asmDudeOptionsPageUI.useAsmDoc;
                changed = true;
            }
            if (Settings.Default.AsmDoc_url != this._asmDudeOptionsPageUI.asmDocUrl)
            {
                Settings.Default.AsmDoc_url = this._asmDudeOptionsPageUI.asmDocUrl;
                changed = true;
                restartNeeded = true;
            }
            #endregion

            #region Syntax Highlighting
            if (Settings.Default.SyntaxHighlighting_On != this._asmDudeOptionsPageUI.useSyntaxHighlighting)
            {
                Settings.Default.SyntaxHighlighting_On = this._asmDudeOptionsPageUI.useSyntaxHighlighting;
                changed = true;
                restartNeeded = true;
            }
            if (Settings.Default.SyntaxHighlighting_Opcode.ToArgb() != this._asmDudeOptionsPageUI.colorMnemonic.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Opcode = this._asmDudeOptionsPageUI.colorMnemonic;
                changed = true;
                restartNeeded = true;
            }
            if (Settings.Default.SyntaxHighlighting_Register.ToArgb() != this._asmDudeOptionsPageUI.colorRegister.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Register = this._asmDudeOptionsPageUI.colorRegister;
                changed = true;
                restartNeeded = true;
            }
            if (Settings.Default.SyntaxHighlighting_Misc.ToArgb() != this._asmDudeOptionsPageUI.colorMisc.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Misc = this._asmDudeOptionsPageUI.colorMisc;
                changed = true;
                restartNeeded = true;
            }
            #endregion

            #region Code Completion
            if (Settings.Default.CodeCompletion_On != this._asmDudeOptionsPageUI.useCodeCompletion)
            {
                Settings.Default.CodeCompletion_On = this._asmDudeOptionsPageUI.useCodeCompletion;
                changed = true;
            }
            if (Settings.Default.SignatureHelp_On != this._asmDudeOptionsPageUI.useSignatureHelp)
            {
                Settings.Default.SignatureHelp_On = this._asmDudeOptionsPageUI.useSignatureHelp;
                changed = true;
            }
            if (Settings.Default.USE_SVML != this._asmDudeOptionsPageUI.useSvml)
            {
                Settings.Default.USE_SVML = this._asmDudeOptionsPageUI.useSvml;
                changed = true;
            }
            if (Settings.Default.ARCH_MMX != this._asmDudeOptionsPageUI.useArch_MMX)
            {
                Settings.Default.ARCH_MMX = this._asmDudeOptionsPageUI.useArch_MMX;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE != this._asmDudeOptionsPageUI.useArch_SSE)
            {
                Settings.Default.ARCH_SSE = this._asmDudeOptionsPageUI.useArch_SSE;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE2 != this._asmDudeOptionsPageUI.useArch_SSE2)
            {
                Settings.Default.ARCH_SSE2 = this._asmDudeOptionsPageUI.useArch_SSE2;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE3 != this._asmDudeOptionsPageUI.useArch_SSE3)
            {
                Settings.Default.ARCH_SSE3 = this._asmDudeOptionsPageUI.useArch_SSE3;
                changed = true;
            }
            if (Settings.Default.ARCH_SSSE3 != this._asmDudeOptionsPageUI.useArch_SSSE3)
            {
                Settings.Default.ARCH_SSSE3 = this._asmDudeOptionsPageUI.useArch_SSSE3;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE41 != this._asmDudeOptionsPageUI.useArch_SSE41)
            {
                Settings.Default.ARCH_SSE41 = this._asmDudeOptionsPageUI.useArch_SSE41;
                changed = true;
            }
            if (Settings.Default.ARCH_SSE42 != this._asmDudeOptionsPageUI.useArch_SSE42)
            {
                Settings.Default.ARCH_SSE42 = this._asmDudeOptionsPageUI.useArch_SSE42;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX != this._asmDudeOptionsPageUI.useArch_AVX)
            {
                Settings.Default.ARCH_AVX = this._asmDudeOptionsPageUI.useArch_AVX;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX2 != this._asmDudeOptionsPageUI.useArch_AVX2)
            {
                Settings.Default.ARCH_AVX2 = this._asmDudeOptionsPageUI.useArch_AVX2;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512VL != this._asmDudeOptionsPageUI.useArch_AVX512VL)
            {
                Settings.Default.ARCH_AVX512VL = this._asmDudeOptionsPageUI.useArch_AVX512VL;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512DQ != this._asmDudeOptionsPageUI.useArch_AVX512DQ)
            {
                Settings.Default.ARCH_AVX512DQ = this._asmDudeOptionsPageUI.useArch_AVX512DQ;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512BW != this._asmDudeOptionsPageUI.useArch_AVX512BW)
            {
                Settings.Default.ARCH_AVX512BW = this._asmDudeOptionsPageUI.useArch_AVX512BW;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512ER != this._asmDudeOptionsPageUI.useArch_AVX512ER)
            {
                Settings.Default.ARCH_AVX512ER = this._asmDudeOptionsPageUI.useArch_AVX512ER;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512F != this._asmDudeOptionsPageUI.useArch_AVX512F)
            {
                Settings.Default.ARCH_AVX512F = this._asmDudeOptionsPageUI.useArch_AVX512F;
                changed = true;
            }
            if (Settings.Default.ARCH_AVX512CD != this._asmDudeOptionsPageUI.useArch_AVX512CD)
            {
                Settings.Default.ARCH_AVX512CD = this._asmDudeOptionsPageUI.useArch_AVX512CD;
                changed = true;
            }
            if (Settings.Default.ARCH_BMI1 != this._asmDudeOptionsPageUI.useArch_BMI1)
            {
                Settings.Default.ARCH_BMI1 = this._asmDudeOptionsPageUI.useArch_BMI1;
                changed = true;
            }
            if (Settings.Default.ARCH_BMI2 != this._asmDudeOptionsPageUI.useArch_BMI2)
            {
                Settings.Default.ARCH_BMI2 = this._asmDudeOptionsPageUI.useArch_BMI2;
                changed = true;
            }
            if (Settings.Default.ARCH_FMA != this._asmDudeOptionsPageUI.useArch_FMA)
            {
                Settings.Default.ARCH_FMA = this._asmDudeOptionsPageUI.useArch_FMA;
                changed = true;
            }
            if (Settings.Default.ARCH_MPX != this._asmDudeOptionsPageUI.useArch_MPX)
            {
                Settings.Default.ARCH_MPX = this._asmDudeOptionsPageUI.useArch_MPX;
                changed = true;
            }
            if (Settings.Default.ARCH_ADX != this._asmDudeOptionsPageUI.useArch_ADX)
            {
                Settings.Default.ARCH_ADX = this._asmDudeOptionsPageUI.useArch_ADX;
                changed = true;
            }
            if (Settings.Default.ARCH_FP16C != this._asmDudeOptionsPageUI.useArch_FP16C)
            {
                Settings.Default.ARCH_FP16C = this._asmDudeOptionsPageUI.useArch_FP16C;
                changed = true;
            }
            if (Settings.Default.ARCH_PCLMULQDQ != this._asmDudeOptionsPageUI.useArch_PCLMULQDQ)
            {
                Settings.Default.ARCH_PCLMULQDQ = this._asmDudeOptionsPageUI.useArch_PCLMULQDQ;
                changed = true;
            }
            if (Settings.Default.ARCH_AES != this._asmDudeOptionsPageUI.useArch_AES)
            {
                Settings.Default.ARCH_AES = this._asmDudeOptionsPageUI.useArch_AES;
                changed = true;
            }
            if (Settings.Default.ARCH_CLFLUSHOPT != this._asmDudeOptionsPageUI.useArch_CLFLUSHOPT)
            {
                Settings.Default.ARCH_CLFLUSHOPT = this._asmDudeOptionsPageUI.useArch_CLFLUSHOPT;
                changed = true;
            }
            if (Settings.Default.ARCH_FXSR != this._asmDudeOptionsPageUI.useArch_FXSR)
            {
                Settings.Default.ARCH_FXSR = this._asmDudeOptionsPageUI.useArch_FXSR;
                changed = true;
            }
            if (Settings.Default.ARCH_KNCNI != this._asmDudeOptionsPageUI.useArch_KNCNI)
            {
                Settings.Default.ARCH_KNCNI = this._asmDudeOptionsPageUI.useArch_KNCNI;
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
