using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DataTransfer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int edgesCount = int.Parse(Console.ReadLine());

			int[] startAndEnd = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int start = startAndEnd[0];

			int end = startAndEnd[1];

			int[,] graph = new int[nodesCount, nodesCount];

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				graph[edgeData[0], edgeData[1]] = edgeData[2];
			}

			int[] parents = InitalizeParents(graph.GetLength(0));

			int maxFlow = GetMaxFlow(graph, parents, start, end);

			Console.WriteLine(maxFlow);
        }

		private static int GetMaxFlow(int[,] graph, int[] parents, int start, int end)
		{
			int maxFlow = 0;

			bool hasAugmentingPath = Bfs(start, end, graph, parents);

			while (hasAugmentingPath)
			{
				int currentFlow = GetCurrentFlow(graph, parents, end);

				ApplyFlow(graph, parents, end, currentFlow);

				maxFlow += currentFlow;

				hasAugmentingPath = Bfs(start, end, graph, parents);
			}

			return maxFlow;
		}

		private static void ApplyFlow(int[,] graph, int[] parents, int node, int currentFlow)
		{
			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				graph[previousNode, node] -= currentFlow;

				node = previousNode;
			}
		}

		private static int GetCurrentFlow(int[,] graph, int[] parents, int node)
		{
			int currentFlow = int.MaxValue;

			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				int possibleFlow = graph[previousNode, node];

				if (currentFlow > possibleFlow)
				{
					currentFlow = possibleFlow;
				}

				node = previousNode;
			}

			return currentFlow;
		}

		private static bool Bfs(int start, int end, int[,] graph, int[] parents)
		{
			bool[] visited = new bool[graph.GetLength(0)];

			Queue<int> queue = new Queue<int>();

			queue.Enqueue(start);

			visited[start] = true;

			while (queue.Count > 0)
			{
				int currentNode = queue.Dequeue();

				for (int child = 0; child < graph.GetLength(1); child++)
				{
					if (!visited[child] && graph[currentNode, child] > 0)
					{
						queue.Enqueue(child);

						visited[child] = true;

						parents[child] = currentNode;
					}
				}
			}

			return visited[end];
		}

		private static int[] InitalizeParents(int size)
		{
			int[] arr = new int[size];

			Array.Fill(arr, -1);

			return arr;
		}
	}
}
