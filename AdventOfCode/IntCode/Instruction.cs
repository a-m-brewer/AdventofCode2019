using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode
{
    public class Instruction
    {
        public Instruction(long instruction)
        {
            var instructionString = instruction.ToString();
            instructionString = instructionString.PadLeft(5, '0');
            var instructionArray = instructionString.ToArray();

            var opCodeChar = instructionArray.TakeLast(2).ToArray();
            Op = GetOpCode(opCodeChar);

            var numberOfParams = GetNumberOfParams(Op);
            var instructionParams = instructionArray.SkipLast(2).Reverse().Select(s => int.Parse(s.ToString())).ToArray();

            ParameterModes = GetParameterModes(instructionParams, numberOfParams);
        }

        public OpCode Op { get; }
        public IList<Mode> ParameterModes { get; }

        private static OpCode GetOpCode(char[] opCode)
        {
            var opCodeInt = long.Parse(opCode);
            return (OpCode) opCodeInt;
        }

        private static int GetNumberOfParams(OpCode opCode)
        {
            return opCode switch
            {
                OpCode.Add => 3,
                OpCode.Multiply => 3,
                OpCode.Save => 1,
                OpCode.Output => 1,
                OpCode.Halt => 0,
                OpCode.JmpT => 2,
                OpCode.JmpF => 2,
                OpCode.LessThan => 3,
                OpCode.Eql => 3,
                OpCode.SetRbo => 1,
                _ => throw new Exception("Unknown OpCode param length")
            };
        }

        private IList<Mode> GetParameterModes(IReadOnlyList<int> paramsAsInt, int numberOfParams)
        {
            var paramModes = new Mode[numberOfParams];
            for (var i = 0; i < Math.Min(paramsAsInt.Count, numberOfParams); i++)
            {
                paramModes[i] = paramsAsInt[i] switch
                {
                    0 => Mode.Position,
                    1 => Mode.Immediate,
                    2 => Mode.Relative,
                    _ => throw new Exception("Unknown Mode")
                };
            }


            if (paramModes.Any())
            {
                var outputInstructionMode = paramModes[numberOfParams - 1];
                if (IsWriteMemoryInstruction() && outputInstructionMode == Mode.Immediate)
                {
                    paramModes[numberOfParams - 1] = Mode.Position;
                }   
            }

            return paramModes;
        }

        private bool IsWriteMemoryInstruction()
        {
            switch (Op)
            {
                case OpCode.Add:
                case OpCode.Multiply:
                case OpCode.LessThan:
                case OpCode.Eql:
                case OpCode.Save:
                    return true;
                case OpCode.JmpT:
                case OpCode.JmpF:
                case OpCode.Output:
                case OpCode.Halt:
                case OpCode.SetRbo:    
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}