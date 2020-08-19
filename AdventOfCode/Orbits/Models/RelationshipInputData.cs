using System.Collections.Generic;
using AdventOfCode.Orbits.Interfaces;

namespace AdventOfCode.Orbits.Models
{
    public class RelationshipInputData : IRelationshipInputData
    {
        public RelationshipInputData(IList<string> relationships)
        {
            Relationships = relationships;
        }
        
        public IList<string> Relationships { get; set; }
    }
}