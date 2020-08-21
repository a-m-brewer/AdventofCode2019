using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Orbits.Interfaces;
using AdventOfCode.Orbits.Models;

namespace AdventOfCode.Orbits.Calculators
{
    public class DirectAndInDirectOrbitCalculator
    {
        private readonly IOrbitMapper _orbitMapper;

        public DirectAndInDirectOrbitCalculator(IOrbitMapper orbitMapper)
        {
            _orbitMapper = orbitMapper;
        }
        
        public int Calculate(IRelationshipInputData data)
        {
            var relationshipData = new RelationshipData(data);

            var parents = relationshipData.Data.ToDictionary(k => k.Value, v => v.Key);
            var objs = relationshipData.Data.SelectMany(s => new List<string> {s.Key, s.Value}).Distinct().ToList();

            var orbs = new Dictionary<string, int>();

            int GetOrbs(string p)
            {
                if (orbs.ContainsKey(p)) return orbs[p];
                
                if (parents.ContainsKey(p))
                {
                    orbs[p] = 1 + GetOrbs(parents[p]);
                }
                else
                {
                    orbs[p] = 0;
                }

                return orbs[p];
            }

            var sum = objs.Select(GetOrbs).Sum();
            
            var youPath = new List<string> {"YOU"};
            while (parents.ContainsKey(youPath.Last()))
            {
                youPath.Add(parents[youPath.Last()]);
            }

            var sanPath = new List<string> {"SAN"};
            while (parents.ContainsKey(sanPath.Last()))
            {
                sanPath.Add(parents[sanPath.Last()]);
            }

            var orbitsToSanta = 0;
            for (var i = 0; i < youPath.Count; i++)
            {
                for (var j = 0; j < sanPath.Count; j++)
                {
                    var p = youPath[i];

                    if (sanPath.Contains(p))
                    {
                        orbitsToSanta = i + j - 2;
                    }
                }
            }

            return sum;
        }
    }
}