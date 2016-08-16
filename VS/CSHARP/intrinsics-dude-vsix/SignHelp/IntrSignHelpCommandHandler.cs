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

using IntrinsicsDude.Tools;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Runtime.InteropServices;

namespace IntrinsicsDude.SignHelp
{
    internal sealed class IntrSignHelpCommandHandler : IOleCommandTarget
    {
        private readonly ITextView m_textView;
        private readonly ISignatureHelpBroker m_broker;
        private readonly ITextStructureNavigator m_navigator;

        private ISignatureHelpSession m_session;
        private IOleCommandTarget m_nextCommandHandler;

        internal IntrSignHelpCommandHandler(IVsTextView textViewAdapter, ITextView textView, ITextStructureNavigator nav, ISignatureHelpBroker broker)
        {
            this.m_textView = textView;
            this.m_broker = broker;
            this.m_navigator = nav;

            //add this to the filter chain
            textViewAdapter.AddCommandFilter(this, out this.m_nextCommandHandler);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec");
            try
            {
                if ((pguidCmdGroup == VSConstants.VSStd2K) && (nCmdID == (uint)VSConstants.VSStd2KCmdID.TYPECHAR))
                {
                    {
                        char typedChar = GetTypeChar(pvaIn);
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: typed char='" + typedChar + "'.");

                        if (typedChar.Equals('('))
                        {
                            SnapshotPoint point = m_textView.Caret.Position.BufferPosition - 1; //move the point back so it's in the preceding word
                            string word = m_navigator.GetExtentOfWord(point).Span.GetText();
                            Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(word);
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: after '(', word=\"" + word + "\"; intrinsic=" + intrinsic);
                            if (intrinsic != Intrinsic.NONE)
                            {
                                var allSessions = this.m_broker.GetSessions(m_textView);
                                if (allSessions.Count == 0)
                                {
                                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: no current sessions");
                                }
                                else
                                {
                                    foreach (var session in allSessions)
                                    {
                                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: current session(" + session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                                    }
                                }
                                if ((this.m_session != null) && (!this.m_session.IsDismissed))
                                {
                                    IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: dismissing session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                                    this.m_session.Dismiss();
                                }
                                this.m_session = this.m_broker.CreateSignatureHelpSession(this.m_textView, this.m_textView.TextSnapshot.CreateTrackingPoint(point + 1, PointTrackingMode.Positive), true);
                                this.m_session.Start();
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: started a new session(" + m_session.GetTriggerPoint(m_textView.TextBuffer)+")");
                            }
                        }
                        if (typedChar.Equals(','))
                        {
                            SnapshotPoint point = this.m_textView.Caret.Position.BufferPosition - 1; //move the point back so it's in the preceding word
                            Tuple<Intrinsic, int> tup = IntrinsicTools.getIntrinsicAndParamIndex(point, this.m_navigator);
                            Intrinsic intrinsic = tup.Item1;
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: after ',', intrinsic=" + intrinsic);
                            if (intrinsic != Intrinsic.NONE)
                            {
                                if ((this.m_session != null) && (!this.m_session.IsDismissed))
                                {
                                    IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: dismissing session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                                    this.m_session.Dismiss();
                                }
                                this.m_session = this.m_broker.CreateSignatureHelpSession(this.m_textView, this.m_textView.TextSnapshot.CreateTrackingPoint(point + 1, PointTrackingMode.Positive), true);
                                this.m_session.Start();
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: started a new session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                            }
                        }
                        else if ((typedChar.Equals(')') && (m_session != null)))
                        {
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: going to close the session(" + m_session.GetTriggerPoint(m_textView.TextBuffer) + ")");
                            this.m_session.Dismiss();
                            this.m_session = null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:Exec; e={1}", this.ToString(), e.ToString()));
            }
            return this.m_nextCommandHandler.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return m_nextCommandHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        #region Private Stuff
        /*
        private void TextBuffer_PostChanged(object sender, EventArgs e)
        {
            if (_scheduleStart)
            {
                lock (_startNewSessionLock)
                {
                    if (true)
                    {
                        int pos = this._textView.Caret.Position.BufferPosition.Position-1;
                        string typedChar = this._textView.TextBuffer.CurrentSnapshot.GetText(pos, 1);
                        IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: TextBuffer_PostChanged: pos = " + pos + "; typedChar='" + typedChar + "'.");
                    }
                    this.StartSession(this._textView.TextSnapshot, this._textView.Caret.Position.BufferPosition.Position);
                    this._scheduleStart = false;
                }
            }
        }

        private void TextBuffer_Changed(object sender, TextContentChangedEventArgs e)
        {
            if (_scheduleStart)
            {
                lock (_startNewSessionLock)
                {
                    this._scheduleStart = false;
                    if (true)
                    {
                        int oldPos = e.Changes[0].OldPosition;
                        int newPos = e.Changes[0].NewPosition;
                        string oldChar = e.Before.TextBuffer.CurrentSnapshot.GetText(oldPos, 1);
                        string newChar = e.After.TextBuffer.CurrentSnapshot.GetText(newPos, 1);
                        IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: TextBuffer_Changed: oldPos = " + oldPos + "; oldChar='" + oldChar + "'; newPos=" + newPos + "; newChar='" + newChar + "'.");
                    }
                    this.StartSession(e.After.TextBuffer.CurrentSnapshot, e.Changes[0].NewPosition);
                    //this.StartSession(this._textView.TextSnapshot, this._textView.Caret.Position.BufferPosition.Position);
                }
            }
        }
        */
        private void DismissSession(ISignatureHelpSession session)
        {
            if (session == null) return;
            try
            {
                if (session.IsDismissed)
                {
                    IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: DismissSession: session is already dismissed. "+debugInfo(session));
                    return;
                }

                string signatureStr = "no signatures";
                if (session.Signatures != null)
                {
                    if (session.Signatures.Count > 0)
                    {
                        signatureStr = session.Signatures[0].Content;
                    }
                }
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: DismissSession: dismissing session: signatureStr=\"" + signatureStr+ "\". " + debugInfo(session));
                session.Dismiss();
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:Exec; e={1}", this.ToString(), e.ToString()));
            }
        }

        private string debugInfo(ISignatureHelpSession session)
        {
            return "triggerPoint=" + session.GetTriggerPoint(session.TextView.TextBuffer).GetPosition(session.TextView.TextSnapshot) + "; char='" + session.GetTriggerPoint(session.TextView.TextBuffer).GetCharacter(session.TextView.TextSnapshot)+"'.";
        }

        private static char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }

        #endregion
    }
}
