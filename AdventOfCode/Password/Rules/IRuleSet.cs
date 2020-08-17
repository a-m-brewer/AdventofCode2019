namespace AdventOfCode.Password.Rules
{
    public interface IRuleSet
    {
        bool Valid(int pass);
    }
}