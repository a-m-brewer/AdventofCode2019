using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Orbits.Interfaces;
using AdventOfCode.Orbits.Models;

namespace AdventOfCode.Orbits
{
    public class OrbitMapper : IOrbitMapper
    {
        private readonly IPlanetSearcher _planetSearcher;

        public OrbitMapper(IPlanetSearcher planetSearcher)
        {
            _planetSearcher = planetSearcher;
        }
        
        public (Planet root, int totalOrbits) Create(RelationshipData relationships)
        {
            Planet com = null;
            var seenPlanets = new Dictionary<string, int>();
            foreach (var (parent, child) in relationships.Data)
            {
                var p = _planetSearcher.Find(parent, com) ?? new Planet(parent);
                var c = _planetSearcher.Find(child, com) ?? new Planet(child);

                if (com == null) com = p;
                if (!p.Orbiters.Contains(c)) p.Orbiters.Add(c);
                if (!c.Orbiting.Contains(p)) c.Orbiting.Add(p);
                c.IndirectOrbitCount = p.IndirectOrbitCount + 1;
                
                if (!seenPlanets.ContainsKey(parent)) seenPlanets.Add(parent, p.IndirectOrbitCount);
                if (!seenPlanets.ContainsKey(child)) seenPlanets.Add(child, c.IndirectOrbitCount);
            }

            var totalOrbits = seenPlanets.Values.Sum();

            return (com, totalOrbits);
        }
    }
}