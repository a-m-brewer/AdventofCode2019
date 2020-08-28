using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.AsteroidMonitoring.Constants;
using AdventOfCode.AsteroidMonitoring.Enums;
using AdventOfCode.AsteroidMonitoring.Interfaces;

namespace AdventOfCode.AsteroidMonitoring.Models
{
    public class Map
    {
        public Map(IRawMap rawMap)
        {
            Width = rawMap.Map[0].Length;
            Height = rawMap.Map.Count;
            InitTiles(rawMap);
        }

        public int Height { get; }

        public int Width { get; }
        
        public Tile[][] Tiles { get; private set; }

        public IList<Tile> FlatTiles { get; private set; }

        public IList<Tile> Asteroids => FlatTiles.Where(w => w.Type == TileType.Asteroid).ToList();
        
        public (Tile asteroid, int visibleAsteroids) FindBestLocation()
        {
            Tile best = null;
            var highest = 0;

            for (var a = 0; a < Asteroids.Count; a++)
            {
                var angles = new List<float>();
                var count = 0;
                for (var b = 0; b < Asteroids.Count; b++)
                {
                    if (a == b)
                    {
                        continue;
                    }

                    var dx = Asteroids[a].Position.X - Asteroids[b].Position.X;
                    var dy = Asteroids[a].Position.Y - Asteroids[b].Position.Y;
                    
                    var angle = (float)Math.Atan2(dx, dy);
                    if (!angles.Contains(angle))
                    {
                        angles.Add(angle);
                        count++;
                    }
                }

                if (count > highest)
                {
                    best = Asteroids[a];
                    highest = count;
                }
            }
            
            return (best, highest);
        }

        private void InitTiles(IRawMap map)
        {
            Tiles = new Tile[Height][];
            FlatTiles = new List<Tile>(Width * Height);
            for (var y = 0; y < Height; y++)
            {
                Tiles[y] = new Tile[Width];
                for (var x = 0; x < Width; x++)
                {
                    var rawTile = map.Map[y][x].ToString();

                    var type = rawTile switch
                    {
                        MapKey.Asteroid => TileType.Asteroid,
                        MapKey.Empty => TileType.Empty,
                        _ => throw new Exception("Unknown tile type")
                    };
                    
                    Tiles[y][x] = new Tile(type, new Coordinates(x, y));
                    FlatTiles.Add(Tiles[y][x]);
                }
            }
        }
    }
}