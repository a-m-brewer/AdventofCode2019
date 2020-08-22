using System.Collections.Generic;
using AdventOfCode.Orbits;
using AdventOfCode.Orbits.Calculators;
using AdventOfCode.Orbits.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Orbits
{
    public class Day6Tests
    {
        private string _filePath;
        private DirectAndInDirectOrbitCalculator _sut;

        [SetUp]
        public void SetUp()
        {
            _filePath = "day6.txt";
            _sut = new DirectAndInDirectOrbitCalculator();
        }

        [Test]
        public void Part1Example1()
        {
            var data = new RelationshipInputData(new List<string>
            {
                "COM)B",
                "B)C",
                "C)D",
                "D)E",
                "E)F",
                "B)G",
                "G)H",
                "D)I",
                "E)J",
                "J)K",
                "K)L"
            });
            _sut.Calculate(data).Should().Be(42);
        }
        
        [Test]
        public void Part1Challenge()
        {
            var data = new FileRelationshipInputData(_filePath);
            _sut.Calculate(data).Should().Be(162439);
        }

        [Test]
        public void Part2Exercise()
        {
            var data = new FileRelationshipInputData(_filePath);
            var sut = new DistanceToSantaCalculator();

            var result = sut.Calculate(data);

            result.Should().Be(367);
        }
        
        [Test]
        public void Part2Example()
        {
            var data = new RelationshipInputData(new List<string>
            {
                "COM)B",
                "B)C",
                "C)D",
                "D)E",
                "E)F",
                "B)G",
                "G)H",
                "D)I",
                "E)J",
                "J)K",
                "K)L",
                "K)YOU",
                "I)SAN"
            });
            var sut = new DistanceToSantaCalculator();

            var result = sut.Calculate(data);

            result.Should().Be(4);
        }
    }
}