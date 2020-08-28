using AdventOfCode.IntCode;
using AdventOfCode.IntCode.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.IntCode
{
    public class InstructionTests
    {
        [Test]
        [TestCase(1, OpCode.Add)]
        [TestCase(2, OpCode.Multiply)]
        [TestCase(3, OpCode.Save)]
        [TestCase(4, OpCode.Output)]
        [TestCase(99, OpCode.Halt)]
        [TestCase(1001, OpCode.Add)]
        [TestCase(1002, OpCode.Multiply)]
        [TestCase(1003, OpCode.Save)]
        [TestCase(1004, OpCode.Output)]
        public void InstructionHasCorrectOpCode(int instruction, OpCode opCode)
        {
            new Instruction(instruction).Op.Should().Be(opCode);
        }

        [Test]
        [TestCase(1001, 3)]
        [TestCase(1002, 3)]
        [TestCase(1003, 1)]
        [TestCase(1004, 1)]
        [TestCase(1099, 0)]
        public void ParameterModesCorrectLength(int instruction, int length)
        {
            new Instruction(instruction).ParameterModes.Count.Should().Be(length);
        }

        [Test]
        [TestCase(1, Mode.Position)]
        [TestCase(101, Mode.Immediate)]
        public void Parameter1CorrectMode(int instruction, Mode mode)
        {
            new Instruction(instruction).ParameterModes[0].Should().Be(mode);
        }
        
        [Test]
        [TestCase(1, Mode.Position)]
        [TestCase(1001, Mode.Immediate)]
        public void Parameter2CorrectMode(int instruction, Mode mode)
        {
            new Instruction(instruction).ParameterModes[1].Should().Be(mode);
        }

        [Test]
        [TestCase(11101, 2)]
        [TestCase(11102, 2)]
        [TestCase(11103, 0)]
        public void WriteToParamIsNeverInImmediateMode(int instruction, int outputPos)
        {
            new Instruction(instruction).ParameterModes[outputPos].Should().Be(Mode.Position);
        }
    }
}