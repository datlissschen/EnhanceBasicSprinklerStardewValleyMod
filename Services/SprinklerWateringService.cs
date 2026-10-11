using System;
using Microsoft.Xna.Framework;
using MyFirstStardewMod.Common;
using StardewModdingAPI;
using StardewValley;
using StardewValley.TerrainFeatures;
using SObject = StardewValley.Object;

namespace MyFirstStardewMod.Services
{
    public class SprinklerWateringService
    {
        private readonly ISprinklerCoverageProvider _coverageProvider;
        private readonly IMonitor _monitor;

        public SprinklerWateringService(ISprinklerCoverageProvider coverageProvider, IMonitor monitor)
        {
            _coverageProvider = coverageProvider ?? throw new ArgumentNullException(nameof(coverageProvider));
            _monitor = monitor ?? throw new ArgumentNullException(nameof(monitor));
        }

        /// <summary>
        /// Iterates through all accessible game locations and waters tiles around basic sprinklers.
        /// </summary>
        public void ApplyWateringToAllLocations()
        {
            int wateredTilesCount = 0;

            // Utility method to recursively access main locations and building interiors
            foreach (GameLocation location in Game1.locations)
            {
                wateredTilesCount += ProcessLocation(location);
            }

            _monitor.Log($"Applied custom sprinkler watering to {wateredTilesCount} dirt tiles.", LogLevel.Trace);
        }

        private int ProcessLocation(GameLocation location)
        {
            if (location == null) return 0;

            int count = 0;

            foreach (var (tile, placedObject) in location.Objects.Pairs)
            {
                if (IsTargetSprinkler(placedObject))
                {
                    count += WaterTilesAround(location, tile);
                }
            }

            return count;
        }

        private static bool IsTargetSprinkler(SObject obj)
        {
            return obj != null && obj.ItemId == ItemIds.BasicSprinkler;
        }

        private int WaterTilesAround(GameLocation location, Vector2 sprinklerTile)
        {
            int watered = 0;

            foreach (Vector2 targetTile in _coverageProvider.GetWateringTiles(sprinklerTile))
            {
                if (location.terrainFeatures.TryGetValue(targetTile, out TerrainFeature feature) && feature is HoeDirt dirt)
                {
                    if (dirt.state.Value != SoilState.Watered)
                    {
                        dirt.state.Value = SoilState.Watered;
                        watered++;
                    }
                }
            }

            return watered;
        }
    }
}