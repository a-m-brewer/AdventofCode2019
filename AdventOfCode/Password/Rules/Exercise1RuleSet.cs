using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Password.Rules
{
    public class Exercise1RuleSet : IRuleSet
    {
        private readonly List<IPasswordRule> _rules;

        public Exercise1RuleSet()
        {
            _rules = new List<IPasswordRule>
            {
                new BetweenPuzzleInputRule(),
                new NeverLessThanPreviousRule(),
                new PasswordLengthRule(),
                new TwoOrMoreSameNumberRule()
            };
        }
        
        public bool Valid(int pass)
        {
            return _rules
                .Select(rule => rule.Valid(pass))
                .All(a => a);
        }
    }
}