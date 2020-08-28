using System.Collections.Generic;
using AdventOfCode.AsteroidMonitoring.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.AsteroidMonitoring
{
    public class Day10Tests
    {
        [Test]
        public void Part1Example1()
        {
            var raw = new RawMap(new List<string>
            {
                ".#..#",
                ".....", 
                "#####",
                "....#",
                "...##"
            });
            var map = new Map(raw);

            var (asteroid, visible) = map.FindBestLocation();
            asteroid.Position.Should().BeEquivalentTo(new Coordinates(3, 4));
            visible.Should().Be(8);
        }
        
        [Test]
        public void Part1Example2()
        {
            var raw = new RawMap(new List<string>
            {
                "......#.#.",
                "#..#.#....",
                "..#######.",
                ".#.#.###..",                
                "..#....#.#",                
                "#..#....#.",
                ".##.#..###",                
                "##...#..#.",
                ".#....####"
            });
            var map = new Map(raw);

            var (asteroid, visible) = map.FindBestLocation();
            asteroid.Position.Should().BeEquivalentTo(new Coordinates(5, 8));
            visible.Should().Be(33);
        }
    }
}