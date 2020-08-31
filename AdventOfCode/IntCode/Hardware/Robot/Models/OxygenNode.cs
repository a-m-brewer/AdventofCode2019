using AdventOfCode.IntCode.Hardware.Arcade.Models;

namespace AdventOfCode.IntCode.Hardware.Robot.Models
{
    public class OxygenNode : IPixel
    {
        // droid related
        public long X { get; }
        public long Y { get; }
        public bool Walkable { get; }
        public string Value { get; set; }

        public bool IsVacuum { get; set; }

        // a star related
        public long GCost { get; set; }
        public long HCost { get; set; }
        public long FCost => GCost + HCost;
        public OxygenNode Parent { get; set; }

        public OxygenNode(long x, long y, string value)
        {
            X = x;
            Y = y;
            Walkable = value != "#";
            IsVacuum = Walkable;
            Value = value;
        }
    }
}