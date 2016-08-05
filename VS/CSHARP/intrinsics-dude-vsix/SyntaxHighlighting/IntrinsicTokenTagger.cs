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
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using IntrinsicsDude.SyntaxHighlighting;
using IntrinsicsDude.Tools;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude
{
    internal sealed class IntrinsicTokenTagger : ITagger<IntrinsicTokenTag>
    {
        private readonly ITextBuffer _buffer;
        private readonly IntrinsicsDudeTools _asmDudeTools = null;

        private readonly IntrinsicTokenTag _mnemonic;
        private readonly IntrinsicTokenTag _register;
        private readonly IntrinsicTokenTag _misc;
        private readonly IntrinsicTokenTag _UNKNOWN;

        internal IntrinsicTokenTagger(ITextBuffer buffer)
        {
            this._buffer = buffer;
            this._asmDudeTools = IntrinsicsDudeTools.Instance;

            this._mnemonic = new IntrinsicTokenTag(IntrinsicTokenType.Intrinsic);
            this._register = new IntrinsicTokenTag(IntrinsicTokenType.RegType);
            this._misc = new IntrinsicTokenTag(IntrinsicTokenType.Misc);
            this._UNKNOWN = new IntrinsicTokenTag(IntrinsicTokenType.UNKNOWN);
        }

        event EventHandler<SnapshotSpanEventArgs> ITagger<IntrinsicTokenTag>.TagsChanged {
            add { }
            remove { }
        }

        private static bool isSeparatorChar(char c)
        {
            if (char.IsLetterOrDigit(c))
            {
                return false;
            }
            if (char.IsWhiteSpace(c) || char.IsControl(c) || c.Equals('(') || c.Equals(')') || c.Equals('='))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ITagSpan<IntrinsicTokenTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            DateTime time1 = DateTime.Now;

            if (spans.Count == 0)
            {  //there is no content in the buffer
                yield break;
            }

            foreach (SnapshotSpan curSpan in spans)
            {
                ITextSnapshotLine containingLine = curSpan.Start.GetContainingLine();
                int curLoc = containingLine.Start.Position;

                string line = containingLine.GetText();

                int startPos = 0;
                for (int i = 0; i < line.Length; ++i)
                {
                    if (isSeparatorChar(line[i]))
                    {
                        int length = i - startPos;
                        if (length > 0)
                        {
                            string keyword = line.Substring(startPos, length);
                            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTokenTagger:GetTags: found keyword \"" + keyword+"\".");
                            Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(keyword);
                            if (intrinsic == Intrinsic.NONE)
                            {
                                IntrinsicRegisterType reg = IntrinsicTools.parseIntrinsicRegisterType(keyword);
                                if (reg == IntrinsicRegisterType.NONE)
                                {
                                    // do nothing
                                } else
                                {
                                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTokenTagger:GetTags: found intrinsic type \"" + keyword + "\".");
                                    SnapshotSpan span = new SnapshotSpan(curSpan.Snapshot, new Span(curLoc + startPos, length));
                                    yield return new TagSpan<IntrinsicTokenTag>(span, new IntrinsicTokenTag(IntrinsicTokenType.RegType));
                                }
                            }
                            else
                            {
                                //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTokenTagger:GetTags: found intrinsic instruction \"" + keyword + "\".");
                                SnapshotSpan span = new SnapshotSpan(curSpan.Snapshot, new Span(curLoc + startPos, length));
                                yield return new TagSpan<IntrinsicTokenTag>(span, new IntrinsicTokenTag(IntrinsicTokenType.Intrinsic));
                            }
                        }
                        startPos = i+1;
                    }
                    else
                    {   // do not change the startPos
                    }
                }
            }
            IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "IntrinsicTokenTagger");
        }
    }
}
