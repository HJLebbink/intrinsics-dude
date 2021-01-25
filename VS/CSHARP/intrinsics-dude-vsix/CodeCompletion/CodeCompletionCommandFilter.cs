// The MIT License (MIT)
//
// Copyright (c) 2021 Henk-Jan Lebbink
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

namespace IntrinsicsDude
{
    using System;
    using System.Runtime.InteropServices;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Editor;

    internal sealed class CodeCompletionCommandFilter : IOleCommandTarget
    {
        private ICompletionSession _currrentSession;
        private const bool LOG_ON = true;

        public CodeCompletionCommandFilter(IWpfTextView textView, ICompletionBroker broker)
        {
            this._currrentSession = null;
            this.TextView = textView ?? throw new ArgumentNullException(nameof(textView));
            this.Broker = broker ?? throw new ArgumentNullException(nameof(broker));
            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:constructor.", this.ToString()));
        }

        public IWpfTextView TextView { get; private set; }

        public ICompletionBroker Broker { get; private set; }

        public IOleCommandTarget NextCommandHandler { get; set; }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:Exec", this.ToString()));

            if (!Settings.Default.StatementCompletion_On)
            {
                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:Exec: code completion is switched off.", this.ToString()));
                int hresult = this.NextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
                return hresult;
            }
            else
            {
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
                                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:Exec; tab or enter pressed", this.ToString()));
                                handledChar = this.Complete();
                                break;
                            case VSConstants.VSStd2KCmdID.CANCEL:
                                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:Exec cancel pressed", this.ToString()));
                                handledChar = this.Cancel();
                                break;
                            case VSConstants.VSStd2KCmdID.TYPECHAR:
                                typedChar = this.GetTypeChar(pvaIn);
                                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:Exec {1} pressed", this.ToString(), typedChar));
                                break;
                        }
                    }
                    #endregion

                    #region 2. Handle the typed char
                    if (!handledChar)
                    {
                        hresult = this.NextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
                    }
                    #endregion

                    //if (LOG_ON) IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Exec; hresult=" + hresult +"; VSConstants.S_OK=" + VSConstants.S_OK + "; ");

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
                                    //if (LOG_ON) IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Exec; Post-process");
                                    this.Filter();
                                    break;
                            }
                        }
                    }
                    #endregion

                    return hresult;
                }
                catch (Exception e)
                {
                    IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:StatementCompletionCommandHandler; e={1}", this.ToString(), e.ToString()));
                    return this.NextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
                }
            }
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: QueryStatus");

            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            if (pguidCmdGroup == VSConstants.VSStd2K)
            {
                switch ((VSConstants.VSStd2KCmdID)prgCmds[0].cmdID)
                {
                    case VSConstants.VSStd2KCmdID.AUTOCOMPLETE:
                        if (LOG_ON)
                        {
                            IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: QueryStatus; AUTOCOMPLETE pressed");
                        }

                        goto case VSConstants.VSStd2KCmdID.COMPLETEWORD;
                    case VSConstants.VSStd2KCmdID.COMPLETEWORD:
                        if (LOG_ON)
                        {
                            IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: QueryStatus; COMPLETEWORD pressed");
                        }

                        prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED;
                        return VSConstants.S_OK;
                }
            }

            return this.NextCommandHandler.QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        #region Private Stuff

        private bool StartSession()
        {
            #region Clear all existing sessions
            if (this._currrentSession != null)
            {
                IntrinsicsDudeToolsStatic.Output_INFO("CodeCompletionCommandHandler: StartSession. dismissing already active session(" + this._currrentSession.GetTriggerPoint(this.TextView.TextBuffer) + ")");
                this._currrentSession.Dismiss();
            }

            //this._broker.DismissAllSessions(this._textView);
            #endregion

            SnapshotPoint caret = this.TextView.Caret.Position.BufferPosition;
            ITextSnapshot snapshot = caret.Snapshot;

            this._currrentSession = this.Broker.TriggerCompletion(this.TextView);
            //this._session = this._broker.CreateCompletionSession(this._textView, snapshot.CreateTrackingPoint(caret, PointTrackingMode.Positive), false);
            //IntrinsicsDudeToolsStatic.Output_INFO("CodeCompletionCommandHandler: StartSession. Created a new auto-complete session(" + _session.GetTriggerPoint(this._textView.TextBuffer) + ")");

            //this._session.Dismissed += (sender, args) => _session = null;
            //if (!this._session.IsStarted)
            //{
            //IntrinsicsDudeToolsStatic.Output_INFO("CodeCompletionCommandHandler: StartSession: starting session(" + _session.GetTriggerPoint(this._textView.TextBuffer) + ")");
            //   this._session.Start();
            //}

            //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:StartSession", this.ToString()));
            return true;
        }

        private bool Complete()
        {
            if (this._currrentSession == null)
            {
                if (this.Broker.IsCompletionActive(this.TextView))
                {
                    this._currrentSession = this.Broker.GetSessions(this.TextView)[0];
                    if (LOG_ON)
                    {
                        IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. current session was null; reusing existing session.");
                    }
                }
            }
            else if (this._currrentSession.IsDismissed)
            {
                if (this.Broker.IsCompletionActive(this.TextView))
                {
                    this._currrentSession = this.Broker.GetSessions(this.TextView)[0];
                    if (LOG_ON)
                    {
                        IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. current session was dismissed; reusing existing session.");
                    }
                }
            }

            if (this._currrentSession == null)
            {
                if (LOG_ON)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. Session is null: no completions.");
                }

                return false;
            }

            if (this._currrentSession.IsDismissed)
            {
                if (LOG_ON)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. Session is dismissed: no completions.");
                }

                return false;
            }

            if (!this._currrentSession.IsStarted)
            {
                if (LOG_ON)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. Session is not started: no completions.");
                }

                return false;
            }

            bool isSelected = this._currrentSession.SelectedCompletionSet.SelectionStatus.IsSelected;
            bool isUnique = this._currrentSession.SelectedCompletionSet.SelectionStatus.IsUnique;
            string insertionText = this._currrentSession.SelectedCompletionSet.SelectionStatus.Completion.InsertionText;

            if (LOG_ON)
            {
                IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. IsSelected=" + isSelected + "; IsUnique=" + isUnique + "; insertionText=" + insertionText);
            }

            if (isSelected)
            {
                if (LOG_ON)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. Committing InsertionText=" + insertionText);
                }

                this._currrentSession.Commit();
                return true;
            }

            if (isUnique)
            {
                if (LOG_ON)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. Committing InsertionText=" + insertionText);
                }

                this._currrentSession.Commit();
                return true;
            }

            this._currrentSession.Dismiss();
            if (LOG_ON)
            {
                IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Complete. exiting; no completion.");
            }

            return false;
        }

        private bool Cancel()
        {
            if (this._currrentSession == null)
            {
                if (LOG_ON)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Cancel: session==null");
                }

                return false;
            }
            else
            {
                if (LOG_ON)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Cancel: session is not null");
                }

                this._currrentSession.Dismiss();
                return true;
            }
        }

        /// <summary>
        /// Narrow down the list of options as the user types input
        /// </summary>
        private void Filter()
        {
            if (this._currrentSession == null)
            {
                return;
            }

            if (this._currrentSession.IsDismissed)
            {
                return;
            }

            if (LOG_ON)
            {
                IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionCommandHandler: Filter: session is not null");
            }

            this._currrentSession.SelectedCompletionSet.Recalculate();
            this._currrentSession.SelectedCompletionSet.SelectBestMatch();
            //this._session.Filter();
        }

        private char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }
        #endregion
    }
}
