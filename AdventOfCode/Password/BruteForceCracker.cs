using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Password.Rules;

namespace AdventOfCode.Password
{
    public class BruteForceCracker
    {
        private readonly IRuleSet _ruleSet;

        public BruteForceCracker(IRuleSet ruleSet)
        {
            _ruleSet = ruleSet;
        }

        public IEnumerable<int> GetPossibilities(int start, int end)
        {
            return Enumerable.Range(start, end)
                .Where(pass => _ruleSet.Valid(pass));
        }
    }
}