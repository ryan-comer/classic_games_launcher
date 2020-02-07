using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using classic_games_launcher.models;
using classic_games_launcher.utils;

namespace classic_games_launcher.data.data_sources
{
    static class PlatformsSource
    {
        private static IGDB.IGDBApi igdbClient = IGDB.Client.Create(classic_games_launcher.Keys.IGDB_API_KEY);
        private static TimeSpan updateThreshold = DateTime.Now.AddDays(7) - DateTime.Now;

        // Get a single platform by ID
        public async static Task<Platform> GetPlatform(int platformId)
        {
            Platform platform = database.PlatformDatabase.GetPlatform(platformId);

            // Update platform from IGDB
            await updatePlatform(platform);

            return platform;
        }

        // Get all platforms
        public async static Task<List<Platform>> GetPlatforms()
        {
            List<Platform> platforms = database.PlatformDatabase.GetPlatforms();

            // Update the platforms from IGDB
            await updatePlatforms(platforms);

            // Push the updates back to the database
            database.PlatformDatabase.UpdatePlatforms(platforms);

            return platforms;
        }

        // Update the list of platforms from IGDB
        private async static Task updatePlatforms(List<Platform> platforms)
        {
            // Create a list of Platform IDs to check
            StringBuilder sb = new StringBuilder("(");
            foreach(var platform in platforms)
            {
                sb.Append(PlatformConverter.EnumToIGDBPlatformId(platform.platformType).ToString());
                sb.Append(",");
            }
            sb.Remove(sb.Length - 1, 1);    // Remove the last comma
            sb.Append(")");

            // Get platforms from IGDB
            var igdbPlatforms = await igdbClient.QueryAsync<models.igdb_models.IGDBPlatform>(IGDB.Client.Endpoints.Platforms, query: "fields *; limit 100; where id=" + sb.ToString() + "; sort id asc;");
        
            // Update the platforms
            foreach(var platform in platforms)
            {
                // See if you need to update
                if (!needToUpdatePlatform(platform))
                {
                    return;
                }

                foreach (var igdbPlatform in igdbPlatforms)
                {
                    if (igdbPlatform.id == PlatformConverter.EnumToIGDBPlatformId(platform.platformType))
                    {
                        platform.lastUpdated = DateTime.Now;
                        platform.Name = igdbPlatform.name;

                        // Get the image
                        var platformLogos = await igdbClient.QueryAsync<models.igdb_models.IGDBPlatformLogo>(IGDB.Client.Endpoints.PlatformLogos, 
                            query: "fields *; where id=" + igdbPlatform.platform_logo + ";");
                        if(platformLogos.Length == 0)
                        {
                            Console.Error.WriteLine("Can't get platform logo for: " + platform.Name);
                            break;
                        }
                        platform.Image = "https:" + platformLogos[0].url;
                    }
                }
            }
        }

        // Check if you need to update the platform data
        private async static Task updatePlatform(Platform platform)
        {
            if(!needToUpdatePlatform(platform))
            {
                // No need to update
                return;
            }

            // Update the platform from IGDB

        }

        // Helper function to determine if a platform needs to be updated
        private static bool needToUpdatePlatform(Platform platform)
        {
            return (platform.lastUpdated != null && (DateTime.Now - platform.lastUpdated) > updateThreshold);
        }

    }
}
