using System.Collections.Generic;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Modules.Output
{
    public class ListOutputModule : IOutputModule
    {
        public List<int> Output { get; set; } = new List<int>();
        
        public void OutputCallback(int val)
        {
            Output.Add(val);
        }
    }
}