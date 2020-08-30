using System;
using System.Collections.Generic;

namespace AdventOfCode.Stoichiometry.Models
{
    public class RecipeVertex : ICloneable
    {
        public decimal PerProductionAmount { get; set; }
        public Dictionary<string, decimal> Edges { get; set; } = new Dictionary<string, decimal>();
        public Dictionary<string, decimal> ReversedEdges { get; set; } = new Dictionary<string, decimal>();
        public decimal Required { get; set; }
        
        public object Clone()
        {
            return new RecipeVertex
            {
                PerProductionAmount = PerProductionAmount,
                Edges = Edges,
                ReversedEdges = ReversedEdges,
                Required = Required
            };
        }
    }
}