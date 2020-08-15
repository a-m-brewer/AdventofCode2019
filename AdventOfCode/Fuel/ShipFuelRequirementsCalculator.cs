using System.Linq;
using AdventOfCode.Fuel.Interfaces;

namespace AdventOfCode.Fuel
{
    public class ShipFuelRequirementsCalculator : IShipFuelRequirementsCalculator
    {
        private readonly IModuleFuelRequirementsCalculator _modulesFuelRequirementsCalculator;
        private readonly IFuelFuelRequirementsCalculator _fuelRequirementsCalculator;

        public ShipFuelRequirementsCalculator(IModuleFuelRequirementsCalculator modulesFuelRequirementsCalculator, IFuelFuelRequirementsCalculator fuelRequirementsCalculator)
        {
            _modulesFuelRequirementsCalculator = modulesFuelRequirementsCalculator;
            _fuelRequirementsCalculator = fuelRequirementsCalculator;
        }
        
        public decimal CalculateShipFuelRequirements(IShip ship)
        {
            var modulesFuelRequirements = ship.Modules.Select(module =>
            {
                var moduleRequirements = _modulesFuelRequirementsCalculator.CalculateFuelRequirements(module);
                var fuelFuelRequirements = _fuelRequirementsCalculator.CalculateFuelNeededForFuel(moduleRequirements);
                return moduleRequirements + fuelFuelRequirements;
            });
            return modulesFuelRequirements.Sum();
        }
    }
}