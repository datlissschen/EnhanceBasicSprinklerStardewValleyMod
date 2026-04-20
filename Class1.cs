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
    }
}