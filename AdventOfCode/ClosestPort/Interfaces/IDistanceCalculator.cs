using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort.Interfaces
{
    public interface IDistanceCalculator
    {
        int Calculate(Node from, Node to);
    }
}