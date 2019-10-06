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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio.Shell;
    using static IntrinsicsDude.Tools.IntrinsicTools;

    public enum PropertyEnum // NOTE: the enum elements should be precisely equal to the keys in Settings
    {
        ARCH_ADX,
        ARCH_AES,
        ARCH_AVX,
        ARCH_AVX2,
        ARCH_AVX512_4FMAPS,
        ARCH_AVX512_4VNNIW,
        ARCH_AVX512_BW,
        ARCH_AVX512_CD,
        ARCH_AVX512_DQ,
        ARCH_AVX512_ER,
        ARCH_AVX512_F,
        ARCH_AVX512_IFMA52,
        ARCH_AVX512_PF,
        ARCH_AVX512_VBMI,
        ARCH_AVX512_VL,
        ARCH_AVX512_VPOPCNTDQ,
        ARCH_BMI1,
        ARCH_BMI2,
        ARCH_CLFLUSHOPT,
        ARCH_CLWB,
        ARCH_FMA,
        ARCH_FP16C,
        ARCH_FSGSBASE,
        ARCH_FXSR,
        ARCH_IA32,
        ARCH_INVPCID,
        ARCH_KNCNI,
        ARCH_LZCNT,
        ARCH_MMX,
        ARCH_MONITOR,
        ARCH_MPX,
        ARCH_PCLMULQDQ,
        ARCH_POPCNT,
        ARCH_PREFETCHWT1,
        ARCH_RDPID,
        ARCH_RDRAND,
        ARCH_RDSEED,
        ARCH_RDTSCP,
        ARCH_RTM,
        ARCH_SHA,
        ARCH_SSE,
        ARCH_SSE2,
        ARCH_SSE3,
        ARCH_SSE41,
        ARCH_SSE42,
        ARCH_SSSE3,
        ARCH_TSC,
        ARCH_XSAVE,
        ARCH_XSAVEC,
        ARCH_XSAVEOPT,
        ARCH_XSS,

        DecorateIncompatibleStatementCompletions_On,
        HideStatementCompletionIncompatibleReturnType_On,
        HideStatementCompletionMmxRegisters_On,
        SignatureHelp_On,
        StatementCompletion_On,

        SyntaxHighlighting_Intrinsic,
        SyntaxHighlighting_Misc,
        SyntaxHighlighting_On,
        SyntaxHighlighting_Register,

        ARCH_SVML,
    }

    [Guid(Guids.GuidOptionsPageIntrinsicsDude)]
    public class IntrinsicsDudeOptionsPage : UIElementDialogPage
    {
        private readonly IntrinsicsDudeOptionsPageUI _intrinsicsDudeOptionsPageUI;

        public IntrinsicsDudeOptionsPage()
        {
            this._intrinsicsDudeOptionsPageUI = new IntrinsicsDudeOptionsPageUI();
        }

        protected override System.Windows.UIElement Child
        {
            get { return this._intrinsicsDudeOptionsPageUI; }
        }

        #region Private Methods

        private bool Setting_Changed(string key, StringBuilder sb)
        {
            try
            {
                object persisted_value = Settings.Default[key];
                object gui_value = this._intrinsicsDudeOptionsPageUI.GetPropValue(key);
                if (gui_value.Equals(persisted_value))
                {
                    return false;
                }
                sb.AppendLine(key + ": old = " + persisted_value + "; new = " + gui_value);
                return true;
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:Setting_Changed; exception {1}", this.ToString(), e));
                return false;
            }
        }

        private bool Setting_Changed(PropertyEnum key, StringBuilder sb)
        {
            return this.Setting_Changed(key.ToString(), sb);
        }

        private bool Setting_Changed(CpuID key, StringBuilder sb)
        {
            return (key == CpuID.ARCH_UNKNOWN) ? false : this.Setting_Changed(key.ToString(), sb);
        }

        private bool Setting_Changed_RGB(PropertyEnum key, StringBuilder sb)
        {
            string k = key.ToString();
            Color persisted_value = (Color)Settings.Default[k];
            Color gui_value = (Color)this._intrinsicsDudeOptionsPageUI.GetPropValue(k);

            if (gui_value.ToArgb() != persisted_value.ToArgb())
            {
                sb.AppendLine(k + " old " + persisted_value.Name + "; new " + gui_value.Name);
                return true;
            }
            return false;
        }

        private bool Setting_Update(string key)
        {
            object persisted_value = Settings.Default[key];
            object gui_value = this._intrinsicsDudeOptionsPageUI.GetPropValue(key);
            if (gui_value.Equals(persisted_value))
            {
                return false;
            }
            Settings.Default[key] = gui_value;
            return true;
        }

        private bool Setting_Update(PropertyEnum key)
        {
            return this.Setting_Update(key.ToString());
        }

        private bool Setting_Update(CpuID key)
        {
            return ((key == CpuID.ARCH_UNKNOWN) || (key == CpuID.ARCH_NONE)) ? false : this.Setting_Update(key.ToString());
        }

        private bool Setting_Update_RGB(PropertyEnum key)
        {
            string k = key.ToString();
            Color persisted_value = (Color)Settings.Default[k];
            Color gui_value = (Color)this._intrinsicsDudeOptionsPageUI.GetPropValue(k);

            if (gui_value.ToArgb() != persisted_value.ToArgb())
            {
                Settings.Default[k] = this._intrinsicsDudeOptionsPageUI.GetPropValue(k);
                return true;
            }
            return false;
        }

        private void Set_GUI(PropertyEnum key)
        {
            string k = key.ToString();
            this._intrinsicsDudeOptionsPageUI.SetPropValue(k, Settings.Default[k]);
        }

        private void Set_GUI_ARCH(CpuID arch)
        {
            /*
            string MakeToolTip()
            {
                MnemonicStore store = AsmDudeTools.Instance.Mnemonic_Store;
                SortedSet<Mnemonic> usedMnemonics = new SortedSet<Mnemonic>();

                foreach (Mnemonic mnemonic in Enum.GetValues(typeof(Mnemonic)).Cast<Mnemonic>())
                {
                    if (store.GetArch(mnemonic).Contains(arch))
                    {
                        usedMnemonics.Add(mnemonic);
                    }
                }
                StringBuilder sb = new StringBuilder();
                string docArch = ArchTools.ArchDocumentation(arch);
                if (docArch.Length > 0)
                {
                    sb.Append(docArch + ":\n");
                }
                if (usedMnemonics.Count > 0)
                {
                    foreach (Mnemonic mnemonic in usedMnemonics)
                    {
                        sb.Append(mnemonic.ToString());
                        sb.Append(", ");
                    }
                    sb.Length -= 2; // get rid of last comma.
                }
                else
                {
                    sb.Append("empty");
                }
                return AsmSourceTools.Linewrap(sb.ToString(), AsmDudePackage.MaxNumberOfCharsInToolTips);
            }
            void SetToolTip(string tooltip)
            {
                switch (arch)
                {
                    case CpuID.UNKNOWN: break;
                    case CpuID.ARCH_8086: this._intrinsicsDudeOptionsPageUI.USE_ARCH_8086_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_186: this._asmDudeOptionsPageUI.ARCH_186_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_286: this._asmDudeOptionsPageUI.ARCH_286_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_386: this._asmDudeOptionsPageUI.ARCH_386_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_486: this._asmDudeOptionsPageUI.ARCH_486_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_PENT: this._asmDudeOptionsPageUI.ARCH_PENT_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_P6: this._asmDudeOptionsPageUI.ARCH_P6_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_MMX: this._asmDudeOptionsPageUI.ARCH_MMX_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSE: this._asmDudeOptionsPageUI.ARCH_SSE_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSE2: this._asmDudeOptionsPageUI.ARCH_SSE2_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSE3: this._asmDudeOptionsPageUI.ARCH_SSE3_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSSE3: this._asmDudeOptionsPageUI.ARCH_SSSE3_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSE4_1: this._asmDudeOptionsPageUI.ARCH_SSE4_1_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSE4_2: this._asmDudeOptionsPageUI.ARCH_SSE4_2_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSE4A: this._asmDudeOptionsPageUI.ARCH_SSE4A_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SSE5: this._asmDudeOptionsPageUI.ARCH_SSE5_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX: this._asmDudeOptionsPageUI.ARCH_AVX_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX2: this._asmDudeOptionsPageUI.ARCH_AVX2_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_F: this._asmDudeOptionsPageUI.ARCH_AVX512_F_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_CD: this._asmDudeOptionsPageUI.ARCH_AVX512_CD_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_ER: this._asmDudeOptionsPageUI.ARCH_AVX512_ER_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_PF: this._asmDudeOptionsPageUI.ARCH_AVX512_PF_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_BW: this._asmDudeOptionsPageUI.ARCH_AVX512_BW_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_DQ: this._asmDudeOptionsPageUI.ARCH_AVX512_DQ_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VL: this._asmDudeOptionsPageUI.ARCH_AVX512_VL_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_IFMA: this._asmDudeOptionsPageUI.ARCH_AVX512_IFMA_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VBMI: this._asmDudeOptionsPageUI.ARCH_AVX512_VBMI_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VPOPCNTDQ: this._asmDudeOptionsPageUI.ARCH_AVX512_VPOPCNTDQ_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_4VNNIW: this._asmDudeOptionsPageUI.ARCH_AVX512_4VNNIW_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_4FMAPS: this._asmDudeOptionsPageUI.ARCH_AVX512_4FMAPS_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VBMI2: this._asmDudeOptionsPageUI.ARCH_AVX512_VBMI2_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VNNI: this._asmDudeOptionsPageUI.ARCH_AVX512_VNNI_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_BITALG: this._asmDudeOptionsPageUI.ARCH_AVX512_BITALG_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_GFNI: this._asmDudeOptionsPageUI.ARCH_AVX512_GFNI_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VAES: this._asmDudeOptionsPageUI.ARCH_AVX512_VAES_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VPCLMULQDQ: this._asmDudeOptionsPageUI.ARCH_AVX512_VPCLMULQDQ_UI.ToolTip = tooltip; break;

                    case Arch.ARCH_AVX512_BF16: this._asmDudeOptionsPageUI.ARCH_AVX512_BF16_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AVX512_VP2INTERSECT: this._asmDudeOptionsPageUI.ARCH_AVX512_VP2INTERSECT_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_ENQCMD: this._asmDudeOptionsPageUI.ARCH_ENQCMD_UI.ToolTip = tooltip; break;

                    case Arch.ARCH_ADX: this._asmDudeOptionsPageUI.ARCH_ADX_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AES: this._asmDudeOptionsPageUI.ARCH_AES_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_VMX: this._asmDudeOptionsPageUI.ARCH_VMX_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_BMI1: this._asmDudeOptionsPageUI.ARCH_BMI1_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_BMI2: this._asmDudeOptionsPageUI.ARCH_BMI2_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_F16C: this._asmDudeOptionsPageUI.ARCH_F16C_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_FMA: this._asmDudeOptionsPageUI.ARCH_FMA_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_FSGSBASE: this._asmDudeOptionsPageUI.ARCH_FSGSBASE_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_HLE: this._asmDudeOptionsPageUI.ARCH_HLE_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_INVPCID: this._asmDudeOptionsPageUI.ARCH_INVPCID_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SHA: this._asmDudeOptionsPageUI.ARCH_SHA_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_RTM: this._asmDudeOptionsPageUI.ARCH_RTM_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_MPX: this._asmDudeOptionsPageUI.ARCH_MPX_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_PCLMULQDQ: this._asmDudeOptionsPageUI.ARCH_PCLMULQDQ_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_LZCNT: this._asmDudeOptionsPageUI.ARCH_LZCNT_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_PREFETCHWT1: this._asmDudeOptionsPageUI.ARCH_PREFETCHWT1_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_PRFCHW: this._asmDudeOptionsPageUI.ARCH_PRFCHW_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_RDPID: this._asmDudeOptionsPageUI.ARCH_RDPID_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_RDRAND: this._asmDudeOptionsPageUI.ARCH_RDRAND_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_RDSEED: this._asmDudeOptionsPageUI.ARCH_RDSEED_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_XSAVEOPT: this._asmDudeOptionsPageUI.ARCH_XSAVEOPT_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SGX1: this._asmDudeOptionsPageUI.ARCH_SGX1_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SGX2: this._asmDudeOptionsPageUI.ARCH_SGX2_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_SMX: this._asmDudeOptionsPageUI.ARCH_SMX_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_CLDEMOTE: this._asmDudeOptionsPageUI.ARCH_CLDEMOTE_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_MOVDIR64B: this._asmDudeOptionsPageUI.ARCH_MOVDIR64B_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_MOVDIRI: this._asmDudeOptionsPageUI.ARCH_MOVDIRI_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_PCONFIG: this._asmDudeOptionsPageUI.ARCH_PCONFIG_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_WAITPKG: this._asmDudeOptionsPageUI.ARCH_WAITPKG_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_X64: this._asmDudeOptionsPageUI.ARCH_X64_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_IA64: this._asmDudeOptionsPageUI.ARCH_IA64_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_UNDOC: this._asmDudeOptionsPageUI.ARCH_UNDOC_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_AMD: this._asmDudeOptionsPageUI.ARCH_AMD_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_TBM: this._asmDudeOptionsPageUI.ARCH_TBM_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_3DNOW: this._asmDudeOptionsPageUI.ARCH_3DNOW_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_CYRIX: this._asmDudeOptionsPageUI.ARCH_CYRIX_UI.ToolTip = tooltip; break;
                    case Arch.ARCH_CYRIXM: this._asmDudeOptionsPageUI.ARCH_CYRIXM_UI.ToolTip = tooltip; break;
                    default:
                        break;
                }
            }
            */
            if (arch == CpuID.ARCH_UNKNOWN)
            {
                return;
            }

            string k = arch.ToString();
            this._intrinsicsDudeOptionsPageUI.SetPropValue(k, Settings.Default[k]);
            //SetToolTip(MakeToolTip());
        }

        private void Set_Settings(PropertyEnum key)
        {
            string k = key.ToString();
            Settings.Default[k] = this._intrinsicsDudeOptionsPageUI.GetPropValue(k);
        }
        #endregion

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
            this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_On = Settings.Default.SyntaxHighlighting_On;
            this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Intrinsic = Settings.Default.SyntaxHighlighting_Intrinsic;
            this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Register = Settings.Default.SyntaxHighlighting_Register;
            this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Misc = Settings.Default.SyntaxHighlighting_Misc;
            #endregion

            #region Code Completion
            this._intrinsicsDudeOptionsPageUI.StatementCompletion_On = Settings.Default.StatementCompletion_On;
            this._intrinsicsDudeOptionsPageUI.HideStatementCompletionMmxRegisters_On = Settings.Default.HideStatementCompletionMmxRegisters_On;
            this._intrinsicsDudeOptionsPageUI.HideStatementCompletionIncompatibleReturnType_On = Settings.Default.HideStatementCompletionIncompatibleReturnType_On;
            this._intrinsicsDudeOptionsPageUI.DecorateIncompatibleStatementCompletions_On = Settings.Default.DecorateIncompatibleStatementCompletions_On;

            this._intrinsicsDudeOptionsPageUI.SignatureHelp_On = Settings.Default.SignatureHelp_On;

            this._intrinsicsDudeOptionsPageUI.ARCH_SVML = Settings.Default.ARCH_SVML;
            this._intrinsicsDudeOptionsPageUI.useSvml_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SVML);
            this._intrinsicsDudeOptionsPageUI.ARCH_ADX = Settings.Default.ARCH_ADX;
            this._intrinsicsDudeOptionsPageUI.UseArch_ADX_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_ADX);
            this._intrinsicsDudeOptionsPageUI.ARCH_AES = Settings.Default.ARCH_AES;
            this._intrinsicsDudeOptionsPageUI.UseArch_AES_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AES);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX = Settings.Default.ARCH_AVX;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX2 = Settings.Default.ARCH_AVX2;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX2_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX2);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_F = Settings.Default.ARCH_AVX512_F;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_F_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_F);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VL = Settings.Default.ARCH_AVX512_VL;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VL_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VL);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_DQ = Settings.Default.ARCH_AVX512_DQ;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_DQ_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_DQ);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_BW = Settings.Default.ARCH_AVX512_BW;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_BW_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_BW);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_ER = Settings.Default.ARCH_AVX512_ER;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_ER_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_ER);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_CD = Settings.Default.ARCH_AVX512_CD;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_CD_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_CD);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_PF = Settings.Default.ARCH_AVX512_PF;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_PF_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_PF);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_IFMA = Settings.Default.ARCH_AVX512_IFMA;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_IFMA_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_IFMA);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VBMI = Settings.Default.ARCH_AVX512_VBMI;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VBMI_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VBMI);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VPOPCNTDQ = Settings.Default.ARCH_AVX512_VPOPCNTDQ;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_VPOPCNTDQ_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VPOPCNTDQ);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_4VNNIW = Settings.Default.ARCH_AVX512_4VNNIW;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4VNNIW_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_4VNNIW);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_4FMAPS = Settings.Default.ARCH_AVX512_4FMAPS;
            this._intrinsicsDudeOptionsPageUI.UseArch_AVX512_4FMAPS_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_4FMAPS);

            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VBMI2 = Settings.Default.ARCH_AVX512_VBMI2;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VBMI2_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VBMI2);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VNNI = Settings.Default.ARCH_AVX512_VNNI;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VNNI_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VNNI);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_BITALG = Settings.Default.ARCH_AVX512_BITALG;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_BITALG_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_BITALG);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_GFNI = Settings.Default.ARCH_AVX512_GFNI;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_GFNI_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_GFNI);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VAES = Settings.Default.ARCH_AVX512_VAES;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VAES_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VAES);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VPCLMULQDQ = Settings.Default.ARCH_AVX512_VPCLMULQDQ;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VPCLMULQDQ_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VPCLMULQDQ);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_BF16 = Settings.Default.ARCH_AVX512_BF16;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_BF16_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_BF16);
            this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VP2INTERSECT = Settings.Default.ARCH_AVX512_VP2INTERSECT;
            //this._intrinsicsDudeOptionsPageUI.ARCH_AVX512_VP2INTERSECT_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_AVX512_VP2INTERSECT);
            this._intrinsicsDudeOptionsPageUI.ARCH_SVML = Settings.Default.ARCH_SVML;
            //this._intrinsicsDudeOptionsPageUI.ARCH_SVML_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SVML);

            this._intrinsicsDudeOptionsPageUI.ARCH_IA32 = Settings.Default.ARCH_IA32;
            this._intrinsicsDudeOptionsPageUI.UseArch_IA32_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_IA32);
            this._intrinsicsDudeOptionsPageUI.ARCH_BMI1 = Settings.Default.ARCH_BMI1;
            this._intrinsicsDudeOptionsPageUI.UseArch_BMI1_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_BMI1);
            this._intrinsicsDudeOptionsPageUI.ARCH_BMI2 = Settings.Default.ARCH_BMI2;
            this._intrinsicsDudeOptionsPageUI.UseArch_BMI2_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_BMI2);
            this._intrinsicsDudeOptionsPageUI.ARCH_CLFLUSHOPT = Settings.Default.ARCH_CLFLUSHOPT;
            this._intrinsicsDudeOptionsPageUI.UseArch_CLFLUSHOPT_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_CLFLUSHOPT);
            this._intrinsicsDudeOptionsPageUI.ARCH_FMA = Settings.Default.ARCH_FMA;
            this._intrinsicsDudeOptionsPageUI.UseArch_FMA_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_FMA);
            this._intrinsicsDudeOptionsPageUI.ARCH_FP16C = Settings.Default.ARCH_FP16C;
            this._intrinsicsDudeOptionsPageUI.UseArch_FP16C_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_FP16C);
            this._intrinsicsDudeOptionsPageUI.ARCH_FXSR = Settings.Default.ARCH_FXSR;
            this._intrinsicsDudeOptionsPageUI.UseArch_FXSR_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_FXSR);
            this._intrinsicsDudeOptionsPageUI.ARCH_KNCNI = Settings.Default.ARCH_KNCNI;
            this._intrinsicsDudeOptionsPageUI.UseArch_KNCNI_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_KNCNI);
            this._intrinsicsDudeOptionsPageUI.ARCH_MMX = Settings.Default.ARCH_MMX;
            this._intrinsicsDudeOptionsPageUI.UseArch_MMX_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_MMX);
            this._intrinsicsDudeOptionsPageUI.ARCH_MPX = Settings.Default.ARCH_MPX;
            this._intrinsicsDudeOptionsPageUI.UseArch_MPX_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_MPX);
            this._intrinsicsDudeOptionsPageUI.ARCH_PCLMULQDQ = Settings.Default.ARCH_PCLMULQDQ;
            this._intrinsicsDudeOptionsPageUI.UseArch_PCLMULQDQ_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_PCLMULQDQ);
            this._intrinsicsDudeOptionsPageUI.ARCH_SSE = Settings.Default.ARCH_SSE;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SSE);
            this._intrinsicsDudeOptionsPageUI.ARCH_SSE2 = Settings.Default.ARCH_SSE2;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE2_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SSE2);
            this._intrinsicsDudeOptionsPageUI.ARCH_SSE3 = Settings.Default.ARCH_SSE3;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE3_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SSE3);
            this._intrinsicsDudeOptionsPageUI.ARCH_SSSE3 = Settings.Default.ARCH_SSSE3;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSSE3_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SSSE3);
            this._intrinsicsDudeOptionsPageUI.ARCH_SSE41 = Settings.Default.ARCH_SSE41;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE41_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SSE41);
            this._intrinsicsDudeOptionsPageUI.ARCH_SSE42 = Settings.Default.ARCH_SSE42;
            this._intrinsicsDudeOptionsPageUI.UseArch_SSE42_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SSE42);

            this._intrinsicsDudeOptionsPageUI.ARCH_LZCNT = Settings.Default.ARCH_LZCNT;
            this._intrinsicsDudeOptionsPageUI.UseArch_LZCNT_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_LZCNT);
            this._intrinsicsDudeOptionsPageUI.ARCH_INVPCID = Settings.Default.ARCH_INVPCID;
            this._intrinsicsDudeOptionsPageUI.UseArch_INVPCID_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_INVPCID);
            this._intrinsicsDudeOptionsPageUI.ARCH_MONITOR = Settings.Default.ARCH_MONITOR;
            this._intrinsicsDudeOptionsPageUI.UseArch_MONITOR_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_MONITOR);
            this._intrinsicsDudeOptionsPageUI.ARCH_POPCNT = Settings.Default.ARCH_POPCNT;
            this._intrinsicsDudeOptionsPageUI.UseArch_POPCNT_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_POPCNT);
            this._intrinsicsDudeOptionsPageUI.ARCH_RDRAND = Settings.Default.ARCH_RDRAND;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDRAND_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_RDRAND);
            this._intrinsicsDudeOptionsPageUI.ARCH_RDSEED = Settings.Default.ARCH_RDSEED;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDSEED_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_RDSEED);
            this._intrinsicsDudeOptionsPageUI.ARCH_TSC = Settings.Default.ARCH_TSC;
            this._intrinsicsDudeOptionsPageUI.UseArch_TSC_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_TSC);
            this._intrinsicsDudeOptionsPageUI.ARCH_RDTSCP = Settings.Default.ARCH_RDTSCP;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDTSCP_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_RDTSCP);
            this._intrinsicsDudeOptionsPageUI.ARCH_FSGSBASE = Settings.Default.ARCH_FSGSBASE;
            this._intrinsicsDudeOptionsPageUI.UseArch_FSGSBASE_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_FSGSBASE);
            this._intrinsicsDudeOptionsPageUI.ARCH_SHA = Settings.Default.ARCH_SHA;
            this._intrinsicsDudeOptionsPageUI.UseArch_SHA_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_SHA);
            this._intrinsicsDudeOptionsPageUI.ARCH_RTM = Settings.Default.ARCH_RTM;
            this._intrinsicsDudeOptionsPageUI.UseArch_RTM_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_RTM);
            this._intrinsicsDudeOptionsPageUI.ARCH_XSAVE = Settings.Default.ARCH_XSAVE;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVE_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_XSAVE);
            this._intrinsicsDudeOptionsPageUI.ARCH_XSAVEC = Settings.Default.ARCH_XSAVEC;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEC_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_XSAVEC);
            this._intrinsicsDudeOptionsPageUI.ARCH_XSS = Settings.Default.ARCH_XSS;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSS_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_XSS);
            this._intrinsicsDudeOptionsPageUI.ARCH_XSAVEOPT = Settings.Default.ARCH_XSAVEOPT;
            this._intrinsicsDudeOptionsPageUI.UseArch_XSAVEOPT_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_XSAVEOPT);
            this._intrinsicsDudeOptionsPageUI.ARCH_PREFETCHWT1 = Settings.Default.ARCH_PREFETCHWT1;
            this._intrinsicsDudeOptionsPageUI.UseArch_PREFETCHWT1_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_PREFETCHWT1);

            this._intrinsicsDudeOptionsPageUI.ARCH_RDPID = Settings.Default.ARCH_RDPID;
            this._intrinsicsDudeOptionsPageUI.UseArch_RDPID_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_RDPID);
            this._intrinsicsDudeOptionsPageUI.ARCH_CLWB = Settings.Default.ARCH_CLWB;
            this._intrinsicsDudeOptionsPageUI.UseArch_CLWB_UI.ToolTip = this.MakeToolTip(CpuID.ARCH_CLWB);
            #endregion
        }

        private string MakeToolTip(CpuID arch)
        {
            IntrinsicStore store = IntrinsicsDudeTools.Instance.IntrinsicStore;
            SortedSet<Intrinsic> usedMnemonics = new SortedSet<Intrinsic>();

            StringBuilder sb = new StringBuilder();
            string docArch = GetCpuID_Documentation(arch);
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

            if (sb.Length > 2)
            {
                sb.Length -= 2; // get rid of last comma.
            }

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
            changed |= this.Setting_Changed(PropertyEnum.SyntaxHighlighting_On, sb);
            changed |= this.Setting_Changed_RGB(PropertyEnum.SyntaxHighlighting_Intrinsic, sb);
            changed |= this.Setting_Changed_RGB(PropertyEnum.SyntaxHighlighting_Register, sb);
            changed |= this.Setting_Changed_RGB(PropertyEnum.SyntaxHighlighting_Misc, sb);
            #endregion

            #region Code Completion
            changed |= this.Setting_Changed(PropertyEnum.StatementCompletion_On, sb);
            changed |= this.Setting_Changed(PropertyEnum.HideStatementCompletionMmxRegisters_On, sb);
            changed |= this.Setting_Changed(PropertyEnum.HideStatementCompletionIncompatibleReturnType_On, sb);
            changed |= this.Setting_Changed(PropertyEnum.DecorateIncompatibleStatementCompletions_On, sb);

            changed |= this.Setting_Changed(PropertyEnum.SignatureHelp_On, sb);
            changed |= this.Setting_Changed(PropertyEnum.ARCH_SVML, sb);
            #endregion

            #region ARCH
            foreach (CpuID arch in Enum.GetValues(typeof(CpuID)))
            {
                if ((arch != CpuID.ARCH_NONE) && (arch != CpuID.ARCH_UNKNOWN))
                {
                    changed |= this.Setting_Changed(arch, sb);
                }
            }
            #endregion

            if (changed)
            {
                string title = "Microsoft Visual Studio";
                string text = "Unsaved changes exist.\n\n" + sb.ToString() + "\nWould you like to save?";

                if (MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.SaveAsync().ConfigureAwait(false);
                }
                else
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
            this.SaveAsync().ConfigureAwait(false);
            base.OnApply(e);
        }

        private async System.Threading.Tasks.Task SaveAsync()
        {
            if (!ThreadHelper.CheckAccess())
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            }


            //Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "INFO:{0}:save", this.ToString()));
            bool changed = false;
            bool restartNeeded = false;
            bool archChanged = false;

            #region Syntax Highlighting
            if (Settings.Default.SyntaxHighlighting_On != this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_On)
            {
                Settings.Default.SyntaxHighlighting_On = this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_On;
                changed = true;
                restartNeeded = true;
            }

            if (Settings.Default.SyntaxHighlighting_Intrinsic.ToArgb() != this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Intrinsic.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Intrinsic = this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Intrinsic;
                changed = true;
                restartNeeded = true;
            }

            if (Settings.Default.SyntaxHighlighting_Register.ToArgb() != this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Register.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Register = this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Register;
                changed = true;
                restartNeeded = true;
            }

            if (Settings.Default.SyntaxHighlighting_Misc.ToArgb() != this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Misc.ToArgb())
            {
                Settings.Default.SyntaxHighlighting_Misc = this._intrinsicsDudeOptionsPageUI.SyntaxHighlighting_Misc;
                changed = true;
                restartNeeded = true;
            }
            #endregion

            #region Code Completion
            if (this.Setting_Update(PropertyEnum.StatementCompletion_On))
            {
                changed = true;
            }
            if (this.Setting_Update(PropertyEnum.HideStatementCompletionMmxRegisters_On))
            {
                changed = true;
            }
            if (this.Setting_Update(PropertyEnum.HideStatementCompletionIncompatibleReturnType_On))
            {
                changed = true;
            }
            if (this.Setting_Update(PropertyEnum.DecorateIncompatibleStatementCompletions_On))
            {
                changed = true;
            }
            #endregion

            #region Signature Help
            if (this.Setting_Update(PropertyEnum.SignatureHelp_On))
            {
                changed = true;
            }
            #endregion

            #region ARCH
            foreach (CpuID arch in Enum.GetValues(typeof(CpuID)))
            {
                if (this.Setting_Update(arch))
                {
                    changed = true; 
                    archChanged = true;
                }
            }
            #endregion

            if (archChanged)
            {
                //AsmDudeTools.Instance.UpdateMnemonicSwitchedOn();
                //AsmDudeTools.Instance.UpdateRegisterSwitchedOn();
            }

            if (changed)
            {
                Settings.Default.Save();
            }

            if (restartNeeded)
            {
                string title = "Microsoft Visual Studio";
                string text1 = "Do you like to restart Visual Studio now?";

                if (MessageBox.Show(text1, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //await ClearMefCache.ClearMefCache.RestartAsync();
                }
                else
                {
                    if (false)
                    {
                        string text2 = "You may need to close and open assembly files, or \nrestart visual studio for the changes to take effect.";
                        MessageBox.Show(text2, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion Event Handlers
    }
}
