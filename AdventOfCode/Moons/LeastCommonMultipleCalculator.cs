using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Moons
{
    // ReSharper disable once InconsistentNaming
    public static class LeastCommonMultipleCalculator
    {
        public static long LCM(this IEnumerable<long> list)
        {
            var internalCopy = list.ToList();
            
            if (internalCopy.Count < 2)
            {
                throw new ArgumentException("list must contain 2+ elements");
            }

            var a = internalCopy[0];
            var b = internalCopy[1];
            var lcm = LCM(a, b);

            for (var i = 1; i < internalCopy.Count; i++)
            {
                lcm = LCM(lcm, internalCopy[i]);
            }

            return lcm;
        }
        
        public static long LCM(long a, long b)
        {
            var aLarger = a > b;
            var num = aLarger ? a : b;
            var den = aLarger ? b : a;
            var rem = num % den;

            while (rem != 0)
            {
                num = den;
                den = rem;
                rem = num % den;
            }

            var gcd = den;

            var lcm = a * b / gcd;

            return lcm;
        }
    }
}