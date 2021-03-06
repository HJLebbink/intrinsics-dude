﻿// The MIT License (MIT)
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

namespace IntrinsicsDude.SignHelp
{
    using System.ComponentModel.Composition;
    using System.Diagnostics.Contracts;
    using IntrinsicsDude.Tools;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Operations;
    using Microsoft.VisualStudio.Utilities;

    /*
    [Export(typeof(SignatureHelpPresenterStyle))]
    [Name("Intrinsic Signature Help Presenter Style")]
    [Order(After = "default")]
    [ContentType(IntrinsicsDudePackage.IntrinsicsDudeContentType)]
    internal class IntrSignHelpPresenterStyle : SignatureHelpPresenterStyle
    {
        public IntrSignHelpPresenterStyle()
        {
            IntrinsicsDudeToolsStatic.Output_INFO("IntrSignHelpPresenterStyle: constructor");
        }

        public override TextRunProperties SignatureDocumentationTextRunProperties {
            get {
                IntrinsicsDudeToolsStatic.Output_INFO("IntrSignHelpPresenterStyle: SignatureDocumentationTextRunProperties: get");
                return null;
            }
            protected set {
                IntrinsicsDudeToolsStatic.Output_INFO("IntrSignHelpPresenterStyle: SignatureDocumentationTextRunProperties: set");
            }
        }
    }
    */

    [Export(typeof(ISignatureHelpSourceProvider))]
    [Name("Intrinsic Signature Help Source")] // make sure this name is unique otherwise it doesn't work!
    [Order(After = "default")] // let the default signature help trigger first, such that we can remove the signatures it adds
    [ContentType(IntrinsicsDudePackage.IntrinsicsDudeContentType)]
    internal class IntrSignatureHelpSourceProvider : ISignatureHelpSourceProvider
    {
        [Import]
        internal ITextStructureNavigatorSelectorService NavigatorService { get; set; }

        //Returns A valid signature help provider, or null if none could be created.
        public ISignatureHelpSource TryCreateSignatureHelpSource(ITextBuffer textBuffer)
        {
            Contract.Requires(textBuffer != null);
            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:TryCreateSignatureHelpSource", this.ToString()));

            if (Settings.Default.SignatureHelp_On)
            {
                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:TryCreateSignatureHelpSource: signature help is switched on", this.ToString()));
                return new IntrSignatureHelpSource(textBuffer, this.NavigatorService.GetTextStructureNavigator(textBuffer));
            }
            else
            {
                IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:TryCreateSignatureHelpSource: signature help is switched off", this.ToString()));
                return null;
            }
        }
    }
}
