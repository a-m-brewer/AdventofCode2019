using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Fuel.Interfaces;

namespace AdventOfCode.Fuel
{
    /// <summary>
    /// This class is only really needed for the first half of day 1 challenge.
    /// </summary>
    public class ShipModulesFuelRequirementsCalculator : IShipModulesFuelRequirementsCalculator
    {
        private readonly IModuleFuelRequirementsCalculator _moduleFuelRequirementsCalculator;

        public ShipModulesFuelRequirementsCalculator(IModuleFuelRequirementsCalculator moduleFuelRequirementsCalculator)
        {
            _moduleFuelRequirementsCalculator = moduleFuelRequirementsCalculator;
        }
        
        public decimal CalculateFuelRequirements(IEnumerable<IModule> modules)
        {
            var moduleFuelCost = modules.Select(module =>
                _moduleFuelRequirementsCalculator.CalculateFuelRequirements(module));
            return moduleFuelCost.Sum();
        }
    }
}