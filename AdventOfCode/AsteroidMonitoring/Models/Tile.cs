using AdventOfCode.AsteroidMonitoring.Enums;

namespace AdventOfCode.AsteroidMonitoring.Models
{
    public class Tile
    {
        public Tile(TileType type, Coordinates position)
        {
            Type = type;
            Position = position;
        }
        
        public TileType Type { get; }
        public Coordinates Position { get; }
    }
}