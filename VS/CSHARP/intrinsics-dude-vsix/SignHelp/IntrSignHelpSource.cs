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

namespace IntrinsicsDude.SignHelp
{
    internal sealed class IntrSignHelpSource : ISignatureHelpSource
    {
        private readonly ITextBuffer m_textBuffer;
        private readonly IntrinsicStore _store;
        private readonly IList<IntrSign> _signatures;

        private readonly IDictionary<ITextBuffer, EventHandler<TextContentChangedEventArgs>> _eventHandlers;
        //private readonly IDictionary<ITextBuffer, EventHandler> _eventHandlers2;

        public IntrSignHelpSource(ITextBuffer buffer)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: constructor");
            this.m_textBuffer = buffer;
            this._store = IntrinsicsDudeTools.Instance.intrinsicStore;

            this._eventHandlers = new Dictionary<ITextBuffer, EventHandler<TextContentChangedEventArgs>>();
            this._signatures = new List<IntrSign>();
        }

        public void AugmentSignatureHelpSession(ISignatureHelpSession session, IList<ISignature> signatures)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession");
            if (!Settings.Default.SignatureHelp_On) return;

            try
            {
                DateTime time1 = DateTime.Now;

                ITextSnapshot snapshot = this.m_textBuffer.CurrentSnapshot;
                int triggerPoint = session.GetTriggerPoint(this.m_textBuffer).GetPosition(snapshot) - 1;

                Tuple<Intrinsic, int> tup = IntrinsicTools.getCurrentIntrinsicAndParamIndex(snapshot, triggerPoint);
                Intrinsic intrinsic = tup.Item1;
                int paramIndex = tup.Item2;

                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession: triggerPoint="+ triggerPoint + "; intrinsic=" + intrinsic+ "; paramIndex=" + paramIndex);

                IntrinsicDataElement dataElement = this._store.get(intrinsic);
                if (dataElement != null)
                {
                    if (true)
                    // if (IntrinsicsDudeToolsStatic.getCpuIDSwithedOn().HasFlag(dataElement.cpuID)) //TODO
                    {
                        ITrackingSpan applicableToSpan = snapshot.CreateTrackingSpan(new Span(triggerPoint, 0), SpanTrackingMode.EdgeInclusive, TrackingFidelityMode.Forward);
                        signatures.Add(this.CreateSignature(this.m_textBuffer, dataElement, applicableToSpan));
                        //session.Dismissed += Session_Dismissed;
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
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch");
            int nSignatures = session.Signatures.Count;
            if (nSignatures > 0)
            {
                ITextSnapshot snapshot = session.Signatures[0].ApplicableToSpan.TextBuffer.CurrentSnapshot;
                SnapshotPoint? triggerPoint = session.GetTriggerPoint(snapshot);
                if (triggerPoint.HasValue)
                {
                    Intrinsic intrinsic = IntrinsicTools.getCurrentIntrinsicAndParamIndex(snapshot, triggerPoint.Value - 1).Item1;
                    if (intrinsic != Intrinsic.NONE)
                    {
                        if (nSignatures > 1)
                        {
                            for (int i = 0; i < nSignatures; ++i)
                            {
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch: signature " + i + ": Content=\"" + session.Signatures[i].Content + "\".");
                            }
                        }
                        return session.Signatures[0];
                    }
                    else
                    {
                        IntrinsicsDudeToolsStatic.Output("WARNING: IntrSignHelpSource: GetBestMatch: could not find intrinsic.");
                    }
                }
            }
            return null;
        }

        private IntrSign CreateSignature(ITextBuffer textBuffer, IntrinsicDataElement dataElement, ITrackingSpan span)
        {
            int nParameters = dataElement.parameters.Count;
            Span[] locus = new Span[nParameters];

            StringBuilder sb = new StringBuilder();
            sb.Append(dataElement.intrinsic.ToString());
            sb.Append("(");

            for (int i = 0; i < nParameters; ++i)
            {
                int locusStart = sb.Length;
                sb.Append(IntrinsicTools.ToString(dataElement.parameters[i].Item1));
                sb.Append(" ");
                sb.Append(dataElement.parameters[i].Item2);
                locus[i] = new Span(locusStart, sb.Length - locusStart);
                if (i < nParameters - 1) sb.Append(", ");
            }
            sb.Append(")  [");
            sb.Append(IntrinsicTools.ToString(dataElement.cpuID));
            sb.Append("]");

            IntrSign sig = new IntrSign(textBuffer, sb.ToString(), dataElement.description, null);
            this._signatures.Add(sig);

            if (this._eventHandlers.ContainsKey(textBuffer)) {
                textBuffer.Changed -= this._eventHandlers[textBuffer];
                this._eventHandlers.Remove(textBuffer);
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: createSignature: removing old event handler");
            }

            EventHandler<TextContentChangedEventArgs> handler = new EventHandler<TextContentChangedEventArgs>(sig.OnSubjectBufferChanged1);
            //textBuffer.Changed += handler;
            this._eventHandlers.Add(textBuffer, handler); // store the handler such that it can be removed once the session is dismissed

            //EventHandler handler2 = new EventHandler(sig.OnSubjectBufferChanged2);
            //textBuffer.PostChanged += handler2;
            //this._eventHandlers2.Add(textBuffer, handler2); // store the handler such that it can be removed once the session is dismissed


            List<IParameter> paramList = new List<IParameter>();
            for (int i = 0; i < nParameters; ++i)
            {
                //string documentation = AsmSignatureElement.makeDoc(dataElement.operands[i]);
                string documentation = "TODO";
                string operandName = dataElement.parameters[i].Item2;
                paramList.Add(new IntrParam(documentation, locus[i], operandName, sig));
            }

            sig.Parameters = new ReadOnlyCollection<IParameter>(paramList);
            sig.ApplicableToSpan = span;
            sig.ComputeCurrentParameter();
            return sig;
        }

        private void cleanup()
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: cleanup");
            foreach (KeyValuePair<ITextBuffer, EventHandler<TextContentChangedEventArgs>> pair in this._eventHandlers)
            {
                pair.Key.Changed -= pair.Value;
            }
            this._eventHandlers.Clear();

            //foreach (KeyValuePair<ITextBuffer, EventHandler> pair in this._eventHandlers2)
            //{
            //    pair.Key.PostChanged -= pair.Value;
            //}
            //this._eventHandlers2.Clear();

            foreach (IntrSign signature in this._signatures)
            {
                signature.cleanup();
            }
            this._signatures.Clear();
        }

        private void Session_Dismissed(object sender, EventArgs e)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: Session_Dismissed");
            cleanup();
        }

        private bool _isDisposed;

        public void Dispose()
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: Dispose");
            if (!_isDisposed)
            {
                cleanup();
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
    }
}