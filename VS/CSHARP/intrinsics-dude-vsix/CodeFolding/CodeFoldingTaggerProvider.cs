﻿// The MIT License (MIT)
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

using IntrinsicsDude.SyntaxHighlighting;
using IntrinsicsDude.Tools;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;

namespace IntrinsicsDude.CodeFolding {

    /// <summary>
    /// Export a <see cref="ITaggerProvider"/>
    /// </summary>
    [Export(typeof(ITaggerProvider))]
    [ContentType(IntrinsicsDudePackage2.AsmDudeContentType)]
    [TagType(typeof(IOutliningRegionTag))]
    internal sealed class CodeFoldingTaggerProvider : ITaggerProvider {

        [Import]
        private IBufferTagAggregatorFactoryService _aggregatorFactory = null;

        /// <summary>
        /// This method is called by VS to generate the tagger
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textView"> The text view we are creating a tagger for</param>
        /// <returns> Returns a OutliningTagger instance</returns>
        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag {

            //Debug.WriteLine("INFO: TaggerProvider:CreateTagger: entering");
            Func<ITagger<T>> sc = delegate () {
                ITagAggregator<AsmTokenTag> aggregator = IntrinsicsDudeToolsStatic.getAggregator(buffer, this._aggregatorFactory);
                return new CodeFoldingTagger(buffer, aggregator, AsmDudeTools.Instance.errorListProvider) as ITagger<T>;
            };
            return buffer.Properties.GetOrCreateSingletonProperty(sc);
        }
    }
}
