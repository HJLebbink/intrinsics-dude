// The MIT License (MIT)
//
// Copyright (c) 2019 Henk-Jan Lebbink
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace IntrinsicsDude.SignHelp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Text;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Operations;

    internal sealed class IntrSignatureHelpSource : ISignatureHelpSource
    {
        private readonly ITextBuffer _textBuffer;
        private readonly ITextStructureNavigator _navigator;

        // see https://msdn.microsoft.com/en-us/library/dd885244.aspx for help
        public IntrSignatureHelpSource(ITextBuffer buffer, ITextStructureNavigator nav)
        {
            Contract.Requires(buffer != null);
            Contract.Requires(nav != null);

            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:constructor", this.ToString()));
            this._textBuffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            this._navigator = nav ?? throw new ArgumentNullException(nameof(nav));
        }

        public void AugmentSignatureHelpSession(ISignatureHelpSession session, IList<ISignature> signatures)
        {
            Contract.Requires(session != null);
            Contract.Requires(signatures != null);
            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:AugmentSignatureHelpSession", this.ToString()));

            if (!Settings.Default.SignatureHelp_On)
            {
                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:AugmentSignatureHelpSession: signature help is switched off", this.ToString()));
                return;
            }

            try
            {
                //if (signatures.Count > 0)
                //    signatures.Clear();
                //    return;
                //}

                DateTime time1 = DateTime.Now;

                ITextSnapshot snapshot = this._textBuffer.CurrentSnapshot;
                int triggerPosition = session.GetTriggerPoint(this._textBuffer).GetPosition(snapshot);

                SnapshotPoint point = new SnapshotPoint(snapshot, triggerPosition - 1);
                TextExtent extent = this._navigator.GetExtentOfWord(point);
                if (extent.IsSignificant)
                {
                    string text = extent.Span.GetText();

                    IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}: AugmentSignatureHelpSession: session({1}; text =\"{2}\".", this.ToString(), session.GetTriggerPoint(this._textBuffer), text));

                    // this method is called either:
                    // 1] when opening parenthesis "(" is typed after an intrinsic function, or
                    // 2] when an comma "," is typed as an parameter separator in an intrinsic function.

                    Intrinsic intrinsic = IntrinsicTools.ParseIntrinsic(text, false);
                    int paramIndex = 0;

                    if (intrinsic == Intrinsic.NONE)
                    {
                        Tuple<Intrinsic, int> tup = IntrinsicTools.GetIntrinsicAndParamIndex(point, this._navigator);
                        IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:AugmentSignatureHelpSession: session({1}); intrinsic = {2}, ({3})", this.ToString(), session.GetTriggerPoint(this._textBuffer), tup.Item1, tup.Item2));
                        intrinsic = tup.Item1;
                        paramIndex = tup.Item2 + 1; // add one because the current typed char was an comma.
                    }

                    if (intrinsic == Intrinsic.NONE)
                    {
                        IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:AugmentSignatureHelpSession: session({1}); no intrinsic found at triggerPosition={2}; char= '{3}'.", this.ToString(), session.GetTriggerPoint(this._textBuffer), triggerPosition, snapshot.GetText(triggerPosition, 1)));
                        return;
                    }

                    // ugly hack to get rid of unwanted session generated by existing intrinsic functions
                    if (signatures.Count > 0)
                    {
                        IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:AugmentSignatureHelpSession: emptying unwanted session({1})", this.ToString(), session.GetTriggerPoint(this._textBuffer)));
                        signatures.Clear();
                        return;
                    }

                    IList<IntrinsicDataElement> dataElements = IntrinsicsDudeTools.Instance.IntrinsicStore.Get(intrinsic);
                    if (dataElements.Count == 0)
                    {
                        IntrinsicsDudeToolsStatic.Output_WARNING(string.Format("{0}:AugmentSignatureHelpSession: session({1}); no dataElements for intrinsic {2}.", this.ToString(), session.GetTriggerPoint(this._textBuffer), intrinsic));
                    }
                    else
                    {
                        ITrackingSpan applicableToSpan = this._textBuffer.CurrentSnapshot.CreateTrackingSpan(new Span(triggerPosition, 0), SpanTrackingMode.EdgeInclusive, 0);
                        foreach (IntrinsicDataElement dataElement in dataElements)
                        {
                            signatures.Add(this.CreateSignature(this._textBuffer, dataElement, paramIndex, applicableToSpan));
                        }
                    }

                    IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "Signature Help");
                }
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:AugmentSignatureHelpSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public ISignature GetBestMatch(ISignatureHelpSession session)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch");
            int nSignatures = session.Signatures.Count;
            if (nSignatures > 0)
            {
                //ITrackingSpan applicableToSpan = session.Signatures[0].ApplicableToSpan;
                //string text = applicableToSpan.GetText(applicableToSpan.TextBuffer.CurrentSnapshot);
                //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: GetBestMatch: text " + text +"; returning signature "+session.Signatures[0].Content);
                return session.Signatures[0];
            }

            IntrinsicsDudeToolsStatic.Output_WARNING("IntrSignHelpSource:GetBestMatch: could not find intrinsic.");
            return null;
        }

        #region Private Methods

        private IntrSignature CreateSignature(ITextBuffer textBuffer, IntrinsicDataElement dataElement, int paramIndex, ITrackingSpan span)
        {
            int nParameters = dataElement._parameters.Count;
            Span[] locus = new Span[nParameters];

            #region Create Signature Text
            StringBuilder signatureText = new StringBuilder();
            signatureText.Append(IntrinsicTools.ToString(dataElement._returnType));
            signatureText.Append(" ");
            signatureText.Append(dataElement._intrinsic.ToString().ToLower());
            signatureText.Append("(");

            for (int i = 0; i < nParameters; ++i)
            {
                int locusStart = signatureText.Length;
                signatureText.Append(IntrinsicTools.ToString(dataElement._parameters[i].Item1).ToLower());
                signatureText.Append(" ");
                signatureText.Append(dataElement._parameters[i].Item2);
                locus[i] = new Span(locusStart, signatureText.Length - locusStart);
                if (i < nParameters - 1)
                {
                    signatureText.Append(", ");
                }
            }

            signatureText.Append(")  [");
            signatureText.Append(IntrinsicTools.ToString(dataElement._cpuID));
            signatureText.Append("]");
            #endregion Create Signature Text

            string doc = IntrinsicTools.Linewrap(dataElement._description, IntrinsicsDudePackage.maxNumberOfCharsInToolTips);
            IntrSignature sig = new IntrSignature(textBuffer, signatureText.ToString(), doc, null);

            List<IParameter> paramList = new List<IParameter>();
            for (int i = 0; i < nParameters; ++i)
            {
                string operandType = IntrinsicTools.ToString(dataElement._parameters[i].Item1);
                string operandName = dataElement._parameters[i].Item2;
                string documentation = operandType;
                paramList.Add(new IntrParam(documentation, locus[i], operandType + " " + operandName, sig));
            }

            sig.Parameters = new ReadOnlyCollection<IParameter>(paramList);
            sig.ApplicableToSpan = span;
            sig.SetCurrentParameter(paramIndex);
            return sig;
        }

        #endregion

        private bool _isDisposed;

        public void Dispose()
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpSource: Dispose");
            if (!this._isDisposed)
            {
                GC.SuppressFinalize(this);
                this._isDisposed = true;
            }
        }
    }
}