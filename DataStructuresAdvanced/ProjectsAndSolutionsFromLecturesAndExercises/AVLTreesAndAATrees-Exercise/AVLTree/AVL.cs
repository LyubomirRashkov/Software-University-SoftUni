namespace AVLTree
{
	using System;

	public class AVL<T>
		where T : IComparable<T>
	{
		public class Node
		{
			public Node(T value)
			{
				this.Value = value;
				this.Height = 1;
			}

			public T Value { get; set; }

			public Node Left { get; set; }

			public Node Right { get; set; }

			public int Height { get; set; }
		}

		public Node Root { get; private set; }

		public bool Contains(T element)
		{
			Node node = this.FindNodeByValue(this.Root, element);

			return node != null;
		}

		public void Delete(T element)
		{
			if (this.Root is null)
			{
				return;
			}

			this.Root = this.Delete(this.Root, element);
		}

		public void DeleteMin()
		{
			if (this.Root is null)
			{
				return;
			}

			Node nodeToDelete = this.FindNodeWithTheSamllestValue(this.Root);

			this.Delete(nodeToDelete.Value);
		}

		public void Insert(T element)
		{
			this.Root = this.Insert(this.Root, element);
		}

		public void EachInOrder(Action<T> action)
		{
			this.EachInOrder(this.Root, action);
		}

		private Node FindNodeByValue(Node node, T value)
		{
			if (node is null)
			{
				return null;
			}

			if (value.CompareTo(node.Value) < 0)
			{
				return this.FindNodeByValue(node.Left, value);
			}
			else if (value.CompareTo(node.Value) > 0)
			{
				return this.FindNodeByValue(node.Right, value);
			}
			else
			{
				return node;
			}
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

		private Node Delete(Node node, T element)
		{
			if (node is null)
			{
				return null;
			}

			int comparisonValue = element.CompareTo(node.Value);

			if (comparisonValue < 0)
			{
				node.Left = this.Delete(node.Left, element);
			}
			else if (comparisonValue > 0)
			{
				node.Right = this.Delete(node.Right, element);
			}
			else
			{
				if (node.Left is null && node.Right is null)
				{
					return null;
				}
				else if (node.Left is null)
				{
					node = node.Right;
				}
				else if (node.Right is null)
				{
					node = node.Left;
				}
				else
				{
					Node minChild = this.FindNodeWithTheSamllestValue(node.Right);

					node.Value = minChild.Value;

					node.Right = this.Delete(node.Right, minChild.Value);
				}
			}

			node = this.Balance(node);

			node.Height = this.CalculateHeight(node);

			return node;
		}

		private Node Insert(Node node, T element)
		{
			if (node is null)
			{
				return new Node(element);
			}

			if (element.CompareTo(node.Value) < 0)
			{
				node.Left = this.Insert(node.Left, element);
			}
			else
			{
				node.Right = this.Insert(node.Right, element);
			}

			node = this.Balance(node);

			node.Height = this.CalculateHeight(node);

			return node;
		}

		// Helper methods:

		private Node FindNodeWithTheSamllestValue(Node node)
		{
			//if (node.Left is null)
			//{
			//	return node;
			//}

			//return this.FindNodeWithTheSamllestValue(node.Left);

			while (node.Left != null)
			{
				node = node.Left;
			}

			return node;
		}

		private Node Balance(Node node)
		{
			int balanceFactor = this.GetHeight(node.Left) - this.GetHeight(node.Right);

			if (balanceFactor > 1)
			{
				int leftChildBalanceFactor = this.GetHeight(node.Left.Left) - this.GetHeight(node.Left.Right);

				if (leftChildBalanceFactor < 0)
				{
					node.Left = this.RotateLeft(node.Left);
				}

				node = this.RotateRight(node);
			}
			else if (balanceFactor < -1)
			{
				int rightChildBalanceFactor = this.GetHeight(node.Right.Left) - this.GetHeight(node.Right.Right);

				if (rightChildBalanceFactor > 0)
				{
					node.Right = this.RotateRight(node.Right);
				}

				node = this.RotateLeft(node);
			}

			return node;
		}

		private int GetHeight(Node node) => node != null ? node.Height : 0;

		private Node RotateLeft(Node node)
		{
			Node temp = node.Right;

			node.Right = temp.Left;

			temp.Left = node;

			node.Height = this.CalculateHeight(node);

			return temp;
		}

		private Node RotateRight(Node node)
		{
			Node temp = node.Left;

			node.Left = temp.Right;

			temp.Right = node;

			node.Height = this.CalculateHeight(node);

			return temp;
		}

		private int CalculateHeight(Node node) => Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;
	}
}
