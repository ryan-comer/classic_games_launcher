using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using classic_games_launcher.models;

namespace classic_games_launcher.data.data_sources
{
    static class GamesSource
    {

        static IGDB.IGDBApi igdbClient = IGDB.Client.Create(classic_games_launcher.Keys.IGDB_API_KEY);

        static GamesSource()
        {

        }
        
        // Return a list of games for a platform
        public async static Task<List<Game>> GetGamesByPlatform(int platformId)
        {
            List<Game> games = await database.GamesDatabase.GetGamesByPlatformAsync(platformId);

            // See if you need to update the game database


            return games;
        }

    }
}
