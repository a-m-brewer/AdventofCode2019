using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.IntCode.Hardware.Robot.Models
{
    public class OxygenRepairDroidResult
    {
        public OxygenRepairDroidResult(Dictionary<string, (int visited, OxygenNode node)> seen, long endX, long endY)
        {
            Nodes = seen.Values.Select(s => s.node).ToList();
            End = (endX, endY);
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
            var tick = 1;

            while (Nodes.Any(a => a.IsVacuum && a.Walkable))
            {
                foreach (var node in Nodes.Where(n => !n.IsVacuum && n.Walkable))
                {
                    foreach (var neighbour in GetNeighbours(node))
                    {
                        neighbour.IsVacuum = false;
                    }
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