using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Stoichiometry.Models
{
    public static class RecipeGraph
    {
        public static Dictionary<string, RecipeVertex> Create(string input)
        {
            var graph = new Dictionary<string, RecipeVertex>();
            
            var lines = input.Split("\n")
                .Where(w => !string.IsNullOrEmpty(w) && !string.IsNullOrWhiteSpace(w))
                .ToList();

            foreach (var line in lines)
            {
                var split = line.Split(" => ");
                var components = split[0];
                
                var output = split.Last().Split(" ");
                var producedAmount = decimal.Parse(output[0]);
                var outputName = output[1];

                var vertex = graph.TryGetValue(outputName, out var value) ? value : new RecipeVertex();
                vertex.PerProductionAmount = producedAmount;

                foreach (var component in components.Split(", "))
                {
                    var compSplit = component.Split(" ");
                    var compAmount = decimal.Parse(compSplit[0]);
                    var compName = compSplit[1];
                    
                    var compVert = graph.TryGetValue(compName, out var compValue) ? compValue : new RecipeVertex();

                    vertex.Edges[compName] = compAmount;
                    compVert.ReversedEdges[outputName] = compAmount;

                    graph[compName] = compVert;
                }

                graph[outputName] = vertex;
            }

            graph["FUEL"].Required = 1;
            graph["ORE"].PerProductionAmount = 1;
            return graph;
        }

        public static List<string> ReversedTopologicalSort(Dictionary<string, RecipeVertex> graph, string start = "ORE")
        {
            var topologicalOrder = new List<string>();
            var seen = new HashSet<string>();

            void TopSortDfs(RecipeVertex vertex, string name)
            {
                if (!vertex.ReversedEdges.Any())
                {
                    topologicalOrder.Add(name);
                    return;
                }

                foreach (var neighbor in vertex.ReversedEdges.Keys)
                {
                    if (seen.Contains(neighbor))
                    {
                        continue;
                    }

                    seen.Add(neighbor);
                    TopSortDfs(graph[neighbor], neighbor);
                }
                
                topologicalOrder.Add(name);
            }
            
            TopSortDfs(graph[start], start);
            return topologicalOrder;
        }

        public static decimal Part1(string input)
        {
            var graph = Create(input);
            return Part1(graph);
        }

        public static decimal Part1(Dictionary<string, RecipeVertex> graphInput)
        {
            var graph = graphInput.ToDictionary(k => k.Key, v => (RecipeVertex)v.Value.Clone());
            var topologicalOrder = ReversedTopologicalSort(graph);

            foreach (var vertexName in topologicalOrder)
            {
                var vertex = graph[vertexName];
                var requiredIterations = Math.Max(1, Math.Ceiling(vertex.Required / vertex.PerProductionAmount));
                foreach (var (componentName, cost) in vertex.Edges)
                {
                    graph[componentName].Required += requiredIterations * cost;
                }
            }

            var required = graph["ORE"].Required;
            return required;
        }

        public static decimal Part2(string input)
        {
            var graph = Create(input);

            var best = 0M;
            const decimal oreLimit = 1000000000000M;
            var right = 1000000000000M;
            var left = 1M;

            while (left <= right)
            {
                var mid = Math.Floor((left + right) / 2);
                graph["FUEL"].Required = mid;
                var requiredOre = Part1(graph);
                if (requiredOre < oreLimit)
                {
                    best = Math.Max(best, mid);
                    left = mid + 1;
                }
                else if (requiredOre > oreLimit)
                {
                    right = mid - 1;
                }
                else
                {
                    return mid;
                }
                
            }

            return best;
        }
    }
}