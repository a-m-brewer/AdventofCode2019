using AdventOfCode.Orbits.Models;

namespace AdventOfCode.Orbits.Interfaces
{
    public interface IOrbitMapper
    {
        (Planet root, int totalOrbits) Create(RelationshipData relationships);
    }
}