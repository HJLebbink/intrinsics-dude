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
        private readonly IDictionary<ReturnType, Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>>> _cachedCompletions;
        private CpuID _cachedCompletionsCpuID;

        private ImageSource icon_IF; // icon created with http://www.sciweavers.org/free-online-latex-equation-editor Plum Modern 36
        private bool _disposed = false;

        private bool _anotateWronglyTypedCompletions = true;
        private bool _hideWronglyTypedCompletions_Existing = false;
        private bool _hideDisabledCompletions_Existing = false;

        private bool _hideWronglyTypedCompletions_New = false;

        public CodeCompletionSource(ITextBuffer buffer, ITextStructureNavigator navigator)
        {
            this._buffer = buffer;
            this._navigator = navigator;

            this._cachedCompletions = new Dictionary<ReturnType, Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>>>();
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
                if (extent.IsSignificant)
                {
                    string partialKeyword = extent.Span.GetText();
                    //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: AugmentCompletionSession: partialKeyword=\"" + partialKeyword + "\".");

                    if (partialKeyword.Length > 0)
                    {
                        if (partialKeyword[0].Equals('_'))
                        {
                            ReturnType restrictedTo = this.findCompletionRestriction(extent);
                            Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>> tup = this.getAllowedCompletions(IntrinsicsDudeToolsStatic.getCpuIDSwithedOn(), restrictedTo);
                            SortedSet<Completion> set_intr = tup.Item1;
                            if (completionSets.Count > 0)
                            {
                                ISet<Intrinsic> alreadyPresent = tup.Item2;
                                ISet<Intrinsic> disabled = tup.Item3;
                                ISet<Intrinsic> disallowed = tup.Item4;
                                CompletionSet set_old = completionSets[0];
                                SortedSet<Completion> set_all = new SortedSet<Completion>(set_intr, new CompletionComparer());
                                IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: AugmentCompletionSession: retrieved " + set_all.Count + " intrinsic completions");

                                foreach (Completion c in set_old.Completions)
                                {
                                    string oldCompletionsText = c.InsertionText;
                                    Intrinsic existingIntrinsic = IntrinsicTools.parseIntrinsic(oldCompletionsText, false);
                                    if (existingIntrinsic == Intrinsic.NONE)
                                    {
                                        set_all.Add(c);
                                    }
                                    else
                                    {
                                        if (alreadyPresent.Contains(existingIntrinsic))
                                        {
                                            // do nothing
                                        }
                                        else if (disabled.Contains(existingIntrinsic))
                                        {
                                            if (_hideDisabledCompletions_Existing)
                                            {
                                                //TODO: unquote following line
                                                set_all.Add(new Completion("[disabled] " + c.DisplayText, oldCompletionsText, c.Description, c.IconSource, c.IconAutomationText));
                                            }
                                            else
                                            {
                                                set_all.Add(new Completion("[disabled] " + c.DisplayText, oldCompletionsText, c.Description, c.IconSource, c.IconAutomationText));
                                            }
                                        }
                                        else if (disallowed.Contains(existingIntrinsic))
                                        {
                                            if (_hideWronglyTypedCompletions_Existing)
                                            {
                                                //TODO: unquote following line
                                                set_all.Add(new Completion("[disallowed] " + c.DisplayText, oldCompletionsText, c.Description, c.IconSource, c.IconAutomationText));
                                            }
                                            else
                                            {
                                                set_all.Add(new Completion("[disallowed] " + c.DisplayText, oldCompletionsText, c.Description, c.IconSource, c.IconAutomationText));
                                            }
                                        }
                                    }
                                }
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

        private ReturnType findCompletionRestriction(TextExtent currentKeywordExtent)
        {
            if (!Settings.Default.CodeCompletionRestrictions_On)
            {
                return ReturnType.NONE;
            }

            ReturnType returnType = this.findLeftHandType(currentKeywordExtent);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findCompletionRestriction: A: returnType=" + returnType);
            if (returnType == ReturnType.NONE)
            {
                returnType = findEmbeddedType(currentKeywordExtent);
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findCompletionRestriction: B: returnType=" + returnType);
            }
            ReturnType returnType2 = returnType;
            switch (returnType)
            {
                case ReturnType.NONE:
                case ReturnType.__INT16:
                case ReturnType.__INT32:
                case ReturnType.__INT64:
                case ReturnType.__INT8:
                case ReturnType.CONST_VOID_PTR:
                //case ReturnType.DOUBLE:
                //case ReturnType.FLOAT:
                case ReturnType.INT:
                case ReturnType.SHORT:
                case ReturnType.UNSIGNED__INT32:
                case ReturnType.UNSIGNED__INT64:
                case ReturnType.UNSIGNED_CHAR:
                case ReturnType.UNSIGNED_INT:
                case ReturnType.UNSIGNED_LONG:
                case ReturnType.UNSIGNED_SHORT:

                case ReturnType.VOID:
                case ReturnType.VOID_PTR:
                    returnType2 = ReturnType.NONE;
                    break;
            }
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: findCompletionRestriction; returnType=" + returnType+ "; returnType2="+ returnType2);
            return returnType2;
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

        private Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>> getAllCompletions(CpuID selectedArchitectures)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: getAllMnemonics; selectedArchitectures=" + selectedArchitectures);

            SortedSet<Completion> completions = new SortedSet<Completion>(new CompletionComparer());
            ISet<Intrinsic> alreadyPresent = new HashSet<Intrinsic>();
            ISet<Intrinsic> disallowed = new HashSet<Intrinsic>();
            ISet<Intrinsic> disabled = new HashSet<Intrinsic>();

            foreach (ReturnType returnType in Enum.GetValues(typeof(ReturnType)))
            {
                if (returnType != ReturnType.NONE)
                {
                    Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>> tup = this.getAllowedCompletions(selectedArchitectures, returnType);
                    foreach (Completion c in tup.Item1)
                    {
                        completions.Add(c);
                    }
                    foreach (Intrinsic s in tup.Item2)
                    {
                        alreadyPresent.Add(s);
                    }
                    foreach (Intrinsic s in tup.Item3)
                    {
                        disabled.Add(s);
                    }
                    foreach (Intrinsic s in tup.Item4)
                    {
                        disallowed.Add(s);
                    }
                }
            }
            return new Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>>(completions, alreadyPresent, disabled, disallowed);
        }

        /// <summary>
        /// Returns 1] sorted set of allowed completions, 2] list of intrinsics that are disabled, 3] list of intrinsics that are disallowed
        /// </summary>
        private Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>> getAllowedCompletions(CpuID selectedArchitectures, ReturnType returnType)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: getAllowedCompletions; selectedArchitectures=" + IntrinsicTools.ToString(selectedArchitectures) + "; returnType=" + returnType);

            DateTime time1 = DateTime.Now;

            if (returnType == ReturnType.NONE)
            {   // if there is no restriction on the possible completions, return all completions for all return types
                return this.getAllCompletions(selectedArchitectures);
            }

            CpuID currentCpuID = IntrinsicsDudeToolsStatic.getCpuIDSwithedOn();
            if (this._cachedCompletionsCpuID != currentCpuID)
            {
                this._cachedCompletionsCpuID = currentCpuID;
                this._cachedCompletions.Clear();
            }


            if (!this._cachedCompletions.ContainsKey(returnType))
            {
                IntrinsicStore store = IntrinsicsDudeTools.Instance.intrinsicStore;
                SortedSet<Completion> completions = new SortedSet<Completion>(new CompletionComparer());
                ISet<Intrinsic> present = new HashSet<Intrinsic>();
                ISet<Intrinsic> disabledSet = new HashSet<Intrinsic>();
                ISet<Intrinsic> disallowedSet = new HashSet<Intrinsic>();

                foreach (Intrinsic intrinsic in Enum.GetValues(typeof(Intrinsic)))
                {
                    if (intrinsic == Intrinsic.NONE) continue;
                    IList<IntrinsicDataElement> dataElements = store.get(intrinsic);

                    CpuID cpuID = CpuID.NONE;
                    foreach (IntrinsicDataElement dataElement in dataElements)
                    {
                        if (IntrinsicTools.isCpuID_Enabled(dataElement.cpuID, selectedArchitectures)) {
                            cpuID |= dataElement.cpuID;
                        }
                    }

                    // if (cpuID == CpuID.AVX512F) 
                    //     IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: getAllowedCompletions; cpuID=" + cpuID);

                    //if (intrinsic == Intrinsic._MM512_ANDNOT_EPI32) IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: getAllowedCompletions; intrinsic=" + intrinsic+"; cpuID=" + cpuID);


                    bool disabled = (cpuID == CpuID.NONE);
                    if (disabled)
                    {
                        disabledSet.Add(intrinsic);
                    }
                    else
                    {
                        IntrinsicDataElement dataElementFirst = dataElements[0];
                        bool correctType = (dataElementFirst.returnType == returnType);

                        if (_hideWronglyTypedCompletions_New)
                        {
                            if (correctType)
                            {
                                present.Add(intrinsic);
                                completions.Add(this.createCompletion(intrinsic.ToString().ToLower(), cpuID, dataElementFirst, true));
                            }
                            else
                            {
                                disallowedSet.Add(intrinsic);
                            }
                        }
                        else
                        {
                            present.Add(intrinsic);
                            completions.Add(this.createCompletion(intrinsic.ToString().ToLower(), cpuID, dataElementFirst, correctType));
                        }
                    }
                }
                this._cachedCompletions.Add(returnType, new Tuple<SortedSet<Completion>, ISet<Intrinsic>, ISet<Intrinsic>, ISet<Intrinsic>>(completions, present, disabledSet, disallowedSet));
            }
            IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Initializing Code Completion");
            return this._cachedCompletions[returnType];
        }

        private Completion createCompletion(string intrinsicStr, CpuID cpuID, IntrinsicDataElement dataElement, bool correctType)
        {
            string cpuID_str = (cpuID == CpuID.IA32) ? "" : " [" + IntrinsicTools.ToString(cpuID) + "]";
            string prefix = (_anotateWronglyTypedCompletions) ? ((correctType) ? "" : "[wrong type] ") : ""; 
            string displayText = IntrinsicsDudeToolsStatic.cleanup(prefix + intrinsicStr + cpuID_str + " - " + dataElement.description, IntrinsicsDudePackage.maxNumberOfCharsInCompletions);
            //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: getAllowedMnemonics; adding displayText=" + displayText);
            return new Completion(displayText, intrinsicStr, dataElement.documenationString, this.icon_IF, "");
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
