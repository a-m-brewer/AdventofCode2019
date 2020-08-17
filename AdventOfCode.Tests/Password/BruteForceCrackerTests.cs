using System.Linq;
using AdventOfCode.Password;
using AdventOfCode.Password.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.Password
{
    public class BruteForceCrackerTests
    {
        [Test]
        public void Exercise1()
        {
            var sut = new BruteForceCracker(new Exercise1RuleSet());
            var results = sut.GetPossibilities(353096, 843212).ToList();
            var count = results.Count;
            count.Should().Be(579);
        }
        
        [Test]
        public void Exercise2()
        {
            var sut = new BruteForceCracker(new Exercise2RuleSet());
            var results = sut.GetPossibilities(353096, 843212).ToList();
            var count = results.Count;
            count.Should().Be(358);
        }
    }
}