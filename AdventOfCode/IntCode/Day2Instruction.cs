using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode
{
    public class Day2Instruction : Instruction, IInstruction
    {
        public Day2Instruction(int instruction) : base(instruction)
        {
            ParameterModes[2] = Mode.Immediate;
        }
    }
}