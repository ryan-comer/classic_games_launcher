using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using classic_games_launcher.pages;

namespace classic_games_launcher
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void SetContent(View newView)
        {
            MainContent.Children.Clear();
            MainContent.Children.Add(newView);
        }

        // User clicked the platforms button
        private void PlatformButtonClicked(object sender, EventArgs e)
        {
            View contentView = MainContent.Children[0];
            if(contentView.GetType() != typeof(PlatformSelector))
            {
                SetContent(new PlatformSelector());
            }
        }
    }
}
