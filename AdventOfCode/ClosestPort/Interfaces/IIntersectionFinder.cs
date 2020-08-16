using System.Collections.Generic;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort.Interfaces
{
    public interface IIntersectionFinder
    {
        IEnumerable<Intersection> Find(IEnumerable<IEnumerable<Node>> nodePorts);
    }
}