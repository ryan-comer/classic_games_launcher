using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Linq;

using classic_games_launcher.models;

namespace classic_games_launcher.data.database
{
    public static class GamesDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DATABASE_FILE_PATH, Constants.DATABASE_OPEN_FLAGS);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        static GamesDatabase()
        {
            InitializeAsync().Start();
        }

        static async Task InitializeAsync()
        {
            if (!initialized)
            {
                // See if the games table exists
                if(!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Game).Name))
                {
                    // Create the Games table
                    await Database.CreateTableAsync(typeof(Game), CreateFlags.None).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        // Get all games
        public static Task<List<Game>> GetGamesAsync()
        {
            return Database.Table<Game>().ToListAsync();
        }

        // Get games by platform
        public static Task<List<Game>> GetGamesByPlatformAsync(int platformId)
        {
            return Database.Table<Game>().Where(game => game.Platform == platformId).ToListAsync();
        }

        // Get a game by ID
        public static Task<Game> GetGame(int gameId)
        {
            return Database.Table<Game>().Where(game => game.ID == gameId).FirstOrDefaultAsync();
        }

    }
}
