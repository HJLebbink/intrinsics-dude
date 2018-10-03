// The MIT License (MIT)
//
// Copyright (c) 2018 Henk-Jan Lebbink
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

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using IntrinsicsDude.Tools;
using IntrinsicsDude.SyntaxHighlighting;

namespace IntrinsicsDude
{
    [Export(typeof(EditorFormatDefinition))] // export as EditorFormatDefinition otherwise the syntax coloring does not work
    [ClassificationType(ClassificationTypeNames = IntrinsicClassificationDefinition.ClassificationTypeNames.Intrinsic)]
    [Name("intrinsic-737B803B-8D26-4222-9AD3-C901E69657A7")]
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(After = Priority.High)] //set the priority to be after the default classifiers
    internal sealed class IntrinsicP : ClassificationFormatDefinition
    {
        public IntrinsicP()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: Entering constructor for: {0}", this.ToString()));
            this.DisplayName = "IntrinsicsDude - Instruction"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            this.ForegroundColor = IntrinsicsDudeToolsStatic.ConvertColor(Settings.Default.SyntaxHighlighting_Intrinsic);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = IntrinsicClassificationDefinition.ClassificationTypeNames.Register)]
    [Name("register-737B803B-8D26-4222-9AD3-C901E69657A7")]
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(After = Priority.High)] //set the priority to be after the default classifiers
    internal sealed class RegisterP : ClassificationFormatDefinition
    {
        public RegisterP()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: Entering constructor for: {0}", this.ToString()));
            this.DisplayName = "IntrinsicsDude - Register Type"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            this.ForegroundColor = IntrinsicsDudeToolsStatic.ConvertColor(Settings.Default.SyntaxHighlighting_Register);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = IntrinsicClassificationDefinition.ClassificationTypeNames.Misc)]
    [Name("misc-737B803B-8D26-4222-9AD3-C901E69657A7")]
    [UserVisible(false)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(After = Priority.High)] //set the priority to be after the default classifiers
    internal sealed class MiscP : ClassificationFormatDefinition
    {
        public MiscP()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: Entering constructor for: {0}", this.ToString()));
            this.DisplayName = "IntrinsicsDude - Misc"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            this.ForegroundColor = IntrinsicsDudeToolsStatic.ConvertColor(Settings.Default.SyntaxHighlighting_Misc);
        }
    }
}
