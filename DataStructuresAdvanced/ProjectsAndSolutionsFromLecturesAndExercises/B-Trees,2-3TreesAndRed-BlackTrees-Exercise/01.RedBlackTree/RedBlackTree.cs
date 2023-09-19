namespace _01.RedBlackTree
{
    using System;

	public class RedBlackTree<T>
        where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public bool Color { get; set; }
        }

        public Node root;

        public RedBlackTree()
        {
        }

        private RedBlackTree(Node node)
        {
            this.PreOrderCopy(node);
        }

		public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

		public RedBlackTree<T> Search(T value)
        {
            Node node = this.FindNode(value);

            return new RedBlackTree<T>(node);
        }

		public void Insert(T value)
        {
            this.root = this.Insert(this.root, value);

            this.root.Color = Black;
        }

		public void Delete(T value)
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.Delete(this.root, value);

            if (this.root != null) 
			{
                this.root.Color = Black;
            }
        }

		public void DeleteMin()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMin(this.root);

            if (this.root != null) 
            {
                this.root.Color = Black;
            }
        }

		public void DeleteMax()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);

            if (this.root != null) 
			{
                this.root.Color = Black;
            }
        }

		public int Count()
        {
            return this.Count(this.root);
        }

		public bool Contains(T value)
		{
			Node node = this.FindNode(value);

			return node != null;
		}

		private void PreOrderCopy(Node node)
		{
            if (node is null)
            {
                return;
            }

            this.Insert(node.Value);

            this.PreOrderCopy(node.Left);

            this.PreOrderCopy(node.Right);
		}

		private void EachInOrder(Node node, Action<T> action)
		{
            if (node is null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);

            action(node.Value);

            this.EachInOrder(node.Right, action);
		}

		private Node FindNode(T value)
		{
            Node current = this.root;

            while (current != null)
            {
                if (this.IsLesser(value, current.Value))
                {
                    current = current.Left;
                }
                else if (this.IsLesser(current.Value, value))
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
		}

		private Node Insert(Node node, T value)
		{
            if (node is null)
            {
                return new Node(value);
            }

            if (this.IsLesser(value, node.Value))
            {
                node.Left = this.Insert(node.Left, value);
            }
			else 
			{
                node.Right = this.Insert(node.Right, value);
            }

			if (this.IsRed(node.Right))
            {
                node = this.LeftRotation(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = this.RightRotation(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                this.FlipColors(node);
            }

            return node;
		}

		private int Count(Node node)
		{
            if (node is null)
            {
                return 0;
            }

            return (1 + this.Count(node.Left) + this.Count(node.Right));
		}

		private Node DeleteMin(Node node)
		{
            if (node.Left is null)
            {
                return null;
            }

            if (!this.IsRed(node.Left) && !this.IsRed(node.Left.Left))
            {
				node = this.MoveRedLeft(node);
            }

            node.Left = this.DeleteMin(node.Left);

			return this.FixUp(node);
		}

		private Node DeleteMax(Node node)
		{
			if (this.IsRed(node.Left))
            {
                node = this.RightRotation(node); 
			}

            if (node.Right is null)
            {
                return null;
            }

            if (!this.IsRed(node.Right) && !this.IsRed(node.Right.Left))
            {
				node = this.MoveRedRight(node);
            }

            node.Right = this.DeleteMax(node.Right);

			return this.FixUp(node);
		}

		private Node Delete(Node node, T value)
		{
            if (this.IsLesser(value, node.Value)) 
            {
                if (!this.IsRed(node.Left) && !this.IsRed(node.Left.Left))
                {
					node = this.MoveRedLeft(node);
                }

                node.Left = this.Delete(node.Left, value);
            }
            else 
            {
                if (this.IsRed(node.Left))
                {
                    node = this.RightRotation(node);
                }

                if (this.AreEqual(value, node.Value) && node.Right is null)
                {
                    return null;
                }

                if (!this.IsRed(node.Right) && !this.IsRed(node.Right.Left))
                {
                    node = this.MoveRedRight(node);
                }

                if (this.AreEqual(value, node.Value))
                {
                    node.Value = this.FindMinimalValueInSubtree(node.Right);

                    node.Right = this.DeleteMin(node.Right);
                }
                else
                {
                    node.Right = this.Delete(node.Right, value);
                }
            }

			return this.FixUp(node);
		}

		private T FindMinimalValueInSubtree(Node node)
		{
            if (node.Left is null)
            {
                return node.Value;
            }

            return this.FindMinimalValueInSubtree(node.Left);
		}

		// Rotations

		private Node MoveRedRight(Node node) 
		{
            this.FlipColors(node);

            if (this.IsRed(node.Left.Left))
            {
                node = this.RightRotation(node);

                this.FlipColors(node);
            }

            return node;
        }

        private Node MoveRedLeft(Node node) 
		{
            this.FlipColors(node);

            if (this.IsRed(node.Right.Left))
            {
                node.Right = this.RightRotation(node.Right);

                node = this.LeftRotation(node);

                this.FlipColors(node);
            }

            return node;
        }

        private Node FixUp(Node node)
        {
            if (this.IsRed(node.Right))
            {
                node = this.LeftRotation(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = this.RightRotation(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                this.FlipColors(node);
            }

            return node;
        }

        private Node LeftRotation(Node node)
        {
            Node temp = node.Right; 

			node.Right = temp.Left;

            temp.Left = node;

            temp.Color = temp.Left.Color;

            temp.Left.Color = Red;

            return temp;
        }

        private Node RightRotation(Node node)
        {
            Node temp = node.Left; 

			node.Left = temp.Right;

            temp.Right = node;

            temp.Color = temp.Right.Color;

            temp.Right.Color = Red;

            return temp;
        }

        private void FlipColors(Node node)
        {
            node.Color = !node.Color;

            node.Left.Color = !node.Left.Color;

            node.Right.Color = !node.Right.Color;
        }

        // Helper methods

        private bool IsRed(Node node)
        {
            if (node is null)
            {
                return false;
            }

            return node.Color == Red;
        }

        private bool IsLesser(T first, T second) => first.CompareTo(second) < 0;

        private bool AreEqual(T first, T second) => first.CompareTo(second) == 0;
	}
}