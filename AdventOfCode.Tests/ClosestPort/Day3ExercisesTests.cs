using System.Collections.Generic;
using AdventOfCode.ClosestPort;
using AdventOfCode.ClosestPort.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.ClosestPort
{
    public class Day3ExercisesTests
    {
        private IntersectionCalculatorRunner<Destination> _part1;
        private IntersectionCalculatorRunner<int> _part2;

        [SetUp]
        public void Setup()
        {

            _part1 = new IntersectionCalculatorRunner<Destination>(
                new ConnectionsParser(), 
                new NodePortMapper(), 
                new IntersectionFinder(), 
                new TaxiCabIntersectionCalculator(new TaxiCabDistanceCalculator()));
            
            _part2 = new IntersectionCalculatorRunner<int>(
                new ConnectionsParser(), 
                new NodePortMapper(), 
                new IntersectionFinder(), 
                new LeastStepsIntersectionCalculator());
        }
        
        [Test]
        public void Part1Example1()
        {
            var connections = new DirectionData(new List<List<string>>
            {
                new List<string> {"R8", "U5", "L5", "D3"},
                new List<string> {"U7", "R6", "D4", "L4"}
            });
            var result = _part1.Find(new Node(1,1), connections);
            result.Distance.Should().Be(6);
        }

        [Test]
        public void Part1Example2()
        {
            var connections = new DirectionData(new List<List<string>>
            {
                new List<string> {"R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72"},
                new List<string> {"U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83"}
            });
            var result = _part1.Find(new Node(1,1), connections);
            result.Distance.Should().Be(159);
        }
        
        [Test]
        public void Part1Example3()
        {
            var connections = new DirectionData(new List<List<string>>
            {
                new List<string> {"R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51"},
                new List<string> {"U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7"}
            });
            var result = _part1.Find(new Node(1,1), connections);
            result.Distance.Should().Be(135);
        }
        
        [Test]
        public void Part1()
        {
            var connections = new FileDirectionData("day3.txt");
            var result = _part1.Find(new Node(1,1), connections);
            result.Distance.Should().Be(266);
        }

        [Test]
        public void Part2Example1()
        {
            var connections = new DirectionData(new List<List<string>>
            {
                new List<string> {"R8", "U5", "L5", "D3"},
                new List<string> {"U7", "R6", "D4", "L4"}
            });
            var result = _part2.Find(new Node(1,1), connections);
            result.Should().Be(30);
        }
        
        [Test]
        public void Part2Example2()
        {
            var connections = new DirectionData(new List<List<string>>
            {
                new List<string> {"R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72"},
                new List<string> {"U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83"}
            });
            var result = _part2.Find(new Node(1,1), connections);
            result.Should().Be(610);
        }
        
        [Test]
        public void Part2Example3()
        {
            var connections = new DirectionData(new List<List<string>>
            {
                new List<string> {"R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51"},
                new List<string> {"U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7"}
            });
            var result = _part2.Find(new Node(1,1), connections);
            result.Should().Be(410);
        }
        
        [Test]
        public void Part2()
        {
            var connections = new FileDirectionData("day3.txt");
            var result = _part2.Find(new Node(1,1), connections);
            result.Should().Be(19242);
        }
    }
}