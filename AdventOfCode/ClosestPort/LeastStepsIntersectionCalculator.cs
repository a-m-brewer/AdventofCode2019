using System.Collections.Generic;
using System.Linq;
using AdventOfCode.ClosestPort.Interfaces;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort
{
    public class LeastStepsIntersectionCalculator : IIntersectionCalculator<int>
    {
        public int Calculate(Node start, IEnumerable<Intersection> intersections)
        {
            var steps = intersections.Select(s => s.Nodes.Select(n => n.Step).Sum());
            var min = steps.Min();
            return min;
        }
    }
}