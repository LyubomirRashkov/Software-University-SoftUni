namespace _02.BinarySearchTree
{
	using System;
	using System.Collections.Generic;

	public class BinarySearchTree<T> : IBinarySearchTree<T>
		where T : IComparable
	{
		private class Node
		{
			public Node(T value)
			{
				this.Value = value;
			}

			public T Value { get; set; }

			public Node Left { get; set; }
			
			public Node Right { get; set; }

            public int Count { get; set; }
        }

		private Node root;

		public BinarySearchTree()
		{
		}

		private BinarySearchTree(Node node)
		{
			this.PreOrderCopy(node);
		}

		public void Insert(T element)
		{
			this.root = this.Insert(element, this.root);
		}

		public bool Contains(T element)
		{
			Node current = this.FindElement(element);

			return current != null;
		}

		public void EachInOrder(Action<T> action)
		{
			this.EachInOrder(this.root, action);
		}

		public IBinarySearchTree<T> Search(T element)
		{
			Node current = this.FindElement(element);

			return new BinarySearchTree<T>(current);
		}

		public IEnumerable<T> Range(T startRange, T endRange)
		{
			List<T> result = new List<T>();

			this.GetElementsInRange(startRange, endRange, result, this.root);

			return result;
		}

		public void DeleteMin()
		{
			this.ValidateCollection();

			this.root = this.DeleteMin(this.root);
		}

		public void DeleteMax()
		{
			this.ValidateCollection();

			this.root = this.DeleteMax(this.root);
		}

		public void Delete(T element)
		{
			this.ValidateCollection();

			this.root = this.Delete(this.root, element);
		}

		public int Count() => this.Count(this.root);

		public int Rank(T element)
		{
			return this.Rank(element, this.root);
		}

		public T Select(int rank)
		{
			this.ValidateCollection();

			Node node = this.Select(this.root, rank);

			return node != null ? node.Value : throw new InvalidOperationException();
		}

		public T Ceiling(T element)
		{
			return this.Select(this.Rank(element) + 1);
		}

		public T Floor(T element)
		{
			return this.Select(this.Rank(element) - 1);
		}

		private void GetElementsInRange(T startValue, T endValue, List<T> elements, Node node)
		{
			if (node is null)
			{
				return;
			}

			if (node.Value.CompareTo(startValue) > 0)
			{
				this.GetElementsInRange(startValue, endValue, elements, node.Left);
			}

			if (node.Value.CompareTo(startValue) >= 0 && node.Value.CompareTo(endValue) <= 0)
			{
				elements.Add(node.Value);
			}

			if (node.Value.CompareTo(endValue) < 0)
			{
				this.GetElementsInRange(startValue, endValue, elements, node.Right);
			}
		}

		private Node FindElement(T element)
		{
			Node current = this.root;

			while (current != null)
			{
				if (current.Value.CompareTo(element) > 0)
				{
					current = current.Left;
				}
				else if (current.Value.CompareTo(element) < 0)
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

		private void PreOrderCopy(Node node)
		{
			if (node == null)
			{
				return;
			}

			this.Insert(node.Value);
			this.PreOrderCopy(node.Left);
			this.PreOrderCopy(node.Right);
		}

		private Node Insert(T element, Node node)
		{
			if (node == null)
			{
				node = new Node(element);
			}
			else if (node.Value.CompareTo(element) > 0)
			{
				node.Left = this.Insert(element, node.Left);
			}
			else if (node.Value.CompareTo(element) < 0)
			{
				node.Right = this.Insert(element, node.Right);
			}

			node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

			return node;
		}

		private void EachInOrder(Node node, Action<T> action)
		{
			if (node == null)
			{
				return;
			}

			this.EachInOrder(node.Left, action);
			action(node.Value);
			this.EachInOrder(node.Right, action);
		}

		private Node DeleteMin(Node node)
		{
			if (node.Left is null)
			{
				return node.Right;
			}

			node.Left = this.DeleteMin(node.Left);

			node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

			return node;
		}

		private void ValidateCollection()
		{
			if (this.root is null)
			{
				throw new InvalidOperationException();
			}
		}

		private Node DeleteMax(Node node)
		{
			if (node.Right is null)
			{
				return node.Left;
			}

			node.Right = this.DeleteMax(node.Right);

			node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

			return node;
		}

		private Node Delete(Node node, T element)
		{
			if (node.Value.CompareTo(element) > 0)
			{
				node.Left = this.Delete(node.Left, element);
			}
			else if (node.Value.CompareTo(element) < 0)
			{
				node.Right = this.Delete(node.Right, element);
			}
			else
			{
				if (node.Left is null && node.Right is null)
				{
					node = null;
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
					Node rightMin = node.Right;

					while (rightMin.Left != null)
					{
						rightMin = rightMin.Left;
					}

					node.Value = rightMin.Value;

					node.Right = this.DeleteMin(node.Right);
				}

				//if (node.Left is null && node.Right is null)
				//{
				//	node = null;
				//}
				//else
				//{
				//	if (node.Right is null)
				//	{
				//		node = node.Left;
				//	}
				//	else
				//	{
				//		Node rightMin = node.Right;

				//		while (rightMin.Left != null)
				//		{
				//			rightMin = rightMin.Left;
				//		}

				//		node.Value = rightMin.Value;

				//		node.Right = this.DeleteMin(node.Right);
				//	}
				//}
			}

			return node;
		}

		private int Count(Node node)
		{
			if (node is null)
			{
				return 0;
			}

			return node.Count;
		}

		private int Rank(T element, Node node)
		{
			if (node is null)
			{
				return 0;
			}

			if (node.Value.CompareTo(element) > 0)
			{
				return this.Rank(element, node.Left);
			}
			else if (node.Value.CompareTo(element) < 0)
			{
				return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
			}

			return this.Count(node.Left);
		}

		private Node Select(Node node, int rank)
		{
			if (node is null)
			{
				return null;
			}

			int countOfLeftElements = this.Count(node.Left);

			if (countOfLeftElements == rank)
			{
				return node;
			}
			else if (countOfLeftElements > rank)
			{
				return this.Select(node.Left, rank);
			}
			else
			{
				return this.Select(node.Right, rank - countOfLeftElements - 1);
			}
		}
	}
}
