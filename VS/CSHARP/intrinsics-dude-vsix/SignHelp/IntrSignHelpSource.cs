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
using Microsoft.VisualStudio.Text.Operations;

namespace IntrinsicsDude.SignHelp
{
    internal sealed class IntrSignHelpSource : ISignatureHelpSource
    {
        private readonly ITextBuffer m_textBuffer;
        private readonly ITextStructureNavigator m_navigator;

        public IntrSignHelpSource(ITextBuffer buffer, ITextStructureNavigator nav)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: constructor");
            this.m_textBuffer = buffer;
            this.m_navigator = nav;
        }

        public void AugmentSignatureHelpSession(ISignatureHelpSession session, IList<ISignature> signatures)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession");
            try
            {
                DateTime time1 = DateTime.Now;
                
                ITextSnapshot snapshot = this.m_textBuffer.CurrentSnapshot;
                int triggerPosition = session.GetTriggerPoint(m_textBuffer).GetPosition(snapshot);

                SnapshotPoint point = new SnapshotPoint(snapshot, triggerPosition - 1);
                string text = m_navigator.GetExtentOfWord(point).Span.GetText();
                IntrinsicsDudeToolsStatic.Output("WARNING: IntrSignHelpSource: AugmentSignatureHelpSession: text=" + text);

                Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(text);
                int paramIndex = 0;
                if (intrinsic == Intrinsic.NONE)
                {
                    Tuple<Intrinsic, int> tup = IntrinsicTools.getIntrinsicAndParamIndex(point, m_navigator);
                    IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession: triggerPosition=" + triggerPosition + "; Intrinsic=" + tup.Item1 + "(" + tup.Item2 + ")");
                    intrinsic = tup.Item1;
                    paramIndex = tup.Item2;
                }

                if (intrinsic == Intrinsic.NONE) {
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrSignHelpSource: AugmentSignatureHelpSession: no intrinsic found at triggerPosition=" + triggerPosition + "; char='" + snapshot.GetText(triggerPosition, 1) + "'.");
                    return;
                }

                IList<IntrinsicDataElement> dataElements = IntrinsicsDudeTools.Instance.intrinsicStore.get(intrinsic);
                if (dataElements.Count == 0) {
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrSignHelpSource: AugmentSignatureHelpSession: no dataElements for intrinsic " + intrinsic);
                    return;
                }

                if (signatures.Count > 0)
                {
                    IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession: removing existing signatures " + signatures[0].Content);
                    signatures.Clear();
                }

                ITrackingSpan applicableToSpan = m_textBuffer.CurrentSnapshot.CreateTrackingSpan(new Span(triggerPosition, 0), SpanTrackingMode.EdgeInclusive, 0);
                foreach (IntrinsicDataElement dataElement in dataElements)
                {
                    if (IntrinsicsDudeToolsStatic.getCpuIDSwithedOn().HasFlag(dataElement.cpuID))
                    {
                        IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: AugmentSignatureHelpSession : adding signature "+dataElement.intrinsic);
                        signatures.Add(this.CreateSignature(this.m_textBuffer, dataElement, paramIndex, applicableToSpan));
                    }
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Signature Help");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrSignHelpSource: AugmentSignatureHelpSession; e="+ e.ToString());
            }
        }

        public ISignature GetBestMatch(ISignatureHelpSession session)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch");
            int nSignatures = session.Signatures.Count;
            if (nSignatures > 0)
            {
                if (true)
                {
                    if (nSignatures > 1)
                    {
                        for (int i = 0; i < nSignatures; ++i)
                        {
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch: multiple signatures " + i + ": " + session.Signatures[i].Content);
                        }
                    }
                }
                ITrackingSpan applicableToSpan = session.Signatures[0].ApplicableToSpan;
                string text = applicableToSpan.GetText(applicableToSpan.TextBuffer.CurrentSnapshot);
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch: text " + text +"; returning signature "+session.Signatures[0].Content);

                return session.Signatures[0];
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
            textBuffer.Changed += new EventHandler<TextContentChangedEventArgs>(sig.OnSubjectBufferChanged);

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
            sig.SetCurrentParameter(paramIndex);
            return sig;
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
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
    }
}