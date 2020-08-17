using System;
using System.Linq;

namespace AdventOfCode.Password.Rules
{
    public class NeverLessThanPreviousRule : IPasswordRule
    {
        public bool Valid(int pass)
        {
            var passList = pass.ToString().ToList()
                .Select(s =>
                    int.TryParse(s.ToString(), out var i) ? i : throw new Exception("how?"))
                .ToList();
            
            for (var i = 1; i < passList.Count; i++)
            {
                if (passList[i] < passList[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}