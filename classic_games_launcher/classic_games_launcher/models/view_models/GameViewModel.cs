﻿using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using classic_games_launcher.models;

namespace classic_games_launcher.models.view_models
{
    public class GameViewModel
    {
        public Game Game { get; set; }

        public int Platform
        {
            get
            {
                return Game.Platform;
            }
        }

        public string Name
        {
            get
            {
                return Game.Name;
            }
        }
    }
}
