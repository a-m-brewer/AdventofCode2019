using System.Collections.Generic;

namespace AdventOfCode.DSN.Interfaces
{
    public interface IRawPicture
    {
        int Width { get; }
        int Height { get; }
        string Pixels { get; }
    }
}