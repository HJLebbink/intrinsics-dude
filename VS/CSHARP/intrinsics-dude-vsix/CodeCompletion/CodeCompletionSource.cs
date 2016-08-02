﻿// The MIT License (MIT)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using System.Windows.Media;

using AsmTools;
using IntrinsicsDude.Tools;
using IntrinsicsDude.SignatureHelp;
using System.Text;

namespace IntrinsicsDude {

    public sealed class CompletionComparer : IComparer<Completion> {
        public int Compare(Completion x, Completion y) {
            return x.InsertionText.CompareTo(y.InsertionText);
        }
    }

    public sealed class CodeCompletionSource : ICompletionSource {

        private readonly ITextBuffer _buffer;
        private readonly ILabelGraph _labelGraph;
        private readonly IDictionary<AsmTokenType, ImageSource> _icons;
        private readonly AsmDudeTools _asmDudeTools;
        private bool _disposed = false;

        public CodeCompletionSource(ITextBuffer buffer, ILabelGraph labelGraph) {
            this._buffer = buffer;
            this._labelGraph = labelGraph;
            this._icons = new Dictionary<AsmTokenType, ImageSource>();
            this._asmDudeTools = AsmDudeTools.Instance;
            this.loadIcons();
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets) {
            //AsmDudeToolsStatic.Output(string.Format("INFO: {0}:AugmentCompletionSession", this.ToString()));

            if (_disposed) return;
            if (!Settings.Default.CodeCompletion_On) return;

            try {
                DateTime time1 = DateTime.Now;
                ITextSnapshot snapshot = this._buffer.CurrentSnapshot;
                SnapshotPoint triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
                if (triggerPoint == null) {
                    return;
                }
                ITextSnapshotLine line = triggerPoint.GetContainingLine();

                //1] check if current position is in a remark; if we are in a remark, no code completion
                #region
                if (triggerPoint.Position > 1) {
                    char currentTypedChar = (triggerPoint - 1).GetChar();
                    //AsmDudeToolsStatic.Output("INFO: CodeCompletionSource:AugmentCompletionSession: current char = "+ currentTypedChar);
                    if (!currentTypedChar.Equals('#')) { //TODO UGLY since the user can configure this starting character
                        int pos = triggerPoint.Position - line.Start;
                        if (AsmSourceTools.isInRemark(pos, line.GetText())) {
                            //AsmDudeToolsStatic.Output("INFO: CodeCompletionSource:AugmentCompletionSession: currently in a remark section");
                            return;
                        } else {
                           // AsmDudeToolsStatic.Output("INFO: CodeCompletionSource:AugmentCompletionSession: not in a remark section");
                        }
                    }
                }
                #endregion

                //2] find the start of the current keyword
                #region
                SnapshotPoint start = triggerPoint;
                while ((start > line.Start) && !AsmTools.AsmSourceTools.isSeparatorChar((start - 1).GetChar())) {
                    start -= 1;
                }
                #endregion

                //3] get the word that is currently being typed
                #region
                ITrackingSpan applicableTo = snapshot.CreateTrackingSpan(new SnapshotSpan(start, triggerPoint), SpanTrackingMode.EdgeInclusive);
                string partialKeyword = applicableTo.GetText(snapshot);
                bool useCapitals = IntrinsicsDudeToolsStatic.isAllUpper(partialKeyword);

                SortedSet<Completion> completions = null;

                string lineStr = line.GetText();
                var t = AsmSourceTools.parseLine(lineStr);
                Mnemonic mnemonic = t.Item2;

                if (mnemonic == Mnemonic.UNKNOWN) {
                    ISet<AsmTokenType> selected = new HashSet<AsmTokenType> { AsmTokenType.Directive, AsmTokenType.Jump, AsmTokenType.Misc, AsmTokenType.Mnemonic /*, AsmTokenType.Register */};
                    completions = this.selectedCompletions(useCapitals, selected);
                } else { // the current line contains a mnemonic
                    string previousKeyword = IntrinsicsDudeToolsStatic.getPreviousKeyword(line.Start, start);
                    //AsmDudeToolsStatic.Output("INFO: AsmCompletionSource:AugmentCompletionSession; mnemonic=" + mnemonic+ "; previousKeyword="+ previousKeyword);

                    if (AsmSourceTools.isJump(AsmSourceTools.parseMnemonic(previousKeyword))) {
                        //AsmDudeToolsStatic.Output("INFO: AsmCompletionSource:AugmentCompletionSession; previous keyword is a jump mnemonic");
                        // previous keyword is jump (or call) mnemonic. Suggest "SHORT" or a label
                        completions = this.labelCompletions();
                        completions.Add(new Completion("SHORT", (useCapitals) ? "SHORT" : "short", null, this._icons[AsmTokenType.Misc], ""));
                        completions.Add(new Completion("NEAR", (useCapitals) ? "NEAR" : "near", null, this._icons[AsmTokenType.Misc], ""));
                    } else if (previousKeyword.Equals("SHORT") || previousKeyword.Equals("NEAR")) {
                        // previous keyword is SHORT. Suggest a label
                        completions = this.labelCompletions();
                    } else {
                        IList<Operand> operands = AsmSourceTools.makeOperands(t.Item3);
                        ISet<AsmSignatureEnum> allowed = new HashSet<AsmSignatureEnum>();
                        int commaCount = AsmSignature.countCommas(lineStr);
                        IList<AsmSignatureElement> allSignatures = this._asmDudeTools.mnemonicStore.getSignatures(mnemonic);

                        ISet<Arch> selectedArchitectures = IntrinsicsDudeToolsStatic.getArchSwithedOn();
                        foreach (AsmSignatureElement se in AsmSignatureHelpSource.constrainSignatures(allSignatures, operands, selectedArchitectures)) {
                            if (commaCount < se.operands.Count) {
                                foreach (AsmSignatureEnum s in se.operands[commaCount]) {
                                    allowed.Add(s);
                                }
                            }
                        }
                        completions = this.mnemonicOperandCompletions(useCapitals, allowed);
                    }
                }
                //AsmDudeToolsStatic.Output("INFO: AsmCompletionSource:AugmentCompletionSession; nCompletions=" + completions.Count);
                #endregion

                completionSets.Add(new CompletionSet("Tokens", "Tokens", applicableTo, completions, Enumerable.Empty<Completion>()));

                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Code Completion");
            } catch (Exception e) {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:AugmentCompletionSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public void Dispose() {
            if (!this._disposed) {
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }

        #region Private Methods

        private SortedSet<Completion> mnemonicOperandCompletions(bool useCapitals, ISet<AsmSignatureEnum> allowedOperands) {

            SortedSet<Completion> completions = new SortedSet<Completion>(new CompletionComparer());
            foreach (string keyword in this._asmDudeTools.getKeywords()) {

                Arch arch = this._asmDudeTools.getArchitecture(keyword);
                AsmTokenType type = this._asmDudeTools.getTokenType(keyword);

                bool selected = IntrinsicsDudeToolsStatic.isArchSwitchedOn(arch);
                //AsmDudeToolsStatic.Output("INFO: AsmCompletionSource:mnemonicOperandCompletions; keyword=" + keyword +"; selected="+selected +"; arch="+arch);

                if (selected) {
                    switch (type) {
                        case AsmTokenType.Register:
                            //AsmDudeToolsStatic.Output("INFO: AsmCompletionSource:mnemonicOperandCompletions; rn=" + keyword);
                            Rn regName = RegisterTools.parseRn(keyword);
                            if (AsmSignatureTools.isAllowedReg(regName, allowedOperands)) {
                                //AsmDudeToolsStatic.Output(string.Format("INFO: AsmCompletionSource:mnemonicOperandCompletions; rn="+ keyword + " is selected"));
                            } else {
                                selected = false;
                            }
                            break;
                        case AsmTokenType.Misc:
                            if (AsmSignatureTools.isAllowedMisc(keyword, allowedOperands)) {
                                //AsmDudeToolsStatic.Output(string.Format("INFO: AsmCompletionSource:mnemonicOperandCompletions; rn="+ keyword + " is selected"));
                            } else {
                                selected = false;
                            }
                            break;
                        default:
                            selected = false;
                            break;
                    }
                }
                if (selected) {
                    //AsmDudeToolsStatic.Output("INFO: AsmCompletionSource:AugmentCompletionSession: keyword \"" + keyword + "\" is added to the completions list");

                    // by default, the entry.Key is with capitals
                    string insertionText = (useCapitals) ? keyword : keyword.ToLower();
                    string archStr = (arch == Arch.NONE) ? "" : " [" + ArchTools.ToString(arch) + "]";
                    string descriptionStr = this._asmDudeTools.getDescription(keyword);
                    descriptionStr = (descriptionStr.Length == 0) ? "" : " - " + descriptionStr;
                    String displayText = keyword + archStr + descriptionStr;
                    //String description = keyword.PadRight(15) + archStr.PadLeft(8) + descriptionStr;

                    ImageSource imageSource = null;
                    this._icons.TryGetValue(type, out imageSource);
                    completions.Add(new Completion(displayText, insertionText, null, imageSource, ""));
                }
            }
            return completions;
        }

        private SortedSet<Completion> labelCompletions() {
            SortedSet<Completion> completions = new SortedSet<Completion>(new CompletionComparer());
            ImageSource imageSource = this._icons[AsmTokenType.Label];

            SortedDictionary<string, string> labels = this._labelGraph.getLabelDescriptions;
            foreach (KeyValuePair<string, string> entry in labels) {
                //Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "INFO:{0}:AugmentCompletionSession; label={1}; description={2}", this.ToString(), entry.Key, entry.Value));
                string displayText = entry.Key + " - " + entry.Value;
                string insertionText = entry.Key;
                completions.Add(new Completion(displayText, insertionText, null, imageSource, ""));
            }
            return completions;
        }

        private IList<Mnemonic> getAllowedMnemonics(ISet<Arch> selectedArchitectures) {
            MnemonicStore store = this._asmDudeTools.mnemonicStore;
            IList<Mnemonic> list = new List<Mnemonic>();
            foreach (Mnemonic mnemonic in Enum.GetValues(typeof(Mnemonic))) {
                foreach (Arch a in store.getArch(mnemonic)) {
                    if (selectedArchitectures.Contains(a)) {
                        list.Add(mnemonic);
                        break;
                    }
                }
            }
            return list;
        }

        private SortedSet<Completion> selectedCompletions(bool useCapitals, ISet<AsmTokenType> selectedTypes) {
            SortedSet<Completion> completions = new SortedSet<Completion>(new CompletionComparer());

            //Add the completions of AsmDude directives (such as code folding directives)
            #region 
            if (Settings.Default.CodeFolding_On) {
                {
                    string insertionText = Settings.Default.CodeFolding_BeginTag;     //the characters that start the outlining region
                    string description = insertionText + " - keyword to start code folding";
                    completions.Add(new Completion(description, insertionText, null, this._icons[AsmTokenType.Directive], ""));
                }
                {
                    string insertionText = Settings.Default.CodeFolding_EndTag;       //the characters that end the outlining region
                    string description = insertionText + " - keyword to end code folding";
                    completions.Add(new Completion(description, insertionText, null, this._icons[AsmTokenType.Directive], ""));
                }
            }
            #endregion
            AssemblerEnum usedAssember = IntrinsicsDudeToolsStatic.usedAssembler;

            #region

            if (selectedTypes.Contains(AsmTokenType.Mnemonic)) {
                ISet<Arch> selectedArchs = IntrinsicsDudeToolsStatic.getArchSwithedOn();
                IList<Mnemonic> allowedMnemonics = this.getAllowedMnemonics(selectedArchs);
                //AsmDudeToolsStatic.Output("INFO: CodeCompletionSource:selectedCompletions; allowedMnemonics.Count=" + allowedMnemonics.Count + "; selectedArchs="+ArchTools.ToString(selectedArchs));
                foreach (Mnemonic mnemonic in allowedMnemonics) {

                    string keyword = mnemonic.ToString();

                    string insertionText = (useCapitals) ? keyword : keyword.ToLower();
                    string archStr = ArchTools.ToString(this._asmDudeTools.mnemonicStore.getArch(mnemonic));
                    string descriptionStr = this._asmDudeTools.mnemonicStore.getDescription(mnemonic);
                    descriptionStr = (descriptionStr.Length == 0) ? "" : " - " + descriptionStr;
                    String displayText = keyword + archStr + descriptionStr;
                    //String description = keyword.PadRight(15) + archStr.PadLeft(8) + descriptionStr;

                    ImageSource imageSource = null;
                    this._icons.TryGetValue(AsmTokenType.Mnemonic, out imageSource);
                    completions.Add(new Completion(displayText, insertionText, null, imageSource, ""));
                }
            }

            //Add the completions that are defined in the xml file
            foreach (string keyword in this._asmDudeTools.getKeywords()) {
                AsmTokenType type = this._asmDudeTools.getTokenType(keyword);
                if (selectedTypes.Contains(type)) {
                    Arch arch = this._asmDudeTools.getArchitecture(keyword);
                    bool selected = IntrinsicsDudeToolsStatic.isArchSwitchedOn(arch);

                    if (selected && (type == AsmTokenType.Directive)) {
                        AssemblerEnum assembler = this._asmDudeTools.getAssembler(keyword);
                        switch (assembler) {
                            case AssemblerEnum.MASM: if (usedAssember != AssemblerEnum.MASM) selected = false; break;
                            case AssemblerEnum.NASM: if (usedAssember != AssemblerEnum.NASM) selected = false; break;
                            case AssemblerEnum.UNKNOWN:
                            default:
                                break;
                        }
                    }
                    //AsmDudeToolsStatic.Output(string.Format(CultureInfo.CurrentCulture, "INFO:{0}:selectedCompletions; keyword={1}; arch={2}; selected={3}", this.ToString(), keyword, arch, selected));

                    if (selected) {
                        //Debug.WriteLine("INFO: CompletionSource:AugmentCompletionSession: name keyword \"" + entry.Key + "\"");

                        // by default, the entry.Key is with capitals
                        string insertionText = (useCapitals) ? keyword : keyword.ToLower();
                        string archStr = (arch == Arch.NONE) ? "" : " [" + ArchTools.ToString(arch) + "]";
                        string descriptionStr = this._asmDudeTools.getDescription(keyword);
                        descriptionStr = (descriptionStr.Length == 0) ? "" : " - " + descriptionStr;
                        String displayText = keyword + archStr + descriptionStr;
                        //String description = keyword.PadRight(15) + archStr.PadLeft(8) + descriptionStr;

                        ImageSource imageSource = null;
                        this._icons.TryGetValue(type, out imageSource);
                        completions.Add(new Completion(displayText, insertionText, null, imageSource, ""));
                    }
                }
            }
            #endregion

            return completions;
        }

        private void loadIcons() {
            Uri uri = null;
            string installPath = IntrinsicsDudeToolsStatic.getInstallPath();
            try {
                uri = new Uri(installPath + "Resources/images/icon-R-blue.png");
                this._icons[AsmTokenType.Register] = IntrinsicsDudeToolsStatic.bitmapFromUri(uri);
            } catch (FileNotFoundException) {
                //MessageBox.Show("ERROR: AsmCompletionSource: could not find file \"" + uri.AbsolutePath + "\".");
            }
            try {
                uri = new Uri(installPath + "Resources/images/icon-M.png");
                this._icons[AsmTokenType.Mnemonic] = IntrinsicsDudeToolsStatic.bitmapFromUri(uri);
                this._icons[AsmTokenType.Jump] = this._icons[AsmTokenType.Mnemonic];
            } catch (FileNotFoundException) {
                //MessageBox.Show("ERROR: AsmCompletionSource: could not find file \"" + uri.AbsolutePath + "\".");
            }
            try {
                uri = new Uri(installPath + "Resources/images/icon-question.png");
                this._icons[AsmTokenType.Misc] = IntrinsicsDudeToolsStatic.bitmapFromUri(uri);
                this._icons[AsmTokenType.Directive] = this._icons[AsmTokenType.Misc];
            } catch (FileNotFoundException) {
                //MessageBox.Show("ERROR: AsmCompletionSource: could not find file \"" + uri.AbsolutePath + "\".");
            }
            try {
                uri = new Uri(installPath + "Resources/images/icon-L.png");
                this._icons[AsmTokenType.Label] = IntrinsicsDudeToolsStatic.bitmapFromUri(uri);
            } catch (FileNotFoundException) {
                //MessageBox.Show("ERROR: AsmCompletionSource: could not find file \"" + uri.AbsolutePath + "\".");
            }
        }
        #endregion
    }
}

