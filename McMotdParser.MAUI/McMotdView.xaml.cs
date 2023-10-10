using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McMotdParser.Enum;
using McMotdParser.MAUI.Extensions;

namespace McMotdParser.MAUI;

public partial class McMotdView : ContentView
{
    public string RawMotdString { get; set; }
    public double? FontSize { get; set; }
    public McMotdView()
    {
        InitializeComponent();
    }   

    private void McMotdView_OnLoaded(object sender, EventArgs e)
    {
        var motds = new MotdParser().deserialize(RawMotdString);
        StackLayout h_stack = new StackLayout() { Orientation = StackOrientation.Horizontal };
        foreach (var motd in motds)
        {
            if (motd.LineBreak)
            { 
                MotdStackLayout.Children.Add(h_stack);
                h_stack = new StackLayout() { Orientation = StackOrientation.Horizontal };
            }
            var text = new Label();
            text.FontSize = FontSize ?? 12;
            text.Text = motd.Text;
            text.TextColor = Color.FromArgb(motd.Color);
            foreach (var textformat in motd.TextFormatting)
            {
                if (textformat == TextFormatEnum.Bold)
                    text.FontAttributes = FontAttributes.Bold;
                if (textformat == TextFormatEnum.Italic)
                    text.FontAttributes = FontAttributes.Italic;
                if (textformat == TextFormatEnum.Underline)
                    text.TextDecorations = TextDecorations.Underline;
                if (textformat == TextFormatEnum.Striktethrough)
                    text.TextDecorations = TextDecorations.Strikethrough;
            }
            h_stack.Children.Add(text);
        }

        
        MotdStackLayout.Children.Add(h_stack);
    }
}