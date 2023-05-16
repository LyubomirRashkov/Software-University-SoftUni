namespace _02.LowestCommonAncestor
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;

            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; private set; }

        public BinaryTree<T> LeftChild { get; private set; }

        public BinaryTree<T> RightChild { get; private set; }

        public BinaryTree<T> Parent { get; private set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = this.GetNodeWithBfs(first);

            BinaryTree<T> secondNode = this.GetNodeWithBfs(second);

            if (firstNode is null || secondNode is null)
            {
                throw new InvalidOperationException();
            }

            IEnumerable<T> firstNodeAncestorsValues = this.GetNodeAncestorsValues(firstNode);

            IEnumerable<T> secondNodeAncestorsValues = this.GetNodeAncestorsValues(secondNode);

            IEnumerable<T> commonAncestorsValues = firstNodeAncestorsValues.Intersect(secondNodeAncestorsValues);

            return commonAncestorsValues.FirstOrDefault();
        }

		private BinaryTree<T> GetNodeWithBfs(T value)
		{
            BinaryTree<T> node = null;

            Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                BinaryTree<T> current = queue.Dequeue();

                if (current.Value.Equals(value))
                {
                    node = current;

                    break;
                }

                if (current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }

            return node;
		}

		private IEnumerable<T> GetNodeAncestorsValues(BinaryTree<T> node)
		{
            List<T> result = new List<T>();

            while (node != null)
            {
                result.Add(node.Value);

                node = node.Parent;
            }

            return result;
		}
	}
}
