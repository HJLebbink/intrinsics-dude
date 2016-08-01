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
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System.ComponentModel.Composition;
using IntrinsicsDude.SyntaxHighlighting;
using System.Text;
using IntrinsicsDude.Tools;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using AsmTools;
using System.IO;

namespace IntrinsicsDude.QuickInfo {

    /// <summary>
    /// Provides QuickInfo information to be displayed in a text buffer
    /// </summary>
    internal sealed class IntrinsicsQuickInfoSource : IQuickInfoSource {

        private readonly ITextBuffer _sourceBuffer;
        private readonly ITagAggregator<AsmTokenTag> _aggregator;
        private readonly ILabelGraph _labelGraph;
        private readonly IntrinsicsDudeTools _asmDudeTools;

        public object CSharpEditorResources { get; private set; }

        public IntrinsicsQuickInfoSource(
                ITextBuffer buffer, 
                ITagAggregator<AsmTokenTag> aggregator,
                ILabelGraph labelGraph) {

            this._sourceBuffer = buffer;
            this._aggregator = aggregator;
            this._labelGraph = labelGraph;
            this._asmDudeTools = IntrinsicsDudeTools.Instance;
        }

        /// <summary>
        /// Determine which pieces of Quickinfo content should be displayed
        /// </summary>
        public void AugmentQuickInfoSession(IQuickInfoSession session, IList<object> quickInfoContent, out ITrackingSpan applicableToSpan) {
            applicableToSpan = null;
            try {
                DateTime time1 = DateTime.Now;

                ITextSnapshot snapshot = _sourceBuffer.CurrentSnapshot;
                var triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
                if (triggerPoint == null) {
                    return;
                }
                string keyword = "";

                IEnumerable<IMappingTagSpan<AsmTokenTag>> enumerator = this._aggregator.GetTags(new SnapshotSpan(triggerPoint, triggerPoint));

                if (enumerator.Count() > 0) {
                    
                    if (false) {
                        // TODO: multiple tags at the provided triggerPoint is most likely the result of a bug in AsmTokenTagger, but it seems harmless...
                        if (enumerator.Count() > 1) {
                            foreach (IMappingTagSpan<AsmTokenTag> v in enumerator) {
                                IntrinsicsDudeToolsStatic.Output(string.Format("WARNING: {0}:AugmentQuickInfoSession. more than one tag! \"{1}\"", this.ToString(), v.Span.GetSpans(_sourceBuffer).First().GetText()));
                            }
                        }
                    }

                    IMappingTagSpan<AsmTokenTag> asmTokenTag = enumerator.First();
                    SnapshotSpan tagSpan = asmTokenTag.Span.GetSpans(_sourceBuffer).First();
                    keyword = tagSpan.GetText();

                    //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:AugmentQuickInfoSession. keyword=\"{1}\"", this.ToString(), keyword));
                    string keywordUpper = keyword.ToUpper();
                    applicableToSpan = snapshot.CreateTrackingSpan(tagSpan, SpanTrackingMode.EdgeExclusive);

                    TextBlock description = null;

                    switch (asmTokenTag.Tag.type) {
                        case AsmTokenType.Misc: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Keyword "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Misc));

                                string descr = this._asmDudeTools.getDescription(keywordUpper);
                                if (descr.Length > 0) {
                                    description.Inlines.Add(new Run(AsmSourceTools.linewrap(": " + descr, IntrinsicsDudePackage2.maxNumberOfCharsInToolTips)));
                                }
                                break;
                            }
                        case AsmTokenType.Directive: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Directive "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Directive));

                                string descr = this._asmDudeTools.getDescription(keywordUpper);
                                if (descr.Length > 0) {
                                    description.Inlines.Add(new Run(AsmSourceTools.linewrap(": " + descr, IntrinsicsDudePackage2.maxNumberOfCharsInToolTips)));
                                }
                                break;
                            }
                        case AsmTokenType.Register: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Register "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Register));

                                string descr = this._asmDudeTools.getDescription(keywordUpper);
                                if (descr.Length > 0) {
                                    description.Inlines.Add(new Run(AsmSourceTools.linewrap(": " + descr, IntrinsicsDudePackage2.maxNumberOfCharsInToolTips)));
                                }
                                break;
                            }
                        case AsmTokenType.Mnemonic: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Mnemonic "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Opcode));

                                string descr = this._asmDudeTools.mnemonicStore.getDescription(AsmSourceTools.parseMnemonic(keywordUpper));
                                if (descr.Length > 0) {
                                    description.Inlines.Add(new Run(AsmSourceTools.linewrap(": " + descr, IntrinsicsDudePackage2.maxNumberOfCharsInToolTips)));
                                }
                                break;
                            }
                        case AsmTokenType.Jump: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Mnemonic "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Jump));

