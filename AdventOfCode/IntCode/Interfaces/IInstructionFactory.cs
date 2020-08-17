namespace AdventOfCode.IntCode.Interfaces
{
    public interface IInstructionFactory
    {
        IInstruction Parse(int instruction);
    }
}