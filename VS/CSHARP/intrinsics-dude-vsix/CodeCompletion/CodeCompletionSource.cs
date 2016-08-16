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
        private readonly SortedSet<Completion> _cachedCompletions;
        private CpuID _cachedCompletionsCpuID;

        private ImageSource icon_IF; // icon created with http://www.sciweavers.org/free-online-latex-equation-editor Plum Modern 36
        private bool _disposed = false;

        public CodeCompletionSource(ITextBuffer buffer, ITextStructureNavigator nav)
        {
            this._buffer = buffer;
            this._navigator = nav;
            this._cachedCompletions = new SortedSet<Completion>(new CompletionComparer());
            this._cachedCompletionsCpuID = CpuID.NONE;
            this.loadIcons();
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

                TextExtent extent = this._navigator.GetExtentOfWord(triggerPoint - 1); // minus one to get the previous word
                ITrackingSpan applicableTo = snapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeExclusive, TrackingFidelityMode.Forward);
                string partialKeyword = extent.Span.GetText();
                //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource: AugmentCompletionSession: partialKeyword=\"" + partialKeyword + "\".");
                
                if (partialKeyword.Length > 0)
                {
                    if (partialKeyword[0].Equals('_'))
                    {
                        bool useCapitals = IntrinsicsDudeToolsStatic.isAllUpper(partialKeyword);
                        SortedSet<Completion> completions = this.getAllowedMnemonics(useCapitals, IntrinsicsDudeToolsStatic.getCpuIDSwithedOn());
                        completionSets.Add(new CompletionSet("Intrinsics", "Intrinsics", applicableTo, completions, Enumerable.Empty<Completion>()));
                    }
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Code Completion");
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

        private SortedSet<Completion> getAllowedMnemonics(bool useCapitals, CpuID selectedArchitectures)
        {
            CpuID currentCpuID = IntrinsicsDudeToolsStatic.getCpuIDSwithedOn();
            if (this._cachedCompletionsCpuID != currentCpuID)
            {
                this._cachedCompletionsCpuID = currentCpuID;
                this._cachedCompletions.Clear();

                IntrinsicStore store = IntrinsicsDudeTools.Instance.intrinsicStore;

                foreach (Intrinsic intrinsic in Enum.GetValues(typeof(Intrinsic)))
                {
                    if (intrinsic == Intrinsic.NONE) continue;

                    IList<IntrinsicDataElement> dataElements = store.get(intrinsic);
                    CpuID cpuID = CpuID.NONE;
                    foreach (IntrinsicDataElement dataElement in dataElements)
                    {
                        if ((selectedArchitectures & dataElement.cpuID) != CpuID.NONE)
                        {
                            cpuID |= dataElement.cpuID;
                        }
                    }
                    if (cpuID != CpuID.NONE)
                    {
                        IntrinsicDataElement dataElement = dataElements[0];
                        string displayText = IntrinsicsDudeToolsStatic.cleanup(dataElement.intrinsic.ToString().ToLower() + "[" + IntrinsicTools.ToString(cpuID) + "] - " + dataElement.description, IntrinsicsDudePackage.maxNumberOfCharsInCompletions);
                        string insertionText = dataElement.intrinsic.ToString().ToLower();
                        //string insertionText = (useCapitals) ? dataElement.intrinsic.ToString() : dataElement.intrinsic.ToString().ToLower();
                        //IntrinsicsDudeToolsStatic.Output("INFO: CodeCompletionSource:getAllowedMnemonics; adding =" + insertionText);
                        this._cachedCompletions.Add(new Completion(displayText, insertionText, dataElement.descriptionString, this.icon_IF, ""));
                    }
                }
            }
            return this._cachedCompletions;
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
