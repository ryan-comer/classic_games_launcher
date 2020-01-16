using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace classic_games_launcher.models
{
    public class Game
    {
        public string Name { get; set; }
        public Platform Platform { get; set; }

        public Game(string name, Platform platform)
        {
            this.Name = name;
            this.Platform = platform;
        }

    }

    public enum Platform
    {
        GAMECUBE,
        PLAYSTATION_2,
        WII,
        WIIU,
        GAMEBOY_ADVANCE,
        NINTENDO_64
    }
}
