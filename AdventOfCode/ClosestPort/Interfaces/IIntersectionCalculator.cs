using System.Collections.Generic;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort.Interfaces
{
    public interface IIntersectionCalculator<out TResult>
    {
        TResult Calculate(Node start, IEnumerable<Intersection> intersections);
    }
}