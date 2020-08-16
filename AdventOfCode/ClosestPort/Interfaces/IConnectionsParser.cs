using System.Collections.Generic;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort.Interfaces
{
    public interface IConnectionsParser
    {
        IList<Connection> Parse(IEnumerable<string> connections);
    }
}