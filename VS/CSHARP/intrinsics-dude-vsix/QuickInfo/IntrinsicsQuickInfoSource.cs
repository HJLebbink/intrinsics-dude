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
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using IntrinsicsDude.SyntaxHighlighting;
using IntrinsicsDude.Tools;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Text;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.QuickInfo
{
    /// <summary>
    /// Provides QuickInfo information to be displayed in a text buffer
    /// </summary>
    internal sealed class IntrinsicsQuickInfoSource : IQuickInfoSource
    {
        private readonly ITextBuffer _sourceBuffer;
        private readonly ITagAggregator<IntrinsicTokenTag> _aggregator;
        private readonly IntrinsicsDudeTools _intrinsicDudeTools;

        public object CSharpEditorResources { get; private set; }

        public IntrinsicsQuickInfoSource(
                ITextBuffer buffer,
                ITagAggregator<IntrinsicTokenTag> aggregator)
        {
            this._sourceBuffer = buffer;
            this._aggregator = aggregator;
            this._intrinsicDudeTools = IntrinsicsDudeTools.Instance;
        }

        /// <summary>
        /// Determine which pieces of Quickinfo content should be displayed
        /// </summary>
        public void AugmentQuickInfoSession(IQuickInfoSession session, IList<object> quickInfoContent, out ITrackingSpan applicableToSpan)
        {
            applicableToSpan = null;
            try
            {
                DateTime time1 = DateTime.Now;

                ITextSnapshot snapshot = _sourceBuffer.CurrentSnapshot;
                var triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
                if (triggerPoint == null)
                {
                    return;
                }

                IEnumerable<IMappingTagSpan<IntrinsicTokenTag>> enumerator = this._aggregator.GetTags(new SnapshotSpan(triggerPoint, triggerPoint));
                if (enumerator.Count() > 1)
                {
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: enumerator has " + enumerator.Count() + " elements");
                }
                if (enumerator.Count() > 0)
                {
                    IMappingTagSpan<IntrinsicTokenTag> tokenTag = enumerator.First();
                    switch (tokenTag.Tag.type)
                    {
                        case IntrinsicTokenType.Intrinsic:
                            {
                                SnapshotSpan tagSpan = tokenTag.Span.GetSpans(_sourceBuffer).First();
                                string keyword = tagSpan.GetText();
                                applicableToSpan = snapshot.CreateTrackingSpan(tagSpan, SpanTrackingMode.EdgeExclusive);

                                //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: keyword=" + keyword);
                                Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(keyword);
                                if (intrinsic != Intrinsic.NONE)
                                {
                                    IntrinsicDataElement dataElement = this._intrinsicDudeTools.intrinsicStore.get(intrinsic);
                                    if (dataElement != null)
                                    {
                                        IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: intrinsic=" + intrinsic);
                                        if (quickInfoContent.Count > 0)
                                        {
                                            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: removing existing content: intrinsic=" + intrinsic + "; " + quickInfoContent[0].ToString());
                                            quickInfoContent.Clear(); // throw the existing quickinfo away
                                        }
                                        quickInfoContent.Add(dataElement.descriptionTextBlock);
                                    }
                                }
                            }
                            break;
                        case IntrinsicTokenType.RegType:
                            {
                                SnapshotSpan tagSpan = tokenTag.Span.GetSpans(_sourceBuffer).First();
                                string keyword = tagSpan.GetText();
                                applicableToSpan = snapshot.CreateTrackingSpan(tagSpan, SpanTrackingMode.EdgeExclusive);

                                IntrinsicRegisterType reg = IntrinsicTools.parseIntrinsicRegisterType(keyword);
                                if (reg != IntrinsicRegisterType.NONE)
                                {
                                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: reg=" + reg);
                                    TextBlock description = this.makeRegisterDescription(reg);
                                    if (description != null)
                                    {
                                        quickInfoContent.Add(description);
                                    }
                                }
                            }
                            break;
                        default: break;
                    }
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "QuickInfo");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:AugmentQuickInfoSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public void Dispose()
        {
            //empty
        }

        #region Private Methods

        private TextBlock makeRegisterDescription(IntrinsicRegisterType reg)
        {
            TextBlock description = new TextBlock();
            description.Inlines.Add(makeRunBold(reg.ToString()));
            return description;
        }

        private static Run makeRunBold(string str)
        {
            Run r1 = new Run(str);
            r1.FontWeight = FontWeights.Bold;
            return r1;
        }

        private static Run makeRun2(string str, System.Drawing.Color color)
        {
            Run r1 = new Run(str);
            r1.FontWeight = FontWeights.Bold;
            r1.Foreground = new SolidColorBrush(IntrinsicsDudeToolsStatic.convertColor(color));
            return r1;
        }

        #endregion Private Methods
    }
}

