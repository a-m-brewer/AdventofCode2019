using System;

namespace AdventOfCode.ClosestPort.Models
{
    public class Node : IEquatable<Node>
    {
        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; }
        public int Y { get; }
        public int Step { get; set; }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }

        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}