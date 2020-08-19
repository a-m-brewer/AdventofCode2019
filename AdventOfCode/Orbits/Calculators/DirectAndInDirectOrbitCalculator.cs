using AdventOfCode.Orbits.Interfaces;
using AdventOfCode.Orbits.Models;

namespace AdventOfCode.Orbits.Calculators
{
    public class DirectAndInDirectOrbitCalculator
    {
        private readonly IOrbitMapper _orbitMapper;

        public DirectAndInDirectOrbitCalculator(IOrbitMapper orbitMapper)
        {
            _orbitMapper = orbitMapper;
        }
        
        public int Calculate(IRelationshipInputData data)
        {
            var (_, totalOrbits) = _orbitMapper.Create(new RelationshipData(data));
            return totalOrbits;
        }
    }
}