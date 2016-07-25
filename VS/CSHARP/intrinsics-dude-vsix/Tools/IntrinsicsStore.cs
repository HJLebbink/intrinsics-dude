﻿// The MIT License (MIT)
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

using IntrinsicsDude.SignatureHelp;
using IntrinsicsDude.Tools;
using AsmTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace IntrinsicsDude.Tools {

    public class IntrinsicsStore {
        private readonly IDictionary<Mnemonic, IList<IntrinsicsSignatureElement>> _data;
        private readonly IDictionary<Mnemonic, IList<Arch>> _arch;
        private readonly IDictionary<Mnemonic, string> _htmlRef;
        private readonly IDictionary<Mnemonic, string> _description;

        public IntrinsicsStore(string filename_RegularData) {
            this._data = new Dictionary<Mnemonic, IList<IntrinsicsSignatureElement>>();
            this._arch = new Dictionary<Mnemonic, IList<Arch>>();
            this._htmlRef = new Dictionary<Mnemonic, string>();
            this._description = new Dictionary<Mnemonic, string>();

            this.loadRegularData(filename_RegularData);
        }

        public bool hasElement(Mnemonic mnemonic) {
            return this._data.ContainsKey(mnemonic);
        }

        public IList<IntrinsicsSignatureElement> getSignatures(Mnemonic mnemonic) {
            IList<IntrinsicsSignatureElement> list;
            if (this._data.TryGetValue(mnemonic, out list)) {
                return list;
            }
            return new List<IntrinsicsSignatureElement>(0);
        }

        public IList<Arch> getArch(Mnemonic mnemonic) {
            IList<Arch> value;
            if (this._arch.TryGetValue(mnemonic, out value)) {
                return value;
            }
            return new List<Arch>(0);
        }

        public string getHtmlRef(Mnemonic mnemonic) {
            string value;
            if (this._htmlRef.TryGetValue(mnemonic, out value)) {
                return value;
            }
            return "";
        }

        public void setHtmlRef(Mnemonic mnemonic, string value) {
            this._htmlRef[mnemonic] = value;
        }

        public void setDescription(Mnemonic mnemonic, string value) {
            this._description[mnemonic] = value;
            if (this._data.ContainsKey(mnemonic)) {
                foreach (IntrinsicsSignatureElement e in _data[mnemonic]) {
                    e.documentation = value;
                }
            }
        }

        public string getDescription(Mnemonic mnemonic) {
            string value = null;
            if (this._description.TryGetValue(mnemonic, out value)) {
                return value;
            }
            return "";
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<Mnemonic, IList<IntrinsicsSignatureElement>> element in _data) {
                Mnemonic mnemonic = element.Key;
                string s1 = mnemonic.ToString().ToUpper();
                string s6 = this._htmlRef[mnemonic];

                foreach (IntrinsicsSignatureElement sig in element.Value) {
                    string s2 = sig.operandsStr;
                    string s3 = sig.archStr;
                    string s4 = sig.sigatureDoc();
                    string s5 = sig.documentation;
                    sb.AppendLine(s1 + "\t" + s2 + "\t" + s3 + "\t" + s4 + "\t" + s5 + "\t" + s6);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Add (and overwrite) return true if an existing signature element is overwritten;
        /// </summary>
        /// <param name="asmSignatureElement"></param>
        private bool add(IntrinsicsSignatureElement asmSignatureElement) {
            Mnemonic mnemonic = asmSignatureElement.mnemonic;
            IList<IntrinsicsSignatureElement> signatureElementList = null;
            bool result = false;

            if (this._data.TryGetValue(mnemonic, out signatureElementList)) {
                if (signatureElementList.Contains(asmSignatureElement)) {
                    signatureElementList.Remove(asmSignatureElement);
                    result = true;
                }
                signatureElementList.Add(asmSignatureElement);

            } else {
                this._data.Add(mnemonic, new List<IntrinsicsSignatureElement> { asmSignatureElement });
            }
            return result;
        }

        private void loadRegularData(string filename) {
            //AsmDudeToolsStatic.Output("INFO: MnemonicStore:loadRegularData: filename=" + filename);
            try {
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                string line;
                while ((line = file.ReadLine()) != null) {
                    if ((line.Length > 0) && (!line.StartsWith(";"))) {
                        string[] columns = line.Split('\t');
                        if (columns.Length == 4) { // general description
                            #region
                            Mnemonic mnemonic = AsmSourceTools.parseMnemonic(columns[1]);
                            if (mnemonic == Mnemonic.UNKNOWN) {
                                // ignore the unknown mnemonic
                                //AsmDudeToolsStatic.Output("WARNING: MnemonicStore:loadRegularData: unknown mnemonic in line: " + line);
                            } else {
                                if (!this._description.ContainsKey(mnemonic)) {
                                    this._description.Add(mnemonic, columns[2]);
                                } else {
                                    // this happens when the mnemonic is defined in multiple files, using the data from the first file
                                    //AsmDudeToolsStatic.Output("WARNING: MnemonicStore:loadRegularData: mnemonic " + mnemonic + " already has a description");
                                }
                                if (!this._htmlRef.ContainsKey(mnemonic)) {
                                    this._htmlRef.Add(mnemonic, columns[3]);
                                } else {
                                    // this happens when the mnemonic is defined in multiple files, using the data from the first file
                                    //AsmDudeToolsStatic.Output("WARNING: MnemonicStore:loadRegularData: mnemonic " + mnemonic + " already has a html ref");
                                }
                            }
                            #endregion
                        } else if ((columns.Length == 5) || (columns.Length == 6)) { // signature description, ignore an old sixth column
                            #region
                            Mnemonic mnemonic = AsmSourceTools.parseMnemonic(columns[0]);
                            if (mnemonic == Mnemonic.UNKNOWN) {
                                IntrinsicsDudeToolsStatic.Output("WARNING: MnemonicStore:loadRegularData: unknown mnemonic in line: " + line);
                            } else {
                                IntrinsicsSignatureElement se = new IntrinsicsSignatureElement(mnemonic, columns[1], columns[2], columns[3], columns[4]);
                                if (this.add(se)) {
                                    IntrinsicsDudeToolsStatic.Output("WARNING: MnemonicStore:loadRegularData: signature already exists" + se.ToString());
                                }
                            }
                            #endregion
                        } else {
                            IntrinsicsDudeToolsStatic.Output("WARNING: MnemonicStore:loadRegularData: s.Length=" + columns.Length + "; funky line" + line);
                        }
                    }
                }
                file.Close();

                #region Fill Arch
                foreach (KeyValuePair<Mnemonic, IList<IntrinsicsSignatureElement>> pair in this._data) {
                    ISet<Arch> archs = new HashSet<Arch>();
                    foreach (IntrinsicsSignatureElement signatureElement in pair.Value) {
                        foreach (Arch arch in signatureElement.arch) {
                            archs.Add(arch);
                        }
                    }
                    IList<Arch> list = new List<Arch>();
                    foreach (Arch a in archs) {
                        list.Add(a);
                    }
                    this._arch[pair.Key] = list;
                }
                #endregion
            } catch (FileNotFoundException) {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicsStore: could not find file \"" + filename + "\".");
                //MessageBox.Show("ERROR: AsmTokenTagger: could not find file \"" + filename + "\".");
            } catch (Exception e) {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicsStore: error while reading file \"" + filename + "\"." + e);
                //MessageBox.Show("ERROR: AsmTokenTagger: error while reading file \"" + filename + "\"." + e);
            }
        }
    }
}
