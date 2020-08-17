namespace AdventOfCode.Password.Rules
{
    public class PasswordLengthRule : IPasswordRule
    {
        public bool Valid(int pass)
        {
            return pass.ToString().Length == 6;
        }
    }
}