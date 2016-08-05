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

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using IntrinsicsDude.Tools;

namespace IntrinsicsDude
{
    public static class IntrinsicsClassificationTypeNames
    {
        public const string IntrinsicTypeName = "intrinsic-CEEC315A-2FDE-428C-A4B0-1A5F4DDB6B12";
        public const string RegisterTypeName = "register-CEEC315A-2FDE-428C-A4B0-1A5F4DDB6B12";
        public const string MiscTypeName = "misc-CEEC315A-2FDE-428C-A4B0-1A5F4DDB6B12";
    }

    [Export(typeof(EditorFormatDefinition))] // export as EditorFormatDefinition otherwise the syntax coloring does not work
    [ClassificationType(ClassificationTypeNames = IntrinsicsClassificationTypeNames.IntrinsicTypeName)]
    [Name("intrinsic-737B803B-8D26-4222-9AD3-C901E69657A7")]
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(After = Priority.High)] //set the priority to be after the default classifiers
    internal sealed class IntrinsicP : ClassificationFormatDefinition
    {
        public IntrinsicP()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: Entering constructor for: {0}", this.ToString()));
            DisplayName = "IntrinsicsDude - Syntax Highlighting - Instruction"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Opcode);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = IntrinsicsClassificationTypeNames.RegisterTypeName)]
    [Name("register-737B803B-8D26-4222-9AD3-C901E69657A7")]
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(After = Priority.High)] //set the priority to be after the default classifiers
    internal sealed class RegisterP : ClassificationFormatDefinition
    {
        public RegisterP()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: Entering constructor for: {0}", this.ToString()));
            DisplayName = "IntrinsicsDude - Syntax Highlighting - Register Type"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Register);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = IntrinsicsClassificationTypeNames.MiscTypeName)]
    [Name("misc-737B803B-8D26-4222-9AD3-C901E69657A7")]
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(After = Priority.High)] //set the priority to be after the default classifiers
    internal sealed class MiscP : ClassificationFormatDefinition
    {
        public MiscP()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: Entering constructor for: {0}", this.ToString()));
            DisplayName = "IntrinsicsDude - Syntax Highlighting - Misc"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Misc);
        }
    }
}
