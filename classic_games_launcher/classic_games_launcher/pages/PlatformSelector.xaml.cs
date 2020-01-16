﻿using classic_games_launcher.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using classic_games_launcher.models;

namespace classic_games_launcher.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlatformSelector : ContentView
    {

        Platform platform;
        string image;

        public Platform GamePlatform
        {
            get
            {
                return platform;
            }
            set
            {
                platform = value;
            }
        }
        public string Image 
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


        public ICommand ImageClickedCommand { private set; get; }


        public static IList<PlatformSelector> All;

        static PlatformSelector()
        {
            All = new List<PlatformSelector>()
            {
                new PlatformSelector
                {
                    GamePlatform = models.Platform.GAMECUBE,
                    image = "https://i.ya-webdesign.com/images/game-cube-logo-png-15.png"
                },
                new PlatformSelector
                {
                    GamePlatform = models.Platform.PLAYSTATION_2,
                    image = "http://icons.iconarchive.com/icons/sykonist/console/256/Playstation-2-black-icon.png"
                },
                new PlatformSelector
                {
                    GamePlatform = models.Platform.WII,
                    image = "https://cdn2.iconfinder.com/data/icons/electrical-devices-2/60/devices-flat-055-wii-512.png"
                },
                new PlatformSelector
                {
                    GamePlatform = models.Platform.WIIU,
                    image = "https://image.flaticon.com/icons/png/512/39/39462.png"
                },
                new PlatformSelector
                {
                    GamePlatform = models.Platform.GAMEBOY_ADVANCE,
                    image = "https://cdn2.iconfinder.com/data/icons/the-evolution-of-consoles-game/64/gameboy_advance_copy-512.png"
                },
                new PlatformSelector
                {
                    GamePlatform = models.Platform.NINTENDO_64,
                    image = "https://www.pngkey.com/png/detail/226-2267265_n64-icon-nintendo-64-logo-png.png"
                }
            };
        }

        public PlatformSelector()
        {
            InitializeComponent();
            ImageClickedCommand = new Command((obj) =>
            {
                PlatformImageClicked(obj);
            });
        }

        // User clicked a platform selection
        private void PlatformImageClicked(object sender)
        {
            // Go to the new page

            ((MainPage)App.Current.MainPage).SetContent(new classic_games_launcher.pages.GameListPage(
                platform,
                image
                ));
        }
    }
}