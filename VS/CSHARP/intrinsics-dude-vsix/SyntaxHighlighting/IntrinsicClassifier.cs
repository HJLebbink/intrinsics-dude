﻿// The MIT License (MIT)
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

namespace IntrinsicsDude
{
    using System;
    using System.Collections.Generic;
    using IntrinsicsDude.SyntaxHighlighting;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Text.Tagging;

    internal sealed class IntrinsicClassifier : ITagger<ClassificationTag>
    {
        //private readonly ITextBuffer _buffer;
        private readonly ITagAggregator<IntrinsicTokenTag> _aggregator;

        private readonly ClassificationTag _intrinsic;
        private readonly ClassificationTag _register;
        private readonly ClassificationTag _misc;

        /// <summary>
        /// Construct the classifier and define search tokens
        /// </summary>
        internal IntrinsicClassifier(
                ITagAggregator<IntrinsicTokenTag> aggregator,
                IClassificationTypeRegistryService typeService)
        {
            this._aggregator = aggregator ?? throw new ArgumentNullException(nameof(aggregator));

            this._intrinsic = new ClassificationTag(typeService.GetClassificationType(IntrinsicClassificationDefinition.ClassificationTypeNames.Intrinsic));
            this._register = new ClassificationTag(typeService.GetClassificationType(IntrinsicClassificationDefinition.ClassificationTypeNames.Register));
            //this._register = new ClassificationTag(typeService.GetClassificationType(PredefinedClassificationTypeNames.Keyword));
            this._misc = new ClassificationTag(typeService.GetClassificationType(IntrinsicClassificationDefinition.ClassificationTypeNames.Misc));
        }

        event EventHandler<SnapshotSpanEventArgs> ITagger<ClassificationTag>.TagsChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Search the given span for any instances of classified tags
        /// </summary>
        public IEnumerable<ITagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (Settings.Default.SyntaxHighlighting_On)
            {
                if (spans.Count == 0)
                { //there is no content in the buffer
                    yield break;
                }

                //DateTime time1 = DateTime.Now;
                foreach (IMappingTagSpan<IntrinsicTokenTag> tagSpan in this._aggregator.GetTags(spans))
                {
                    NormalizedSnapshotSpanCollection tagSpans = tagSpan.Span.GetSpans(spans[0].Snapshot);
                    switch (tagSpan.Tag.Type)
                    {
                        case IntrinsicTokenType.Intrinsic: yield return new TagSpan<ClassificationTag>(tagSpans[0], this._intrinsic); break;
                        case IntrinsicTokenType.RegType: yield return new TagSpan<ClassificationTag>(tagSpans[0], this._register); break;
                        case IntrinsicTokenType.Misc: yield return new TagSpan<ClassificationTag>(tagSpans[0], this._misc); break;
                        default:
                            break;
                    }
                }

                //IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Intrinsic-Classifier");
            }
            else
            {
                //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:GetTags: syntax highlighting is switched off", this.ToString()));
            }
        }
    }
}
