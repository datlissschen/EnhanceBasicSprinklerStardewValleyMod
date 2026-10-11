using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MyFirstStardewMod.Services
{
    public interface ISprinklerCoverageProvider
    {
        /// <summary>
        /// Retrieves world tile coordinates that should be watered around the given sprinkler origin.
        /// </summary>
        /// <param name="origin">The world tile coordinate of the sprinkler.</param>
        /// <returns>A collection of target world coordinates.</returns>
        IEnumerable<Vector2> GetWateringTiles(Vector2 origin);
    }
}