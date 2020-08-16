using System;
using AdventOfCode.ClosestPort.Interfaces;
using AdventOfCode.ClosestPort.Models;

namespace AdventOfCode.ClosestPort
{
    public class TaxiCabDistanceCalculator : IDistanceCalculator
    {
        public int Calculate(Node from, Node to)
        {
            var xDist = Math.Abs(to.X - from.X);
            var yDist = Math.Abs(to.Y - from.Y);
            return xDist + yDist;
        }
    }
}