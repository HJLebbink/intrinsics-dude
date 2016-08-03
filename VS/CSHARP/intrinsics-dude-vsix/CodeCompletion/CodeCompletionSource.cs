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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using IntrinsicsDude.Tools;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude
{
    public sealed class CompletionComparer : IComparer<Completion>
    {
        public int Compare(Completion x, Completion y)
        {
            return x.InsertionText.CompareTo(y.InsertionText);
        }
    }

    public sealed class CodeCompletionSource : ICompletionSource
    {
        private readonly ITextBuffer _buffer;
        private readonly IntrinsicsDudeTools _intrinsicsDudeTools;
        private bool _disposed = false;

        public CodeCompletionSource(ITextBuffer buffer)
        {
            this._buffer = buffer;
            this._intrinsicsDudeTools = IntrinsicsDudeTools.Instance;
            //this.loadIcons();
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:AugmentCompletionSession", this.ToString()));

            if (_disposed) return;
            if (!Settings.Default.CodeCompletion_On) return;

            try
            {
                DateTime time1 = DateTime.Now;
                ITextSnapshot snapshot = this._buffer.CurrentSnapshot;
                SnapshotPoint triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
                if (triggerPoint == null)
                {
                    return;
                }
                ITextSnapshotLine line = triggerPoint.GetContainingLine();

                //2] find the start of the current keyword
                #region
                SnapshotPoint start = triggerPoint;
                while ((start > line.Start) && !AsmTools.AsmSourceTools.isSeparatorChar((start - 1).GetChar()))
                {
                    start -= 1;
                }
                #endregion

                //3] get the word that is currently being typed
                #region
                ITrackingSpan applicableTo = snapshot.CreateTrackingSpan(new SnapshotSpan(start, triggerPoint), SpanTrackingMode.EdgeInclusive);
                string partialKeyword = applicableTo.GetText(snapshot);
                bool useCapitals = IntrinsicsDudeToolsStatic.isAllUpper(partialKeyword);

                SortedSet<Completion> completions = null;
                if (partialKeyword.StartsWith("_mm", StringComparison.OrdinalIgnoreCase))
                {
                    completions = this.getAllowedMnemonics(IntrinsicsDudeToolsStatic.getCpuIDSwithedOn());
                }
                //IntrinsicsDudeToolsStatic.Output("INFO: AsmCompletionSource:AugmentCompletionSession; nCompletions=" + completions.Count);
                #endregion
                completionSets.Add(new CompletionSet("Intrinsics", "Intrinsics", applicableTo, completions, Enumerable.Empty<Completion>()));

                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Code Completion");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:AugmentCompletionSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public void Dispose()
        {
            if (!this._disposed)
            {
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }

        #region Private Methods

        private SortedSet<Completion> getAllowedMnemonics(CpuID selectedArchitectures)
        {
            IntrinsicStore store = this._intrinsicsDudeTools.intrinsicStore;
            SortedSet<Completion> set = new SortedSet<Completion>(new CompletionComparer());
            foreach (Intrinsic mnemonic in Enum.GetValues(typeof(Intrinsic)))
            {
                if (mnemonic != Intrinsic.NONE)
                {
                    IntrinsicDataElement element = store.get(mnemonic);
                    if (element != null)
                    {
                        bool selected = (selectedArchitectures & element.cpuID) != 0;
                        if (selected)
                        {
                            string description = element.description;
                            string cpuID = IntrinsicTools.ToString(element.cpuID);
                            string displayText = IntrinsicsDudeToolsStatic.cleanup(element.intrinsic.ToString() + " ["+cpuID+"] - " + description);
                            string insertionText = element.intrinsic.ToString().ToLower();
                            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource:getAllowedMnemonics; adding =" + insertionText);
                            set.Add(new Completion(displayText, insertionText, null, null, ""));
                        }
                    }
                }
            }
            return set;
        }
        #endregion
    }
}
