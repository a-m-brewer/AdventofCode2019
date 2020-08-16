using System.Collections.Generic;
using System.Linq;
using AdventOfCode.ClosestPort.Interfaces;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort
{
    public class IntersectionFinder : IIntersectionFinder
    {
        public IEnumerable<Intersection> Find(IEnumerable<IEnumerable<Node>> nodePorts)
        {
            var nodes = nodePorts.SelectMany(m => m).Where(w => w.Step != 0);

            var res = from node in nodes
                group node by new {node.X, node.Y}
                into grouped
                where grouped.Count() > 1
                select new Intersection
                {
                    X = grouped.First().X,
                    Y = grouped.First().Y,
                    Nodes = grouped.ToList()
                };

            return res;
        }
    }
}