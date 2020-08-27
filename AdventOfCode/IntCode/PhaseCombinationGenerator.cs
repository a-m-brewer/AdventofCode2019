using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.IntCode
{
    public class PhaseCombinationGenerator
    {
        public IEnumerable<IEnumerable<long>> GenerateCombinations(int length, int offset = 0)
        {
            var l = int.Parse(new string('4', length));
            var max = FromBase(l, 5) + 1;
            var res = Enumerable.Range(0, max)
                .Select(ToBase5)
                .Where(w => w.Distinct().Count() == w.Count)
                .Select(s => s.Select(d => d + offset))
                .ToList();
            return res;
        }

        private List<long> ToBase5(int quotient)
        {
            var result = new List<long>();

            while (quotient != 0)
            {
                quotient = Math.DivRem(quotient, 5, out var remainder);
                result.Add(remainder);
            }

            var padAmount = 5 - result.Count;
            result.AddRange(new long[padAmount]);
            
            return result;
        }
        
        public static int FromBase(int value, int baseValue)
        {
            var number = value.ToString();
            var n = 1;
            var r = 0;

            for (var i = number.Length - 1; i >= 0; --i)
            {
                r += n*(number[i] - '0');
                n *= baseValue;
            }

            return r;
        }
    }
}