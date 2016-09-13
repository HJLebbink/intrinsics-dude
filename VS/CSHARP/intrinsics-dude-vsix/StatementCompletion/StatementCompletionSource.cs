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
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Adornments;

using IntrinsicsDude.Tools;
using static IntrinsicsDude.Tools.IntrinsicTools;
using System.Windows;
using Microsoft.VisualStudio.Text.Editor;
using System.Threading;
using Amib.Threading;

namespace IntrinsicsDude.StatementCompletion
{
    public sealed class CompletionComparer : IComparer<Completion>
    {
        public int Compare(Completion x, Completion y)
        {
            if ((y == null) || (x == null)) return -1;
            return x.InsertionText.CompareTo(y.InsertionText);
        }
    }

    public sealed class StatementCompletionSource : ICompletionSource
    {
        private readonly ITextBuffer _buffer;
        private readonly ITextStructureNavigator _navigator;
        private readonly StatementCompletionStore _statement_Completion_Store;
        private TextAdornment _textAdornment;
        private IWpfTextView _textView;

        private bool _disposed = false;

        public StatementCompletionSource(
            ITextBuffer buffer, 
            ITextStructureNavigator navigator)
        {
            this._buffer = buffer;
            this._navigator = navigator;
            this._statement_Completion_Store = IntrinsicsDudeTools.Instance.statementCompletionStore;
            this._textAdornment = null;
            this._textView = null;
            IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: constructor");
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            try
            {
                IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: AugmentCompletionSession");

                if (_disposed) return;
                if (!Settings.Default.StatementCompletion_On) return;

                DateTime time1 = DateTime.Now;

                SnapshotPoint triggerPoint = (SnapshotPoint)session.GetTriggerPoint(this._buffer.CurrentSnapshot);
                if (triggerPoint == null)
                {
                    return;
                }

                TextExtent extent = this._navigator.GetExtentOfWord(triggerPoint - 1); // minus one to get the previous word
                if (extent.IsSignificant)
                {
                    string partialKeyword = extent.Span.GetText();
                    //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: AugmentCompletionSession: partialKeyword=\"" + partialKeyword + "\".");

                    if (partialKeyword.Length > 0)
                    {
                        //this.updateCompletionsSets_method1(partialKeyword, extent, session, completionSets);
                        this.updateCompletionsSets_method2(partialKeyword, extent, session, completionSets);
                    }
                }

                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Statement-Completion");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: StatementCompletionSource: AugmentCompletionSession; e=" + e.ToString());
            }
        }

