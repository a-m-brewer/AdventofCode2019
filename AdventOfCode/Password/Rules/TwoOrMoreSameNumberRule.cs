using System.Linq;

namespace AdventOfCode.Password.Rules
{
    public class TwoOrMoreSameNumberRule : IPasswordRule
    {
        public bool Valid(int pass)
        {
            var passString = pass.ToString().ToList();
            for (var i = 1; i < passString.Count; i++)
            {
                if (passString[i - 1] == passString[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}