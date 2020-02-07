using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace classic_games_launcher.models
{
    [Table("Platform")]
    public class Platform
    {
        [PrimaryKey]
        [AutoIncrement]
        [NotNull]
        public int ID { get; set; }
        public PlatformType platformType { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    // Enum for game platforms
    public enum PlatformType
    {
        WII,
        GAMECUBE,
        PLAYSTATION2,
        NINTENDO64,
        GAMEBOYADVANCED
    }

}
