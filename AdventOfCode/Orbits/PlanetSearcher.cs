using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Orbits.Interfaces;
using AdventOfCode.Orbits.Models;

namespace AdventOfCode.Orbits
{
    public class PlanetSearcher : IPlanetSearcher
    {
        public Planet Find(string id, Planet com)
        {
            var q = new Queue<Planet>();
            Search(id, com, q);
            return q.Count > 0 ? q.Dequeue() : null;
        }

        private static Planet Search(string id, Planet planet, Queue<Planet> queue)
        {
            if (planet == null) return null;
            
            if (planet.Id == id)
            {
                return planet;
            }

            if (planet.Orbiters == null || !planet.Orbiters.Any())
            {
                return null;
            }

            var orbitingPlanet = planet.Orbiters.FirstOrDefault(o => Search(id, o, queue) != null);

            if (orbitingPlanet != null)
            {
                queue.Enqueue(orbitingPlanet);
                
            }
            return orbitingPlanet;
            
            // var orbiter = planet.Orbiting.FirstOrDefault(o => Search(id, o, queue) != null);
            //
            // if (orbiter != null)
            // {
            //     queue.Enqueue(orbiter);
            // }
            //
            // return orbiter;
        }
    }
}