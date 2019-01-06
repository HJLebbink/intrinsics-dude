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

using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace IntrinsicsDude.SignHelp
{
    [Export(typeof(IVsTextViewCreationListener))]
    [Name("Intrinsic Signature Help controller")] // make sure this name is unique!
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    [ContentType(IntrinsicsDudePackage.IntrinsicsDudeContentType)]
    internal sealed class IntrSignatureHelpCommandProvider : IVsTextViewCreationListener
    {
        [Import]
        private IVsEditorAdaptersFactoryService _adapterService = null;

        [Import]
        private ITextStructureNavigatorSelectorService _navigatorService = null;

        [Import]
        private ISignatureHelpBroker _signatureHelpBroker = null;

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            ITextView textView = this._adapterService.GetWpfTextView(textViewAdapter);
            if (textView != null)
            {
                textView.Properties.GetOrCreateSingletonProperty(
                    () => new IntrSignatureHelpCommandFilter(textViewAdapter, textView, this._navigatorService.GetTextStructureNavigator(textView.TextBuffer), this._signatureHelpBroker)
                );
            }
        }
    }
}
