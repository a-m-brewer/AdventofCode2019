using System.Collections.Generic;
using System.Linq;
using AdventOfCode.ClosestPort.Interfaces;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort
{
    public class IntersectionCalculatorRunner<TResult>
    {
        private readonly IConnectionsParser _parser;
        private readonly INodePortMapper _mapper;
        private readonly IIntersectionFinder _finder;
        private readonly IIntersectionCalculator<TResult> _calculator;

        public IntersectionCalculatorRunner(          
            IConnectionsParser parser,
            INodePortMapper mapper,
            IIntersectionFinder finder,
            IIntersectionCalculator<TResult> calculator)
        {
            _parser = parser;
            _mapper = mapper;
            _finder = finder;
            _calculator = calculator;
        }

        public TResult Find(Node start, IDirectionData data)
        {
            var wires = data.Data.Select(wire => _parser.Parse(wire));
            var nodePorts = wires.Select(c => _mapper.Map(start, c));
            var intersections = _finder.Find(nodePorts);
            return _calculator.Calculate(start, intersections);
        }
    }
}