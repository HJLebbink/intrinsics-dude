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
using Microsoft.VisualStudio.Language.Intellisense;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Media;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.StatementCompletion
{
    public class StatementCompletionStore
    {
        private readonly List<Tuple<Completion, ReturnType>> _data;

        private CpuID _selectedCpuID;
        private bool _hide_mmx_reg_intrinsics;


        private ImageSource icon_IF; // icon created with http://www.sciweavers.org/free-online-latex-equation-editor Plum Modern 36
        
        public StatementCompletionStore()
        {
            this._data = new List<Tuple<Completion, ReturnType>>();
            this.loadIcons();
            this.init();
        }

        public ReadOnlyCollection<Tuple<Completion, ReturnType>> data {
            get {
                if (this.needInit())
                {
                    this.init();
                }
                return this._data.AsReadOnly();
            }
        }

        #region Private Methods

        private bool needInit()
        {
            if (this._selectedCpuID != IntrinsicsDudeToolsStatic.getCpuIDSwithedOn())
            {
                return true;
            }
            if (this._hide_mmx_reg_intrinsics != Settings.Default.HideStatementCompletionMmxRegisters_On)
            {
                return true;
            }
            return false;
        }

        private void init()
        {
            DateTime time1 = DateTime.Now;
            this._data.Clear();

            this._selectedCpuID = IntrinsicsDudeToolsStatic.getCpuIDSwithedOn();
            this._hide_mmx_reg_intrinsics = Settings.Default.HideStatementCompletionMmxRegisters_On;

            foreach (KeyValuePair<Intrinsic, IList<IntrinsicDataElement>> pair in IntrinsicsDudeTools.Instance.intrinsicStore.data)
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
                    if (IntrinsicTools.uses_mmx_register(intrinsic))
                    {
                        enabled = false;
                    }
                }

                if (enabled)
                {
                    IntrinsicDataElement dataElementFirst = dataElements[0];
                    string intrinsicStr = intrinsic.ToString().ToLower();
                    string displayText = this.createDisplayText(intrinsicStr, cpuID, dataElementFirst.description, true, true);
                    //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: getAllowedMnemonics; adding displayText=" + displayText);
                    Completion completion = new Completion(displayText, intrinsicStr, dataElementFirst.documenationString, this.icon_IF, "");

                    this._data.Add(new Tuple<Completion, ReturnType>(completion, dataElementFirst.returnType));
                }
            }
            IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Statement-Completion-Store-Initialization");
        }

        public string createDisplayText(string intrinsicStr, CpuID cpuID, string description, bool correctType, bool decorateIncompatibleStatementCompletion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(intrinsicStr);
            sb.Append(" [");
            sb.Append(IntrinsicTools.ToString(cpuID));
            sb.Append("] - ");
            sb.Append(description);

            string displayText = IntrinsicsDudeToolsStatic.cleanup(sb.ToString(), IntrinsicsDudePackage.maxNumberOfCharsInCompletions);
            return displayText;
        }

        private void loadIcons()
        {
            Uri uri = null;
            string installPath = IntrinsicsDudeToolsStatic.getInstallPath();
            try
            {
                uri = new Uri(installPath + "Resources/images/icon-IF.png");
                this.icon_IF = IntrinsicsDudeToolsStatic.bitmapFromUri(uri);
            }
            catch (FileNotFoundException)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: StatementCompletionSource: loadIcons. could not find file \"" + uri.AbsolutePath + "\".");
            }
        }

        #endregion
    }
}
