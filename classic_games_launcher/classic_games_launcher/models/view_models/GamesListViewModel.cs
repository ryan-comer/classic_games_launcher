using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace classic_games_launcher.models.view_models
{
    public class GamesListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<GameViewModel> gamesList;
        public List<GameViewModel> GamesList
        {
            get
            {
                return gamesList;
            }
            set
            {
                gamesList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GamesList"));
            }
        }

    }
}
