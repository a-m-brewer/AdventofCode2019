using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Password.Rules
{
    public class TwoSameNumberRuleExact : IPasswordRule
    {
        public bool Valid(int pass)
        {
            var d = new Dictionary<char, int>();
            
            var passString = pass.ToString().ToList();
            for (var i = 1; i < passString.Count; i++)
            {
                if (passString[i - 1] == passString[i])
                {
                    var c = passString[i];
                    var containsChar = d.ContainsKey(c);

                    if (containsChar)
                    {
                        d[c] = d[c] + 1;
                    }
                    else
                    {
                        d[c] = 2;
                    }
                }
            }

            return d.Any(a => a.Value == 2);
        }
    }
}