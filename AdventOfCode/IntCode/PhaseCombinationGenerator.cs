using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.IntCode
{
    public class PhaseCombinationGenerator
    {
        public IEnumerable<IEnumerable<int>> GenerateCombinations(int length)
        {
            var l = int.Parse(new string('4', length));
            var max = FromBase(l, 5) + 1;
            var res = Enumerable.Range(0, max).Select(ToBase5).ToList();
            return res;
        }

        private List<int> ToBase5(int quotient)
        {
            var result = new List<int>();

            while (quotient != 0)
            {
                quotient = Math.DivRem(quotient, 5, out var remainder);
                result.Add(remainder);
            }

            var padAmount = 5 - result.Count;
            result.AddRange(new int[padAmount]);
            
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