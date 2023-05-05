namespace Tree
{
	using System.Collections.Generic;
	using System.Linq;

	public class IntegerTree : Tree<int>, IIntegerTree
	{
		public IntegerTree(int key, params Tree<int>[] children)
			: base(key, children)
		{
		}

		public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
		{
			List<Stack<int>> result = new List<Stack<int>>();

			IEnumerable<IntegerTree> allNodes = this.GetAllNodesWithBfs(this).Select(n => n as IntegerTree).ToList();

			//IEnumerable<IntegerTree> allNodes = this.GetAllNodesWithDfs().Select(n => n as IntegerTree).ToList();

			IEnumerable<IntegerTree> leafNodes = allNodes
				.Where(n => n.Children.Count == 0)
				.ToList();

			foreach (var leafNode in leafNodes)
			{
				IntegerTree currentNode = leafNode;

				Stack<int> currentStack = new Stack<int>();

				int currentSum = 0;

				while (currentNode != null)
				{
					currentSum += currentNode.Key;

					if (currentSum > sum)
					{
						break;
					}

					currentStack.Push(currentNode.Key);

					currentNode = currentNode.Parent as IntegerTree;
				}

				if (currentSum == sum)
				{
					result.Add(currentStack);
				}
			}

			return result;
		}

		public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
		{
			List<Tree<int>> result = new List<Tree<int>>();

			IEnumerable<IntegerTree> allNodes = this.GetAllNodesWithBfs(this).Select(n => n as IntegerTree).ToList();

			//IEnumerable<IntegerTree> allNodes = this.GetAllNodesWithDfs().Select(n => n as IntegerTree).ToList();

			foreach (var node in allNodes)
			{
				int currentSum = 0;

				Queue<IntegerTree> queue = new Queue<IntegerTree>();

				queue.Enqueue(node);

				while (queue.Count > 0)
				{
					IntegerTree currentNode = queue.Dequeue();

					currentSum += currentNode.Key;

					if (currentSum > sum)
					{
						break;
					}

					foreach (var child in currentNode.Children)
					{
						queue.Enqueue(child as IntegerTree);
					}
				}

				if (currentSum == sum)
				{
					result.Add(node);
				}
			}

			return result;
		}
	}
}
