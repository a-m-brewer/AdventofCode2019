using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Moons;
using AdventOfCode.Moons.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Moons
{
    public class MoonOrbitSimulatorTests
    {
        private MoonOrbitSimulator _sut;
        private List<Moon> _moons;
        private List<Moon> _moons2;

        [SetUp]
        public void Setup()
        {
            var moonString = new List<string>
            {
                "<x=-1, y=0, z=2>",
                "<x=2, y=-10, z=-7>",
                "<x=4, y=-8, z=8>",
                "<x=3, y=5, z=-1>"
            };

            _moons = moonString.Select(m => new Moon(m)).ToList();
            
            var moonString2 = new List<string>
            {
                "<x=-8, y=-10, z=0>",
                "<x=5, y=5, z=10>",
                "<x=2, y=-7, z=3>",
                "<x=9, y=-8, z=-3>"
            };
            
            _moons2 = moonString2.Select(m => new Moon(m)).ToList();
            
            _sut = new MoonOrbitSimulator();
        }

        [Test]
        public void CorrectAfterStep0()
        {
            var result = _sut.Simulate(_moons, 0);
            result.Should().BeEquivalentTo(_moons);
        }
        
        [Test]
        public void CorrectAfterStep1()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 2, y=-1, z= 1>, vel=<x= 3, y=-1, z=-1>",
                "pos=<x= 3, y=-7, z=-4>, vel=<x= 1, y= 3, z= 3>",
                "pos=<x= 1, y=-7, z= 5>, vel=<x=-3, y= 1, z=-3>",
                "pos=<x= 2, y= 2, z= 0>, vel=<x=-1, y=-3, z= 1>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 1);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep2()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 5, y=-3, z=-1>, vel=<x= 3, y=-2, z=-2>",
                "pos=<x= 1, y=-2, z= 2>, vel=<x=-2, y= 5, z= 6>",
                "pos=<x= 1, y=-4, z=-1>, vel=<x= 0, y= 3, z=-6>",
                "pos=<x= 1, y=-4, z= 2>, vel=<x=-1, y=-6, z= 2>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 2);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep3()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 5, y=-6, z=-1>, vel=<x= 0, y=-3, z= 0>",
                "pos=<x= 0, y= 0, z= 6>, vel=<x=-1, y= 2, z= 4>",
                "pos=<x= 2, y= 1, z=-5>, vel=<x= 1, y= 5, z=-4>",
                "pos=<x= 1, y=-8, z= 2>, vel=<x= 0, y=-4, z= 0>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 3);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep4()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 2, y=-8, z= 0>, vel=<x=-3, y=-2, z= 1>",
                "pos=<x= 2, y= 1, z= 7>, vel=<x= 2, y= 1, z= 1>",
                "pos=<x= 2, y= 3, z=-6>, vel=<x= 0, y= 2, z=-1>",
                "pos=<x= 2, y=-9, z= 1>, vel=<x= 1, y=-1, z=-1>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 4);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep5()
        {
            var expectedState = new List<string>
            {
                "pos=<x=-1, y=-9, z= 2>, vel=<x=-3, y=-1, z= 2>",
                "pos=<x= 4, y= 1, z= 5>, vel=<x= 2, y= 0, z=-2>",
                "pos=<x= 2, y= 2, z=-4>, vel=<x= 0, y=-1, z= 2>",
                "pos=<x= 3, y=-7, z=-1>, vel=<x= 1, y= 2, z=-2>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 5);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep6()
        {
            var expectedState = new List<string>
            {
                "pos=<x=-1, y=-7, z= 3>, vel=<x= 0, y= 2, z= 1>",
                "pos=<x= 3, y= 0, z= 0>, vel=<x=-1, y=-1, z=-5>",
                "pos=<x= 3, y=-2, z= 1>, vel=<x= 1, y=-4, z= 5>",
                "pos=<x= 3, y=-4, z=-2>, vel=<x= 0, y= 3, z=-1>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 6);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep7()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 2, y=-2, z= 1>, vel=<x= 3, y= 5, z=-2>",
                "pos=<x= 1, y=-4, z=-4>, vel=<x=-2, y=-4, z=-4>",
                "pos=<x= 3, y=-7, z= 5>, vel=<x= 0, y=-5, z= 4>",
                "pos=<x= 2, y= 0, z= 0>, vel=<x=-1, y= 4, z= 2>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 7);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep8()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 5, y= 2, z=-2>, vel=<x= 3, y= 4, z=-3>",
                "pos=<x= 2, y=-7, z=-5>, vel=<x= 1, y=-3, z=-1>",
                "pos=<x= 0, y=-9, z= 6>, vel=<x=-3, y=-2, z= 1>",
                "pos=<x= 1, y= 1, z= 3>, vel=<x=-1, y= 1, z= 3>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 8);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep9()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 5, y= 3, z=-4>, vel=<x= 0, y= 1, z=-2>",
                "pos=<x= 2, y=-9, z=-3>, vel=<x= 0, y=-2, z= 2>",
                "pos=<x= 0, y=-8, z= 4>, vel=<x= 0, y= 1, z=-2>",
                "pos=<x= 1, y= 1, z= 5>, vel=<x= 0, y= 0, z= 2>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 9);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void CorrectAfterStep10()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 2, y= 1, z=-3>, vel=<x=-3, y=-2, z= 1>",
                "pos=<x= 1, y=-8, z= 0>, vel=<x=-1, y= 1, z= 3>",
                "pos=<x= 3, y=-6, z= 1>, vel=<x= 3, y= 2, z=-3>",
                "pos=<x= 2, y= 0, z= 4>, vel=<x= 1, y=-1, z=-1>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons, 10);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Step10TotalEnergyExample()
        {
            var result = _sut.Simulate(_moons, 10);
            _sut.GetSumOfTotalEnergy(result).Should().Be(179);
        }
        
        [Test]
        public void Example2CorrectAfterStep0()
        {
            var result = _sut.Simulate(_moons2, 0);
            result.Should().BeEquivalentTo(_moons2);
        }
        
        [Test]
        public void Example2CorrectAfterStep10()
        {
            var expectedState = new List<string>
            {
                "pos=<x= -9, y=-10, z=  1>, vel=<x= -2, y= -2, z= -1>",
                "pos=<x=  4, y= 10, z=  9>, vel=<x= -3, y=  7, z= -2>",
                "pos=<x=  8, y=-10, z= -3>, vel=<x=  5, y= -1, z= -2>",
                "pos=<x=  5, y=-10, z=  3>, vel=<x=  0, y= -4, z=  5>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 10);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep20()
        {
            var expectedState = new List<string>
            {
                "pos=<x=-10, y=  3, z= -4>, vel=<x= -5, y=  2, z=  0>",
                "pos=<x=  5, y=-25, z=  6>, vel=<x=  1, y=  1, z= -4>",
                "pos=<x= 13, y=  1, z=  1>, vel=<x=  5, y= -2, z=  2>",
                "pos=<x=  0, y=  1, z=  7>, vel=<x= -1, y= -1, z=  2>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 20);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep30()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 15, y= -6, z= -9>, vel=<x= -5, y=  4, z=  0>",
                "pos=<x= -4, y=-11, z=  3>, vel=<x= -3, y=-10, z=  0>",
                "pos=<x=  0, y= -1, z= 11>, vel=<x=  7, y=  4, z=  3>",
                "pos=<x= -3, y= -2, z=  5>, vel=<x=  1, y=  2, z= -3>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 30);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep40()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 14, y=-12, z= -4>, vel=<x= 11, y=  3, z=  0>",
                "pos=<x= -1, y= 18, z=  8>, vel=<x= -5, y=  2, z=  3>",
                "pos=<x= -5, y=-14, z=  8>, vel=<x=  1, y= -2, z=  0>",
                "pos=<x=  0, y=-12, z= -2>, vel=<x= -7, y= -3, z= -3>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 40);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep50()
        {
            var expectedState = new List<string>
            {
                "pos=<x=-23, y=  4, z=  1>, vel=<x= -7, y= -1, z=  2>",
                "pos=<x= 20, y=-31, z= 13>, vel=<x=  5, y=  3, z=  4>",
                "pos=<x= -4, y=  6, z=  1>, vel=<x= -1, y=  1, z= -3>",
                "pos=<x= 15, y=  1, z= -5>, vel=<x=  3, y= -3, z= -3>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 50);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep60()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 36, y=-10, z=  6>, vel=<x=  5, y=  0, z=  3>",
                "pos=<x=-18, y= 10, z=  9>, vel=<x= -3, y= -7, z=  5>",
                "pos=<x=  8, y=-12, z= -3>, vel=<x= -2, y=  1, z= -7>",
                "pos=<x=-18, y= -8, z= -2>, vel=<x=  0, y=  6, z= -1>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 60);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep70()
        {
            var expectedState = new List<string>
            {
                "pos=<x=-33, y= -6, z=  5>, vel=<x= -5, y= -4, z=  7>",
                "pos=<x= 13, y= -9, z=  2>, vel=<x= -2, y= 11, z=  3>",
                "pos=<x= 11, y= -8, z=  2>, vel=<x=  8, y= -6, z= -7>",
                "pos=<x= 17, y=  3, z=  1>, vel=<x= -1, y= -1, z= -3>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 70);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep80()
        {
            var expectedState = new List<string>
            {
                "pos=<x= 30, y= -8, z=  3>, vel=<x=  3, y=  3, z=  0>",
                "pos=<x= -2, y= -4, z=  0>, vel=<x=  4, y=-13, z=  2>",
                "pos=<x=-18, y= -7, z= 15>, vel=<x= -8, y=  2, z= -2>",
                "pos=<x= -2, y= -1, z= -8>, vel=<x=  1, y=  8, z=  0>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 80);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep90()
        {
            var expectedState = new List<string>
            {
                "pos=<x=-25, y= -1, z=  4>, vel=<x=  1, y= -3, z=  4>",
                "pos=<x=  2, y= -9, z=  0>, vel=<x= -3, y= 13, z= -1>",
                "pos=<x= 32, y= -8, z= 14>, vel=<x=  5, y= -4, z=  6>",
                "pos=<x= -1, y= -2, z= -8>, vel=<x= -3, y= -6, z= -9>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 90);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2CorrectAfterStep100()
        {
            var expectedState = new List<string>
            {
                "pos=<x=  8, y=-12, z= -9>, vel=<x= -7, y=  3, z=  0>",
                "pos=<x= 13, y= 16, z= -3>, vel=<x=  3, y=-11, z= -5>",
                "pos=<x=-29, y=-11, z= -1>, vel=<x= -3, y=  7, z=  4>",
                "pos=<x= 16, y=-13, z= 23>, vel=<x=  7, y=  1, z=  1>"
            };

            var expectedMoons = expectedState.Select(Moon.InitWithVelocity).ToList();
            
            var result = _sut.Simulate(_moons2, 100);
            result.Should().BeEquivalentTo(expectedMoons);
        }
        
        [Test]
        public void Example2TotalEnergyAfterStep100()
        {
            var result = _sut.Simulate(_moons2, 100);
            _sut.GetSumOfTotalEnergy(result).Should().Be(1940);
        }

        [Test]
        public void Part1Exercise()
        {
            var moonString = new List<string>
            {
                "<x=13, y=-13, z=-2>",
                "<x=16, y=2, z=-15>",
                "<x=7, y=-18, z=-12>",
                "<x=-3, y=-8, z=-8>"
            };
            
            var moons = moonString.Select(m => new Moon(m)).ToList();
            var result = _sut.Simulate(moons, 1000);
            var totalEnergy = _sut.GetSumOfTotalEnergy(result);
            totalEnergy.Should().Be(12082);
        }

        [Test]
        public void Example1Repeats()
        {
            var result = _sut.Simulate(_moons, 2772);
            result.Should().BeEquivalentTo(_moons);
        }
        
        [Test]
        public void Part2Exercise()
        {
            var moonString = new List<string>
            {
                "<x=13, y=-13, z=-2>",
                "<x=16, y=2, z=-15>",
                "<x=7, y=-18, z=-12>",
                "<x=-3, y=-8, z=-8>"
            };
            
            List<Moon> Init() => moonString.Select(m => new Moon(m)).ToList();

            var moonsX = Init();
            var xRepeat = _sut.FirstRepeatOnAxis(moonsX, moon => moon.X);
            
            var moonsY = Init();
            var yRepeat = _sut.FirstRepeatOnAxis(moonsY, moon => moon.Y);
            
            var moonsZ = Init();
            var zRepeat = _sut.FirstRepeatOnAxis(moonsZ, moon => moon.Z);

            var lcm = new List<long> {xRepeat, yRepeat, zRepeat}.LCM();

            lcm.Should().Be(295693702908636);
        }
    }
}