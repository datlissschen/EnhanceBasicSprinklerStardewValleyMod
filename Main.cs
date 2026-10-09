using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.TerrainFeatures;

namespace MyFirstStardewMod
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            Monitor.Log("Hello to the sprinkler Mod!", LogLevel.Info);
            // Tell SMAPI to call our 'OnDayStarted' method every time a new day begins

            helper.Events.GameLoop.DayStarted += OnDayStarted;
        }
        
        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            // Loop through every location in game 
            foreach (GameLocation location in Game1.locations)
            {
                // Look at every object placed in that location
                foreach (var pair in location.Objects.Pairs)
                {
                    Vector2 tileLocation = pair.Key; 
                    StardewValley.Object placedObject = pair.Value; 

                    // Check if the object is a Basic Sprinkler. Basic sprinkler = "599"
                    if (placedObject.ItemId == "599")
                    {
                        ApplyExtraWatering(location, tileLocation);
                    }
                }
            }
        }
        
        private void ApplyExtraWatering(GameLocation location, Vector2 sprinklerTile)
        {
            // Define the tile offsets to water (12x12). 
            List<Vector2> offsets = new List<Vector2>
            {
                // 3x3 square
                new Vector2(-1, -1), new Vector2(1, -1), 
                new Vector2(-1, 1),  new Vector2(1, 1),
        
                // 5x5 square
                // left down
                new Vector2(0, -2), 
                new Vector2(-1,-2),
                new Vector2(-2,-2),
                new Vector2(-2, -1),
                
                // right up
                new Vector2(0, 2),
                new Vector2(1,2),
                new Vector2(2,2),
                new Vector2(2, 1),
                
                // left up
                new Vector2(-2, 0), 
                new Vector2(-2,1),
                new Vector2(-2, 2),
                new Vector2(-1, 2),
                
                //right down
                new Vector2(2, 0),
                new Vector2(2,-1),
                new Vector2(2,-2),
                new Vector2(1,-2)
            };

            foreach (Vector2 offset in offsets)
            {
                // Calculate exact world coordinate of target tile
                Vector2 targetTile = sprinklerTile + offset;

                // Check if the terrain feature at this tile is "HoeDirt" (tilled soil/pots)
                if (location.terrainFeatures.TryGetValue(targetTile, out TerrainFeature feature) && feature is HoeDirt dirt)
                {
                    // Set the dirt's state to 1 ("watered")
                    dirt.state.Value = 1;
                }
            }
        }
    }
}