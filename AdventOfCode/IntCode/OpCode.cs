namespace AdventOfCode.IntCode
{
    public enum OpCode
    {
        Add = 1,
        Multiply = 2,
        Save = 3,
        Output = 4,
        JmpT = 5,
        JmpF = 6,
        LessThan = 7,
        Eql = 8,
        Halt = 99
    }
}