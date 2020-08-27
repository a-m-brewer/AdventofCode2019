using System.Collections.Generic;
using AdventOfCode.IntCode.Interfaces;

namespace AdventOfCode.IntCode.Modules.Output
{
    public class ListOutputModule : IOutputModule
    {
        public List<long> Output { get; set; } = new List<long>();
        
        public void OutputCallback(long val)
        {
            Output.Add(val);
        }
    }
}