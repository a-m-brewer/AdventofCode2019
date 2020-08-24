using System.Collections.Generic;

namespace AdventOfCode.DSN.Interfaces
{
    public interface ILayer
    {
        IList<IList<int>> Rows { get; set; }
    }
}