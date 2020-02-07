using System;
using System.Collections.Generic;
using System.Text;

using classic_games_launcher.models;

namespace classic_games_launcher.utils
{
    public static class PlatformConverter
    {

        // Convert a platform ID into a platform type enum
        public static PlatformType IGDBPlatformIDToEnum(int id)
        {
            return new Dictionary<int, PlatformType>
            {
                {5, PlatformType.WII},
                {4, PlatformType.NINTENDO64},
                {8, PlatformType.PLAYSTATION2},
                {21, PlatformType.GAMECUBE},
            }[id];
        }

        // Get the IGDB ID from the platform type
        public static int EnumToIGDBPlatformId(PlatformType platformType)
        {
            return new Dictionary<PlatformType, int>
            {
                {PlatformType.WII, 5},
                {PlatformType.NINTENDO64, 4},
                {PlatformType.PLAYSTATION2, 8},
                {PlatformType.GAMECUBE, 21}
            }[platformType];
        }

    }
}
