using System.Collections.Generic;
using AdventOfCode.Moons;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Moons
{
    public class LCMTests
    {
        [Test]
        public void Example1()
        {
            new List<long> {3, 4, 6}.LCM().Should().Be(12);
        }
    }
}