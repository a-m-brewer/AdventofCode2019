using System.Collections.Generic;

namespace AdventOfCode.Fuel.Interfaces
{
    public interface IShipModulesFuelRequirementsCalculator
    {
        decimal CalculateFuelRequirements(IEnumerable<IModule> modules);
    }
}