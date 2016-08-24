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

    public sealed class CodeCompletionSource : ICompletionSource
    {
        private readonly ITextBuffer _buffer;
        private readonly ITextStructureNavigator _navigator;
        private readonly StatementCompletionStore _completionStore;
        private bool _disposed = false;

        public CodeCompletionSource(ITextBuffer buffer, ITextStructureNavigator navigator)
        {
            this._buffer = buffer;
            this._navigator = navigator;
            this._completionStore = new StatementCompletionStore();
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: AugmentCompletionSession");

            if (_disposed) return;
            if (!Settings.Default.StatementCompletion_On) return;

            try
            {
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
                    //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: AugmentCompletionSession: partialKeyword=\"" + partialKeyword + "\".");

                    if (partialKeyword.Length > 0)
                    {
                        if (partialKeyword[0].Equals('_'))
                        {
                            ReturnType restrictedTo = this.findCompletionRestriction(extent);
                            SortedSet<Completion> set_intr = this.getCompletions(restrictedTo);
                            if (completionSets.Count > 0)
                            {
                                CompletionSet set_old = completionSets[0];
                                SortedSet<Completion> set_all = this.addExistingCompletions(set_intr, set_old.Completions);

                                completionSets.Clear();
                                completionSets.Add(new CompletionSet(set_old.Moniker, set_old.DisplayName, set_old.ApplicableTo, set_all, set_old.CompletionBuilders));
                                completionSets.Add(new CompletionSet("Intrinsics", "Intrinsics", set_old.ApplicableTo, set_intr, Enumerable.Empty<Completion>()));
                                completionSets.Add(new CompletionSet("Original", "Original", set_old.ApplicableTo, set_old.Completions, set_old.CompletionBuilders));
                            }
                            else
                            {
                                ITrackingSpan applicableTo = snapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeExclusive, TrackingFidelityMode.Forward);
                                completionSets.Add(new CompletionSet("Intrinsics", "Intrinsics", applicableTo, set_intr, Enumerable.Empty<Completion>()));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: CodeCompletionSource:AugmentCompletionSession; e=" + e.ToString());
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

        SortedSet<Completion> addExistingCompletions(SortedSet<Completion> set, IList<Completion> existing)
        {
            SortedSet<Completion> set2 = new SortedSet<Completion>(set, new CompletionComparer());
            foreach (Completion c in existing)
            {
                string oldCompletionsText = c.InsertionText;
                Intrinsic existingIntrinsic = IntrinsicTools.parseIntrinsic(oldCompletionsText, false);
                if (existingIntrinsic == Intrinsic.NONE)
                {
                    set2.Add(c);
                }
            }
            return set2;
        }

        private ReturnType findCompletionRestriction(TextExtent currentKeywordExtent)
        {
            ReturnType returnType = this.findLeftHandType(currentKeywordExtent);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findCompletionRestriction: A: returnType=" + returnType);
            if (returnType == ReturnType.NONE)
            {
                returnType = findEmbeddedType(currentKeywordExtent);
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findCompletionRestriction: B: returnType=" + returnType);
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
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findEmbeddedType: B: returnType=" + returnType);
            return returnType;
        }

        private ReturnType findLeftHandType(TextExtent currentKeywordExtent)
        {
            TextExtent word = this._navigator.GetExtentOfWord(currentKeywordExtent.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findLeftHandType: A: word=\"" + word.Span.GetText() + "\".");

            if (word.Span.GetText().Equals(" "))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findLeftHandType: B: word=\"" + word.Span.GetText() + "\".");
            }
            if (word.Span.GetText().Equals("="))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findLeftHandType: C: word=\"" + word.Span.GetText() + "\".");
            }
            else
            {
                return ReturnType.NONE;
            }
            if (word.Span.GetText().Equals(" "))
            {
                word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findLeftHandType: D: word=\"" + word.Span.GetText() + "\".");
            }
            word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findLeftHandType: E: word=\"" + word.Span.GetText() + "\".");

            word = this._navigator.GetExtentOfWord(word.Span.Start - 1);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findLeftHandType: E: word=\"" + word.Span.GetText() + "\".");
            ReturnType returnType = IntrinsicTools.parseReturnType(word.Span.GetText(), false);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findLeftHandType: F: ReturnType=\"" + returnType + "\".");
            return returnType;
        }

        /// <summary>
        /// Returns 1] sorted set of allowed completions, 2] list of intrinsics that are disabled, 3] list of intrinsics that are disallowed
        /// </summary>
        private SortedSet<Completion> getCompletions(ReturnType returnType)
        {
            DateTime time1 = DateTime.Now;

            bool decorateIncompatibleStatementCompletions = Settings.Default.DecorateIncompatibleStatementCompletions_On;
            bool hideStatementCompletionIncompatibleReturnType = Settings.Default.HideStatementCompletionIncompatibleReturnType_On;

            SortedSet<Completion> completions = new SortedSet<Completion>(new CompletionComparer());

            foreach (Tuple<Completion, ReturnType> e in _completionStore.data)
            {
                Completion completion = e.Item1;
                ReturnType returnType2 = e.Item2;

                if (!isCompatible(returnType2, returnType))
                {
                    if (!hideStatementCompletionIncompatibleReturnType)
                    {
                        if (decorateIncompatibleStatementCompletions)
                        {
                            completions.Add(decorate(completion, "[Incompatible]"));
                        }
                        else
                        {
                            completions.Add(completion);
                        }
                    }
                }
                else
                {
                    completions.Add(completion);
                }
            }
            IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Initializing Code Completion");
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
