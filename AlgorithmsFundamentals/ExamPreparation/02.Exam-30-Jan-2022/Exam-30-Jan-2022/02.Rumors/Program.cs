using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Rumors
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<int>[] graph = new List<int>[nodesCount + 1];

			for (int i = 1; i < graph.Length; i++)
			{
				graph[i] = new List<int>();
			}

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] parts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = parts[0];

				int secondNode = parts[1];

				graph[firstNode].Add(secondNode);

				graph[secondNode].Add(firstNode);
			}

			int startNode = int.Parse(Console.ReadLine());

			int[] parent = new int[graph.Length];
			
			Array.Fill(parent, -1);

			for (int i = 1; i < graph.Length; i++)
			{
				if (i == startNode)
				{
					continue;
				}

				bool[] visited = new bool[graph.Length];

				int destination = i;

				int pathLength = Bfs(startNode, destination, graph, visited, parent);

				if (pathLength != -1)
				{
					Console.WriteLine($"{startNode} -> {destination} ({pathLength})");
				}
			}
		}

		private static int Bfs(int startNode, int destination, List<int>[] graph, bool[] visited, int[] parent)
		{
			Queue<int> queue = new Queue<int>();

			queue.Enqueue(startNode);

			visited[startNode] = true;

			while (queue.Count > 0)
			{
				int node = queue.Dequeue();

				if (node == destination)
				{
					int pathLength = GetPathLength(destination, parent);

					return pathLength;
				}

				foreach (var child in graph[node])
				{
					if (!visited[child])
					{
						queue.Enqueue(child);

						visited[child] = true;

						parent[child] = node;
					}
				}
			}

			return -1;
		}

		private static int GetPathLength(int destination, int[] parent)
		{
			int length = -1;

			int node = destination;

			while (node != -1)
			{
				length++;

				node = parent[node];
			}

			return length;
		}
	}
}
