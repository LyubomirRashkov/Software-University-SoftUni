using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrainsPartThree
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int edgesCount = int.Parse(Console.ReadLine());

			int[] targetNodes = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int source = targetNodes[0];

			int destination = targetNodes[1];

			Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

			for (int i = 0; i < nodesCount; i++)
			{
				graph[i] = new Dictionary<int, int>();
			}

			ReadInputEdges(graph, edgesCount);

			int[] parents = new int[nodesCount];

			for (int i = 0; i < parents.Length; i++)
			{
				parents[i] = -1;
			}

			int maxFlow = GetMaxFlow(graph, parents, source, destination);

			Console.WriteLine(maxFlow);
		}

		private static int GetMaxFlow(
			Dictionary<int, Dictionary<int, int>> graph,
			int[] parents,
			int source,
			int destination)
		{
			int maxFlow = 0;

			bool hasAugmentingPath = Bfs(source, destination, graph, parents);

			while (hasAugmentingPath)
			{
				int currentFlow = GetCurrentFlow(graph, parents, destination);

				ApplyFlow(graph, parents, destination, currentFlow);

				maxFlow += currentFlow;

				hasAugmentingPath = Bfs(source, destination, graph, parents);
			}

			return maxFlow;
		}

		private static void ApplyFlow(
			Dictionary<int, Dictionary<int, int>> graph,
			int[] parents,
			int node,
			int currentFlow)
		{
			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				graph[previousNode][node] -= currentFlow;

				node = previousNode;
			}
		}

		private static int GetCurrentFlow(
			Dictionary<int, Dictionary<int, int>> graph,
			int[] parents,
			int node)
		{
			int currentFlow = int.MaxValue;

			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				int possibleFlow = graph[previousNode][node];

				if (currentFlow > possibleFlow)
				{
					currentFlow = possibleFlow;
				}

				node = previousNode;
			}

			return currentFlow;
		}

		private static bool Bfs(
			int source,
			int destination,
			Dictionary<int, Dictionary<int, int>> graph,
			int[] parents)
		{
			bool[] visited = new bool[graph.Keys.Count];

			Queue<int> queue = new Queue<int>();

			queue.Enqueue(source);

			visited[source] = true;

			while (queue.Count > 0)
			{
				int currentNode = queue.Dequeue();

				foreach (var kvp in graph[currentNode])
				{
					int childNode = kvp.Key;

					if (!visited[childNode] && kvp.Value > 0)
					{
						queue.Enqueue(childNode);

						visited[childNode] = true;

						parents[childNode] = currentNode;
					}
				}
			}

			return visited[destination];
		}

		private static void ReadInputEdges(Dictionary<int, Dictionary<int, int>> graph, int edgesCount)
		{
			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				int fromNode = edgeData[0];

				int toNode = edgeData[1];

				int weight = edgeData[2];

				graph[fromNode][toNode] = weight;
			}
		}
	}
}
