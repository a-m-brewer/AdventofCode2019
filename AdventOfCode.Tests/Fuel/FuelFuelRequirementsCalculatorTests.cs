using AdventOfCode.Fuel;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Fuel
{
    public class FuelFuelRequirementsCalculatorTests
    {
        private FuelFuelRequirementsCalculator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new FuelFuelRequirementsCalculator(new FuelRequirementsCalculator());
        }

        [Test]
        [TestCase(2, 0)]
        [TestCase(654, 312)]
        [TestCase(33583, 16763)]
        public void Correct(decimal fuel, decimal expected)
        {
            _sut.CalculateFuelNeededForFuel(fuel).Should().Be(expected);
        }
    }
}