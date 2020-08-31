using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode.Hardware.Arcade.Models;

namespace AdventOfCode.IntCode.Hardware.Robot.Models
{
    public class OxygenRepairDroidResult
    {
        private Screen _screen;

        public OxygenRepairDroidResult(Dictionary<string, (int visited, OxygenNode node)> seen, long endX, long endY)
        {
            Nodes = seen.Values.Select(s => s.node).ToList();
            End = (endX, endY);

            _screen = null;
        }

        private bool _showScreen;
        public bool ShowScreen
        {
            get => _showScreen;
            set
            {
                _screen = new Screen();
                Nodes.ForEach(n => _screen.Update(n));
                _showScreen = value;
            }
        }

        public List<OxygenNode> Nodes { get; }
        public (long X, long Y) Start { get; } = (0, 0);
        public (long X, long Y) End { get; }

        public IEnumerable<OxygenNode> GetNeighbours(OxygenNode node)
        {
            var neighbourCoordinates = GetNeighbourCoordinates(node);

            var nodes = neighbourCoordinates
                .Select(s =>
                    Nodes.FirstOrDefault(f => f.X == s.x && f.Y == s.y))
                .Where(w => w != null);

            return nodes;
        }

        public int TimeTillOxygenRegenerated()
        {
            Nodes.First(f => f.X == End.X && f.Y == End.Y).IsVacuum = false;
            Nodes.First(f => f.X == End.X && f.Y == End.Y).Value = "O";
            
            var tick = 1;

            if (ShowScreen)
            {
                _screen.Update(Nodes.First(f => f.X == End.X && f.Y == End.Y));
                Console.Write(_screen.ToString());
            }

            while (Nodes.Any(a => a.IsVacuum && a.Walkable))
            {
                var available = Nodes.Where(n => !n.IsVacuum && n.Walkable).ToList();
                foreach (var node in available)
                {
                    foreach (var neighbour in GetNeighbours(node))
                    {
                        neighbour.IsVacuum = false;
                        neighbour.Value = "O";

                        if (_showScreen)
                        {
                            _screen.Update(neighbour);
                        }
                    }
                }

                if (_showScreen)
                {
                    Console.Write(_screen.ToString());
                }
                tick++;
            }

            return tick;
        }

        private static IEnumerable<(long x, long y)> GetNeighbourCoordinates(OxygenNode node)
        {
            var x = node.X;
            var y = node.Y;
            return new List<(long x, long y)>
            {
                (x, y - 1),
                (x, y + 1),
                (x - 1, y),
                (x + 1, y),
            };
        }
    }
}