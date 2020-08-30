using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Stoichiometry.Models
{
    public class Recipe
    {
        public List<Reaction> Reactions { get; }

        public Recipe(List<Reaction> reactions)
        {
            if (reactions.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(reactions));
            Reactions = reactions;
        }

        public static Recipe FromString(string input)
        {
            var split = input.Split("\n").Where(w => !string.IsNullOrEmpty(w) && !string.IsNullOrWhiteSpace(w));
            var reactions = split.Select(Reaction.FromString).ToList();
            return new Recipe(reactions);
        }

        public double CalculateFuelCost()
        {
            var extraChemicals = new Dictionary<string, double>();
            
            double FindOreRequirement(string type, double amount)
            {
                var total = 0.0;
                var reaction = Reactions.First(f => f.Output.Type == type);

                foreach (var input in reaction.Inputs)
                {
                    if (input.Type == "ORE")
                    {
                        var cExtra = extraChemicals.TryGetValue("ORE", out var v) ? v : 0;
                        var extraCurrent = cExtra + (input.Amount - amount);
                        extraChemicals["ORE"] = extraCurrent;
                        total += input.Amount;
                    }
                    else
                    {
                        total += FindOreRequirement(input.Type, input.Amount);
                    }
                }
                 
                return total;
            }
            
            
            var res = FindOreRequirement("FUEL", 1);
            return res;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var reaction in Reactions)
            {
                sb.AppendLine(reaction.ToString());
            }

            return sb.ToString();
        }
    }
}