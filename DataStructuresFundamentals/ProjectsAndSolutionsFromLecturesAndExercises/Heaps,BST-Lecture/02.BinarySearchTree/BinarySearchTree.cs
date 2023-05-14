namespace _02.BinarySearchTree
{
	using System;
	using System.Collections.Generic;

	public class BinarySearchTree<T> : IBinarySearchTree<T>
		where T : IComparable<T>
	{
		private class Node
		{
			public Node(T value)
			{
				this.Value = value;
			}

			public T Value { get; private set; }

			public Node LeftChild { get; set; }

			public Node RightChild { get; set; }
		}

		private Node root;

		public BinarySearchTree()
		{
		}

		private BinarySearchTree(Node node)
		{
			this.PreOrderCopy(node);
		}

		public bool Contains(T value)
		{
			return this.FindNode(value) != null;
		}

		public void EachInOrder(Action<T> action)
		{
			IEnumerable<Node> nodes = this.InOrder(this.root);

			foreach (var node in nodes)
			{
				action.Invoke(node.Value);
			}
		}

		public void Insert(T value)
		{
			//this.root = this.Insert(value, this.root);

			Node newNode = new Node(value);

			Node currentNode = this.root;

			if (currentNode is null)
			{
				this.root = newNode;

				return;
			}

			while (true)
			{
				if (currentNode.Value.Equals(value))
				{
					break;
				}

				if (currentNode.Value.CompareTo(value) > 0)
				{
					if (currentNode.LeftChild is null)
					{
						currentNode.LeftChild = newNode;

						break;
					}
					else
					{
						currentNode = currentNode.LeftChild;
					}
				}
				else if (currentNode.Value.CompareTo(value) < 0)
				{
					if (currentNode.RightChild is null)
					{
						currentNode.RightChild = newNode;

						break;
					}
					else
					{
						currentNode = currentNode.RightChild;
					}
				}
			}
		}

		public IBinarySearchTree<T> Search(T value)
		{
			Node node = this.FindNode(value);

			if (node is null)
			{
				return null;
			}

			IBinarySearchTree<T> tree = new BinarySearchTree<T>(node);

			return tree;
		}

		private void PreOrderCopy(Node node)
		{
			if (node is null)
			{
				return;
			}

			this.Insert(node.Value);
			this.PreOrderCopy(node.LeftChild);
			this.PreOrderCopy(node.RightChild);
		}

		private Node FindNode(T value)
		{
			Node node = this.root;

			while (true)
			{
				if (node is null || node.Value.Equals(value))
				{
					break;
				}

				if (node.Value.CompareTo(value) > 0)
				{
					node = node.LeftChild;
				}
				else if (node.Value.CompareTo(value) < 0)
				{
					node = node.RightChild;
				}
			}

			return node;
		}

		private IEnumerable<Node> InOrder(Node node)
		{
			List<Node> nodes = new List<Node>();

			if (node.LeftChild != null)
			{
				nodes.AddRange(this.InOrder(node.LeftChild));
			}

			nodes.Add(node);

			if (node.RightChild != null)
			{
				nodes.AddRange(this.InOrder(node.RightChild));
			}

			return nodes;
		}

		private Node Insert(T value, Node node)
		{
			if (node is null)
			{
				node = new Node(value);
			}

			if (node.Value.CompareTo(value) > 0)
			{
				node.LeftChild = this.Insert(value, node.LeftChild);
			}
			else if (node.Value.CompareTo(value) < 0)
			{
				node.RightChild = this.Insert(value, node.RightChild);
			}

			return node;
		}
	}
}
