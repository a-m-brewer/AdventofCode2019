using System.Collections.Generic;
using AdventOfCode.AsteroidMonitoring.Interfaces;

namespace AdventOfCode.AsteroidMonitoring.Models
{
    public class RawMap : IRawMap
    {
        public RawMap(IList<string> map)
        {
            Map = map;
        }
        
        public IList<string> Map { get; }
    }
}