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
using IntrinsicsDude.Tools;

namespace IntrinsicsDude
{
    internal sealed class StatementCompletionCommandHandler : IOleCommandTarget
    {
        private ICompletionSession _session;
        private const bool LOG_ON = false;


        public StatementCompletionCommandHandler(IWpfTextView textView, ICompletionBroker broker)
        {
            this._session = null;
            this._textView = textView;
            this._broker = broker;
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: constructor");
        }

        public IWpfTextView _textView { get; private set; }
        public ICompletionBroker _broker { get; private set; }
        public IOleCommandTarget _nextCommandHandler { get; set; }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            //if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Exec");
            try
            {
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
                            //handledChar = this.StartSession(); // do not start the session; the existing commandHandler does that for you, otherwise you may create multiple sessions at the same time.
                            break;
                        case VSConstants.VSStd2KCmdID.RETURN:
                        case VSConstants.VSStd2KCmdID.TAB:
                            if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Exec; tab or enter pressed.");
                            handledChar = this.Complete();
                            break;
                        case VSConstants.VSStd2KCmdID.CANCEL:
                            if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Exec; cancel pressed.");
                            handledChar = this.Cancel();
                            break;
                        case VSConstants.VSStd2KCmdID.TYPECHAR:
                            //if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Exec; "+typedChar+" pressed.");
                            typedChar = GetTypeChar(pvaIn);
                            break;
                    }
                }
                #endregion

                #region 2. Handle the typed char
                if (!handledChar)
                {
                    hresult = this._nextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
                }
                #endregion

                //if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Exec; hresult=" + hresult +"; VSConstants.S_OK=" + VSConstants.S_OK + "; ");

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
                                //if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Exec; Post-process");
                                this.Filter();
                                break;
                        }
                    }
                }
                #endregion

                return hresult;

            } catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: StatementCompletionCommandHandler: Exec; e=" + e.ToString());
                return this._nextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
            }
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: QueryStatus");
            if (pguidCmdGroup == VSConstants.VSStd2K)
            {
                switch ((VSConstants.VSStd2KCmdID)prgCmds[0].cmdID)
                {
                    case VSConstants.VSStd2KCmdID.AUTOCOMPLETE:
                        if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: QueryStatus; AUTOCOMPLETE pressed");
                        goto case VSConstants.VSStd2KCmdID.COMPLETEWORD;
                    case VSConstants.VSStd2KCmdID.COMPLETEWORD:
                        if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: QueryStatus; COMPLETEWORD pressed");
                        prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED;
                        return VSConstants.S_OK;
                }
            }
            return this._nextCommandHandler.QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        #region Private Stuff

        private bool StartSession()
        {
            #region Clear all existing sessions
            if (this._session != null)
            {
                IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionCommandHandler: StartSession. dismissing already active session(" + _session.GetTriggerPoint(this._textView.TextBuffer) + ")");
                this._session.Dismiss();
            }
            //this._broker.DismissAllSessions(this._textView);
            #endregion

            SnapshotPoint caret = this._textView.Caret.Position.BufferPosition;
            ITextSnapshot snapshot = caret.Snapshot;

            this._session = this._broker.TriggerCompletion(this._textView);
            //this._session = this._broker.CreateCompletionSession(this._textView, snapshot.CreateTrackingPoint(caret, PointTrackingMode.Positive), false);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionCommandHandler: StartSession. Created a new auto-complete session(" + _session.GetTriggerPoint(this._textView.TextBuffer) + ")");

            //this._session.Dismissed += (sender, args) => _session = null;
            //if (!this._session.IsStarted)
            //{
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionCommandHandler: StartSession: starting session(" + _session.GetTriggerPoint(this._textView.TextBuffer) + ")");
             //   this._session.Start();
            //}

            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:StartSession", this.ToString()));
            return true;
        }

        private bool Complete()
        {
            if (this._session == null)
            {
                if (this._broker.IsCompletionActive(_textView))
                {
                    this._session = this._broker.GetSessions(_textView)[0];
                    if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. current session was null; reusing existing session.");
                }
            } else if (this._session.IsDismissed)
            {
                if (this._broker.IsCompletionActive(_textView))
                {
                    this._session = this._broker.GetSessions(_textView)[0];
                    if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. current session was dismissed; reusing existing session.");
                }
            }
            if (this._session == null)
            {
                if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. Session is null: no completions.");
                return false;
            }
            if (this._session.IsDismissed)
            {
                if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. Session is dismissed: no completions.");
                return false;
            }
            if (!this._session.IsStarted)
            {
                if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. Session is not started: no completions.");
                return false;
            }


            bool isSelected = _session.SelectedCompletionSet.SelectionStatus.IsSelected;
            bool isUnique = _session.SelectedCompletionSet.SelectionStatus.IsUnique;
            string insertionText = this._session.SelectedCompletionSet.SelectionStatus.Completion.InsertionText;

            if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. IsSelected="+ isSelected + "; IsUnique=" + isUnique+ "; insertionText="+ insertionText);

            if (isSelected)
            {
                if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. Committing InsertionText=" + insertionText);
                this._session.Commit();
                return true;
            }

            if (isUnique)
            {
                if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. Committing InsertionText=" + insertionText);
                this._session.Commit();
                return true;
            }

            this._session.Dismiss();
            if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Complete. exiting; no completion.");
            return false;
        }

        private bool Cancel()
        {
            if (this._session == null)
            {
                if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Cancel: session==null");
                return false;
            } else
            {
                if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Cancel: session is not null");
                this._session.Dismiss();
                return true;
            }
        }

        /// <summary>
        /// Narrow down the list of options as the user types input
        /// </summary>
        private void Filter()
        {
            if (this._session == null)
            {
                return;
            }
            if (this._session.IsDismissed)
            {
                return;
            }
            if (LOG_ON) IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionCommandHandler: Filter: session is not null");
            this._session.SelectedCompletionSet.Recalculate();
            this._session.SelectedCompletionSet.SelectBestMatch();
            //this._session.Filter();
        }

        private char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }
        #endregion
    }
}