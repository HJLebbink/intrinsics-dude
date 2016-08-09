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
                            if (this._session != null)
                            {
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: A dismissing an old session");
                                this._session.Dismiss();
                                this._session = null;
                            }
                            this.startNewSession();
                        }
                        else if (typedChar.Equals(')') || typedChar.Equals(';'))
                        {
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: triggerPoint=" + _textView.Caret.Position.BufferPosition.Position);
                            if (this._session != null)
                            {
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: B dismissing an old session");
                                this._session.Dismiss();
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
                            IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: Exec: C dismissing an old session");
                            this._session.Dismiss();
                            this._session = null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:Exec; e={1}", this.ToString(), e.ToString()));
            }
            return _nextCommandHandler.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return _nextCommandHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        private void startNewSession()
        {
           // lock (_startNewSessionLock)
            {
                int triggerPoint = _textView.Caret.Position.BufferPosition.Position - 1;
                Tuple<Intrinsic, int> tup = IntrinsicTools.getCurrentIntrinsicAndParamIndex(this._textView.TextSnapshot, triggerPoint);
                Intrinsic intrinsic = tup.Item1;
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: startNewSession: triggerPoint=" + triggerPoint + "; Intrinsic=" + intrinsic + "; paramIndex=" + tup.Item2);

                if (intrinsic != Intrinsic.NONE)
                {
                    this._session = _broker.TriggerSignatureHelp(_textView);
                }
            }
        }

        private void TextBuffer_Changed(object sender, EventArgs e)
        {
            //if (_sessionStartScheduled)
           // {
                this.startNewSession();
              //  _sessionStartScheduled = false;
            //}
        }

        private static char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }
    }
}
