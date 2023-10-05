using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McMotdParser.MAUI.Extensions;

namespace McMotdParser.MAUI;

public partial class McMotdView : ContentView
{
    public string RawMotdString { get; set; }
    public McMotdView()
    {
        InitializeComponent();
    }   

    private void McMotdView_OnLoaded(object sender, EventArgs e)
    {
        var motds = new MotdParser().ToXaml(RawMotdString);
        foreach (var motd in motds)
        {
            var text = new Label();
            text.Text = motd.Text;
            text.TextColor = Color.FromArgb(motd.Color);
            MotdFrame.Children.Add(text);
        } 
    }
}