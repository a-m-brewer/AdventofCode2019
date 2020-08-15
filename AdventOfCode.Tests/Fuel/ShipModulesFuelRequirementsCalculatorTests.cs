using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Fuel;
using AdventOfCode.Fuel.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Fuel
{
    public class ShipModulesFuelRequirementsCalculatorTests
    {
        private ShipModulesFuelRequirementsCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ShipModulesFuelRequirementsCalculator(new ModuleFuelRequirementsCalculator(new FuelRequirementsCalculator()));
        }
        
        [Test]
        public void Correct()
        {
            const decimal expected = 34241;
            _sut.CalculateFuelRequirements(new []
            {
                new Module {Mass = 12},
                new Module {Mass = 14},
                new Module {Mass = 1969},
                new Module {Mass = 100756}
            }).Should().Be(expected);
        }

        [Test]
        public void Challenge()
        {
            var modules = FuelChallenge.Data.Select(mass => new Module {Mass = mass});
            var result = _sut.CalculateFuelRequirements(modules);
            result.Should().Be(3429947);
        }
    }
}