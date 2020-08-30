namespace AdventOfCode.IntCode.Hardware.Robot.Models
{
    public class OxygenNode
    {
        // droid related
        public long X { get; }
        public long Y { get; }
        public bool Walkable { get; }

        public bool IsVacuum { get; set; }

        // a star related
        public long GCost { get; set; }
        public long HCost { get; set; }
        public long FCost => GCost + HCost;
        public OxygenNode Parent { get; set; }

        public OxygenNode(long x, long y, bool walkable)
        {
            X = x;
            Y = y;
            Walkable = walkable;
            IsVacuum = walkable;
        }
    }
}