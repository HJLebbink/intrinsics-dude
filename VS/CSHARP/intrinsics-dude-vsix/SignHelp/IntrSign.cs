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

using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.ObjectModel;

namespace IntrinsicsDude.SignHelp
{
    internal class IntrSign : ISignature
    {
        private readonly ITextBuffer _subjectBuffer;
        private IParameter _currentParameter;
        private string _content;
        private string _documentation;
        private ITrackingSpan _applicableToSpan;
        private ReadOnlyCollection<IParameter> _parameters;
        private string _printContent;


        internal IntrSign(ITextBuffer subjectBuffer, string content, string doc, ReadOnlyCollection<IParameter> parameters)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: constructor");
            this._subjectBuffer = subjectBuffer;
            this._content = content;
            this._documentation = doc;
            this._parameters = parameters;
        }

        public event EventHandler<CurrentParameterChangedEventArgs> CurrentParameterChanged;

        public IParameter CurrentParameter {
            get { return this._currentParameter; }
            internal set { this._currentParameter = value; }
        }

        public ITrackingSpan ApplicableToSpan {
            get { return (this._applicableToSpan); }
            internal set { this._applicableToSpan = value; }
        }

        public void SetCurrentParameter(int paramIndex)
        {
            this._currentParameter = ((paramIndex >= 0) && (paramIndex < this.Parameters.Count)) ? this.Parameters[paramIndex] : null;
        }

        public string Content {
            get { return (_content); }
            internal set { _content = value; }
        }

        public string Documentation {
            get { return (_documentation); }
            internal set { _documentation = value; }
        }

        public ReadOnlyCollection<IParameter> Parameters {
            get { return (_parameters); }
            internal set { _parameters = value; }
        }

        public string PrettyPrintedContent {
            get { return (_printContent); }
            internal set { _printContent = value; }
        }
        
     }
}
