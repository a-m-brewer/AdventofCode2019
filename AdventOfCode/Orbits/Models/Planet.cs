using System.Collections.Generic;

namespace AdventOfCode.Orbits.Models
{
    public class Planet
    {
        public Planet(string id)
        {
            Id = id;
        }
        
        public string Id { get; }
        public List<Planet> Orbiting { get; set; } = new List<Planet>();
        public List<Planet> Orbiters { get; } = new List<Planet>();
        public int IndirectOrbitCount { get; set; }
    }
}