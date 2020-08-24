using System.Collections.Generic;
using AdventOfCode.DSN.Models;

namespace AdventOfCode.DSN.Interfaces
{
    public interface IPicture
    {
        int Width { get; }
        int Height { get; }
        List<ILayer> Layers { get; }
    }
}