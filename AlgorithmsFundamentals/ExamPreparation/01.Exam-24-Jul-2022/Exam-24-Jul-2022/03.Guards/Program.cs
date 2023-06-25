using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Guards
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<int>[] graph = new List<int>[nodesCount + 1];

			for (int i = 0; i < graph.Length; i++)
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

				int fromNode = parts[0];

				int toNode = parts[1];

				graph[fromNode].Add(toNode);
			}

			int startNode = int.Parse(Console.ReadLine());

			bool[] visited = new bool[graph.Length];

			Bfs(graph, startNode, visited);

			HashSet<int> unreachableNodes = new HashSet<int>();

			for (int i = 1; i < visited.Length; i++)
			{
				if (!visited[i])
				{
					unreachableNodes.Add(i);
				}
			}

            Console.WriteLine(string.Join(' ', unreachableNodes));
        }

		private static void Bfs(List<int>[] graph, int startNode, bool[] visited)
		{
			Queue<int> queue = new Queue<int>();

			queue.Enqueue(startNode);

			visited[startNode] = true;

			while (queue.Count > 0)
			{
				int node = queue.Dequeue();

				foreach (var child in graph[node])
				{
					if (!visited[child])
					{
						queue.Enqueue(child);

						visited[child] = true;
					}
				}
			}
		}
	}
}
