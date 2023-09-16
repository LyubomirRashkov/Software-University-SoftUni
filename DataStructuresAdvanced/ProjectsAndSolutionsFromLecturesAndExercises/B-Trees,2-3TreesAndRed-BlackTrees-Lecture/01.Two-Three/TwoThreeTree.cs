namespace _01.Two_Three
{
	using System;
	using System.Text;

	public class TwoThreeTree<T>
		where T : IComparable<T>
	{
		private TreeNode<T> root;

		public void Insert(T element)
		{
			if (this.root is null)
			{
				this.root = new TreeNode<T>(element);
			}
			else
			{
				this.root = this.Insert(this.root, element);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			RecursivePrint(this.root, sb);
			return sb.ToString();
		}

		private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
		{
			if (node == null)
			{
				return;
			}

			if (node.LeftKey != null)
			{
				sb.Append(node.LeftKey).Append(" ");
			}

			if (node.RightKey != null)
			{
				sb.Append(node.RightKey).Append(Environment.NewLine);
			}
			else
			{
				sb.Append(Environment.NewLine);
			}

			if (node.IsTwoNode())
			{
				RecursivePrint(node.LeftChild, sb);
				RecursivePrint(node.MiddleChild, sb);
			}
			else if (node.IsThreeNode())
			{
				RecursivePrint(node.LeftChild, sb);
				RecursivePrint(node.MiddleChild, sb);
				RecursivePrint(node.RightChild, sb);
			}
		}

		private TreeNode<T> Insert(TreeNode<T> node, T element)
		{
			if (node.IsLeaf())
			{
				TreeNode<T> newNode = new TreeNode<T>(element);

				return this.MergeNodes(node, newNode);
			}

			if (element.CompareTo(node.LeftKey) < 0)
			{
				TreeNode<T> newNode = this.Insert(node.LeftChild, element);

				return newNode == node.LeftChild ? node : this.MergeNodes(node, newNode);
			}
			else if (node.IsTwoNode() || element.CompareTo(node.RightKey) < 0)
			{
				TreeNode<T> newNode = this.Insert(node.MiddleChild, element);

				return newNode == node.MiddleChild ? node : this.MergeNodes(node, newNode);
			}
			else
			{
				TreeNode<T> newNode = this.Insert(node.RightChild, element);

				return newNode == node.RightChild ? node : this.MergeNodes(node, newNode);
			}
		}

		private TreeNode<T> MergeNodes(TreeNode<T> currentNode, TreeNode<T> newNode)
		{
			if (currentNode.IsTwoNode())
			{
				if (currentNode.LeftKey.CompareTo(newNode.LeftKey) < 0)
				{
					currentNode.RightKey = newNode.LeftKey;

					currentNode.MiddleChild = newNode.LeftChild;

					currentNode.RightChild = newNode.MiddleChild;
				}
				else
				{
					currentNode.RightKey = currentNode.LeftKey;

					currentNode.RightChild = currentNode.MiddleChild;

					currentNode.MiddleChild = newNode.MiddleChild;

					currentNode.LeftChild = newNode.LeftChild;

					currentNode.LeftKey = newNode.LeftKey;
				}

				return currentNode;
			}
			else if (newNode.LeftKey.CompareTo(currentNode.LeftKey) < 0)
			{
				TreeNode<T> node = new TreeNode<T>(currentNode.LeftKey)
				{
					LeftChild = newNode,
					MiddleChild = currentNode,
				};

				currentNode.LeftChild = currentNode.MiddleChild;

				currentNode.MiddleChild = currentNode.RightChild;

				currentNode.LeftKey = currentNode.RightKey;

				currentNode.RightKey = default;

				currentNode.RightChild = default;

				return node;
			}
			else if (newNode.LeftKey.CompareTo(currentNode.RightKey) < 0)
			{
				newNode.MiddleChild = new TreeNode<T>(currentNode.RightKey)
				{
					LeftChild = newNode.MiddleChild,
					MiddleChild = currentNode.RightChild,
				};

				newNode.LeftChild = currentNode;

				currentNode.RightKey = default;

				currentNode.RightChild = default;

				return newNode;
			}
			else
			{
				TreeNode<T> node = new TreeNode<T>(currentNode.RightKey)
				{
					LeftChild = currentNode,
					MiddleChild = newNode,
				};

				newNode.LeftChild = currentNode.RightChild;

				currentNode.RightKey = default;

				currentNode.RightChild = default;

				return node;
			}
		}
	}
}