        private void updateCompletionsSets_method1(
            string partialKeyword, 
            TextExtent extent, 
            ICompletionSession session, 
            IList<CompletionSet> completionSets)
        {
            if (partialKeyword[0].Equals('_'))
            {
                List<Completion> intrinsicCompletions = this.getCompletions(this.findCompletionRestriction(extent));
                intrinsicCompletions.Sort(new CompletionComparer());

                if (completionSets.Count > 0)
                {
                    IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource:updateCompletionsSets_method1: there are existing completionSets");

                    CompletionSet existingCompletions = completionSets[0];
                    List<Completion> allCompletionsList = new List<Completion>(intrinsicCompletions);

                    if (partialKeyword.Length > 1)
                    {   // only add existing code completions when the partial keyword has more than 2 chars, this for speed considerations
                        foreach (Completion completion in existingCompletions.Completions)
                        {
                            string insertionText = completion.InsertionText;
                            if (insertionText != null)
                            {
                                Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(insertionText, false);
                                if (intrinsic == Intrinsic.NONE)
                                {
                                    if (insertionText.StartsWith(partialKeyword))
                                    {
                                        if (!IntrinsicTools.isSimdRegister(insertionText))
                                        {
                                            allCompletionsList.Add(new Completion(completion.DisplayText, insertionText, completion.Description, completion.IconSource, completion.IconAutomationText));
                                            //set_all.Add(completion); // adding the completion without a deep copy does not work.
                                        }
                                    }
                                }
                            }
                        }
                    }
                    allCompletionsList.Sort(new CompletionComparer());
                    completionSets.Add(new CompletionSet("New", "New", existingCompletions.ApplicableTo, allCompletionsList, Enumerable.Empty<Completion>()));
                    completionSets.Add(new CompletionSet("Intrinsics-Only", "Intrinsics-Only", existingCompletions.ApplicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                } else
                {
                    IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: updateCompletionsSets_method1: no existing completionSet");

                    ITrackingSpan applicableTo = this._buffer.CurrentSnapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeExclusive, TrackingFidelityMode.Forward);
                    completionSets.Add(new CompletionSet("Intrinsics-Only", "Intrinsics-Only", applicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                }
            }
        }

        private void updateCompletionsSets_method2(
            string partialKeyword,
            TextExtent extent,
            ICompletionSession session,
            IList<CompletionSet> completionSets)
        {
            if (partialKeyword[0].Equals('_'))
            {
                List<Completion> intrinsicCompletions = this.getCompletions(this.findCompletionRestriction(extent));

                if (completionSets.Count > 0)
                {
                    IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: updateCompletionsSets_method2: there are existing completionSets");

                    CompletionSet existingCompletions = completionSets[0];
                    this.init_Cached_Completions(existingCompletions, intrinsicCompletions, session);
                    intrinsicCompletions.Sort(new CompletionComparer());
                    completionSets.Insert(0, new CompletionSet("New", "New", existingCompletions.ApplicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                }
                else
                {
                    IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource:AugmentCompletionSession: no existing completionSet");

                    ITrackingSpan applicableTo = this._buffer.CurrentSnapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeExclusive, TrackingFidelityMode.Forward);
                    intrinsicCompletions.Sort(new CompletionComparer());
                    completionSets.Add(new CompletionSet("Intrinsics-Only", "Intrinsics-Only", applicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                }
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

        private void init_Cached_Completions(CompletionSet existingCompletions, List<Completion> intrinsicCompletions, ICompletionSession session)
        {
            DateTime startTime = DateTime.Now;
            IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: init_Cached_Completions");


            bool is_Initialized = this._statement_Completion_Store.is_Initialized;

            foreach (Completion completion in existingCompletions.Completions)
            {
                string insertionText = completion.InsertionText;
                if (insertionText != null)
                {
                    Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(insertionText, false);
                    if (intrinsic == Intrinsic.NONE)
                    {
                        if (!IntrinsicTools.isSimdRegister(insertionText))
                        {
                            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: init_Cached_Completions: adding completion "+insertionText);
                            intrinsicCompletions.Add(this._statement_Completion_Store.get_Cached_Completion(completion));
                        }
                    }
                }
            }
            if (!is_Initialized)
            {
                int lineNumber = session.TextView.Selection.StreamSelectionSpan.SnapshotSpan.Start.GetContainingLine().LineNumber;
                int pos = 0;// session.TextView.Selection.Start.Position - session.TextView.Selection.StreamSelectionSpan.SnapshotSpan.Start.GetContainingLine().Start;
                string message = "Done Initializing Statement Completions. Sorry for that";

                this._textView = (IWpfTextView)session.TextView;
                if (false)
                {
                    var x = WorkItemPriority.Highest;
                    IntrinsicsDudeTools.Instance.threadPool.QueueWorkItem(this.makeAdornment, lineNumber, pos, message, x);
                } else
                {
                    this.makeAdornment(lineNumber, pos, message);
                }
            }
            //IntrinsicsDudeToolsStatic.printSpeedWarning(startTime, "Init-Cached-Completions");
        }

        private void makeAdornment(int lineNumber, int pos, string message)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: makeAdornment: pos="+pos);
            this._textAdornment = new TextAdornment(this._textView, lineNumber, pos, message);
            this._textView.TextBuffer.Insert(0, "x");
        }

        private void addRegisterCompletions(ref List<Completion> completions, ReturnType returnType)
        {
            if (returnType == ReturnType.UNKNOWN) {
                CpuID selectedCpuID = IntrinsicsDudeToolsStatic.getCpuIDSwithedOn();

                if ((selectedCpuID & (CpuID.MMX)) != CpuID.NONE)
                {
                    completions.Add(new Completion("__m64", "__m64", null, null, null));
                }
                if ((selectedCpuID & (CpuID.SSE | CpuID.SSE2 | CpuID.SSE3 | CpuID.SSE4_1 | CpuID.SSE4_2 | CpuID.SSSE3)) != CpuID.NONE)
                {
                    completions.Add(new Completion("__m128", "__m128 ", null, null, null));
                    completions.Add(new Completion("__m128d", "__m128d ", null, null, null));
                    completions.Add(new Completion("__m128i", "__m128i ", null, null, null));
                }
                if ((selectedCpuID & (CpuID.AVX | CpuID.AVX2)) != CpuID.NONE) {
                    completions.Add(new Completion("__m256", "__m256 ", null, null, null));
                    completions.Add(new Completion("__m256d", "__m256d ", null, null, null));
                    completions.Add(new Completion("__m256i", "__m256i ", null, null, null));
                }
                if ((selectedCpuID & (CpuID.AVX512BW | CpuID.AVX512CD | CpuID.AVX512DQ | CpuID.AVX512ER | CpuID.AVX512F | CpuID.AVX512IFMA52 | CpuID.AVX512PF | CpuID.AVX512VBMI | CpuID.AVX512VL | CpuID.KNCNI)) != CpuID.NONE) {
                    completions.Add(new Completion("__m512", "__m512 ", null, null, null));
                    completions.Add(new Completion("__m512d", "__m512d ", null, null, null));
                    completions.Add(new Completion("__m512i", "__m512i ", null, null, null));
                    completions.Add(new Completion("__mmask8", "__mmask8 ", null, null, null));
                    completions.Add(new Completion("__mmask16", "__mmask16 ", null, null, null));
                    completions.Add(new Completion("__mmask32", "__mmask32 ", null, null, null));
                    completions.Add(new Completion("__mmask64", "__mmask64 ", null, null, null));
                }
            }
        }

        private ReturnType findCompletionRestriction(TextExtent currentKeywordExtent)
        {
            ReturnType returnType = this.findLeftHandType(currentKeywordExtent);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findCompletionRestriction: A: returnType=" + returnType);
            if (returnType == ReturnType.UNKNOWN)
            {
                returnType = findEmbeddedType(currentKeywordExtent);
                //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findCompletionRestriction: B: returnType=" + returnType);
            }
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findCompletionRestriction: C: returnType=" + returnType);
            return returnType;
        }

        private ReturnType findEmbeddedType(TextExtent currentKeywordExtent)
        {
            SnapshotPoint point = currentKeywordExtent.Span.Start;
            Tuple<Intrinsic, int> tup = IntrinsicTools.getIntrinsicAndParamIndex(point, this._navigator);
            if (tup.Item1 == Intrinsic.NONE)
            {
                return ReturnType.UNKNOWN;
            }

            IntrinsicStore store = IntrinsicsDudeTools.Instance.intrinsicStore;
            IntrinsicDataElement dataElement = store.get(tup.Item1)[0];
            ParamType paramType = dataElement.parameters[tup.Item2].Item1;
            ReturnType returnType = IntrinsicTools.parseReturnType(IntrinsicTools.ToString(paramType), false);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findEmbeddedType: B: returnType=" + returnType+"; intrinsic="+tup.Item1+"; param="+tup.Item2);
            return returnType;
        }

        private ReturnType findLeftHandType(TextExtent currentKeywordExtent)
        {
            TextExtent word = this._navigator.GetExtentOfWord(currentKeywordExtent.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findLeftHandType: A: word=\"" + word.Span.GetText() + "\".");

            if (word.Span.GetText().Equals(" "))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findLeftHandType: B: word=\"" + word.Span.GetText() + "\".");
            }
            if (word.Span.GetText().Equals("="))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findLeftHandType: C: word=\"" + word.Span.GetText() + "\".");
            }
            else
            {
                return ReturnType.UNKNOWN;
            }
            if (word.Span.GetText().Equals(" "))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findLeftHandType: D: word=\"" + word.Span.GetText() + "\".");
            }
            word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findLeftHandType: E: word=\"" + word.Span.GetText() + "\".");

            word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findLeftHandType: E: word=\"" + word.Span.GetText() + "\".");
            ReturnType returnType = IntrinsicTools.parseReturnType(word.Span.GetText(), false);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findLeftHandType: F: ReturnType=\"" + returnType + "\".");
            return returnType;
        }

        private List<Completion> getCompletions(ReturnType returnType)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: getCompletions: returnType=" + returnType);

            bool decorateIncompatibleStatementCompletions = Settings.Default.DecorateIncompatibleStatementCompletions_On;
            bool hideStatementCompletionIncompatibleReturnType = Settings.Default.HideStatementCompletionIncompatibleReturnType_On;

            List<Completion> completions = new List<Completion>();

            foreach (Tuple<Completion, ReturnType> e in IntrinsicsDudeTools.Instance.statementCompletionStore.intrinsic_Completions)
            {
                Completion completion = e.Item1;
                ReturnType returnType2 = e.Item2;

                if (!IntrinsicTools.isConversionPossible(returnType2, returnType))
                {
                    if (!hideStatementCompletionIncompatibleReturnType)
                    {
                        completions.Add((decorateIncompatibleStatementCompletions) ? decorate(completion, "[Incompatible]") : completion);
                    }
                }
                else
                {
                    completions.Add(completion);
                }
            }

            this.addRegisterCompletions(ref completions, returnType);
            return completions;
        }

        private Completion decorate(Completion completion, string str)
        {
            string displayText = completion.DisplayText.Replace(" [", " "+str+"[");
            return new Completion(displayText, completion.InsertionText, completion.Description, completion.IconSource, completion.IconAutomationText);
        }
       
        #endregion
    }
}
