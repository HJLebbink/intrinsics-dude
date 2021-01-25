// The MIT License (MIT)
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
    using System.Diagnostics.Contracts;
    using IntrinsicsDude.SyntaxHighlighting;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Operations;
    using Microsoft.VisualStudio.Text.Tagging;
    using static IntrinsicsDude.Tools.IntrinsicTools;

    internal sealed class IntrinsicTokenTagger : ITagger<IntrinsicTokenTag>
    {
        private readonly ITextBuffer _buffer;
        private readonly ITextStructureNavigator _navigator;

        private readonly IntrinsicTokenTag _mnemonic;
        private readonly IntrinsicTokenTag _register;
        private readonly IntrinsicTokenTag _misc;
        private readonly IntrinsicTokenTag _UNKNOWN;

        internal IntrinsicTokenTagger(ITextBuffer buffer, ITextStructureNavigator navigator)
        {
            Contract.Requires(buffer != null);
            Contract.Requires(navigator != null);

            this._buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            this._navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));

            this._mnemonic = new IntrinsicTokenTag(IntrinsicTokenType.Intrinsic);
            this._register = new IntrinsicTokenTag(IntrinsicTokenType.RegType);
            this._misc = new IntrinsicTokenTag(IntrinsicTokenType.Misc);
            this._UNKNOWN = new IntrinsicTokenTag(IntrinsicTokenType.UNKNOWN);
        }

        event EventHandler<SnapshotSpanEventArgs> ITagger<IntrinsicTokenTag>.TagsChanged
        {
            add { }
            remove { }
        }

        public IEnumerable<ITagSpan<IntrinsicTokenTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            Contract.Requires(spans != null);
            //DateTime time1 = DateTime.Now;

            //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:GetTags: nSpans={1}", this.ToString(), spans.Count));

            if (spans.Count == 0)
            { //there is no content in the buffer
                yield break;
            }

            foreach (SnapshotSpan curSpan in spans)
            {
                SnapshotPoint point = curSpan.Start;
                while (true)
                {
                    TextExtent extent = this._navigator.GetExtentOfWord(point);
                    if (extent.IsSignificant)
                    {
                        string keyword = extent.Span.GetText();
                        //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:GetTags: at point={1}, found keyword \"{2}\".", this.ToString(), point.Position, keyword));

                        bool is_capitals = false;
                        bool warn = false;
                        if (ParseIntrinsic(keyword, is_capitals, warn) == Intrinsic.NONE)
                        {
                            if (ParseSimdRegisterType(keyword, is_capitals, warn) != SimdRegisterType.NONE)
                            {
                                //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:GetTags: found intrinsic type \"{1}\".", this.ToString(), keyword));
                                yield return new TagSpan<IntrinsicTokenTag>(extent.Span, new IntrinsicTokenTag(IntrinsicTokenType.RegType));
                            }
                        }
                        else
                        {
                            //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:GetTags: found intrinsic instruction \"{1}\".", this.ToString(), keyword));
                            yield return new TagSpan<IntrinsicTokenTag>(extent.Span, new IntrinsicTokenTag(IntrinsicTokenType.Intrinsic));
                        }
                    }

                    if (extent.Span.End.Position >= curSpan.End.Position)
                    {
                        //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:GetTags: leaving the loop. point={1}; curSpan.End={2}.", this.ToString(), point, curSpan.End));
                        break;
                    }

                    point = extent.Span.End + 1;
                }
            }

            //IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Intrinsic-Token-Tagger");
        }
    }
}
