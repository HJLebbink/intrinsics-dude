// The MIT License (MIT)
//
// Copyright (c) 2019 Henk-Jan Lebbink
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

namespace IntrinsicsDude.SignHelp
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Text;

    internal class IntrSignature : ISignature
    {
        private readonly ITextBuffer m_subjectBuffer;
        private IParameter m_currentParameter;
        private string m_content;
        private string m_documentation;
        private ITrackingSpan m_applicableToSpan;
        private ReadOnlyCollection<IParameter> m_parameters;
        private string m_printContent;

        internal IntrSignature(ITextBuffer subjectBuffer, string content, string doc, ReadOnlyCollection<IParameter> parameters)
        {
            //IntrinsicsDudeToolsStatic.Output_INFO("IntrSign: constructor");
            this.m_subjectBuffer = subjectBuffer;
            this.m_content = content;
            this.m_documentation = doc;
            this.m_parameters = parameters;
        }

        #region Public Stuff
        public event EventHandler<CurrentParameterChangedEventArgs> CurrentParameterChanged;

        public IParameter CurrentParameter
        {
            get { return this.m_currentParameter; }

            internal set
            {
                if (this.m_currentParameter != value)
                {
                    IParameter prevCurrentParameter = this.m_currentParameter;
                    this.m_currentParameter = value;
                    //IntrinsicsDudeToolsStatic.Output_INFO("IntrSign: CurrentParameter: going to RaiseCurrentParameterChanged.");
                    this.RaiseCurrentParameterChanged(prevCurrentParameter, this.m_currentParameter);
                }
            }
        }

        public ITrackingSpan ApplicableToSpan
        {
            get { return (this.m_applicableToSpan); }
            internal set { this.m_applicableToSpan = value; }
        }

        public void SetCurrentParameter(int paramIndex)
        {
            //IntrinsicsDudeToolsStatic.Output_INFO("IntrSign: SetCurrentParameter: paramIndex="+ paramIndex+ "; this.Parameters.Count="+this.Parameters.Count);
            this.CurrentParameter = ((paramIndex >= 0) && (paramIndex < this.Parameters.Count)) ? this.Parameters[paramIndex] : null;
        }

        public string Content
        {
            get { return (this.m_content); }
            internal set { this.m_content = value; }
        }

        public string Documentation
        {
            get { return (this.m_documentation); }
            internal set { this.m_documentation = value; }
        }

        public ReadOnlyCollection<IParameter> Parameters
        {
            get { return (this.m_parameters); }
            internal set { this.m_parameters = value; }
        }

        public string PrettyPrintedContent
        {
            get { return (this.m_printContent); }
            internal set { this.m_printContent = value; }
        }

        #endregion

        #region Private Stuff

        private void RaiseCurrentParameterChanged(IParameter prevCurrentParameter, IParameter newCurrentParameter)
        {
            //IntrinsicsDudeToolsStatic.Output_INFO("IntrSign: RaiseCurrentParameterChanged");
            this.CurrentParameterChanged?.Invoke(this, new CurrentParameterChangedEventArgs(prevCurrentParameter, newCurrentParameter));
        }
        #endregion

    }
}
