// The MIT License (MIT)
//
// Copyright (c) 2018 Henk-Jan Lebbink
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

using Microsoft.VisualStudio.Language.Intellisense;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Media;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.Tools
{
    public class StatementCompletionStore
    {
        private readonly IntrinsicStore _intrinsic_Store;
        private readonly List<Tuple<Completion, ReturnType>> _intrinsic_Completions;
        private readonly IDictionary<string, Completion> _cached_Completions;

        private CpuID _selectedCpuID;
        private bool _hide_mmx_reg_intrinsics;

        private ImageSource icon_IF; // icon created with http://www.sciweavers.org/free-online-latex-equation-editor Plum Modern 36
        
        public StatementCompletionStore(IntrinsicStore intrinsic_Store)
        {
            this._intrinsic_Store = intrinsic_Store;
            this._intrinsic_Completions = new List<Tuple<Completion, ReturnType>>();
            this._cached_Completions = new Dictionary<string, Completion>();
            this.LoadIcons();
            this.Init();
        }

        public ReadOnlyCollection<Tuple<Completion, ReturnType>> Intrinsic_Completions {
            get {
                if (this.NeedInit())
                {
                    this.Init();
                }
                return this._intrinsic_Completions.AsReadOnly();
            }
        }

        public Completion Get_Cached_Completion(Completion completion)
        {
            string insertion_Text = completion.InsertionText;

            if (!this._cached_Completions.TryGetValue(insertion_Text, out var result))
            {
                //result = completion; // a reference to an existing completion does not work, you need to make a deep copy.
                result = new Completion(completion.DisplayText, insertion_Text, completion.Description, completion.IconSource, completion.IconAutomationText);
                this._cached_Completions.Add(insertion_Text, result);
            };
            return result;
        }

        public bool Is_Initialized { get { return this._cached_Completions.Count > 0; } }

        #region Private Methods

        private bool NeedInit()
        {
            if (this._selectedCpuID != IntrinsicsDudeToolsStatic.GetCpuIDSwithedOn())
            {
                return true;
            }
            if (this._hide_mmx_reg_intrinsics != Settings.Default.HideStatementCompletionMmxRegisters_On)
            {
                return true;
            }
            return false;
        }

        private void Init()
        {
            DateTime time1 = DateTime.Now;
            this._intrinsic_Completions.Clear();

            this._selectedCpuID = IntrinsicsDudeToolsStatic.GetCpuIDSwithedOn();
            this._hide_mmx_reg_intrinsics = Settings.Default.HideStatementCompletionMmxRegisters_On;

            foreach (KeyValuePair<Intrinsic, IList<IntrinsicDataElement>> pair in this._intrinsic_Store.Data)
            {
                Intrinsic intrinsic = pair.Key;
                IList<IntrinsicDataElement> dataElements = pair.Value;

                CpuID cpuID = CpuID.NONE;
                foreach (IntrinsicDataElement dataElement in dataElements)
                {
                    cpuID |= dataElement.cpuID;
                }
                bool enabled = (cpuID & this._selectedCpuID) == cpuID;


                if (enabled && this._hide_mmx_reg_intrinsics)
                {
                    if (IntrinsicTools.Uses_MMX_Register(intrinsic))
                    {
                        enabled = false;
                    }
                }

                if (enabled)
                {
                    IntrinsicDataElement dataElementFirst = dataElements[0];
                    string intrinsicStr = intrinsic.ToString().ToLower();
                    string displayText = this.CreateDisplayText(intrinsicStr, cpuID, dataElementFirst.description, true, true);
                    //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: getAllowedMnemonics; adding displayText=" + displayText);
                    Completion completion = new Completion(displayText, intrinsicStr, dataElementFirst.DocumenationString, this.icon_IF, "");

                    this._intrinsic_Completions.Add(new Tuple<Completion, ReturnType>(completion, dataElementFirst.returnType));
                }
            }
            IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "Statement-Completion-Store-Initialization");
        }

        public string CreateDisplayText(string intrinsicStr, CpuID cpuID, string description, bool correctType, bool decorateIncompatibleStatementCompletion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(intrinsicStr);
            sb.Append(" [");
            sb.Append(IntrinsicTools.ToString(cpuID));
            sb.Append("] - ");
            sb.Append(description);

            string displayText = IntrinsicsDudeToolsStatic.Cleanup(sb.ToString(), IntrinsicsDudePackage.maxNumberOfCharsInCompletions);
            return displayText;
        }

        private void LoadIcons()
        {
            Uri uri = null;
            string installPath = IntrinsicsDudeToolsStatic.GetInstallPath();
            try
            {
                uri = new Uri(installPath + "Resources/images/icon-IF.png");
                this.icon_IF = IntrinsicsDudeToolsStatic.BitmapFromUri(uri);
            }
            catch (FileNotFoundException)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: StatementCompletionSource: loadIcons. could not find file \"" + uri.AbsolutePath + "\".");
            }
        }

        #endregion
    }
}
