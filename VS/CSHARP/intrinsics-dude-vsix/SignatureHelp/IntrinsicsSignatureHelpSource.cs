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

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using IntrinsicsDude.Tools;
using System.Text;
using System.Collections.ObjectModel;

namespace IntrinsicsDude.SignatureHelp
{
    internal class IntrinsicsSignatureHelpSource : ISignatureHelpSource
    {
        private readonly ITextBuffer _buffer;
        private readonly IntrinsicStore _store;

        public IntrinsicsSignatureHelpSource(ITextBuffer buffer)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsSignatureHelpSource: constructor");
            this._buffer = buffer;
            this._store = IntrinsicsDudeTools.Instance.intrinsicStore;
        }

        public void AugmentSignatureHelpSession(ISignatureHelpSession session, IList<ISignature> signatures)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsSignatureHelpSource: AugmentSignatureHelpSession");
            if (!Settings.Default.SignatureHelp_On) return;

            try
            {
                DateTime time1 = DateTime.Now;

                ITextSnapshot snapshot = this._buffer.CurrentSnapshot;
                int triggerPoint = session.GetTriggerPoint(_buffer).GetPosition(snapshot) - 1; // TODO why the minus 1?
                Intrinsic intrinsic = IntrinsicsSignatureHelpCommandFilter.getCurrentIntrinsic(snapshot, triggerPoint, '(');
                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsSignatureHelpSource: AugmentSignatureHelpSession: intrinsic=" + intrinsic);

                IntrinsicDataElement dataElement = this._store.get(intrinsic);
                if (dataElement != null)
                {
                    if (IntrinsicsDudeToolsStatic.getCpuIDSwithedOn().HasFlag(dataElement.cpuID))
                    {
                        ITrackingSpan applicableToSpan = snapshot.CreateTrackingSpan(new Span(triggerPoint, 0), SpanTrackingMode.EdgeInclusive, 0);
                        signatures.Add(this.createSignature(_buffer, dataElement, applicableToSpan));
                    }
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Signature Help");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:AugmentSignatureHelpSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public ISignature GetBestMatch(ISignatureHelpSession session)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsSignatureHelpSource: GetBestMatch");

            if (session.Signatures.Count > 0)
            {
                ITrackingSpan applicableToSpan = session.Signatures[0].ApplicableToSpan;
                string text = applicableToSpan.GetText(applicableToSpan.TextBuffer.CurrentSnapshot).Trim();
                Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(text);
                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsSignatureHelpSource: GetBestMatch: session.Signatures.Count=" + session.Signatures.Count+ "; intrinsic="+ intrinsic);
                if (intrinsic != Intrinsic.NONE)
                {
                    return session.Signatures[0];
                }
            }
            return null;
        }

        private IntrinsicSignature createSignature(ITextBuffer textBuffer, IntrinsicDataElement dataElement, ITrackingSpan span)
        {
            int nParameters = dataElement.parameters.Count;
            Span[] locus = new Span[nParameters];

            StringBuilder sb = new StringBuilder();
            sb.Append(dataElement.intrinsic.ToString());
            sb.Append("(");
            //AsmDudeToolsStatic.Output("INFO: AsmSignatureHelpSource: createSignature: sb=" + sb.ToString());

            for (int i = 0; i < nParameters; ++i)
            {
                int locusStart = sb.Length;
                sb.Append(IntrinsicTools.ToString(dataElement.parameters[i].Item1));
                sb.Append(dataElement.parameters[i].Item2);
                locus[i] = new Span(locusStart, sb.Length - locusStart);
                if (i < nParameters - 1) sb.Append(", ");
            }

            sb.Append(IntrinsicTools.ToString(dataElement.cpuID));
            IntrinsicSignature sig = new IntrinsicSignature(textBuffer, sb.ToString(), dataElement.description, null);
            textBuffer.Changed += new EventHandler<TextContentChangedEventArgs>(sig.OnSubjectBufferChanged);

            List<IParameter> paramList = new List<IParameter>();
            for (int i = 0; i < nParameters; ++i)
            {
                //string documentation = AsmSignatureElement.makeDoc(dataElement.operands[i]);
                string documentation = "TODO";
                string operandName = dataElement.parameters[i].Item2;
                paramList.Add(new IntrinsicParameter(documentation, locus[i], operandName, sig));
            }

            sig.Parameters = new ReadOnlyCollection<IParameter>(paramList);
            sig.ApplicableToSpan = span;
            sig.computeCurrentParameter();
            return sig;
        }

        private bool _isDisposed;
        public void Dispose()
        {
            if (!_isDisposed)
            {
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
    }
}