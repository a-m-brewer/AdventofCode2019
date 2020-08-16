using System.Collections.Generic;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort.Interfaces
{
    public interface INodePortMapper
    {
        IEnumerable<Node> Map(Node startPoint, IEnumerable<Connection> connections);
    }
}