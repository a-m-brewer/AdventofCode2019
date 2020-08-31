using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.Hardware.Amp;
using AdventOfCode.IntCode.Hardware.Arcade;
using AdventOfCode.IntCode.Hardware.Robot;
using AdventOfCode.IntCode.Hardware.Robot.Algorithms;
using AdventOfCode.IntCode.Hardware.Robot.Models;
using AdventOfCode.IntCode.Interfaces;
using AdventOfCode.IntCode.Modules.Output;
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
        private List<long> _output;

        [SetUp]
        public void Setup()
        {
            _inputModule = new Mock<IInputModule>();
            _outputModule = new Mock<IOutputModule>();
            
            _output = new List<long>();
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            _outputModule.Setup(s => s.OutputCallback(It.IsAny<long>())).Callback<long>(i => _output.Add(i));
            
            _sut = Create();
        }

        [Test]
        public void Example1()
        {
            var input = new long[] {1, 0, 0, 0, 99};
            var output = new long[] {2, 0, 0, 0, 99};
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Example2()
        {
            var input = new long[] {2, 3, 0, 3, 99};
            var output = new long[] {2, 3, 0, 6, 99};
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Example3()
        {
            var input = new long[] {2, 4, 4, 5, 99, 0};
            var output = new long[] {2, 4, 4, 5, 99, 9801};
            _sut.Load(input);
            _sut.Run().Should().Equal(output);
        }
        
        [Test]
        public void Example4()
        {
            var input = new long[] {1, 1, 1, 4, 99, 5, 6, 0, 99};
            var output = new long[] {30, 1, 1, 4, 2, 5, 6, 0, 99};
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
            const long expected = 19690720;
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
            var input = new long[] {1002, 4, 3, 4, 33};
            var output = new long[] {1002, 4, 3, 4, 99};
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
            var memory = new List<long> {3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(0);
        }
        
        [Test]
        public void Day5Part2Example2()
        {
            _sut = Create();
            var memory = new List<long> {3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
                
        [Test]
        public void Day5Part2Example3()
        {
            _sut = Create();
            var memory = new List<long> {3, 3, 1108, -1, 8, 3, 4, 3, 99};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(0);
        } 
        
        [Test]
        public void Day5Part2Example4()
        {
            _sut = Create();
            var memory = new List<long> {3, 3, 1107, -1, 8, 3, 4, 3, 99};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day5Part2Example5()
        {
            _sut = Create();
            var memory = new List<long> {3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day5Part2Example6()
        {
            _sut = Create();
            var memory = new List<long> {3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1};
            _sut.Load(memory);
            _sut.Run();
            _output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day5Part2Example7()
        {
            _sut = Create();
            var memory = new List<long>
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
            var program = new List<long> {3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0};
            var phaseSequence = new List<long> {4, 3, 2, 1, 0};
            var ampPipeline = new AmplifierPipeline(program, phaseSequence.Count);
            var res = ampPipeline.Run(phaseSequence);
            res.Should().Be(43210);
        }
        
        [Test]
        public void Day7Example2()
        {
            var program = new List<long> {3,23,3,24,1002,24,10,24,1002,23,-1,23, 101,5,23,23,1,24,23,23,4,23,99,0,0};
            var phaseSequence = new List<long> {0,1,2,3,4};
            var ampPipeline = new AmplifierPipeline(program, phaseSequence.Count);
            var res = ampPipeline.Run(phaseSequence);
            res.Should().Be(54321);
        }
        
        [Test]
        public void Day7Example3()
        {
            var program = new List<long> {3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0};
            var phaseSequence = new List<long> {1,0,4,3,2};
            var ampPipeline = new AmplifierPipeline(program, phaseSequence.Count);
            var res = ampPipeline.Run(phaseSequence);
            res.Should().Be(65210);
        }

        [Test]
        public void Day7Part1Exercise()
        {
            var combinations = new PhaseCombinationGenerator().GenerateCombinations( 5).ToList();
            var memory = ThrusterAmplification.Memory;
            
            var result = combinations.AsParallel().Max(m =>
            {
                var ampPipeline = new AmplifierPipeline(memory, 5);
                return ampPipeline.Run(m.ToList());
            });
            
            result.Should().Be(34686);
        }

        [Test]
        public void Day7Part2Example1()
        {
            var program = new List<long> {3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26, 27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5};
            var phaseSequence = new List<long> {9,8,7,6,5};
            var ampPipeline = new AmplifierPipeline(program, phaseSequence.Count);
            var res = ampPipeline.Run(phaseSequence, true);
            res.Should().Be(139629729);
        }
        
        [Test]
        public void Day7Part2Example2()
        {
            var program = new List<long>
            {
                3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54,
                -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4,
                53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10
            };
            var phaseSequence = new List<long> {9,7,8,5,6};
            var ampPipeline = new AmplifierPipeline(program, phaseSequence.Count);
            var res = ampPipeline.Run(phaseSequence, true);
            res.Should().Be(18216);
        }
        
        [Test]
        public void Day7Part2Exercise()
        {
            var combinations = new PhaseCombinationGenerator().GenerateCombinations( 5, 5).ToList();
            var memory = ThrusterAmplification.Memory;
            
            var result = combinations.AsParallel().Max(m =>
            {
                var ampPipeline = new AmplifierPipeline(memory, 5);
                return ampPipeline.Run(m.ToList(), true);
            });
            
            result.Should().Be(36384144);
        }

        [Test]
        public void Day9Part1Example1()
        {
            var program = new List<long> {109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Should().BeEquivalentTo(program);
        }

        [Test]
        public void Day9Part1Example2()
        {
            var program = new List<long> {1102,34915192,34915192,7,4,7,99,0};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().ToString().Length.Should().Be(16);
        }
        
        [Test]
        public void Day9Part1Example3()
        {
            const long expected = 1125899906842624;
            var program = new List<long> {104,expected,99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(expected);
        }
        
        [Test]
        public void Day9Part1Exercise()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = BOOST.Memory;
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(2745604242);
        }
        
        [Test]
        public void Day9Part1RedditTestCase1()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, -1, 4, 1, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(-1);
        }
        
        [Test]
        public void Day9Part1RedditTestCase2()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, -1, 104, 1, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day9Part1RedditTestCase3()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, -1, 204, 1, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(109);
        }
        
        [Test]
        public void Day9Part1RedditTestCase4()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, 1, 9, 2, 204, -6, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(204);
        }
        
        [Test]
        public void Day9Part1RedditTestCase5()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, 1, 109, 9, 204, -6, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(204);
        }
        
        [Test]
        public void Day9Part1RedditTestCase6()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, 1, 209, -1, 204, -106, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(204);
        }
        
        [Test]
        public void Day9Part1RedditTestCase7()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, 1, 3, 3, 204, 2, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day9Part1RedditTestCase8()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(1);
            var program = new long[] {109, 1, 203, 2, 204, 2, 99};
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(1);
        }
        
        [Test]
        public void Day9Part2Exercise()
        {
            _inputModule.Setup(s => s.InputCallback()).Returns(2);
            var program = BOOST.Memory;
            var output = new List<long>();
            var pc = new Computer(_inputModule.Object, new ActionOutputModule(a => output.Add(a)));
            pc.Load(program);
            pc.Run();
            output.Last().Should().Be(51135);
        }

        [Test]
        public void Day11Part1Exercise()
        {
            var robot = new HullPaintingRobot();
            var visited = robot.Paint();
            visited.Count.Should().Be(2255);
        }
        
        [Test]
        public void Day11Part2Exercise()
        {
            var robot = new HullPaintingRobot(1);
            var visited = robot.Paint();

            var numberPlate = new NumberPlate {Panels = visited};
            // BCKFPCRA
        }

        [Test]
        public void Day13Part1Exercise()
        {
            var arcade = new ArcadeMachine();
            arcade.Load();
            arcade.Play();
            var blocks = arcade.Screen.Pixels.Count(c => c.Value == "#");
            blocks.Should().Be(324);
        }
        
        [Test]
        public void Day13Part2Exercise()
        {
            var arcade = new ArcadeMachine();
            arcade.Load();
            arcade.InsertCash();
            arcade.Play();
            arcade.Score.Should().Be(15957);
        }

        [Test]
        public void Day15Part1()
        {
            var repair = new OxygenRepairDroid(UserMode.LeastExplored);
            var result = repair.Repair();
            var pathfinder = new AStarPathfinder();
            var path = pathfinder.FindPath(result);
            var numberOfCommands = path.Count + 1;
            numberOfCommands.Should().Be(238);
        }

        [Test]
        public void Day15Part2()
        {
            var repair = new OxygenRepairDroid(UserMode.LeastExplored);
            var result = repair.Repair();
            
            /*
             * I Don't know if this is a hack or if it always solves the problem in all cases
             *
             * The general strat is run the least explored algorithm once. and then run it again with the seen tiles
             * from the last run. As the algorithm prioritises the least visited tiles (including unvisited). This generally
             * finds the rest of the unvisited tiles that are missing.
             */
            repair = new OxygenRepairDroid(UserMode.LeastExplored, result.Seen);
            result = repair.Repair();

            var timeTillOxygen = result.TimeTillOxygenRegenerated();
            timeTillOxygen.Should().Be(392);
        }
        
        private Computer Create()
        {
            return new Computer(_inputModule.Object, _outputModule.Object);
        }
    }
}