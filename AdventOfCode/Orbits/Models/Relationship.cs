namespace AdventOfCode.Orbits.Models
{
    public class Relationship<T>
    {
        public T Parent { get; }
        public T Child { get; }

        public Relationship(T parent, T child)
        {
            Parent = parent;
            Child = child;
        }
    }
}