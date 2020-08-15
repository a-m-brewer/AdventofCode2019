using System.Collections.Generic;

namespace AdventOfCode.Fuel.Interfaces
{
    public interface IShip
    {
        IEnumerable<IModule> Modules { get; set; }
    }
}