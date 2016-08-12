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
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using IntrinsicsDude.Tools;


namespace IntrinsicsDude.SignHelp
{
    internal sealed class IntrSignHelpSource : ISignatureHelpSource
    {
        private readonly ITextBuffer m_textBuffer;
        private readonly IntrinsicStore _store;
        private readonly IList<IntrSign> _signatures;

        private readonly IDictionary<ITextBuffer, EventHandler<TextContentChangedEventArgs>> _eventHandlers;

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
                SnapshotPoint triggerPoint = session.GetTriggerPoint(this.m_textBuffer).GetPoint(snapshot) - 1;
                int triggerPointInt = triggerPoint.Position;

                Tuple<Intrinsic, int, ITrackingSpan> tup = IntrinsicTools.getCurrentIntrinsicAndParamIndex(snapshot, triggerPointInt);
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession: triggerPoint=" + triggerPointInt + "; char='" + triggerPoint.GetChar() + "'; Intrinsic=" + tup.Item1 + "(" + tup.Item2 + "); startPos="+tup.Item3.GetStartPoint(snapshot).Position);

                Intrinsic intrinsic = tup.Item1;
                int paramIndex = tup.Item2;

                if (intrinsic == Intrinsic.NONE) {
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrSignHelpSource: AugmentSignatureHelpSession: no intrinsic found at triggerPoint=" + triggerPointInt+ "; char='" + triggerPoint.GetChar() + "'.");
                    return;
                }

                IList<IntrinsicDataElement> dataElements = this._store.get(intrinsic);
                if (dataElements.Count == 0) {
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrSignHelpSource: AugmentSignatureHelpSession: no dataElements for intrinsic " + intrinsic);
                    return;
                }

                if (signatures.Count > 0)
                {
                    IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession: removing existing signatures " + signatures[0].Content);
                    signatures.Clear();
                }

                foreach (IntrinsicDataElement dataElement in dataElements)
                {
                    if (IntrinsicsDudeToolsStatic.getCpuIDSwithedOn().HasFlag(dataElement.cpuID))
                    {
                        signatures.Add(this.CreateSignature(this.m_textBuffer, dataElement, paramIndex, tup.Item3));
                        session.Dismissed += Session_Dismissed;
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
                    int triggerPointInt = triggerPoint.Value.Position;
                    Tuple<Intrinsic, int, ITrackingSpan> tup = IntrinsicTools.getCurrentIntrinsicAndParamIndex(snapshot, triggerPointInt);
                    IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch: triggerPoint=" + triggerPointInt + "; char='" + triggerPoint.Value.GetChar() + "'; Intrinsic=" + tup.Item1 + "(" + tup.Item2 + "); startPos=" + tup.Item3.GetStartPoint(snapshot).Position);

                    Intrinsic intrinsic = tup.Item1;
                    if (intrinsic != Intrinsic.NONE)
                    {
                        return session.Signatures[0];
                    }
                }
            }
            IntrinsicsDudeToolsStatic.Output("WARNING: IntrSignHelpSource: GetBestMatch: could not find intrinsic.");
            return null;
        }

        #region Private Methods

        private IntrSign CreateSignature(ITextBuffer textBuffer, IntrinsicDataElement dataElement, int paramIndex, ITrackingSpan span)
        {
            int nParameters = dataElement.parameters.Count;
            Span[] locus = new Span[nParameters];

            #region Create Signature Text
            StringBuilder signatureText = new StringBuilder();
            signatureText.Append(IntrinsicTools.ToString(dataElement.returnType));
            signatureText.Append(" ");
            signatureText.Append(dataElement.intrinsic.ToString().ToLower());
            signatureText.Append("(");

            for (int i = 0; i < nParameters; ++i)
            {
                int locusStart = signatureText.Length;
                signatureText.Append(IntrinsicTools.ToString(dataElement.parameters[i].Item1).ToLower());
                signatureText.Append(" ");
                signatureText.Append(dataElement.parameters[i].Item2);
                locus[i] = new Span(locusStart, signatureText.Length - locusStart);
                if (i < nParameters - 1) signatureText.Append(", ");
            }
            signatureText.Append(")  [");
            signatureText.Append(IntrinsicTools.ToString(dataElement.cpuID));
            signatureText.Append("]");
            #endregion Create Signature Text

            IntrSign sig = new IntrSign(textBuffer, signatureText.ToString(), dataElement.description, null);

            #region Update Event Handling
            this._signatures.Add(sig);

            if (this._eventHandlers.ContainsKey(textBuffer)) {
                textBuffer.Changed -= this._eventHandlers[textBuffer];
                this._eventHandlers.Remove(textBuffer);
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: createSignature: removing old event handler");
            }

            EventHandler<TextContentChangedEventArgs> handler = new EventHandler<TextContentChangedEventArgs>(sig.OnSubjectBufferChanged1);
            textBuffer.Changed += handler;
            this._eventHandlers.Add(textBuffer, handler); // store the handler such that it can be removed once the session is dismissed
            #endregion

            List<IParameter> paramList = new List<IParameter>();
            for (int i = 0; i < nParameters; ++i)
            {
                string operandType = IntrinsicTools.ToString(dataElement.parameters[i].Item1);
                string operandName = dataElement.parameters[i].Item2;
                string documentation = operandType;
                paramList.Add(new IntrParam(documentation, locus[i], operandType + " " + operandName, sig));
            }

            sig.Parameters = new ReadOnlyCollection<IParameter>(paramList);
            sig.ApplicableToSpan = span;
            sig.SetCurrentParameter(paramIndex, false);
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

            foreach (IntrSign signature in this._signatures)
            {
                signature.cleanup();
            }
            this._signatures.Clear();
        }

        private void Session_Dismissed(object sender, EventArgs e)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: Session_Dismissed:" +debugInfo((ISignatureHelpSession)sender));
            cleanup();
        }

        private string debugInfo(ISignatureHelpSession session)
        {
            return "triggerPoint=" + session.GetTriggerPoint(session.TextView.TextBuffer).GetPosition(session.TextView.TextSnapshot) + "; char='" + session.GetTriggerPoint(session.TextView.TextBuffer).GetCharacter(session.TextView.TextSnapshot)+"'.";
        }

        #endregion

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