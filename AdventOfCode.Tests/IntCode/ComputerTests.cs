using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode;
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
        private List<int> _output;

        [SetUp]
        public void Setup()
        {
            _inputModule = new Mock<IInputModule>();
            _outputModule = new Mock<IOutputModule>();
            
            _output = new List<int>();
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            _outputModule.Setup(s => s.OutputCallback(It.IsAny<int>())).Callback<int>(i => _output.Add(i));
            
            _sut = Create();
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
            _sut = Create();
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Day5Exercise1()
        {
            _sut = Create();
            var memory = AirConDiagnostic.Memory;
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(15259545);
        }

        [Test]
        public void Day5Part2Example1()
        {
            _sut = Create();
            var memory = new List<int> {3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(0);
        }
        
        [Test]
        public void Day5Part2Example2()
        {
            _sut = Create();
            var memory = new List<int> {3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
                
        [Test]
        public void Day5Part2Example3()
        {
            _sut = Create();
            var memory = new List<int> {3, 3, 1108, -1, 8, 3, 4, 3, 99};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(0);
        } 
        
        [Test]
        public void Day5Part2Example4()
        {
            _sut = Create();
            var memory = new List<int> {3, 3, 1107, -1, 8, 3, 4, 3, 99};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day5Part2Example5()
        {
            _sut = Create();
            var memory = new List<int> {3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day5Part2Example6()
        {
            _sut = Create();
            var memory = new List<int> {3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day5Part2Example7()
        {
            _sut = Create();
            var memory = new List<int>
            {
                3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31,
                1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104,
                999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
            };
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(999);
        }

        [Test]
        public void Day5Part2Exercise()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(5);
            _sut = Create();
            var memory = AirConDiagnostic.Memory;
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(7616021);
        }

        [Test]
        public void Day7Example1()
        {
            var program = new List<int> {3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0};
            var phaseSequence = new List<int> {4, 3, 2, 1, 0};
            var ampPipeline = new AmplifierPipeline(program);
            var res = ampPipeline.Run(phaseSequence);
            res.Should().Be(43210);
        }
        
        [Test]
        public void Day7Example2()
        {
            var program = new List<int> {3,23,3,24,1002,24,10,24,1002,23,-1,23, 101,5,23,23,1,24,23,23,4,23,99,0,0};
            var phaseSequence = new List<int> {0,1,2,3,4};
            var ampPipeline = new AmplifierPipeline(program);
            var res = ampPipeline.Run(phaseSequence);
            res.Should().Be(54321);
        }
        
        [Test]
        public void Day7Example3()
        {
            var program = new List<int> {3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0};
            var phaseSequence = new List<int> {1,0,4,3,2};
            var ampPipeline = new AmplifierPipeline(program);
            var res = ampPipeline.Run(phaseSequence);
            res.Should().Be(65210);
        }

        [Test]
        public void Day7Part1Exercise()
        {
            var combinations = new PhaseCombinationGenerator().GenerateCombinations( 5).ToList();
        }

        private Computer Create()
        {
            return new Computer(_inputModule.Object, _outputModule.Object);
        }
    }
}