using IntrinsicsDude.Tools;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using System.Windows.Controls;

namespace MefRegistration
{
    /*
        [Export(typeof(IWpfTextViewCreationListener))]
        [ContentType("text")]
        [TextViewRole(PredefinedTextViewRoles.Document)]
        public sealed class TextAdornment1TextViewCreationListener : IWpfTextViewCreationListener
        {
            public void TextViewCreated(IWpfTextView textView)
            {
                //TextAdornment a = new TextAdornment(textView, 0, "BLA1");
                //a.show(1, "BLA2");
            }

    #pragma warning disable CS0169 // C# warning "the field editorAdornmentLayer is never used" -- but it is used, by MEF!
            [Export(typeof(AdornmentLayerDefinition))]
            [Name("TextAdornment1")]
            [Order(After = PredefinedAdornmentLayers.Selection, Before = PredefinedAdornmentLayers.Text)]
            private AdornmentLayerDefinition editorAdornmentLayer;
    #pragma warning restore CS0169
        }
    */
}

public sealed class TextAdornment
{
    private readonly IWpfTextView _view;
    private TextBlock _adornment;

    public TextAdornment(IWpfTextView view, int lineNumber, int pos, string message)
    {
        this._view = view;

        //IntrinsicsDudeToolsStatic.Output("INFO: TextAdornment: constructor");
        ITextViewLine line = this.GetLine(this._view.TextViewLines, lineNumber);
        if (line == null)
        {
            return;
        }

        //IntrinsicsDudeToolsStatic.Output("INFO: TextAdornment: show: line=\"" + line.Extent.GetText() + "\".");
        System.Windows.Media.Geometry geometry = this._view.TextViewLines.GetMarkerGeometry(line.Extent);
        if (geometry == null)
        {
            return;
        }

        this._adornment = new TextBlock
        {
            Text = message,
            Width = 400,
            Height = geometry.Bounds.Height,
            Background = System.Windows.Media.Brushes.Yellow,
            Opacity = 0.4,
        };
        Canvas.SetLeft(this._adornment, pos);
        Canvas.SetTop(this._adornment, geometry.Bounds.Top);
        IAdornmentLayer layer = this._view.GetAdornmentLayer("TextAdornment1");
        layer.AddAdornment(AdornmentPositioningBehavior.TextRelative, line.Extent, null, this._adornment, (tag, ui) => this._adornment = null);
    }

    public void Cleanup()
    {
        this._view.GetAdornmentLayer("TextAdornment1").RemoveAllAdornments();
    }

    private ITextViewLine GetLine(ITextViewLineCollection c, int lineNumber)
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
            IntrinsicsDudeToolsStatic.Output_INFO("WaitAdornment: constructor: could not fine linenumber " + lineNumber);
        }

        return line;
    }
}
