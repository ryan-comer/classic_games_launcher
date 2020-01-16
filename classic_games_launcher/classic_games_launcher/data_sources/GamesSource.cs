using System;
using System.Collections.Generic;
using System.Text;

using classic_games_launcher.models;

namespace classic_games_launcher.data_sources
{
    class GamesSource
    {

        private static List<Game> Games;

        static GamesSource()
        {
            Games = new List<Game>()
            {
                new Game("Star Wars: The Clone Wars", Platform.GAMECUBE),
                new Game("Luigi's Mansion", Platform.GAMECUBE),
                new Game("Super Mario Sunshine", Platform.GAMECUBE),
            };
        }

        // Return a list of games for a platform
        public static List<Game> GetGamesByPlatform(Platform platform)
        {
            // Filter games by platform
            return Games.FindAll((game) =>
            {
                return game.Platform == platform;
            });
        }

    }
}
