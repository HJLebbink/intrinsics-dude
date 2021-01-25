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

namespace IntrinsicsDude.StatementCompletion
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Operations;
    using static IntrinsicsDude.Tools.IntrinsicTools;

    public sealed class CompletionComparer : IComparer<Completion>
    {
        public int Compare(Completion x, Completion y)
        {
            if ((y == null) || (x == null))
            {
                return -1;
            }

            return x.InsertionText.CompareTo(y.InsertionText);
        }
    }

    public sealed class CodeCompletionSource : ICompletionSource
    {
        private readonly ITextBuffer _buffer;
        private readonly ITextStructureNavigator _navigator;
        private readonly StatementCompletionStore _statement_Completion_Store;
        private bool _disposed = false;

        public CodeCompletionSource(
            ITextBuffer buffer,
            ITextStructureNavigator navigator)
        {
            this._buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            this._navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            this._statement_Completion_Store = IntrinsicsDudeTools.Instance.StatementCompletionStore;
            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:constructor.", this.ToString()));
        }

        public void AugmentCompletionSession(
            ICompletionSession session,
            IList<CompletionSet> completionSets)
        {
            Contract.Requires(session != null);
            Contract.Requires(completionSets != null);

            try
            {
                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:AugmentCompletionSession", this.ToString()));

                if (this._disposed)
                {
                    return;
                }

                if (!Settings.Default.StatementCompletion_On)
                {
                    IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:AugmentCompletionSession: code completion is switched off.", this.ToString()));
                    return;
                }

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
                    //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: AugmentCompletionSession: partialKeyword=\"" + partialKeyword + "\".");

                    if ((partialKeyword.Length > 0) && partialKeyword[0].Equals('_'))
                    {
                        List<Completion> intrinsicCompletions = this.GetCompletions(this.FindCompletionRestriction(extent));

                        if (completionSets.Count > 0)
                        {
                            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource:updateCompletionsSets_method1: there are existing completionSets");

                            CompletionSet existingCompletions = completionSets[0];
                            this.Init_Cached_Completions_method1(existingCompletions, intrinsicCompletions, session, partialKeyword);
                            //this.init_Cached_Completions_method2(existingCompletions, intrinsicCompletions, session);
                            intrinsicCompletions.Sort(new CompletionComparer());
                            completionSets.Insert(0, new CompletionSet("New", "New", existingCompletions.ApplicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                        }
                        else
                        {
                            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: updateCompletionsSets_method1: no existing completionSet");

                            ITrackingSpan applicableTo = this._buffer.CurrentSnapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeExclusive, TrackingFidelityMode.Forward);
                            intrinsicCompletions.Sort(new CompletionComparer());
                            completionSets.Add(new CompletionSet("Intrinsics-Only", "Intrinsics-Only", applicableTo, intrinsicCompletions, Enumerable.Empty<Completion>()));
                        }
                    }
                }

                IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "Statement-Completion");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:AugmentCompletionSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public void Dispose()
        {
            if (!this._disposed)
            {
                GC.SuppressFinalize(this);
                this._disposed = true;
            }
        }

        #region Private Methods

        private void Init_Cached_Completions_method1(
            CompletionSet existingCompletions,
            List<Completion> intrinsicCompletions,
            ICompletionSession session,
            string partialKeyword)
        {
            DateTime startTime = DateTime.Now;
            string partialKeyword2 = (partialKeyword.Length < 2) ? "__" : partialKeyword.Substring(0, 2);
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: init_Cached_Completions_method1: partialKeyword=" + partialKeyword+ "; partialKeyword2="+ partialKeyword2);

            int nCompletionsAdded = 0;
            int maxTimeMs = 1000;

            foreach (Completion completion in existingCompletions.Completions)
            {
                string insertionText = completion.InsertionText;
                if ((insertionText != null) && (insertionText.Length > 0) && (insertionText[0].Equals('_')) && (insertionText.StartsWith(partialKeyword2)))
                {
                    insertionText = insertionText.ToUpper();
                    bool is_capitals = true;
                    bool warn = false;
                    Intrinsic intrinsic = ParseIntrinsic(insertionText, is_capitals, warn);
                    if (intrinsic == Intrinsic.NONE)
                    {
                        if (!IsSimdRegister(insertionText, is_capitals))
                        {
                            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: init_Cached_Completions: adding completion "+insertionText);
                            intrinsicCompletions.Add(this._statement_Completion_Store.Get_Cached_Completion(completion));
                            nCompletionsAdded++;
                            if ((DateTime.Now.Ticks - startTime.Ticks) > (maxTimeMs * 10000))
                            {
                                IntrinsicsDudeToolsStatic.Output_WARNING("StatementCompletionSource: Truncated initialization: took more than the maximum " + maxTimeMs + " ms to initialize " + nCompletionsAdded + " existing statement completions (of total " + existingCompletions.Completions.Count + ")");
                                break;
                            }
                        }
                    }
                }
            }

            // IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: initialized " + nCompletionsAdded + " existing statement completions of the total " + existingCompletions.Completions.Count);
        }

        private void Init_Cached_Completions_method2(
            CompletionSet existingCompletions,
            List<Completion> intrinsicCompletions,
            ICompletionSession session)
        {
            DateTime startTime = DateTime.Now;
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: init_Cached_Completions");

            bool is_Initialized = this._statement_Completion_Store.Is_Initialized;

            foreach (Completion completion in existingCompletions.Completions)
            {
                string insertionText = completion.InsertionText;
                if (insertionText != null)
                {
                    insertionText = insertionText.ToUpper();
                    bool is_capitals = true;
                    bool warn = false;
                    Intrinsic intrinsic = ParseIntrinsic(insertionText, is_capitals, warn);
                    if (intrinsic == Intrinsic.NONE)
                    {
                        if (!IsSimdRegister(insertionText, is_capitals))
                        {
                            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: init_Cached_Completions: adding completion "+insertionText);
                            intrinsicCompletions.Add(this._statement_Completion_Store.Get_Cached_Completion(completion));
                        }
                    }
                }
            }

            if (!is_Initialized)
            {
                int lineNumber = session.TextView.Selection.StreamSelectionSpan.SnapshotSpan.Start.GetContainingLine().LineNumber;
                int pos = 0; // session.TextView.Selection.Start.Position - session.TextView.Selection.StreamSelectionSpan.SnapshotSpan.Start.GetContainingLine().Start;
                string message = "Done Initializing Intrinsic Statement Completions. Sorry for that";
            }

            IntrinsicsDudeToolsStatic.PrintSpeedWarning(startTime, "Init-Cached-Completions");
        }

        private void AddRegisterCompletions(ref List<Completion> completions, ReturnType returnType)
        {
            if (returnType == ReturnType.UNKNOWN)
            {
                CpuID selectedCpuID = IntrinsicsDudeToolsStatic.GetCpuIDSwithedOn();

                if ((selectedCpuID & (CpuID.ARCH_MMX)) != CpuID.ARCH_NONE)
                {
                    completions.Add(new Completion("__m64", "__m64", null, null, null));
                }

                if ((selectedCpuID & (CpuID.ARCH_SSE | CpuID.ARCH_SSE2 | CpuID.ARCH_SSE3 | CpuID.ARCH_SSE41 | CpuID.ARCH_SSE42 | CpuID.ARCH_SSSE3)) != CpuID.ARCH_NONE)
                {
                    completions.Add(new Completion("__m128", "__m128 ", null, null, null));
                    completions.Add(new Completion("__m128d", "__m128d ", null, null, null));
                    completions.Add(new Completion("__m128i", "__m128i ", null, null, null));
                }

                if ((selectedCpuID & (CpuID.ARCH_AVX | CpuID.ARCH_AVX2)) != CpuID.ARCH_NONE)
                {
                    completions.Add(new Completion("__m256", "__m256 ", null, null, null));
                    completions.Add(new Completion("__m256d", "__m256d ", null, null, null));
                    completions.Add(new Completion("__m256i", "__m256i ", null, null, null));
                }

                if ((selectedCpuID & (CpuID.ARCH_AVX512_BW | CpuID.ARCH_AVX512_CD | CpuID.ARCH_AVX512_DQ | CpuID.ARCH_AVX512_ER | CpuID.ARCH_AVX512_F | CpuID.ARCH_AVX512_IFMA | CpuID.ARCH_AVX512_PF | CpuID.ARCH_AVX512_VBMI | CpuID.ARCH_AVX512_VL | CpuID.ARCH_KNCNI)) != CpuID.ARCH_NONE)
                {
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

        private ReturnType FindCompletionRestriction(TextExtent currentKeywordExtent)
        {
            ReturnType returnType = this.FindLeftHandType(currentKeywordExtent);
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findCompletionRestriction: A: returnType=" + returnType);
            if (returnType == ReturnType.UNKNOWN)
            {
                returnType = this.FindEmbeddedType(currentKeywordExtent);
                //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findCompletionRestriction: B: returnType=" + returnType);
            }

            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findCompletionRestriction: C: returnType=" + returnType);
            return returnType;
        }

        private ReturnType FindEmbeddedType(TextExtent currentKeywordExtent)
        {
            SnapshotPoint point = currentKeywordExtent.Span.Start;
            Tuple<Intrinsic, int> tup = GetIntrinsicAndParamIndex(point, this._navigator);
            if (tup.Item1 == Intrinsic.NONE)
            {
                return ReturnType.UNKNOWN;
            }

            IntrinsicStore store = IntrinsicsDudeTools.Instance.IntrinsicStore;
            IntrinsicDataElement dataElement = store.Get(tup.Item1)[0];
            ParamType paramType = dataElement._parameters[tup.Item2].Item1;

            bool is_capital = false;
            bool warn = false;
            ReturnType returnType = ParseReturnType(IntrinsicTools.ToString(paramType), is_capital, warn);
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findEmbeddedType: B: returnType=" + returnType+"; intrinsic="+tup.Item1+"; param="+tup.Item2);
            return returnType;
        }

        private ReturnType FindLeftHandType(TextExtent currentKeywordExtent)
        {
            TextExtent word = this._navigator.GetExtentOfWord(currentKeywordExtent.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findLeftHandType: A: word=\"" + word.Span.GetText() + "\".");

            if (word.Span.GetText().Equals(" "))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findLeftHandType: B: word=\"" + word.Span.GetText() + "\".");
            }

            if (word.Span.GetText().Equals("="))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findLeftHandType: C: word=\"" + word.Span.GetText() + "\".");
            }
            else
            {
                return ReturnType.UNKNOWN;
            }

            if (word.Span.GetText().Equals(" "))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findLeftHandType: D: word=\"" + word.Span.GetText() + "\".");
            }

            word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findLeftHandType: E: word=\"" + word.Span.GetText() + "\".");

            word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findLeftHandType: E: word=\"" + word.Span.GetText() + "\".");

            bool is_capitals = false;
            bool warn = false;
            ReturnType returnType = ParseReturnType(word.Span.GetText(), is_capitals, warn);
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: findLeftHandType: F: ReturnType=\"" + returnType + "\".");
            return returnType;
        }

        private List<Completion> GetCompletions(ReturnType returnType)
        {
            //IntrinsicsDudeToolsStatic.Output_INFO("StatementCompletionSource: getCompletions: returnType=" + returnType);

            bool decorateIncompatibleStatementCompletions = Settings.Default.DecorateIncompatibleStatementCompletions_On;
            bool hideStatementCompletionIncompatibleReturnType = Settings.Default.HideStatementCompletionIncompatibleReturnType_On;

            List<Completion> completions = new List<Completion>();

            foreach (Tuple<Completion, ReturnType> e in IntrinsicsDudeTools.Instance.StatementCompletionStore.Intrinsic_Completions)
            {
                Completion completion = e.Item1;
                ReturnType returnType2 = e.Item2;

                if (!IsConversionPossible(returnType2, returnType))
                {
                    if (!hideStatementCompletionIncompatibleReturnType)
                    {
                        completions.Add((decorateIncompatibleStatementCompletions) ? this.Decorate(completion, "[Incompatible]") : completion);
                    }
                }
                else
                {
                    completions.Add(completion);
                }
            }

            this.AddRegisterCompletions(ref completions, returnType);
            return completions;
        }

        private Completion Decorate(Completion completion, string str)
        {
            string displayText = completion.DisplayText.Replace(" [", " " + str + "[");
            return new Completion(displayText, completion.InsertionText, completion.Description, completion.IconSource, completion.IconAutomationText);
        }

        #endregion
    }
}
