using System.Collections.Generic;

namespace AdventOfCode.AsteroidMonitoring.Interfaces
{
    public interface IRawMap
    {
        IList<string> Map { get; }
    }
}