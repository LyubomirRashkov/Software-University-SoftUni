using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DistanceBetweenVertices
{
	public class Program
	{
		private static Dictionary<int, List<int>> graph;

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int pairsCount = int.Parse(Console.ReadLine());

			graph = new Dictionary<int, List<int>>();

			for (int i = 0; i < nodesCount; i++)
			{
				string[] inputParts = Console.ReadLine()
					.Split(':', StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				int node = int.Parse(inputParts[0]);

				if (inputParts.Length == 1)
				{
					graph.Add(node, new List<int>());
				}
				else
				{
					List<int> children = inputParts[1]
						.Split(' ', StringSplitOptions.RemoveEmptyEntries)
						.Select(int.Parse)
						.ToList();

					graph.Add(node, children);
				}
			}

			for (int i = 0; i < pairsCount; i++)
			{
				int[] parts = Console.ReadLine()
					.Split('-', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int startNode = parts[0];

				int destinationNode = parts[1];

				int edgesCount = Bfs(startNode, destinationNode);

                Console.WriteLine($"{{{startNode}, {destinationNode}}} -> {edgesCount}");
            }
		}

		private static int Bfs(int startNode, int destinationNode)
		{
			HashSet<int> visited = new HashSet<int>();

			Dictionary<int, int> parentByNode = new Dictionary<int, int>();

			Queue<int> queue = new Queue<int>();

			visited.Add(startNode);

			queue.Enqueue(startNode);

			parentByNode.Add(startNode, -1);

			while (queue.Count > 0)
			{
				int node = queue.Dequeue();

				if (node == destinationNode)
				{
					return GetEdgesCount(parentByNode, node);
				}

				foreach (var child in graph[node])
				{
					if (!visited.Contains(child))
					{
						visited.Add(child);

						queue.Enqueue(child);

						parentByNode.Add(child, node);
					}
				}
			}

			return -1;
		}

		private static int GetEdgesCount(Dictionary<int, int> parentByNode, int node)
		{
			int edgesCount = 0;

			int currentNode = node;

			while (parentByNode[currentNode] != -1)
			{
				edgesCount++;

				currentNode = parentByNode[currentNode];
			}

			return edgesCount;
		}
	}
}
