using System.Collections.Generic;
using AdventOfCode.ClosestPort.Interfaces;

namespace AdventOfCode.ClosestPort.Models
{
    public class DirectionData : IDirectionData
    {
        public DirectionData(IEnumerable<IEnumerable<string>> data)
        {
            Data = data;
        }
        
        public IEnumerable<IEnumerable<string>> Data { get; }
    }
}