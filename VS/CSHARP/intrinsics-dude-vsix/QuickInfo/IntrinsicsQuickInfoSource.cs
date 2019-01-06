// The MIT License (MIT)
//
// Copyright (c) 2018 Henk-Jan Lebbink
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;

using IntrinsicsDude.SyntaxHighlighting;
using IntrinsicsDude.Tools;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.QuickInfo
{
    /// <summary>
    /// Provides QuickInfo information to be displayed in a text buffer
    /// </summary>
    internal sealed class IntrinsicsQuickInfoSource : IQuickInfoSource //TODO for IAsyncQuickInfoSource Reference Microsoft.VisualStudio.Language.Intellisense v16 is needed
    {
        private readonly ITextBuffer _sourceBuffer;
        private readonly ITagAggregator<IntrinsicTokenTag> _aggregator;
        private readonly IntrinsicsDudeTools _intrinsicDudeTools;
        private readonly Brush _textForegroundColor;

        public object CSharpEditorResources { get; private set; }

        public IntrinsicsQuickInfoSource(
            ITextBuffer buffer,
            ITagAggregator<IntrinsicTokenTag> aggregator)
        {
            this._sourceBuffer = buffer;
            this._aggregator = aggregator;
            this._intrinsicDudeTools = IntrinsicsDudeTools.Instance;
            this._textForegroundColor = IntrinsicsDudeToolsStatic.Get_Font_Color_Async().Result;
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

                ITextSnapshot snapshot = this._sourceBuffer.CurrentSnapshot;
                var triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
                if (triggerPoint == null)
                {
                    return;
                }

                Brush foreground = IntrinsicsDudeToolsStatic.Get_Font_Color_Async().Result;

                IEnumerable<IMappingTagSpan<IntrinsicTokenTag>> enumerator = this._aggregator.GetTags(new SnapshotSpan(triggerPoint, triggerPoint));
                if (enumerator.Count() > 1)
                {
                    IntrinsicsDudeToolsStatic.Output_WARNING(string.Format("{0}:AugmentQuickInfoSession: enumerator has {1} elements", this.ToString(), enumerator.Count()));
                }
                if (enumerator.Count() > 0)
                {
                    IMappingTagSpan<IntrinsicTokenTag> tokenTag = enumerator.First();
                    switch (tokenTag.Tag.Type)
                    {
                        case IntrinsicTokenType.Intrinsic:
                            {
                                SnapshotSpan tagSpan = tokenTag.Span.GetSpans(this._sourceBuffer).First();
                                string keyword = tagSpan.GetText();
                                applicableToSpan = snapshot.CreateTrackingSpan(tagSpan, SpanTrackingMode.EdgeExclusive);

                                //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: keyword=" + keyword);
                                Intrinsic intrinsic = ParseIntrinsic(keyword, false);
                                if (intrinsic != Intrinsic.NONE)
                                {
                                    IList<IntrinsicDataElement> dataElements = this._intrinsicDudeTools.IntrinsicStore.Get(intrinsic);
                                    if (dataElements.Count > 0)
                                    {
                                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: intrinsic=" + intrinsic);
                                        if (quickInfoContent.Count > 0)
                                        {
                                            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: removing existing content: intrinsic=" + intrinsic + "; " + quickInfoContent[0].ToString());
                                            quickInfoContent.Clear(); // throw the existing quickinfo away
                                        }
                                        quickInfoContent.Add(dataElements[0].DocumentationTextBlock(foreground)); //only show the description of the first intrinsic data element
                                    }
                                }
                            }
                            break;
                        case IntrinsicTokenType.RegType:
                            {
                                SnapshotSpan tagSpan = tokenTag.Span.GetSpans(this._sourceBuffer).First();
                                string keyword = tagSpan.GetText();
                                applicableToSpan = snapshot.CreateTrackingSpan(tagSpan, SpanTrackingMode.EdgeExclusive);

                                SimdRegisterType reg = ParseSimdRegisterType(keyword, true);
                                if (reg != SimdRegisterType.NONE)
                                {
                                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSource: AugmentQuickInfoSession: reg=" + reg);
                                    TextBlock description = this.MakeRegisterDescription(reg);
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
                IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "QuickInfo");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:AugmentQuickInfoSession; e={1}", this.ToString(), e.ToString()));
            }
        }

        public void Dispose()
        {
            //empty
        }

        #region Private Methods

        private TextBlock MakeRegisterDescription(SimdRegisterType reg)
        {
            TextBlock description = new TextBlock();
            description.Inlines.Add(MakeRunBold(reg.ToString(), this._textForegroundColor));
            return description;
        }

        private static Run MakeRunBold(string str, Brush foreGround)
        {
            Run r1 = new Run(str)
            {
                FontWeight = FontWeights.Bold,
                Foreground = foreGround
            };
            return r1;
        }

        private static Run MakeRun2(string str, Brush foreground) ///System.Drawing.Color color)
        {
            Run r1 = new Run(str)
            {
                FontWeight = FontWeights.Bold,
                Foreground = foreground // new SolidColorBrush(IntrinsicsDudeToolsStatic.ConvertColor(color))
            };
            return r1;
        }

        #endregion Private Methods
    }
}

