using System.Collections.Generic;

namespace AdventOfCode.IntCode.Interfaces
{
    public interface IInstruction
    {
        OpCode Op { get; }
        IList<Mode> ParameterModes { get; }
    }
}