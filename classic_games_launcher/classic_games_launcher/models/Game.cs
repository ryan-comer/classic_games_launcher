using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace classic_games_launcher.models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Platform { get; set; }
        public string ImagePath { get; set; }

        public Game()
        {

        }

    }

}
