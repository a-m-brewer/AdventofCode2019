using System;
using AdventOfCode.IntCode.Hardware.Arcade;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var arcade = new ArcadeMachine(false, true, 100);
            arcade.Load();
            arcade.InsertCash();
            arcade.Play();
            Console.WriteLine($"Score: {arcade.Score}");
            Console.WriteLine($"Inputs: {string.Join(", ", arcade.Inputs)}");
        }
    }
}