using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace classic_games_launcher
{
    public static class Constants
    {
        public const string DATABASE_FILE_NAME = "emulation_station_data.db3";
        public const SQLite.SQLiteOpenFlags DATABASE_OPEN_FLAGS =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DATABASE_FILE_PATH
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DATABASE_FILE_NAME);
            }
        }
    }
}
