using System;
using AdventOfCode.IntCode.Hardware.Robot;
using AdventOfCode.IntCode.Hardware.Robot.Algorithms;
using AdventOfCode.IntCode.Hardware.Robot.Models;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var repair = new OxygenRepairDroid(UserMode.LeastExplored,true);
            var result = repair.Repair();
            Console.WriteLine($"x: {result.End.X}, y: {result.End.Y}");
            var pathfinder = new AStarPathfinder();
            var path = pathfinder.FindPath(result);
            var numberOfCommands = path.Count + 1;
        }
    }
}