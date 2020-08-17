namespace AdventOfCode.Password.Rules
{
    public class BetweenPuzzleInputRule : IPasswordRule
    {
        public bool Valid(int pass)
        {
            return 353096 < pass && pass < 843212;
        }
    }
}