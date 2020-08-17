namespace AdventOfCode.Password.Rules
{
    public interface IPasswordRule
    {
        bool Valid(int pass);
    }
}