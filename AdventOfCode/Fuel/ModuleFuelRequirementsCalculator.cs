using System;
using AdventOfCode.Fuel.Interfaces;

namespace AdventOfCode.Fuel
{
    public class ModuleFuelRequirementsCalculator : IModuleFuelRequirementsCalculator
    {
        private readonly IFuelRequirementsCalculator _requirementsCalculator;

        public ModuleFuelRequirementsCalculator(IFuelRequirementsCalculator requirementsCalculator)
        {
            _requirementsCalculator = requirementsCalculator;
        }
        
        public decimal CalculateFuelRequirements(IModule module)
        {
            return _requirementsCalculator.Calculate(module.Mass);
        }
    }
}