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

                    var angle = GetAsteroidDelta(Asteroids[a], Asteroids[b]);
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

        public Tile DestroyAsteroids(Tile currentBase, int amount)
        {
            var targets = new Dictionary<float, List<Tile>>();
        
            for (var c = 0; c < Asteroids.Count; c++)
            {
                if (currentBase == Asteroids[c])
                {
                    continue;
                }

                var angle = GetAsteroidDelta(currentBase, Asteroids[c]);
                
                if (!targets.ContainsKey(angle))
                {
                    targets[angle] = new List<Tile>();
                }
                
                targets[angle].Add(Asteroids[c]);
            }
            
            var keyOrder = targets.Keys.OrderBy(x => (180 - x) % 180).ToArray();
            var keyIndex = 0;

            Tile last = null;

            foreach (var range in targets.Values)
            {
                range.Sort((x, y) => Distance(currentBase, x).CompareTo(Distance(currentBase, y)));
            }
            
            for (; amount > 0; amount--)
            {
                List<Tile> firingLine;
                do
                {
                    firingLine = targets[keyOrder[keyIndex]];
                    keyIndex = (++keyIndex) % keyOrder.Length;

                } while (firingLine.Count == 0);

                last = firingLine[0];
                firingLine.RemoveAt(0);
            }

            return last;
        }

        private float GetAsteroidDelta(Tile a, Tile b)
        {
            var dx = a.Position.X - b.Position.X;
            var dy = a.Position.Y - b.Position.Y;
                    
            var angle = (float)Math.Atan2(dx, dy);
            return angle;
        }
        
        private static float Distance(Tile a, Tile b)
        {
            return (float)Math.Sqrt(Math.Pow(a.Position.X - b.Position.X, 2) + Math.Pow(a.Position.Y - b.Position.Y, 2));
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