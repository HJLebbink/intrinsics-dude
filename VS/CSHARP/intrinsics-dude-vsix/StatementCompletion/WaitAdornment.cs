using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using IntrinsicsDude.Tools;
/*
namespace IntrinsicsDude.StatementCompletion
{
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    public sealed class TextAdornment1TextViewCreationListener : IWpfTextViewCreationListener
    {
        //public void TextViewCreated(IWpfTextView textView) => new WaitAdornment(textView);

        public void TextViewCreated(IWpfTextView textView)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: TextAdornment1TextViewCreationListener: TextViewCreated");
            //new WaitAdornment(textView, 10);
        }

#pragma warning disable CS0169 // C# warning "the field editorAdornmentLayer is never used" -- but it is used, by MEF!
        [Export(typeof(AdornmentLayerDefinition))]
        [Name("WaitAdornment")]
        //[Order(After = PredefinedAdornmentLayers.Selection, Before = Microsoft.VisualStudio.Text.Editor.PredefinedAdornmentLayers.Text)]
        private AdornmentLayerDefinition editorAdornmentLayer;
#pragma warning restore CS0169
    }

    public sealed class WaitAdornment
    {
        private TextBlock Adornment;

        private ITextViewLine getLine(ITextViewLineCollection c, int lineNumber)
        {
            ITextViewLine line = null;
            for (int i = 0; i < c.Count; ++i)
            {
                line = c[i];
                if (line.Start.GetContainingLine().LineNumber == lineNumber)
                {
                    break;
                }
            }
            if (line == null)
            {
                IntrinsicsDudeToolsStatic.Output("INFO: WaitAdornment: constructor: could not fine linenumber " + lineNumber);
            }
            return line;
        }

        public WaitAdornment(IWpfTextView view, int lineNumber)
        {
            ITextViewLine line = getLine(view.TextViewLines, lineNumber);
            SnapshotSpan span = line.Extent;
            IntrinsicsDudeToolsStatic.Output("INFO: WaitAdornment: constructor: span=\"" + span.GetText()+"\".");


            Geometry geometry = view.TextViewLines.GetMarkerGeometry(span);
            if (geometry == null) {
                IntrinsicsDudeToolsStatic.Output("INFO: WaitAdornment: constructor: geometry is null");
                return;
            }

            double heigth = 20; //geometry.Bounds.Height,

            this.Adornment = new TextBlock {
                Width = 200,
                Height = heigth,
                Background = Brushes.Yellow,
                Opacity = 0.5
            };

            //Canvas.SetLeft(Adornment, 300);
            //Canvas.SetTop(Adornment, geometry.Bounds.Top);
            view.GetAdornmentLayer("WaitAdornment").AddAdornment(AdornmentPositioningBehavior.TextRelative, line.Extent, null, Adornment, (tag, ui) => Adornment = null);

            Adornment.Text = "Initializing Statement Completions. May take 5 sec.";
        }

        public void clear()
        {
            this.Adornment = null;
        }
    }
}
*/