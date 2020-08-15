using AdventOfCode.IntCode;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.IntCode
{
    public class ComputerTests
    {
        private Computer _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Computer();
        }

        [Test]
        public void Example1()
        {
            var input = new[] {1, 0, 0, 0, 99};
            var output = new[] {2, 0, 0, 0, 99};
            _sut.RunProgram(input).Should().Equal(output);
        }
        
        [Test]
        public void Example2()
        {
            var input = new[] {2, 3, 0, 3, 99};
            var output = new[] {2, 3, 0, 6, 99};
            _sut.RunProgram(input).Should().Equal(output);
        }
        
        [Test]
        public void Example3()
        {
            var input = new[] {2, 4, 4, 5, 99, 0};
            var output = new[] {2, 4, 4, 5, 99, 9801};
            _sut.RunProgram(input).Should().Equal(output);
        }
        
        [Test]
        public void Example4()
        {
            var input = new[] {1, 1, 1, 4, 99, 5, 6, 0, 99};
            var output = new[] {30, 1, 1, 4, 2, 5, 6, 0, 99};
            _sut.RunProgram(input).Should().Equal(output);
        }

        [Test]
        public void Challenge()
        {
            var memory = GravityAssist.Memory;
            memory[1] = 12;
            memory[2] = 2;
            var result = _sut.RunProgram(memory);
            result[0].Should().Be(5434663);
        }

        [Test]
        public void Challenge2()
        {
            const int expected = 19690720;
            var memory = GravityAssist.Memory;
            memory[1] = 45;
            memory[2] = 59;
            var result = _sut.RunProgram(memory);
            result[0].Should().Be(expected);
        }
    }
}