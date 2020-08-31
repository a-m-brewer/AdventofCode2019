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
            var repair = new OxygenRepairDroid(UserMode.LeastExplored);
            var result = repair.Repair();
            
            repair = new OxygenRepairDroid(UserMode.LeastExplored, result.Seen);
            result = repair.Repair();
            
            //result.ShowScreen = true;
            Console.WriteLine($"x: {result.End.X}, y: {result.End.Y}");
            // var pathfinder = new AStarPathfinder();
            // var path = pathfinder.FindPath(result);
            // var numberOfCommands = path.Count + 1;

            Console.WriteLine($"Oxygen Regeneration Time: {result.TimeTillOxygenRegenerated()}");
        }
    }
}