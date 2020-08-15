using System;

namespace AdventOfCode.Fuel
{
    public class FuelRequirementsCalculator : IFuelRequirementsCalculator
    {
        public decimal Calculate(decimal mass)
        {
            return Math.Floor(mass / 3) - 2;
        }
    }
}