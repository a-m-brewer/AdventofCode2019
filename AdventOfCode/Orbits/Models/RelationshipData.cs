using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Orbits.Interfaces;

namespace AdventOfCode.Orbits.Models
{
    public class RelationshipData
    {
        public RelationshipData(IRelationshipInputData relationshipInputData)
        {
            Data = relationshipInputData.Relationships.Select(r =>
            {
                var kvs = r.Split(")");
                return new KeyValuePair<string, string>(kvs[0], kvs[1]);
            });
        }

        public IEnumerable<KeyValuePair<string, string>> Data { get; set; }
    }
}