﻿// The MIT License (MIT)
//
// Copyright (c) 2017 Henk-Jan Lebbink
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
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;

namespace IntrinsicsDude.QuickInfo
{
    /// <summary>
    /// Factory for quick info sources
    /// </summary>
    [Export(typeof(IQuickInfoSourceProvider))]
    [ContentType(IntrinsicsDudePackage.IntrinsicsDudeContentType)]
    [Name("Intrinsics QuickInfo Source Provider")]
    [Order(After = "default")] // order after the default quickinfo provider such the default tooltips can be removed
    internal sealed class IntrinsicsQuickInfoSourceProvider : IQuickInfoSourceProvider
    {
        [Import]
        private IBufferTagAggregatorFactoryService _aggregatorFactory = null;


        public IQuickInfoSource TryCreateQuickInfoSource(ITextBuffer buffer)
        {
            Func<IntrinsicsQuickInfoSource> sc = delegate ()
            {
                ITagAggregator<IntrinsicTokenTag> aggregator = IntrinsicsDudeToolsStatic.GetAggregator(buffer, this._aggregatorFactory);
                return new IntrinsicsQuickInfoSource(buffer, aggregator);
            };
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsQuickInfoSourceProvider: TryCreateQuickInfoSource");

            return buffer.Properties.GetOrCreateSingletonProperty(sc);
        }
    }
}
