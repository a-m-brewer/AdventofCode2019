namespace AdventOfCode.IntCode.Hardware.Arcade.Models
{
    public class Pixel : IPixel
    {
        public string Value { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
    }
}