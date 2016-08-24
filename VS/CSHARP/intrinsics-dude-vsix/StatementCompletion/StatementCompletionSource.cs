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
using IntrinsicsDude.Tools;
using System.Windows.Media;
using System.IO;
using Microsoft.VisualStudio.Text.Operations;
using static IntrinsicsDude.Tools.IntrinsicTools;
using System.Text;

namespace IntrinsicsDude.CodeCompletion
{
    public sealed class CompletionComparer : IComparer<Completion>
    {
        public int Compare(Completion x, Completion y)
        {
            return x.InsertionText.CompareTo(y.InsertionText);
        }
    }

    public sealed class StatementCompletionSource2 : ICompletionSource
    {
        private bool _disposed = false;

        public StatementCompletionSource2()
        {
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            if (_disposed) return;
            if (!Settings.Default.StatementCompletion_On) return;
            DateTime time1 = DateTime.Now;

            try
            {
                if (completionSets.Count > 1)
                {
                    CompletionSet intrinsicCompletions = completionSets[0];
                    //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource2: AugmentCompletionSession: a=\"" + intrinsicCompletions.DisplayName + "\".");
                    CompletionSet existingCompletions = completionSets[1];
                    //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource2: AugmentCompletionSession: b=\"" + existingCompletions.DisplayName + "\".");

                    List<Completion> set_all = new List<Completion>(intrinsicCompletions.Completions);

                    string partialKeyword = intrinsicCompletions.ApplicableTo.GetText(session.TextView.TextSnapshot);
                    if (partialKeyword.Length > 2)
                    {
                        foreach (Completion completion in existingCompletions.Completions)
                        {
                            string insertionText = completion.InsertionText;
                            if (insertionText != null)
                            {
                                if (IntrinsicTools.parseIntrinsic(insertionText, false) == Intrinsic.NONE)
                                {
                                    if (insertionText.StartsWith(partialKeyword))
                                    {
                                        set_all.Add(new Completion(completion.DisplayText, insertionText, completion.Description, completion.IconSource, completion.IconAutomationText));
                                        //set_all.Add(completion);
                                    }
                                }
                            }
                        }
                        set_all.Sort(new CompletionComparer());
                    }

                    completionSets.Clear();
                    completionSets.Add(new CompletionSet("New", "New", intrinsicCompletions.ApplicableTo, set_all, intrinsicCompletions.CompletionBuilders));
                    completionSets.Add(intrinsicCompletions);
                    completionSets.Add(existingCompletions);
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Statement-Completion-2");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: StatementCompletionSource2:AugmentCompletionSession; e=" + e.ToString());
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

    }

    public sealed class StatementCompletionSource : ICompletionSource
    {
        private readonly ITextBuffer _buffer;
        private readonly ITextStructureNavigator _navigator;
        private readonly StatementCompletionStore _completionStore;
        private bool _disposed = false;

        public StatementCompletionSource(ITextBuffer buffer, ITextStructureNavigator navigator)
        {
            this._buffer = buffer;
            this._navigator = navigator;
            this._completionStore = new StatementCompletionStore();
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            try
            {
                //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: AugmentCompletionSession");

                if (_disposed) return;
                if (!Settings.Default.StatementCompletion_On) return;
                DateTime time1 = DateTime.Now;

                ITextSnapshot snapshot = this._buffer.CurrentSnapshot;
                SnapshotPoint triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
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
                        if (partialKeyword[0].Equals('_'))
                        {
                            List<Completion> intrinsicCompletions = this.getCompletions(this.findCompletionRestriction(extent));
                            this.addRegisterCompletions(ref intrinsicCompletions);
                            intrinsicCompletions.Sort(new CompletionComparer());

                            if (completionSets.Count > 0)
                            {
                                CompletionSet existingCompletions = completionSets[0];
                                List<Completion> allCompletionsList = new List<Completion>(intrinsicCompletions);

                                if (partialKeyword.Length > 2)
                                {
                                    foreach (Completion completion in existingCompletions.Completions)
                                    {
                                        string insertionText = completion.InsertionText;
                                        if (insertionText != null)
                                        {
                                            if (IntrinsicTools.parseIntrinsic(insertionText, false) == Intrinsic.NONE)
                                            {
                                                if (insertionText.StartsWith(partialKeyword))
                                                {
                                                    allCompletionsList.Add(new Completion(completion.DisplayText, insertionText, completion.Description, completion.IconSource, completion.IconAutomationText));
                                                    //set_all.Add(completion);
                                                }
                                            }
                                        }
                                    }
                                    allCompletionsList.Sort(new CompletionComparer());
                                }
                                completionSets.Insert(0, new CompletionSet("New", "New", existingCompletions.ApplicableTo, allCompletionsList, Enumerable.Empty<Completion>()));
                                completionSets.Insert(1, new CompletionSet("Intrinsics-Only", "Intrinsics-Only", existingCompletions.ApplicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                            }
                            else
                            {
                                ITrackingSpan applicableTo = snapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeExclusive, TrackingFidelityMode.Forward);
                                completionSets.Add(new CompletionSet("Intrinsics-Only", "Intrinsics-Only", applicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                            }
                        }
                    }
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Statement-Completion");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: StatementCompletionSource:AugmentCompletionSession; e=" + e.ToString());
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

        private void addRegisterCompletions(ref List<Completion> completions)
        {
            CpuID selectedCpuID = IntrinsicsDudeToolsStatic.getCpuIDSwithedOn();

            if ((selectedCpuID & (CpuID.MMX)) != CpuID.NONE)
            {
                completions.Add(new Completion("__m64 [MMX]", "__m64", null, null, null));
            }
            if ((selectedCpuID & (CpuID.SSE | CpuID.SSE2 | CpuID.SSE3 | CpuID.SSE4_1 | CpuID.SSE4_2 | CpuID.SSSE3)) != CpuID.NONE)
            {
                completions.Add(new Completion("__m128 [SSE]", "__m128", null, null, null));
                completions.Add(new Completion("__m128d [SSE]", "__m128d", null, null, null));
                completions.Add(new Completion("__m128i [SSE]", "__m128i", null, null, null));
            }
            if ((selectedCpuID & (CpuID.AVX | CpuID.AVX2)) != CpuID.NONE) {
                completions.Add(new Completion("__m256 [AVX]", "__m256", null, null, null));
                completions.Add(new Completion("__m256d [AVX]", "__m256d", null, null, null));
                completions.Add(new Completion("__m256i [AVX]", "__m256i", null, null, null));
            }
            if ((selectedCpuID & (CpuID.AVX512BW | CpuID.AVX512CD | CpuID.AVX512DQ | CpuID.AVX512ER | CpuID.AVX512F | CpuID.AVX512IFMA52 | CpuID.AVX512PF | CpuID.AVX512VBMI | CpuID.AVX512VL | CpuID.KNCNI)) != CpuID.NONE)
            {
                completions.Add(new Completion("__m512 [AVX512F]", "__m512", null, null, null));
                completions.Add(new Completion("__m512d [AVX512F]", "__m512d", null, null, null));
                completions.Add(new Completion("__m512i [AVX512F]", "__m512i", null, null, null));
                completions.Add(new Completion("__mmask8 [AVX512F]", "__mmask8", null, null, null));
                completions.Add(new Completion("__mmask16 [AVX512F]", "__mmask16", null, null, null));
                completions.Add(new Completion("__mmask32 [AVX512F]", "__mmask32", null, null, null));
                completions.Add(new Completion("__mmask64 [AVX512F]", "__mmask64", null, null, null));
            }
        }

        private ReturnType findCompletionRestriction(TextExtent currentKeywordExtent)
        {
            ReturnType returnType = this.findLeftHandType(currentKeywordExtent);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findCompletionRestriction: A: returnType=" + returnType);
            if (returnType == ReturnType.NONE)
            {
                returnType = findEmbeddedType(currentKeywordExtent);
                //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findCompletionRestriction: B: returnType=" + returnType);
            }

            return funel(returnType);
        }

        private ReturnType findEmbeddedType(TextExtent currentKeywordExtent)
        {
            SnapshotPoint point = currentKeywordExtent.Span.Start;
            Tuple<Intrinsic, int> tup = IntrinsicTools.getIntrinsicAndParamIndex(point, this._navigator);
            if (tup.Item1 == Intrinsic.NONE)
            {
                return ReturnType.NONE;
            }

            IntrinsicStore store = IntrinsicsDudeTools.Instance.intrinsicStore;
            IntrinsicDataElement dataElement = store.get(tup.Item1)[0];
            ParamType paramType = dataElement.parameters[tup.Item2].Item1;
            ReturnType returnType = IntrinsicTools.parseReturnType(IntrinsicTools.ToString(paramType), false);
            //IntrinsicsDudeToolsStatic.Output("INFO: StatementCompletionSource: findEmbeddedType: B: returnType=" + returnType);
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
                return ReturnType.NONE;
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
            bool decorateIncompatibleStatementCompletions = Settings.Default.DecorateIncompatibleStatementCompletions_On;
            bool hideStatementCompletionIncompatibleReturnType = Settings.Default.HideStatementCompletionIncompatibleReturnType_On;

            List<Completion> completions = new List<Completion>();

            foreach (Tuple<Completion, ReturnType> e in _completionStore.data)
            {
                Completion completion = e.Item1;
                ReturnType returnType2 = e.Item2;

                if (!isCompatible(returnType2, returnType))
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
            return completions;
        }

        private bool isCompatible(ReturnType type1, ReturnType type2)
        {
            return funel(type1) == funel(type2);
        }

        private ReturnType funel(ReturnType type)
        {
            switch (type)
            {
                case ReturnType.__M128:
                case ReturnType.__M128D:
                case ReturnType.__M128I:
                case ReturnType.__M256:
                case ReturnType.__M256D:
                case ReturnType.__M256I:
                case ReturnType.__M512:
                case ReturnType.__M512D:
                case ReturnType.__M512I:
                case ReturnType.__M64:
                case ReturnType.__MMASK16:
                case ReturnType.__MMASK32:
                case ReturnType.__MMASK64:
                case ReturnType.__MMASK8:
                case ReturnType.FLOAT:
                case ReturnType.DOUBLE:
                case ReturnType.VOID:
                    return type;
                default:
                    return ReturnType.NONE;
            }
        }

        private Completion decorate(Completion completion, string str)
        {
            string displayText = completion.DisplayText.Replace(" [", " "+str+"[");
            return new Completion(displayText, completion.InsertionText, completion.Description, completion.IconSource, completion.IconAutomationText);
        }
        #endregion
    }
}
