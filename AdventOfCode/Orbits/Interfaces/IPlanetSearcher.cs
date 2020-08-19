using AdventOfCode.Orbits.Models;

namespace AdventOfCode.Orbits.Interfaces
{
    public interface IPlanetSearcher
    {
        Planet Find(string id, Planet com);
    }
}