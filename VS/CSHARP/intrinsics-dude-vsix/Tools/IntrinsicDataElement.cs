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

using AsmTools;
using System;
using System.Collections.Generic;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.Tools
{
    public class IntrinsicDataElement
    {
        public Intrinsic intrinsic;
        public ReturnType returnType;
        public readonly IList<Tuple<ParamType, string>> parameters;
        public CpuID cpuID;
        public int id;
        public Mnemonic instruction;
        public bool isSVML;

        public string description;
        public string performance;
        public string operation;

        
        /// <summary>Constructor</summary>
        public IntrinsicDataElement()
        {
            parameters = new List<Tuple<ParamType, string>>();
        }
    }
}
