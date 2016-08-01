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
using AsmTools;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Runtime.InteropServices;

namespace IntrinsicsDude.SignatureHelp {

    internal sealed class IntrinsicsSignatureHelpCommandFilter : IOleCommandTarget {
        private readonly ITextView _textView;
        private readonly ISignatureHelpBroker _broker;

        private ISignatureHelpSession _session;
        private IOleCommandTarget _nextCommandHandler;

        internal IntrinsicsSignatureHelpCommandFilter(IVsTextView textViewAdapter, ITextView textView, ISignatureHelpBroker broker) {
            this._textView = textView;
            this._broker = broker;

            //add this to the filter chain
            textViewAdapter.AddCommandFilter(this, out _nextCommandHandler);
        }

        private char GetTypeChar(IntPtr pvaIn) {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut) {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsSignatureHelpCommandFilter: Exec");

            try {
                SnapshotPoint currentPoint = _textView.Caret.Position.BufferPosition;
                if ((currentPoint != null) && (currentPoint > 0)) {
                    SnapshotPoint point = currentPoint - 1;
                    if (point.Position > 1) {
                        if ((pguidCmdGroup == VSConstants.VSStd2K) && (nCmdID == (uint)VSConstants.VSStd2KCmdID.TYPECHAR)) {

                            ITextSnapshotLine line = point.Snapshot.GetLineFromPosition(point.Position);
                            string lineStr = line.GetText();
                            int pos = point.Position - line.Start;

                            char typedChar = this.GetTypeChar(pvaIn);
                            if (char.IsWhiteSpace(typedChar) || typedChar.Equals('(')) {
                                if (this._session != null) this._session.Dismiss(); // cleanup previous session

                                Tuple<Intrinsic,int> tup = IntrinsicTools.getPreviousKeywordPos(pos, lineStr);
                                if (tup.Item1 != Intrinsic.NONE) {
                                    this._session = _broker.TriggerSignatureHelp(_textView);
                                }
                            }
                        } else {
                            bool enterPressed = (nCmdID == (uint)VSConstants.VSStd2KCmdID.RETURN);
                            if (enterPressed && (this._session != null)) {
                                this._session.Dismiss();
                                this._session = null;
                            }
                        }
                    }
                }
            } catch (Exception e) {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:Exec; e={1}", this.ToString(), e.ToString()));
            }
            return _nextCommandHandler.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText) {
            return _nextCommandHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }
    }
}
