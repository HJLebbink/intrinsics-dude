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

using IntrinsicsDude.Tools;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.ObjectModel;

namespace IntrinsicsDude.SignHelp
{
    internal class IntrSign : ISignature
    {
        private readonly ITextBuffer m_subjectBuffer;
        private IParameter m_currentParameter;
        private string m_content;
        private string m_documentation;
        private ITrackingSpan m_applicableToSpan;
        private ReadOnlyCollection<IParameter> m_parameters;
        private string m_printContent;
        private EventHandler<TextContentChangedEventArgs> m_eventHandler;


        internal IntrSign(ITextBuffer subjectBuffer, string content, string doc, ReadOnlyCollection<IParameter> parameters)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: constructor");
            this.m_subjectBuffer = subjectBuffer;
            this.m_content = content;
            this.m_documentation = doc;
            this.m_parameters = parameters;
            this.m_eventHandler = new EventHandler<TextContentChangedEventArgs>(OnSubjectBufferChanged);
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: constructor: adding event handler");
            this.m_subjectBuffer.Changed += this.m_eventHandler;
        }

        #region Public Stuff
        public event EventHandler<CurrentParameterChangedEventArgs> CurrentParameterChanged;

        public IParameter CurrentParameter {
            get { return m_currentParameter; }
            internal set {
                if (m_currentParameter != value)
                {
                    IParameter prevCurrentParameter = m_currentParameter;
                    m_currentParameter = value;
                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: CurrentParameter: going to RaiseCurrentParameterChanged.");
                    this.RaiseCurrentParameterChanged(prevCurrentParameter, m_currentParameter);
                }
            }
        }

        public ITrackingSpan ApplicableToSpan {
            get { return (this.m_applicableToSpan); }
            internal set { this.m_applicableToSpan = value; }
        }

        public void SetCurrentParameter(int paramIndex)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: SetCurrentParameter: paramIndex="+ paramIndex+ "; this.Parameters.Count="+this.Parameters.Count);
            this.CurrentParameter = ((paramIndex >= 0) && (paramIndex < this.Parameters.Count)) ? this.Parameters[paramIndex] : null;
        }

        public string Content {
            get { return (m_content); }
            internal set { m_content = value; }
        }

        public string Documentation {
            get { return (m_documentation); }
            internal set { m_documentation = value; }
        }

        public ReadOnlyCollection<IParameter> Parameters {
            get { return (m_parameters); }
            internal set { m_parameters = value; }
        }

        public string PrettyPrintedContent {
            get { return (m_printContent); }
            internal set { m_printContent = value; }
        }

        #endregion
        
        #region Private Stuff

        internal void OnSubjectBufferChanged(object sender, TextContentChangedEventArgs e)
        {
            /*
            string newText = e.Changes[0].NewText;
            if (newText.Contains(","))
            {
                IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: OnSubjectBufferChanged: newText=\""+newText+"\".");
                this.ComputeCurrentParameter();
            }
            */
        }

        public void cleanup()
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: cleanup: removing event handler");
            this.m_subjectBuffer.Changed -= this.m_eventHandler;
            this.m_eventHandler = null;
         }

        internal void ComputeCurrentParameter()
        {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: ComputeCurrentParameter: ApplicableToSpan=" + ApplicableToSpan.GetText(m_subjectBuffer.CurrentSnapshot));

            if (Parameters.Count == 0)
            {
                this.CurrentParameter = null;
                return;
            }

            //the number of commas in the string is the index of the current parameter
            string sigText = ApplicableToSpan.GetText(m_subjectBuffer.CurrentSnapshot);

            int currentIndex = 0;
            int commaCount = 0;
            while (currentIndex < sigText.Length)
            {
                int commaIndex = sigText.IndexOf(',', currentIndex);
                if (commaIndex == -1)
                {
                    break;
                }
                commaCount++;
                currentIndex = commaIndex + 1;
            }

            if (commaCount < Parameters.Count)
            {
                this.CurrentParameter = Parameters[commaCount];
            }
            else
            {
                //too many commas, so use the last parameter as the current one.
                this.CurrentParameter = null;
            }
        }

        void RaiseCurrentParameterChanged(IParameter prevCurrentParameter, IParameter newCurrentParameter)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrSign: RaiseCurrentParameterChanged");

            EventHandler<CurrentParameterChangedEventArgs> tempHandler = this.CurrentParameterChanged;
            if (tempHandler != null)
            {
                tempHandler(this, new CurrentParameterChangedEventArgs(prevCurrentParameter, newCurrentParameter));
            }
        }
        #endregion

    }
}
