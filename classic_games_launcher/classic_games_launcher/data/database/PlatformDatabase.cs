using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using classic_games_launcher.models;

namespace classic_games_launcher.data.database
{
    public static class PlatformDatabase
    {
        static readonly Lazy<SQLiteConnection> lazyInitializer = new Lazy<SQLiteConnection>(() =>
        {
            return new SQLiteConnection(Constants.DATABASE_FILE_NAME, Constants.DATABASE_OPEN_FLAGS);
        });

        static SQLiteConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        // List of starting platforms to insert into the database
        static List<Platform> startingPlatforms = new List<Platform>
        {
            new Platform{platformType=PlatformType.GAMECUBE},
            new Platform{platformType=PlatformType.PLAYSTATION2}
        };

        static PlatformDatabase()
        {
            Initialize();
        }

        static void Initialize()
        {
            if (!initialized)
            {
                // See if the platform table exists
                var tableInfo = Database.GetTableInfo("Platform");
                if (tableInfo.Count == 0)
                {
                    // Create the platform table
                    Database.CreateTable(typeof(Platform), CreateFlags.None);
                    initialized = true;

                    // Add the available platforms
                    Database.InsertAll(startingPlatforms);
                }
            }
        }

        // Get a platform by ID
        public static Platform GetPlatform(int platformId)
        {
            return Database.Table<Platform>().Where(platform => platform.ID == platformId).FirstOrDefault();
        }

        // Get all platforms
        public static List<Platform> GetPlatforms()
        {
            return Database.Table<Platform>().ToList();
        }

        // Update the platforms in the database
        public static int UpdatePlatforms(List<Platform> platforms)
        {
            return Database.UpdateAll(platforms);
        }

    }
}
