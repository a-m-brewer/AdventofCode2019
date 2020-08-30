using System;
using System.IO;
using AdventOfCode.Stoichiometry.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Stoichiometry
{
    public class Day14Tests
    {

        [Test]
        public void Part1Example1()
        {
            var input =
                "10 ORE => 10 A\n1 ORE => 1 B\n7 A, 1 B => 1 C\n7 A, 1 C => 1 D\n7 A, 1 D => 1 E\n7 A, 1 E => 1 FUEL\n";
            RecipeGraph.Part1(input).Should().Be(31);
        }
        
        [Test]
        public void Part1Example2()
        {
            var input =
                "9 ORE => 2 A\n8 ORE => 3 B\n7 ORE => 5 C\n3 A, 4 B => 1 AB\n5 B, 7 C => 1 BC\n4 C, 1 A => 1 CA\n2 AB, 3 BC, 4 CA => 1 FUEL";
            RecipeGraph.Part1(input).Should().Be(165);
        }

        [Test]
        public void Part1Exercise()
        {
            var input = File.ReadAllText("day14.txt");
            var result = RecipeGraph.Part1(input);
            result.Should().Be(720484);
        }
        
        [Test]
        public void Part2Exercise()
        {
            var input = File.ReadAllText("day14.txt");
            var p2 = RecipeGraph.Part2(input);
            p2.Should().Be(1993284);
        }
    }
}