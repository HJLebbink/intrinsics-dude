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
    using System.Diagnostics.Contracts;
    using System.Runtime.InteropServices;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Operations;
    using Microsoft.VisualStudio.TextManager.Interop;

    internal sealed class IntrSignatureHelpCommandFilter : IOleCommandTarget
    {
        private readonly ITextView _textView;
        private readonly ISignatureHelpBroker _broker;
        private readonly ITextStructureNavigator _navigator;

        private ISignatureHelpSession _session;
        private readonly IOleCommandTarget _nextCommandHandler;

        internal IntrSignatureHelpCommandFilter(IVsTextView textViewAdapter, ITextView textView, ITextStructureNavigator nav, ISignatureHelpBroker broker)
        {
            Contract.Requires(textViewAdapter != null);
            Contract.Requires(textView != null);
            Contract.Requires(nav != null);
            Contract.Requires(broker != null);

            this._textView = textView ?? throw new ArgumentNullException(nameof(textView));
            this._broker = broker ?? throw new ArgumentNullException(nameof(broker));
            this._navigator = nav ?? throw new ArgumentNullException(nameof(nav));

            if (Settings.Default.SignatureHelp_On)
            {
                //add this to the filter chain
                textViewAdapter.AddCommandFilter(this, out this._nextCommandHandler);
            }
            else
            {
                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:constructor: signature help is switched off", this.ToString()));
            }
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            //IntrinsicsDudeToolsStatic.Output_INFO("IntrSignHelpCommandHandler: Exec");
            ThreadHelper.ThrowIfNotOnUIThread();
            try
            {
                if (Settings.Default.SignatureHelp_On)
                {
                    if ((pguidCmdGroup == VSConstants.VSStd2K) && (nCmdID == (uint)VSConstants.VSStd2KCmdID.TYPECHAR))
                    {
                        {
                            char typedChar = GetTypeChar(pvaIn);
                            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: typed char='" + typedChar + "'.");

                            if (typedChar.Equals('('))
                            {
                                SnapshotPoint point = this._textView.Caret.Position.BufferPosition - 1; //move the point back so it's in the preceding word
                                string word = this._navigator.GetExtentOfWord(point).Span.GetText();
                                bool is_capitals = false;
                                bool warn = false;
                                Intrinsic intrinsic = IntrinsicTools.ParseIntrinsic(word, is_capitals, warn);
                                //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: after '(', word=\"" + word + "\"; intrinsic=" + intrinsic);
                                if (intrinsic != Intrinsic.NONE)
                                {
                                    if ((this._session != null) && (!this._session.IsDismissed))
                                    {
                                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: dismissing session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                                        this._session.Dismiss();
                                    }

                                    this._session = this._broker.CreateSignatureHelpSession(this._textView, this._textView.TextSnapshot.CreateTrackingPoint(point + 1, PointTrackingMode.Positive), true);
                                    this._session.Dismissed += (sender, args) => this._session = null;
                                    this._session.Start();
                                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: started a new session(" + m_session.GetTriggerPoint(m_textView.TextBuffer)+")");
                                }
                            }

                            if (typedChar.Equals(','))
                            {
                                SnapshotPoint point = this._textView.Caret.Position.BufferPosition - 1; //move the point back so it's in the preceding word
                                Tuple<Intrinsic, int> tup = IntrinsicTools.GetIntrinsicAndParamIndex(point, this._navigator);
                                Intrinsic intrinsic = tup.Item1;
                                //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: after ',', intrinsic=" + intrinsic);
                                if (intrinsic != Intrinsic.NONE)
                                {
                                    if ((this._session != null) && (!this._session.IsDismissed))
                                    {
                                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: dismissing session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                                        this._session.Dismiss();
                                    }

                                    this._session = this._broker.CreateSignatureHelpSession(this._textView, this._textView.TextSnapshot.CreateTrackingPoint(point + 1, PointTrackingMode.Positive), true);
                                    this._session.Dismissed += (sender, args) => this._session = null;
                                    this._session.Start();
                                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: started a new session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                                }
                            }
                            else if ((typedChar.Equals(')') || typedChar.Equals(';') || typedChar.Equals('=')) && (this._session != null))
                            {
                                //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: going to close the session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                                this._session.Dismiss();
                                this._session = null;
                            }
                        }
                    }
                }
                else
                {
                    IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:Exec: signature help is switched off", this.ToString()));
                }
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:Exec; e={1}", this.ToString(), e.ToString()));
            }

            return this._nextCommandHandler.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            return this._nextCommandHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        #region Private Stuff

        private static char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }

        #endregion
    }
}
