using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace classic_games_launcher.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListPage : ContentView
    {

        string platformName;
        string image;

        public string PlatformNameProperty
        {
            get
            {
                return platformName + " Games";
            }
            set
            {
                platformName = value;
            }
        }
        public string ImageProperty
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public GameListPage(string platformName, string image)
        {
            this.platformName = platformName;
            this.image = image;

            InitializeComponent();
            BindingContext = this;
        }
    }
}