using System.Collections.Generic;
using System.Linq;
using AdventOfCode.ClosestPort.Interfaces;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort
{
    public class TaxiCabIntersectionCalculator : IIntersectionCalculator<Destination>
    {
        private readonly IDistanceCalculator _calculator;

        public TaxiCabIntersectionCalculator(IDistanceCalculator calculator)
        {
            _calculator = calculator;
        }
        
        public Destination Calculate(Node start, IEnumerable<Intersection> intersections)
        {
            var destinations = intersections
                .Select(s => s.Nodes.First())
                .Select(i => new Destination
                {
                    Node = i,
                    Distance = _calculator.Calculate(start, i)
                })
                .Where(d => d.Distance != 0);

            var closest = destinations.OrderBy(o => o.Distance).FirstOrDefault();

            return closest;
        }
    }
}