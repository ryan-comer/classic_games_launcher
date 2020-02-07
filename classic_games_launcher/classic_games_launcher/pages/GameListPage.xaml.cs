using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using classic_games_launcher.models;
using classic_games_launcher.models.view_models;
using classic_games_launcher.data.data_sources;
using classic_games_launcher.utils;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace classic_games_launcher.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListPage : ContentView, INotifyPropertyChanged
    {
        int GamePlatform { get; set; }

        public string PlatformName
        {
            get
            {
                return "Temp";
            }
        }

        private GamesListViewModel gamesListViewModel;
        public GamesListViewModel GamesListViewModel
        {
            get
            {
                if(gamesListViewModel == null)
                {
                    gamesListViewModel = new GamesListViewModel();
                }
                return gamesListViewModel;
            }
            set
            {
                gamesListViewModel = value;
            }
        }

        public GameListPage(int platform)
        {
            this.GamePlatform = platform;

            InitializeComponent();
            BindingContext = this;

            populateGames(platform);
        }

        // Populate games by platform
        private async void populateGames(int platform)
        {
            var games = await GamesSource.GetGamesByPlatform(platform);
            List<GameViewModel> gameModels = new List<GameViewModel>();
            foreach(var game in games)
            {
                gameModels.Add(new GameViewModel { Game = game });
            }
            GamesListViewModel.GamesList = gameModels;
        }
    }
}