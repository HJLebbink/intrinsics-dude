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
using static IntrinsicsDude.Tools.IntrinsicTools;
using System.Windows.Media;
using System.IO;
using Microsoft.VisualStudio.Text.Operations;

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
        private readonly ITextStructureNavigator _navigator;
        private readonly IDictionary<ReturnType, Tuple<SortedSet<Completion>, ISet<string>>> _cachedCompletions;
        private CpuID _cachedCompletionsCpuID;

        private ImageSource icon_IF; // icon created with http://www.sciweavers.org/free-online-latex-equation-editor Plum Modern 36
        private bool _disposed = false;

        public CodeCompletionSource(ITextBuffer buffer, ITextStructureNavigator nav)
        {
            this._buffer = buffer;
            this._navigator = nav;

            this._cachedCompletions = new Dictionary<ReturnType, Tuple<SortedSet<Completion>, ISet<string>>>();
            this._cachedCompletionsCpuID = CpuID.NONE;
            this.loadIcons();
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: AugmentCompletionSession");

            if (_disposed) return;
            if (!Settings.Default.CodeCompletion_On) return;

            try
            {
                ITextSnapshot snapshot = this._buffer.CurrentSnapshot;
                SnapshotPoint triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
                if (triggerPoint == null)
                {
                    return;
                }

                TextExtent extent = this._navigator.GetExtentOfWord(triggerPoint - 1); // minus one to get the previous word
                string partialKeyword = extent.Span.GetText();
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: AugmentCompletionSession: partialKeyword=\"" + partialKeyword + "\".");

                if (partialKeyword.Length > 0)
                {
                    if (partialKeyword[0].Equals('_'))
                    {
                        ReturnType restrictedTo = this.findCompletionRestriction(extent);
                        Tuple<SortedSet<Completion>, ISet<string>> tup = this.getAllowedMnemonics(IntrinsicsDudeToolsStatic.getCpuIDSwithedOn(), restrictedTo);
                        SortedSet<Completion> set_intr = tup.Item1;
                        if (completionSets.Count > 0)
                        {
                            ISet<string> notAllowed = tup.Item2;
                            CompletionSet set_old = completionSets[0];
                            SortedSet<Completion> set_all = new SortedSet<Completion>(set_intr, new CompletionComparer());

                            foreach (Completion c in set_old.Completions)
                            {
                                if (!notAllowed.Contains(c.InsertionText))
                                {
                                    set_all.Add(c);
                                }
                            }

                            completionSets.Clear();
                            completionSets.Add(new CompletionSet(set_old.Moniker, set_old.DisplayName, set_old.ApplicableTo, set_all, set_old.CompletionBuilders));
                            completionSets.Add(new CompletionSet("Intrinsics", "Intrinsics", set_old.ApplicableTo, set_intr, set_old.CompletionBuilders));
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

        private ReturnType findCompletionRestriction(TextExtent currentKeywordExtent)
        {
            ReturnType returnType = this.findLeftHandType(currentKeywordExtent);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findCompletionRestriction: A: returnType=" + returnType);
            if (returnType == ReturnType.NONE)
            {
                returnType = findEmbeddedType(currentKeywordExtent);
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findCompletionRestriction: B: returnType=" + returnType);
            }
            return returnType;
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
        /// Returns the sorted set of selected completions and the list of intrinsics that are not allowed
        /// </summary>
        private Tuple<SortedSet<Completion>, ISet<string>> getAllowedMnemonics(CpuID selectedArchitectures, ReturnType returnType)
        {
            DateTime time1 = DateTime.Now;
            CpuID currentCpuID = IntrinsicsDudeToolsStatic.getCpuIDSwithedOn();
            if (this._cachedCompletionsCpuID != currentCpuID)
            {
                this._cachedCompletionsCpuID = currentCpuID;
                this._cachedCompletions.Clear();
            }

            if (!this._cachedCompletions.ContainsKey(returnType))
            {
                IntrinsicStore store = IntrinsicsDudeTools.Instance.intrinsicStore;
                SortedSet<Completion> set = new SortedSet<Completion>(new CompletionComparer());
                ISet<string> disallowed = new HashSet<string>();

                foreach (Intrinsic intrinsic in Enum.GetValues(typeof(Intrinsic)))
                {
                    if (intrinsic == Intrinsic.NONE) continue;
                    IList<IntrinsicDataElement> dataElements = store.get(intrinsic);

                    CpuID cpuID = CpuID.NONE;
                    foreach (IntrinsicDataElement dataElement in dataElements)
                    {
                        if (dataElement.returnType == returnType)
                        {
                            if ((selectedArchitectures & dataElement.cpuID) != CpuID.NONE)
                            {
                                cpuID |= dataElement.cpuID;
                            }
                        }
                    }
                    if (cpuID == CpuID.NONE)
                    {
                        disallowed.Add(intrinsic.ToString().ToLower());
                    }
                    else
                    {
                        IntrinsicDataElement dataElement = dataElements[0];
                        string cpuID_str = (cpuID == CpuID.NONE) ? "" : " [" + IntrinsicTools.ToString(cpuID) + "]";
                        string displayText = IntrinsicsDudeToolsStatic.cleanup(dataElement.intrinsic.ToString().ToLower() + cpuID_str + " - " + dataElement.description, IntrinsicsDudePackage.maxNumberOfCharsInCompletions);
                        string insertionText = dataElement.intrinsic.ToString().ToLower();
                        //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: getAllowedMnemonics; adding =" + insertionText);
                        set.Add(new Completion(displayText, insertionText, dataElement.descriptionString, this.icon_IF, ""));
                    }
                }
                this._cachedCompletions.Add(returnType, new Tuple<SortedSet<Completion>, ISet<string>>(set, disallowed));
            }
            IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Initializing Code Completion");
            return this._cachedCompletions[returnType];
        }

        private void loadIcons()
        {
            Uri uri = null;
            string installPath = IntrinsicsDudeToolsStatic.getInstallPath();
            try
            {
                uri = new Uri(installPath + "Resources/images/icon-IF.png");
                this.icon_IF = IntrinsicsDudeToolsStatic.bitmapFromUri(uri);
            }
            catch (FileNotFoundException)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: CodeCompletionSource: loadIcons. could not find file \"" + uri.AbsolutePath + "\".");
            }
        }

        #endregion
    }
}
