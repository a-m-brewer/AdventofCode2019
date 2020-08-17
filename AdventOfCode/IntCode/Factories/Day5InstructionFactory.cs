using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Factories
{
    public class Day5InstructionFactory : IInstructionFactory
    {
        public IInstruction Parse(int instruction)
        {
            return new Instruction(instruction);
        }
    }
}