using System.Collections.Generic;
using System.IO;
using AdventOfCode.Orbits.Interfaces;

namespace AdventOfCode.Orbits.Models
{
    public class FileRelationshipInputData : IRelationshipInputData
    {
        public FileRelationshipInputData(string path)
        {
            Relationships =  File.ReadAllLines(path);
        }
        
        public IList<string> Relationships { get; set; }
    }
}