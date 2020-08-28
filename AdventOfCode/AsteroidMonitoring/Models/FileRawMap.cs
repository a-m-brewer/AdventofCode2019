using System.Collections.Generic;
using System.IO;
using AdventOfCode.AsteroidMonitoring.Interfaces;

namespace AdventOfCode.AsteroidMonitoring.Models
{
    public class FileRawMap : IRawMap
    {
        public FileRawMap(string path)
        {
            Map = File.ReadAllLines(path);
        }

        public IList<string> Map { get; }
    }
}