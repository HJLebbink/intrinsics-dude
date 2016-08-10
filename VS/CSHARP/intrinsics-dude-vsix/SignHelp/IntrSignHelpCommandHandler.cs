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

using IntrinsicsDude.Tools;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Runtime.InteropServices;

namespace IntrinsicsDude.SignHelp
{
    internal sealed class IntrSignHelpCommandHandler : IOleCommandTarget
    {
        private readonly ITextView _textView;
        private readonly ISignatureHelpBroker _broker;

        private ISignatureHelpSession _session;
        private IOleCommandTarget _nextCommandHandler;

        private Object _startNewSessionLock = new Object();


        internal IntrSignHelpCommandHandler(IVsTextView textViewAdapter, ITextView textView, ISignatureHelpBroker broker)
        {
            this._textView = textView;
            this._broker = broker;

            //add this to the filter chain
            textViewAdapter.AddCommandFilter(this, out this._nextCommandHandler);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec");
            try
            {
                if ((pguidCmdGroup == VSConstants.VSStd2K) && (nCmdID == (uint)VSConstants.VSStd2KCmdID.TYPECHAR))
                {
                    //lock (_startNewSessionLock)
                    {
                        char typedChar = GetTypeChar(pvaIn);
                        if (typedChar.Equals('(') || typedChar.Equals(','))
                        {
                            this.StartSession();
                        }
                        else if (typedChar.Equals(')') || typedChar.Equals(';'))
                        {
                            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: triggerPoint=" + _textView.Caret.Position.BufferPosition.Position);
                            if (this._session != null)
                            {
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: B dismissing an existing session");
                                this.DismissSession(this._session);
                                this._session = null;
                            }
                        }

                    }
                }
                else
                {
                    bool enterPressed = (nCmdID == (uint)VSConstants.VSStd2KCmdID.RETURN);
                    if (enterPressed)
                    {
                        IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: enter pressed");
                        if (this._session != null)
                        {
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: C dismissing an existing session");
                            this.DismissSession(this._session);
                            this._session = null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:Exec; e={1}", this.ToString(), e.ToString()));
            }
            return this._nextCommandHandler.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return _nextCommandHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        #region Private Stuff

        private void DismissSession(ISignatureHelpSession session)
        {
            if (session == null) return;

            if (session.IsDismissed)
            {
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: DismissSession: session is already dismissed");
                return;
            }

            string signatureStr = "no signatures";
            if (session.Signatures != null)
            {
                if (session.Signatures.Count > 0)
                {
                    signatureStr = _session.Signatures[0].Content;
                }
            }
            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: DismissSession: dismissing session: " + signatureStr);
            session.Dismiss();
        }

        private void StartSession()
        {
           // lock (_startNewSessionLock)
            {
                int triggerPoint = _textView.Caret.Position.BufferPosition.Position - 1;
                Tuple<Intrinsic, int, int> tup = IntrinsicTools.getCurrentIntrinsicAndParamIndex(this._textView.TextSnapshot, triggerPoint);
                Intrinsic intrinsic = tup.Item1;
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: StartSession: triggerPoint=" + triggerPoint + "; Intrinsic=" + intrinsic + "; paramIndex=" + tup.Item2);

                if (intrinsic != Intrinsic.NONE)
                {
                    if (this._broker.IsSignatureHelpActive(this._textView))
                    {
                        IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: StartSession. Recycling an existing session: " + ((_session.Signatures.Count > 0) ? _session.Signatures[0].Content : "no signatures"));
                        this._session = this._broker.GetSessions(this._textView)[0];
                        this._session.Recalculate();
                    }
                    else
                    {
                        foreach (ISignatureHelpSession session in this._broker.GetSessions(this._textView))
                        {
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: StartSession: dismissing active session");
                            this.DismissSession(session);
                        }
                        this._session = this._broker.TriggerSignatureHelp(this._textView);
                    }
                }
            }
        }

        private static char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }

        #endregion
    }
}
