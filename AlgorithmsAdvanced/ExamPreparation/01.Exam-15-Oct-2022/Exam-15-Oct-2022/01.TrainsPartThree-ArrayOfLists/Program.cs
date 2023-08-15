using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrainsPartThree
{
	public class Edge
	{
		public int From { get; set; }

		public int To { get; set; }

		public int Weight { get; set; }
	}

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

			List<Edge>[] graph = new List<Edge>[nodesCount];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<Edge>();
			}

			ReadInputEdges(graph, edgesCount);

			int[] parents = InitializeParents(graph.GetLength(0));

			int maxFlow = GetMaxFlow(graph, parents, source, destination);

			Console.WriteLine(maxFlow);
		}

		private static int GetMaxFlow(List<Edge>[] graph, int[] parents, int source, int destination)
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

		private static void ApplyFlow(List<Edge>[] graph, int[] parents, int node, int currentFlow)
		{
			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				graph[previousNode].FirstOrDefault(e => e.To == node).Weight -= currentFlow;

				node = previousNode;
			}
		}

		private static int GetCurrentFlow(List<Edge>[] graph, int[] parents, int node)
		{
			int currentFlow = int.MaxValue;

			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				int possibleFlow = graph[previousNode].FirstOrDefault(e => e.To == node).Weight;

				if (currentFlow > possibleFlow)
				{
					currentFlow = possibleFlow;
				}

				node = previousNode;
			}

			return currentFlow;
		}

		private static bool Bfs(int source, int destination, List<Edge>[] graph, int[] parents)
		{
			bool[] visited = new bool[graph.Length];

			Queue<int> queue = new Queue<int>();

			queue.Enqueue(source);

			visited[source] = true;

			while (queue.Count > 0)
			{
				int currentNode = queue.Dequeue();

				foreach (var edge in graph[currentNode])
				{
					int childNode = edge.To;

					if (!visited[childNode] && edge.Weight > 0)
					{
						queue.Enqueue(childNode);

						visited[childNode] = true;

						parents[childNode] = currentNode;
					}
				}
			}

			return visited[destination];
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = -1;
			}

			return arr;
		}

		private static void ReadInputEdges(List<Edge>[] graph, int edgesCount)
		{
			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				int fromNode = edgeData[0];

				Edge edge = graph[fromNode].FirstOrDefault(e => e.To == edgeData[1]);

				if (edge is null)
				{
					graph[fromNode].Add(new Edge()
					{
						From = fromNode,
						To = edgeData[1],
						Weight = edgeData[2],
					});
				}
				else
				{
					edge.Weight = edgeData[2];
				}
			}
		}
	}
}
