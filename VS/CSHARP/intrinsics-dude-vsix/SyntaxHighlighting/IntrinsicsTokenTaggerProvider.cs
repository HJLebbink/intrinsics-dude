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

using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Text;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

using IntrinsicsDude.SyntaxHighlighting;
using System;
using IntrinsicsDude.Tools;
using AsmTools;

namespace IntrinsicsDude {

    [Export(typeof(ITaggerProvider))]
    [ContentType(IntrinsicsDudePackage2.IntrinsicsDudeContentType)]
    [TagType(typeof(AsmTokenTag))]
    internal sealed class IntrinsicsTokenTagProvider : ITaggerProvider {

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag {
            Func <ITagger<T>> sc = delegate () {
                return new NasmTokenTagger(buffer) as ITagger<T>;
            };
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsTokenTagProvider:CreateTagger");
            return buffer.Properties.GetOrCreateSingletonProperty(sc);
        }
    }
}
