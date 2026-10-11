using MyFirstStardewMod.Services;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace MyFirstStardewMod
{
    public class ModEntry : Mod
    {
        private SprinklerWateringService _wateringService;

        public override void Entry(IModHelper helper)
        {
            // Initialize dependencies (Dependency Injection / Composition Root)
            ISprinklerCoverageProvider coverageProvider = new DiamondSprinklerCoverageProvider();
            _wateringService = new SprinklerWateringService(coverageProvider, Monitor);

            // Subscribe to game loop events
            helper.Events.GameLoop.DayStarted += OnDayStarted;

            Monitor.Log("Enhanced Sprinkler Mod initialized successfully.", LogLevel.Info);
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            _wateringService.ApplyWateringToAllLocations();
        }
    }
}