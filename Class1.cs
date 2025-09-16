using StardewModdingAPI;

namespace MyFirstStardewMod
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            Monitor.Log("Hallo aus meiner ersten Mod!", LogLevel.Info);
        }
    }
}