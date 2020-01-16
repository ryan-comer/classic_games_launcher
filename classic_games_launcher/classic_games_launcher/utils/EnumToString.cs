using System;
using System.Collections.Generic;
using System.Text;

using classic_games_launcher.models;

namespace classic_games_launcher.utils
{
    public static class EnumToString
    {

        public static string PlatformEnumToString(Platform platform)
        {
            return new Dictionary<Platform, string>
            {
                {Platform.GAMEBOY_ADVANCE, "Gameboy Advance"},
                {Platform.GAMECUBE, "Gamecube"},
                {Platform.NINTENDO_64, "Nintendo 64"},
                {Platform.PLAYSTATION_2, "Playstation 2"},
                {Platform.WII, "Wii"},
                {Platform.WIIU, "Wii U"},
            }[platform];
        }

    }
}
