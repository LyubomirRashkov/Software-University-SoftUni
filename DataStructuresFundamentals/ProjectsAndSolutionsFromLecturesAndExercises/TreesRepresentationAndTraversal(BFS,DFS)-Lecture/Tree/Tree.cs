namespace Tree
{
	using System;
	using System.Collections.Generic;

	public class Tree<T> : IAbstractTree<T>
	{
		private readonly T value;
		private Tree<T> parent;
		private List<Tree<T>> children;

		public Tree(T value)
		{
			this.value = value;
			this.children = new List<Tree<T>>();
		}

		public Tree(T value, params Tree<T>[] children)
			: this(value)
		{
			foreach (var child in children)
			{
				this.children.Add(child);
				child.parent = this;
			}
		}

		public void AddChild(T parentKey, Tree<T> child)
		{
			//List<Tree<T>> result = new List<Tree<T>>();

			//Tree<T> node = this.FindNodeWithDfs(result, this, parentKey) ?? throw new ArgumentNullException();

			Tree<T> node = this.FindNodeWithBfs(parentKey) ?? throw new ArgumentNullException();

			node.children.Add(child);
			child.parent = node;
		}

		public void RemoveNode(T nodeKey)
		{
			//List<Tree<T>> result = new List<Tree<T>>();

			//Tree<T> node = this.FindNodeWithDfs(result, this, nodeKey) ?? throw new ArgumentNullException();

			Tree<T> node = this.FindNodeWithBfs(nodeKey) ?? throw new ArgumentNullException();

			Tree<T> nodeParent = node.parent ?? throw new ArgumentException();

			nodeParent.children.Remove(node);
		}

		public void Swap(T firstKey, T secondKey)
		{
			//List<Tree<T>> firstResult = new List<Tree<T>>();

			//Tree<T> firstNode = this.FindNodeWithDfs(firstResult, this, firstKey) ?? throw new ArgumentNullException();

			//List<Tree<T>> secondResult = new List<Tree<T>>();

			//Tree<T> secondNode = this.FindNodeWithDfs(secondResult, this, secondKey) ?? throw new ArgumentNullException();

			Tree<T> firstNode = this.FindNodeWithBfs(firstKey) ?? throw new ArgumentNullException();

			Tree<T> secondNode = this.FindNodeWithBfs(secondKey) ?? throw new ArgumentNullException();

			Tree<T> firstParent = firstNode.parent ?? throw new ArgumentException();

			Tree<T> secondParent = secondNode.parent ?? throw new ArgumentException();

			int firstNodeIndex = firstParent.children.IndexOf(firstNode);

			int secondNodeIndex = secondParent.children.IndexOf(secondNode);

			firstParent.children[firstNodeIndex] = secondNode;
			secondNode.parent = firstParent;

			secondParent.children[secondNodeIndex] = firstNode;
			firstNode.parent = secondNode;
		}

		public IEnumerable<T> OrderBfs()
		{
			List<T> result = new List<T>();

			Queue<Tree<T>> queue = new Queue<Tree<T>>();

			queue.Enqueue(this);

			while (queue.Count > 0)
			{
				Tree<T> currentNode = queue.Dequeue();

				result.Add(currentNode.value);

				foreach (var child in currentNode.children)
				{
					queue.Enqueue(child);
				}
			}

			return result;
		}

		public IEnumerable<T> OrderDfs()
		{
			List<T> result = new List<T>();

			this.Dfs(this, result);

			return result;
		}

		private void Dfs(Tree<T> currentNode, List<T> result)
		{
			foreach (var child in currentNode.children)
			{
				this.Dfs(child, result);
			}

			result.Add(currentNode.value);
		}

		private Tree<T> FindNodeWithBfs(T targetValue)
		{
			Queue<Tree<T>> queue = new Queue<Tree<T>>();

			queue.Enqueue(this);

			while (queue.Count > 0)
			{
				Tree<T> current = queue.Dequeue();

				if (current.value.Equals(targetValue))
				{
					return current;
				}

				foreach (var child in current.children)
				{
					queue.Enqueue(child);
				}
			}

			return null;
		}

		private Tree<T> FindNodeWithDfs(List<Tree<T>> result, Tree<T> currentTree, T targetValue)
		{
			this.DfsForNodes(result, currentTree, targetValue);

			return (result.Count > 0 ? result[0] : null);
		}

		private void DfsForNodes(List<Tree<T>> result, Tree<T> currentTree, T targetValue)
		{
			if (currentTree.value.Equals(targetValue))
			{
				result.Add(currentTree);
			}

			foreach (var child in currentTree.children)
			{
				this.DfsForNodes(result, child, targetValue);
			}
		}
	}
}
