using System.Linq;
using AdventOfCode.Fuel;
using AdventOfCode.Fuel.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Fuel
{
    public class ShipFuelRequirementsCalculatorTests
    {
        private ShipFuelRequirementsCalculator _sut;

        [SetUp]
        public void Setup()
        {
            var fuelRequirementsCalculator = new FuelRequirementsCalculator();
            _sut = new ShipFuelRequirementsCalculator(
                new ModuleFuelRequirementsCalculator(fuelRequirementsCalculator),
                new FuelFuelRequirementsCalculator(fuelRequirementsCalculator));
        }

        [Test]
        public void Challenge()
        {
            var modules = FuelChallenge.Data.Select(mass => new Module {Mass = mass});
            var ship = new Ship {Modules = modules};
            var result = _sut.CalculateShipFuelRequirements(ship);
            result.Should().Be(5142043);
        }
    }
}