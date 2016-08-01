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

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using IntrinsicsDude.Tools;

namespace IntrinsicsDude {

    [Export(typeof(EditorFormatDefinition))] // export as EditorFormatDefinition otherwise the syntax coloring does not work
    [ClassificationType(ClassificationTypeNames = "mnemonic")]
    [Name("mnemonic")]  //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class OpcodeP : ClassificationFormatDefinition {
        
        public OpcodeP() {
            //Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "INFO: Entering constructor for: {0}", this.ToString()));
            DisplayName = "AsmDude - Syntax Highlighting - Mnemonic"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Opcode);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "register")]
    [Name("register")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class RegisterP : ClassificationFormatDefinition {
        public RegisterP() {
            DisplayName = "AsmDude - Syntax Highlighting - Register"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Register);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "remark")]
    [Name("remark")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class RemarkP : ClassificationFormatDefinition {
        public RemarkP() {
            DisplayName = "AsmDude - Syntax Highlighting - Remark"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Remark);
            IsItalic = true;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "directive")]
    [Name("directive")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class DirectiveP : ClassificationFormatDefinition {
        public DirectiveP() {
            DisplayName = "AsmDude - Syntax Highlighting - Directive"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Directive);
            IsItalic = true;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "jump")]
    [Name("jump")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class JumpP : ClassificationFormatDefinition {
        public JumpP() {
            DisplayName = "AsmDude - Syntax Highlighting - Jump"; //human readable version of the name
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Jump);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "label")]
    [Name("label")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class LabelP : ClassificationFormatDefinition {
        public LabelP() {
            DisplayName = "AsmDude - Syntax Highlighting - Label"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Label);
            //TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "labelDef")]
    [Name("labelDef")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class LabelDefP : ClassificationFormatDefinition {
        public LabelDefP() {
            DisplayName = "AsmDude - Syntax Highlighting - Label Definition"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Label);
            //TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "constant")]
    [Name("constant")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class ConstantP : ClassificationFormatDefinition {
        public ConstantP() {
            DisplayName = "AsmDude - Syntax Highlighting - Constant"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Constant);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "misc")]
    [Name("misc")] //this should be visible to the end user
    [UserVisible(true)] // sets this editor format definition visible for the user (in Tools>Options>Environment>Fonts and Colors>Text Editor
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class MiscP : ClassificationFormatDefinition {
        public MiscP() {
            DisplayName = "AsmDude - Syntax Highlighting - Misc"; //human readable version of the name found in Tools>Options>Environment>Fonts and Colors>Text Editor
            ForegroundColor = IntrinsicsDudeToolsStatic.convertColor(Settings.Default.SyntaxHighlighting_Misc);
        }
    }
}
