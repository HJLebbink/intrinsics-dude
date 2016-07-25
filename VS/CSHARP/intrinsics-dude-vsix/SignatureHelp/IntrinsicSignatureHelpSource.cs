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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using IntrinsicsDude.Tools;
using AsmTools;
using System.Text;

namespace IntrinsicsDude.SignatureHelp {

    internal class AsmSignatureHelpSource : ISignatureHelpSource {
        private readonly ITextBuffer _buffer;
        private readonly IntrinsicsStore _store;

        public AsmSignatureHelpSource(ITextBuffer buffer) {
            IntrinsicsDudeToolsStatic.Output("INFO: AsmSignatureHelpSource:constructor");
            this._buffer = buffer;
            this._store = IntrinsicsDudeTools.Instance.mnemonicStore;
        }

        /// <summary>
        /// Constrain the list of signatures given: 1) the currently operands provided by the user; and 2) the selected architectures
        /// </summary>
        /// <param name="data"></param>
        /// <param name="operands"></param>
        /// <returns></returns>
        public static IList<IntrinsicsSignatureElement> constrainSignatures(
                IList<IntrinsicsSignatureElement> data,
                IList<Operand> operands,
                ISet<Arch> selectedArchitectures) {

            IList<IntrinsicsSignatureElement> list = new List<IntrinsicsSignatureElement>();
            foreach (IntrinsicsSignatureElement asmSignatureElement in data) {
                bool allowed = true;

                //1] constrain on architecture
                if (!asmSignatureElement.isAllowed(selectedArchitectures)) {
                    allowed = false;
                }

                //2] constrain on operands
                if (allowed) {
                    if ((operands == null) || (operands.Count == 0)) {
                        // do nothing
                    } else {
                        for (int i = 0; i < operands.Count; ++i) {
                            Operand operand = operands[i];
                            if (operand != null) {
                                if (!asmSignatureElement.isAllowed(operand, i)) {
                                    allowed = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (allowed) list.Add(asmSignatureElement);
            }
            return list;
        }

        public void AugmentSignatureHelpSession(ISignatureHelpSession session, IList<ISignature> signatures) {
            IntrinsicsDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: AugmentSignatureHelpSession");

            //if (true) return;
            //if (!Settings.Default.SignatureHelp_On) return;

            try {
                DateTime time1 = DateTime.Now;
                ITextSnapshot snapshot = this._buffer.CurrentSnapshot;
                int position = session.GetTriggerPoint(_buffer).GetPosition(snapshot);
                ITrackingSpan applicableToSpan = _buffer.CurrentSnapshot.CreateTrackingSpan(new Span(position, 0), SpanTrackingMode.EdgeInclusive, 0);

                ITextSnapshotLine line = snapshot.GetLineFromPosition(position);
                string lineStr = line.GetText();
                //AsmDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: AugmentSignatureHelpSession: lineStr=" + lineStr+ "; positionInLine=" + positionInLine);

                var t = AsmSourceTools.parseLine(lineStr);
                IList<Operand> operands = AsmSourceTools.makeOperands(t.Item3);
                Mnemonic mnemonic = t.Item2;

                /*
                ISet<Arch> selectedArchitectures = IntrinsicsDudeToolsStatic.getArchSwithedOn();
                //AsmDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: AugmentSignatureHelpSession: selected architectures=" + ArchTools.ToString(selectedArchitectures));

                foreach (IntrinsicsSignatureElement se in AsmSignatureHelpSource.constrainSignatures(this._store.getSignatures(mnemonic), operands, selectedArchitectures)) {
                    signatures.Add(this.createSignature(_buffer, se, applicableToSpan));
                }
                */
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Signature Help");
            } catch (Exception e) {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:AugmentSignatureHelpSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public ISignature GetBestMatch(ISignatureHelpSession session) {
            IntrinsicsDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: GetBestMatch");

            if (session.Signatures.Count > 0) {
                ITrackingSpan applicableToSpan = session.Signatures[0].ApplicableToSpan;
                string text = applicableToSpan.GetText(applicableToSpan.TextBuffer.CurrentSnapshot).Trim().ToUpper();

                IntrinsicsDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: GetBestMatch: session.Signatures.Count=" + session.Signatures.Count);
                /*
                if (text.Equals("ADD")) {
                    return session.Signatures[0];
                } else if (text.Equals("AND")) {
                    return session.Signatures[0];
                }
                */
            }
            return null;
        }

        private IntrinsicsSignature createSignature(ITextBuffer textBuffer, IntrinsicsSignatureElement signatureElement, ITrackingSpan span) {
            int nOperands = signatureElement.operands.Count;
            Span[] locus = new Span[nOperands];

            StringBuilder sb = new StringBuilder();
            sb.Append(signatureElement.mnemonic.ToString());
            sb.Append(" ");
            //IntrinsicsDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: createSignature: sb=" + sb.ToString());

            for (int i = 0; i < nOperands; ++i) {
                int locusStart = sb.Length;
                sb.Append(signatureElement.getOperandDoc(i));
                //AsmDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: createSignature: i="+i+"; sb=" + sb.ToString());
                locus[i] = new Span(locusStart, sb.Length - locusStart);
                if (i < nOperands - 1) sb.Append(", ");
            }

            sb.Append(ArchTools.ToString(signatureElement.arch));
            IntrinsicsSignature sig = new IntrinsicsSignature(textBuffer, sb.ToString(), signatureElement.documentation, null);
            textBuffer.Changed += new EventHandler<TextContentChangedEventArgs>(sig.OnSubjectBufferChanged);

            List<IParameter> paramList = new List<IParameter>();
            for (int i = 0; i < nOperands; ++i) {
                string documentation = IntrinsicsSignatureElement.makeDoc(signatureElement.operands[i]);
                string operandName = signatureElement.getOperandStr(i);
                paramList.Add(new IntrinsicsParameter(documentation, locus[i], operandName, sig));
            }

            sig.Parameters = new ReadOnlyCollection<IParameter>(paramList);
            sig.ApplicableToSpan = span;
            sig.computeCurrentParameter();
            return sig;
        }

        private bool _isDisposed;
        public void Dispose() {
            if (!_isDisposed) {
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
    }
}