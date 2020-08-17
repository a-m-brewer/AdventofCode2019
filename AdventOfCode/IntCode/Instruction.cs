using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode
{
    public class Instruction : IInstruction
    {
        public Instruction(int instruction)
        {
            var inputChars = instruction.ToString().Reverse().ToArray();
            var instructionChars = Enumerable.Range(0, 5).Select(s => '0').ToArray();
            for (var i = 0; i < inputChars.Length; i++) instructionChars[i] = inputChars[i];

            var opChar = instructionChars.Take(2).Reverse().ToArray();

            Op = GetOpCode(opChar);
            
            var modes = instructionChars.Skip(2).ToArray();
            ParameterModes = GetModes(modes);
        }

        public OpCode Op { get; }
        public IList<Mode> ParameterModes { get; }

        private static OpCode GetOpCode(char[] opCode)
        {
            var opCodeInt = int.Parse(opCode);
            return (OpCode) opCodeInt;
        }

        private static IList<Mode> GetModes(IEnumerable<char> modes)
        {
            var intModes = modes.Select(m => (Mode) int.Parse(m.ToString())).ToArray();
            return intModes;
        }
    }
}