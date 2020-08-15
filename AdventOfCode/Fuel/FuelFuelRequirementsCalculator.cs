using AdventOfCode.Fuel.Interfaces;

namespace AdventOfCode.Fuel
{
    /// <summary>
    /// Fuel needs Fuel to Fuel the Ship.
    /// </summary>
    public class FuelFuelRequirementsCalculator : IFuelFuelRequirementsCalculator
    {
        private readonly IFuelRequirementsCalculator _fuelRequirementsCalculator;

        public FuelFuelRequirementsCalculator(IFuelRequirementsCalculator fuelRequirementsCalculator)
        {
            _fuelRequirementsCalculator = fuelRequirementsCalculator;
        }
        
        public decimal CalculateFuelNeededForFuel(decimal fuel)
        {
            decimal total = 0;
            var requiredFuel = _fuelRequirementsCalculator.Calculate(fuel);
            while (requiredFuel > 0)
            {
                total += requiredFuel;
                requiredFuel = _fuelRequirementsCalculator.Calculate(requiredFuel);
            }

            return total;
        }
    }
}