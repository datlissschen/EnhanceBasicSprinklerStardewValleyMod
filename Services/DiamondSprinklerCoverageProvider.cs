using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MyFirstStardewMod.Services
{
    public class DiamondSprinklerCoverageProvider : ISprinklerCoverageProvider
    {
        // Cached unique relative offsets to avoid per-sprinkler heap allocations
        private static readonly IReadOnlyList<Vector2> RelativeOffsets = new List<Vector2>
        {
            // 3x3 diagonal corners
            new Vector2(-1, -1),
            new Vector2(1, -1),
            new Vector2(-1, 1),
            new Vector2(1, 1),

            // 5x5 outer ring expansion (deduplicated)
            new Vector2(0, -2),
            new Vector2(-1, -2),
            new Vector2(-2, -2),
            new Vector2(-2, -1),
            new Vector2(0, 2),
            new Vector2(1, 2),
            new Vector2(2, 2),
            new Vector2(2, 1),
            new Vector2(-2, 0),
            new Vector2(-2, 1),
            new Vector2(-1, 2),
            new Vector2(2, 0),
            new Vector2(2, -1),
            new Vector2(1, -2)
        };

        public IEnumerable<Vector2> GetWateringTiles(Vector2 origin)
        {
            foreach (Vector2 offset in RelativeOffsets)
            {
                yield return origin + offset;
            }
        }
    }
}