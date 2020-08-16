using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.ClosestPort.Interfaces;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort
{
    public class NodePortMapper : INodePortMapper
    {
        public IEnumerable<Node> Map(Node startPoint, IEnumerable<Connection> connections)
        {
            var currX = startPoint.X;
            var currY = startPoint.Y;
            
            var nodes = new List<Node>();

            var steps = 0;
            
            foreach (var con in connections)
            {
                var (xMult, yMult) = GetMultiplier(con.Direction);

                var currXTemp = currX;
                var currYTemp = currY;
                
                var newNodes = Enumerable.Range(0, con.Distance).Select(s =>
                {
                    var x = currXTemp + s * xMult;
                    var y = currYTemp + s * yMult;
                    var n = new Node(x, y) {Step = steps};
                    steps += 1;
                    return n;
                });
                
                nodes.AddRange(newNodes);

                currX += con.Distance * xMult;
                currY += con.Distance * yMult;
            }

            var distinctNodes = from node in nodes
                group node by new {node.X, node.Y}
                into grouped
                select grouped.OrderBy(o => o.Step).First();
            
            return distinctNodes;
        }

        private static (int x, int y) GetMultiplier(Direction direction)
        {
            return direction switch
            {
                Direction.Up => (0, 1),
                Direction.Down => (0, -1),
                Direction.Left => (-1, 0),
                Direction.Right => (1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}