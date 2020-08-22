using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Orbits.Models
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
        }
        
        public T Value { get; }
        public List<TreeNode<T>> Children { get; } = new List<TreeNode<T>>();
        public bool HasParent { get; set; }

        public bool HasChild(T child)
        {
            return Children.Any(a => a.Value.Equals(child)) || Children.Any(a => a.HasChild(child));
        }

        public void Add(TreeNode<T> child)
        {
            child.HasParent = true;
            Children.Add(child);
        }

        public int ShortestPath(T value)
        {
            if (!HasChild(value)) return 0;
            
            if (Children.Any(child => child.Value.Equals(value)))
            {
                return 1;
            }

            return 1 + Children.Sum(child => child.ShortestPath(value));
        }
        
        public int CountNodes()
        {
            var total = 0;
            
            int CountNodes(TreeNode<T> root)
            {
                var rootCount = root.Children.Count;
                total += rootCount;
                return rootCount + root.Children.Sum(CountNodes);
            }
            
            CountNodes(this);
            return total;
        }
    }
}