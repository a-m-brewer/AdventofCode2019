using System.Collections.Generic;

namespace AdventOfCode.ClosestPort.Interfaces
{
    public interface IDirectionData
    {
        IEnumerable<IEnumerable<string>> Data { get; }
    }
}