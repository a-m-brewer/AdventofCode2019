using System.Linq;
using AdventOfCode.Orbits.Interfaces;
using AdventOfCode.Orbits.Models;

namespace AdventOfCode.Orbits.Calculators
{
    public class DistanceToSantaCalculator
    {
        public int Calculate(IRelationshipInputData data)
        {
            var relationshipData = new RelationshipData(data);
            var relationships = relationshipData.Data
                .Select(r => new Relationship<string>(r.Key, r.Value))
                .ToList();
            
            var root = new TreeNode<string>("COM");            
            
            var tree = new Tree<string>(root, relationships);

            var distance = tree.DistanceBetweenNodes("YOU", "SAN");

            return distance;
        }
    }
}