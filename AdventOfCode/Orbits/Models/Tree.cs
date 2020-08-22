using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Orbits.Models
{
    public class Tree<T>
    {
        private readonly List<Relationship<T>> _relationships;
        private readonly List<TreeNode<T>> _nodes = new List<TreeNode<T>>();
        
        public Tree(TreeNode<T> root, List<Relationship<T>> relationships)
        {
            _relationships = relationships;
            Root = root;
            Init(Root);
        }

        public TreeNode<T> Root { get; }

        public int CountNodes()
        {
            return _nodes.Sum(n => n.CountNodes());
        }

        public int DistanceBetweenNodes(T from, T to)
        {
            var lastCommonTree = _nodes.Last(node => node.HasChild(to) && node.HasChild(from));
            var length = lastCommonTree.ShortestPath(to) + lastCommonTree.ShortestPath(from) - 2;
            return length;
        }

        private void Init(TreeNode<T> root)
        {
            _nodes.Add(root);
            
            _relationships.Where(orbits => orbits.Parent.Equals(root.Value)).ToList().ForEach(orbit =>
            {
                var childValue = orbit.Child;
                var child = new TreeNode<T>(childValue);
                root.Add(child);
                Init(child);
            });
        }
    }
}