                                string descr = this._asmDudeTools.getDescription(keywordUpper);
                                if (descr.Length > 0) {
                                    description.Inlines.Add(new Run(AsmSourceTools.linewrap(": " + descr, IntrinsicsDudePackage2.maxNumberOfCharsInToolTips)));
                                }
                                break;
                            }
                        case AsmTokenType.Label: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Label "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Label));

                                string descr = this.getLabelDescription(keyword);
                                if (descr.Length > 0) {
                                    description.Inlines.Add(new Run(AsmSourceTools.linewrap(": " + descr, IntrinsicsDudePackage2.maxNumberOfCharsInToolTips)));
                                }
                                break;
                            }
                        case AsmTokenType.LabelDef: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Label "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Label));

                                string descr = this.getLabelDefDescription(keyword);
                                if (descr.Length > 0) {
                                    description.Inlines.Add(new Run(AsmSourceTools.linewrap(": " + descr, IntrinsicsDudePackage2.maxNumberOfCharsInToolTips)));
                                }
                                break;
                            }
                        case AsmTokenType.Constant: {
                                description = new TextBlock();
                                description.Inlines.Add(makeRun1("Constant "));
                                description.Inlines.Add(makeRun2(keyword, Settings.Default.SyntaxHighlighting_Constant));
                                break;
                            }
                        default:
                            //description = new TextBlock();
                            //description.Inlines.Add(makeRun1("Unused tagType " + asmTokenTag.Tag.type));
                            break;
                    }
                    if (description != null) {
                        description.FontSize = IntrinsicsDudeToolsStatic.getFontSize() + 2;
                        description.FontFamily = IntrinsicsDudeToolsStatic.getFontType();
                        //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:AugmentQuickInfoSession; setting description fontSize={1}; fontFamily={2}", this.ToString(), description.FontSize, description.FontFamily));
                        quickInfoContent.Add(description);
                    }
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "QuickInfo");
            } catch (Exception e) {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:AugmentQuickInfoSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public void Dispose() {
            //empty
        }

        #region Private Methods

        private static Run makeRun1(string str) {
            Run r1 = new Run(str);
            r1.FontWeight = FontWeights.Bold;
            return r1;
        }

        private static Run makeRun2(string str, System.Drawing.Color color) {
            Run r1 = new Run(str);
            r1.FontWeight = FontWeights.Bold;
            r1.Foreground = new SolidColorBrush(IntrinsicsDudeToolsStatic.convertColor(color));
            return r1;
        }

        private string getLabelDescription(string label) {
            if (this._labelGraph.isEnabled) {
                StringBuilder sb = new StringBuilder();
                SortedSet<uint> labelDefs = this._labelGraph.getLabelDefLineNumbers(label);
                if (labelDefs.Count > 1) {
                    sb.AppendLine("");
                }
                foreach (uint id in labelDefs) {
                    int lineNumber = this._labelGraph.getLinenumber(id);
                    string filename = Path.GetFileName(this._labelGraph.getFilename(id));
                    string lineContent;
                    if (this._labelGraph.isFromMainFile(id)) {
                        lineContent = " :" + this._sourceBuffer.CurrentSnapshot.GetLineFromLineNumber(lineNumber).GetText();
                    } else {
                        lineContent = "";
                    }
                    sb.AppendLine(IntrinsicsDudeToolsStatic.cleanup(string.Format("Defined at LINE {0} ({1}){2}", lineNumber + 1, filename, lineContent)));
                }
                string result = sb.ToString();
                return result.TrimEnd(Environment.NewLine.ToCharArray());
            } else {
                return "Label analysis is disabled";
            }
        }

        private string getLabelDefDescription(string label) {
            if (this._labelGraph.isEnabled) {
                SortedSet<uint> usage = this._labelGraph.labelUsedAtInfo(label);
                if (usage.Count > 0) {
                    StringBuilder sb = new StringBuilder();
                    if (usage.Count > 1) {
                        sb.AppendLine("");
                    }
                    foreach (uint id in usage) {
                        int lineNumber = this._labelGraph.getLinenumber(id);
                        string filename = Path.GetFileName(this._labelGraph.getFilename(id));
                        string lineContent;
                        if (this._labelGraph.isFromMainFile(id)) {
                            lineContent = " :" + this._sourceBuffer.CurrentSnapshot.GetLineFromLineNumber(lineNumber).GetText();
                        } else {
                            lineContent = "";
                        }
                        sb.AppendLine(IntrinsicsDudeToolsStatic.cleanup(string.Format("Used at LINE {0} ({1}){2}", lineNumber + 1, filename, lineContent)));
                        //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:getLabelDefDescription; sb=\"{1}\"", this.ToString(), sb.ToString()));
                    }
                    string result = sb.ToString();
                    return result.TrimEnd(Environment.NewLine.ToCharArray());
                } else {
                    return "Not used";
                }
            } else {
                return "Label analysis is disabled";
            }
        }

        #endregion Private Methods
    }
}

