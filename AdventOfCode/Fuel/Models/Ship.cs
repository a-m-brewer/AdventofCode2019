using System.Collections.Generic;
using AdventOfCode.Fuel.Interfaces;

namespace AdventOfCode.Fuel
{
    public class Ship : IShip
    {
        public IEnumerable<IModule> Modules { get; set; }
    }
}