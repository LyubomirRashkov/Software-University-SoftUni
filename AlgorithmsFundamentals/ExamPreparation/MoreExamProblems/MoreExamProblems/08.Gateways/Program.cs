using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Gateways
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

			int targetNode = int.Parse(Console.ReadLine());

			bool[] visited = new bool[graph.Length];

			int[] parents = new int[graph.Length];

			Array.Fill(parents, -1);

			Bfs(startNode, targetNode, graph, visited, parents);
		}

		private static void Bfs(int startNode, int targetNode, List<int>[] graph, bool[] visited, int[] parents)
		{
			Queue<int> queue = new Queue<int>();

			queue.Enqueue(startNode);

			visited[startNode] = true;

			while (queue.Count > 0)
			{
				int currentNode = queue.Dequeue();

				if (currentNode == targetNode)
				{
					Stack<int> path = GetPath(targetNode, parents);

                    Console.WriteLine(string.Join(' ', path));

					break;
                }

				foreach (var child in graph[currentNode])
				{
					if (!visited[child])
					{
						queue.Enqueue(child);

						visited[child] = true;

						parents[child] = currentNode;
					}
				}
			}
		}

		private static Stack<int> GetPath(int node, int[] parents)
		{
			Stack<int> path = new Stack<int>();

			while (node != -1)
			{
				path.Push(node);

				node = parents[node];
			}

			return path;
		}
	}
}
