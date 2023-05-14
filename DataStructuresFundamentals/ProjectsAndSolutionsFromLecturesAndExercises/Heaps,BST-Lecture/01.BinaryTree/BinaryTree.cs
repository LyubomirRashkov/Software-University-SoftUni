namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
	using System.Text;

	public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            this.AsString(this, sb, indent);

            return sb.ToString().Trim();
        }

		public void ForEachInOrder(Action<T> action)
        {
            IEnumerable<IAbstractBinaryTree<T>> elements = this.InOrder();

            foreach (var element in elements)
            {
                action.Invoke(element.Value);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.InOrder());
            }

            result.Add(this);

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.InOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PostOrder());
            }

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PostOrder());
            }

            result.Add(this);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            result.Add(this);

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PreOrder());
            }

            return result;
        }

		private void AsString(IAbstractBinaryTree<T> node, StringBuilder sb, int indent)
		{
            sb.Append(' ', indent).AppendLine(node.Value.ToString());

            if (node.LeftChild != null)
            {
                this.AsString(node.LeftChild, sb, indent + 2);
            }

            if (node.RightChild != null)
            {
                this.AsString(node.RightChild, sb, indent + 2);
            }
		}
    }
}
