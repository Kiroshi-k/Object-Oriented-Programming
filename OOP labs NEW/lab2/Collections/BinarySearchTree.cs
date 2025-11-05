using System.Collections;
using System.Collections.Generic;

namespace Lab32.Collections
{
    // Узагальнене бінарне пошукове дерево (BST)
    // reference-тип + IComparable<T>
    public class BinarySearchTree<T> : IEnumerable<T> where T : class, System.IComparable<T>
    {
        private class Node
        {
            public T Value;
            public Node Left;
            public Node Right;
            public Node(T value) { Value = value; }
        }

        private Node _root;
        public int Count { get; private set; }

        public void Add(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            _root = Insert(_root, item);
            Count++;
        }

        private Node Insert(Node node, T item)
        {
            if (node == null) return new Node(item);
            int cmp = item.CompareTo(node.Value);
            if (cmp < 0) node.Left = Insert(node.Left, item);
            else node.Right = Insert(node.Right, item); 
            return node;
        }

        public bool Contains(T item)
        {
            var cur = _root;
            while (cur != null)
            {
                int cmp = item.CompareTo(cur.Value);
                if (cmp == 0) return true;
                cur = cmp < 0 ? cur.Left : cur.Right;
            }
            return false;
        }

        // Власний ітератор: центральний обхід (inorder): Left -> Node -> Right
        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<Node>();
            var cur = _root;

            while (stack.Count > 0 || cur != null)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.Left;
                }
                cur = stack.Pop();
                yield return cur.Value;      // центральний момент 
                cur = cur.Right;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
