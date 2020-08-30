using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Stoichiometry.Models
{
    public class Reaction
    {
        public List<Element> Inputs { get; }
        public Element Output { get; }

        public string InputKey => string.Join(", ", Inputs);
        public string OutputKey => Output.Key;

        public Reaction(List<Element> inputs, Element output)
        {
            if (inputs.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(inputs));
            Inputs = inputs;
            Output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public static Reaction FromString(string input)
        {
            var inputOutput = input.Split(" => ");
            var inputs = inputOutput[0].Split(", ");
            var output = inputOutput[1];

            var inputModels = inputs.Select(Element.FromString).ToList();
            var outputModel = Element.FromString(output);
            
            return new Reaction(inputModels, outputModel);
        }

        public override string ToString()
        {
            return $"{InputKey} => {Output}";
        }
    }
}