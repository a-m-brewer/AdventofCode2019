using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.ClosestPort.Interfaces;

namespace AdventOfCode.ClosestPort.Models
{
    public class FileDirectionData : IDirectionData
    {
        public FileDirectionData(string path)
        {
            var text = File.ReadAllLines(path);
            Data = text.Select(m => m.Split(","));;
        }

        public IEnumerable<IEnumerable<string>> Data { get; }
    }
}