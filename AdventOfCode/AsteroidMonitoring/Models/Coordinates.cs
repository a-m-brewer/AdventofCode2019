namespace AdventOfCode.AsteroidMonitoring.Models
{
    public class Coordinates
    {
        public int X { get; }
        public int Y { get; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Deconstruct(out int x1, out int y1)
        {
            x1 = X;
            y1 = Y;
        }
    }
}