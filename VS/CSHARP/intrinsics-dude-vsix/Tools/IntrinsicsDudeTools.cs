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

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Collections.Generic;

using AsmTools;
using Microsoft.VisualStudio.Shell;
using IntrinsicsDude.Tools;

namespace IntrinsicsDude {

    public sealed class IntrinsicsDudeTools {

        private IDictionary<string, AssemblerEnum> _assembler;
        private IDictionary<string, Arch> _arch;
        private IDictionary<string, string> _description;
        private readonly ErrorListProvider _errorListProvider;

        private readonly IntrinsicsStore _intrisicsStore;

        #region Singleton Stuff
        private static readonly Lazy<IntrinsicsDudeTools> lazy = new Lazy<IntrinsicsDudeTools>(() => new IntrinsicsDudeTools());
        public static IntrinsicsDudeTools Instance { get { return lazy.Value; } }
        #endregion Singleton Stuff


        /// <summary>
        /// Singleton pattern: use AsmDudeTools.Instance for the instance of this class
        /// </summary>
        private IntrinsicsDudeTools() {
            IntrinsicsDudeToolsStatic.Output("INFO: AsmDudeTools constructor");
            /*
            #region load signature store
            string path = IntrinsicsDudeToolsStatic.getInstallPath() + "Resources" + Path.DirectorySeparatorChar;
            //string filename = path + "mnemonics-nasm.txt";
            string filename_Regular = path + "signature-june2016.txt";
            this._intrisicsStore = new IntrinsicsStore(filename_Regular);
            #endregion
            */
        }

        #region Public Methods

        public ErrorListProvider errorListProvider { get { return this._errorListProvider; } }

        public IntrinsicsStore mnemonicStore { get { return this._intrisicsStore; } }

        /// <summary>
        /// get url for the provided keyword. Returns empty string if the keyword does not exist or the keyword does not have an url.
        /// </summary>
        public string getUrl(string keyword) {
            // no need to pre-process this information.
            try {
                string keywordUpper = keyword.ToUpper();
                Mnemonic mnemonic = AsmSourceTools.parseMnemonic(keyword);
                if (mnemonic != Mnemonic.UNKNOWN) {
                    string url = this.mnemonicStore.getHtmlRef(mnemonic);
                    //AsmDudeToolsStatic.Output(string.Format("INFO: {0}:getUrl: keyword {1}; url {2}.", this.ToString(), keyword, url));
                    return url;
                }
                return "";
            } catch (Exception e) {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:getUrl: exception {1}.", this.ToString(), e.ToString()));
                return "";
            }
        }

        /// <summary>
        /// get url for the provided keyword. Returns empty string if the keyword does not exist or the keyword does not have an url.
        /// </summary>
        public string getDescription(string keyword) {
            string description;
            if (!this._description.TryGetValue(keyword, out description)) {
                description = "";
            }
            return description;
        }

        /// <summary>
        /// Get architecture of the provided keyword
        /// </summary>
        public Arch getArchitecture(string keyword) {
            return this._arch[keyword.ToUpper()];
        }

        #endregion Public Methods
        #region Private Methods

        #endregion
    }
}