namespace Tree
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Tree<T> : IAbstractTree<T>
	{
		private readonly List<Tree<T>> children;

		public Tree(T key, params Tree<T>[] children)
		{
			this.Key = key;
			this.children = new List<Tree<T>>();

			foreach (var child in children)
			{
				child.Parent = this;
				this.children.Add(child);
			}
		}

		public T Key { get; private set; }

		public Tree<T> Parent { get; private set; }

		public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

		public void AddChild(Tree<T> child)
		{
			this.children.Add(child);
		}

		public void AddParent(Tree<T> parent)
		{
			this.Parent = parent;
		}

		public string AsString()
		{
			StringBuilder sb = new StringBuilder();

			int initialIndent = 0;

			this.DfsAsString(this, sb, initialIndent);

			return sb.ToString().Trim();
		}

		public IEnumerable<T> GetLeafKeys()
		{
			//IEnumerable<Tree<T>> allNodes = this.GetAllNodesWithBfs(this);

			IEnumerable<Tree<T>> allNodes = this.GetAllNodesWithDfs();

			IEnumerable<T> leafValues = allNodes
				.Where(n => n.children.Count == 0)
				.Select(n => n.Key)
				.ToList();

			return leafValues;
		}

		public IEnumerable<T> GetInternalKeys()
		{
			IEnumerable<Tree<T>> allNodes = this.GetAllNodesWithBfs(this);

			//IEnumerable<Tree<T>> allNodes = this.GetAllNodesWithDfs();

			IEnumerable<T> internalNodesValues = allNodes
				.Where(n => n.children.Count > 0 && n.Parent != null)
				.Select(n => n.Key)
				.ToList();

			return internalNodesValues;
		}

		public T GetDeepestKey()
		{
			Tree<T> deepestLeftmostNode = this.GetDeepestLeftmostNode();

			return deepestLeftmostNode.Key;
		}

		public IEnumerable<T> GetLongestPath()
		{
			Tree<T> node = this.GetDeepestLeftmostNode();

			Stack<T> path = new Stack<T>();

			while (node != null)
			{
				path.Push(node.Key);

				node = node.Parent;
			}

			return path;
		}

		protected IEnumerable<Tree<T>> GetAllNodesWithBfs(Tree<T> currentNode)
		{
			List<Tree<T>> result = new List<Tree<T>>();

			Queue<Tree<T>> queue = new Queue<Tree<T>>();

			queue.Enqueue(currentNode);

			while (queue.Count > 0)
			{
				Tree<T> current = queue.Dequeue();

				result.Add(current);

				foreach (var child in current.children)
				{
					queue.Enqueue(child);
				}
			}

			return result;
		}

		protected IEnumerable<Tree<T>> GetAllNodesWithDfs()
		{
			List<Tree<T>> allNodes = new List<Tree<T>>();

			this.GetNodesWithDfs(this, allNodes);

			return allNodes;
		}

		private void DfsAsString(Tree<T> tree, StringBuilder sb, int indent)
		{
			T treeValue = tree.Key;

			sb.Append(' ', indent).AppendLine(treeValue.ToString());

			foreach (var child in tree.children)
			{
				this.DfsAsString(child, sb, indent + 2);
			}
		}

		private void GetNodesWithDfs(Tree<T> currentTree, List<Tree<T>> allNodes)
		{
			allNodes.Add(currentTree);

			foreach (var child in currentTree.children)
			{
				this.GetNodesWithDfs(child, allNodes);
			}
		}

		private Tree<T> GetDeepestLeftmostNode()
		{
			IEnumerable<Tree<T>> allNodes = this.GetAllNodesWithBfs(this);

			//IEnumerable<Tree<T>> allNodes = this.GetAllNodesWithDfs();

			IEnumerable<Tree<T>> leafNodes = allNodes
				.Where(n => n.children.Count == 0)
				.ToList();

			Tree<T> deepestNode = null;

			int maxDepth = 0;

			foreach (var leaf in leafNodes)
			{
				Tree<T> node = leaf;

				int nodeDepth = 0;

				while (node.Parent != null)
				{
					nodeDepth++;

					node = node.Parent;
				}

				if (nodeDepth > maxDepth)
				{
					maxDepth = nodeDepth;
					deepestNode = leaf;
				}
			}

			return deepestNode;
		}
	}
}
