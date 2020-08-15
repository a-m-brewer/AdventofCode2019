using AdventOfCode.Fuel;
using AdventOfCode.Fuel.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Fuel
{
    public class ModuleFuelRequirementsCalculatorTests
    {
        private ModuleFuelRequirementsCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ModuleFuelRequirementsCalculator(new FuelRequirementsCalculator());
        }

        [Test]
        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]
        public void Correct(decimal mass, decimal expected)
        {
            _sut.CalculateFuelRequirements(new Module {Mass = mass}).Should().Be(expected);
        }
    }
}