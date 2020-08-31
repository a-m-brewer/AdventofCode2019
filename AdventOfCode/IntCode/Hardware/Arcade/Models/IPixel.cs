namespace AdventOfCode.IntCode.Hardware.Arcade.Models
{
    public interface IPixel
    {
        string Value { get; }
        long X { get; }
        long Y { get; }
    }
}