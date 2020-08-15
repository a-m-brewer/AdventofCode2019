using System;
using System.Collections.Generic;

namespace AdventOfCode.IntCode
{
    public class Computer
    {
        public IList<int> RunProgram(IList<int> memory)
        {
            var instructionPointer = 0;
            while (instructionPointer < memory.Count && memory[instructionPointer] != (int) OpCode.Halt)
            {
                var instruction = memory[instructionPointer];
                var parameter1Pos = memory[instructionPointer + 1];
                var parameter2Pos = memory[instructionPointer + 2];
                var parameter3Post = memory[instructionPointer + 3];

                var parameter1 = memory[parameter1Pos];
                var parameter2 = memory[parameter2Pos];

                memory[parameter3Post] = instruction switch
                {
                    (int) OpCode.Add => parameter1 + parameter2,
                    (int) OpCode.Multiply => parameter1 * parameter2,
                    _ => throw new Exception("Unknown Opcode")
                };

                instructionPointer += 4;
            }
            
            return memory;
        }
    }
}