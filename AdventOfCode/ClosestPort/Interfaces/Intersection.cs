using System.Collections.Generic;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort.Interfaces
{
    public class Intersection
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Node> Nodes { get; set; }
    }
}