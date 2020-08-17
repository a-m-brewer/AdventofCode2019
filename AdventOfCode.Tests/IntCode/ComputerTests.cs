using System.Collections.Generic;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.Factories;
using AdventOfCode.IntCode.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AdventOfCode.Tests.IntCode
{
    public class ComputerTests
    {
        private Computer _sut;
        private Mock<IInputModule> _inputModule;
        private Mock<IOutputModule> _outputModule;

        [SetUp]
        public void Setup()
        {
            _inputModule = new Mock<IInputModule>();
            _outputModule = new Mock<IOutputModule>();
            _sut = Create(new Day2InstructionFactory());
        }

        [Test]
        public void Example1()
        {
            var input = new[] {1, 0, 0, 0, 99};
            var output = new[] {2, 0, 0, 0, 99};
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Example2()
        {
            var input = new[] {2, 3, 0, 3, 99};
            var output = new[] {2, 3, 0, 6, 99};
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Example3()
        {
            var input = new[] {2, 4, 4, 5, 99, 0};
            var output = new[] {2, 4, 4, 5, 99, 9801};
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Example4()
        {
            var input = new[] {1, 1, 1, 4, 99, 5, 6, 0, 99};
            var output = new[] {30, 1, 1, 4, 2, 5, 6, 0, 99};
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }

        [Test]
        public void Challenge()
        {
            var memory = GravityAssist.Memory;
            memory[1] = 12;
            memory[2] = 2;
            _sut.Load(memory);
            var result = _sut.Run();
            result[0].Should().Be(5434663);
        }

        [Test]
        public void Challenge2()
        {
            const int expected = 19690720;
            var memory = GravityAssist.Memory;
            memory[1] = 45;
            memory[2] = 59;
            _sut.Load(memory);
            var result = _sut.Run();
            result[0].Should().Be(expected);
        }

        [Test]
        public void Day5Example1()
        {
            var input = new[] {1002, 4, 3, 4, 33};
            var output = new[] {1002, 4, 3, 4, 99};
            _sut = Create(new Day5InstructionFactory());
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Day5Exercise1()
        {
            var output = new List<int>();
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            _outputModule.Setup(s => s.OutputCallback(It.IsAny<int>())).Callback<int>(i => output.Add(i));
            
            _sut = Create(new Day5InstructionFactory());
            
            var memory = AirConDiagnostic.Memory;
            _sut.Load(memory);
            _sut.Run();
        }

        private Computer Create(IInstructionFactory instructionFactory)
        {
            return new Computer(_inputModule.Object, _outputModule.Object, instructionFactory);
        }
    }
}