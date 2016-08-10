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
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace IntrinsicsDude
{
    internal sealed class CodeCompletionCommandHandler : IOleCommandTarget
    {
        private ICompletionSession _currentSession;

        public CodeCompletionCommandHandler(IWpfTextView textView, ICompletionBroker broker)
        {
            this._currentSession = null;
            this._textView = textView;
            this._broker = broker;
            //Debug.WriteLine(string.Format("INFO: {0}:constructor", this.ToString()));
        }

        public IWpfTextView _textView { get; private set; }
        public ICompletionBroker _broker { get; private set; }
        public IOleCommandTarget _nextCommandHandler { get; set; }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:ExecMethod2", this.ToString()));

            bool handledChar = false;
            int hresult = VSConstants.S_OK;
            char typedChar = char.MinValue;

            #region 1. Pre-process
            if (pguidCmdGroup == VSConstants.VSStd2K)
            {
                switch ((VSConstants.VSStd2KCmdID)nCmdID)
                {
                    case VSConstants.VSStd2KCmdID.AUTOCOMPLETE:
                    case VSConstants.VSStd2KCmdID.COMPLETEWORD:
                        handledChar = this.StartSession();
                        break;
                    case VSConstants.VSStd2KCmdID.RETURN:
                        handledChar = this.Complete(true);
                        break;
                    case VSConstants.VSStd2KCmdID.TAB:
                        this.Complete(true);
                        handledChar = false;
                        break;
                    case VSConstants.VSStd2KCmdID.CANCEL:
                        handledChar = this.Cancel();
                        break;
                    case VSConstants.VSStd2KCmdID.TYPECHAR:
                        typedChar = GetTypeChar(pvaIn);
                        if (char.IsWhiteSpace(typedChar))
                        {
                            this.Complete(true);
                            handledChar = false;
                        }
                        else if (AsmTools.AsmSourceTools.isSeparatorChar(typedChar))
                        {
                            this.Complete(false);
                            handledChar = false;
                        }
                        else if (AsmTools.AsmSourceTools.isRemarkChar(typedChar))
                        {
                            this.Complete(true);
                            handledChar = false;
                        }
                        break;
                }
            }
            #endregion

            #region 2. Handle the typed char
            if (!handledChar)
            {
                hresult = this._nextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);

                if (!typedChar.Equals(char.MinValue) && char.IsLetterOrDigit(typedChar))
                {
                    //if (!typedChar.Equals(char.MinValue)) {
                    if ((this._currentSession == null) || this._currentSession.IsDismissed)
                    { // If there is no active session, bring up completion
                        this.StartSession();
                    }
                    this.Filter();
                    hresult = VSConstants.S_OK;
                }
                else if (nCmdID == (uint)VSConstants.VSStd2KCmdID.BACKSPACE   //redo the filter if there is a deletion
                      || nCmdID == (uint)VSConstants.VSStd2KCmdID.DELETE)
                {
                    if ((this._currentSession != null) && !this._currentSession.IsDismissed)
                    {
                        this.Filter();
                    }
                    hresult = VSConstants.S_OK;
                }
            }
            #endregion

            #region Post-process
            if (ErrorHandler.Succeeded(hresult))
            {
                if (pguidCmdGroup == VSConstants.VSStd2K)
                {
                    switch ((VSConstants.VSStd2KCmdID)nCmdID)
                    {
                        case VSConstants.VSStd2KCmdID.TYPECHAR:
                        case VSConstants.VSStd2KCmdID.BACKSPACE:
                        case VSConstants.VSStd2KCmdID.DELETE:
                            this.Filter();
                            break;
                    }
                }
            }
            #endregion

            return hresult;
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:QueryStatus", this.ToString()));
            if (pguidCmdGroup == VSConstants.VSStd2K)
            {
                switch ((VSConstants.VSStd2KCmdID)prgCmds[0].cmdID)
                {
                    case VSConstants.VSStd2KCmdID.AUTOCOMPLETE:
                    case VSConstants.VSStd2KCmdID.COMPLETEWORD:
                        //Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "INFO: {0}:QueryStatus", this.ToString()));
                        prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED;
                        return VSConstants.S_OK;
                }
            }
            return this._nextCommandHandler.QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        #region Private Stuff

        private bool StartSession()
        {
            if (this._currentSession != null)
            {
                return false;
            }
            SnapshotPoint caret = this._textView.Caret.Position.BufferPosition;
            ITextSnapshot snapshot = caret.Snapshot;

            if (this._broker.IsCompletionActive(this._textView))
            {
                //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:StartSession. Recycling an existing auto-complete session", this.ToString()));
                this._currentSession = this._broker.GetSessions(this._textView)[0];
            }
            else
            {
                //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:StartSession. Creating a new auto-complete session", this.ToString()));
                this._currentSession = this._broker.CreateCompletionSession(this._textView, snapshot.CreateTrackingPoint(caret, PointTrackingMode.Positive), true);
            }
            this._currentSession.Dismissed += (sender, args) => _currentSession = null;
            if (!this._currentSession.IsStarted)
            {
                this._currentSession.Start();
            }

            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:StartSession", this.ToString()));
            return true;
        }

        /// <summary>
        /// Complete the auto-complete
        /// </summary>
        /// <param name="force">force the selection even if it has not been manually selected</param>
        /// <returns></returns>
        private bool Complete(bool force)
        {
            if (this._currentSession == null)
            {
                return false;
            }
            if (!_currentSession.SelectedCompletionSet.SelectionStatus.IsSelected && !force)
            {
                this._currentSession.Dismiss();
                return false;
            }
            else
            {
                this._currentSession.Commit();
                return true;
            }
        }

        private bool Cancel()
        {
            if (this._currentSession == null)
            {
                return false;
            }
            this._currentSession.Dismiss();
            return true;
        }

        /// <summary>
        /// Narrow down the list of options as the user types input
        /// </summary>
        private void Filter()
        {
            if (this._currentSession == null)
            {
                return;
            }
            // this._currentSession.SelectedCompletionSet.SelectBestMatch();
            //this._currentSession.SelectedCompletionSet.Recalculate();
            this._currentSession.Filter();
        }

        private char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }
        #endregion
    }
}
