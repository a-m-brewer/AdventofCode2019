using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Factories
{
    public class Day2InstructionFactory : IInstructionFactory
    {
        public IInstruction Parse(int instruction)
        {
            return new Day2Instruction(instruction);
        }
    }
}