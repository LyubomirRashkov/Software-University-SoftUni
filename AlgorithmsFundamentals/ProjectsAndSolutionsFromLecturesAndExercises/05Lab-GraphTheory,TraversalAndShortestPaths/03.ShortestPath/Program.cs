using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShortestPath
{
	public class Program
	{
		private static HashSet<int>[] graph;
		private static bool[] visited;
		private static int[] parents;

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			graph = new HashSet<int>[nodesCount + 1];

			visited = new bool[graph.Length];

			parents = new int[graph.Length];

			Array.Fill(parents, -1);

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new HashSet<int>();
			}

			for (int i = 0; i < edgesCount; i++)
			{
				int[] input = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = input[0];

				int secondNode = input[1];

				graph[firstNode].Add(secondNode);

				graph[secondNode].Add(firstNode);
			}

			int startNode = int.Parse(Console.ReadLine());

			int endNode = int.Parse(Console.ReadLine());

			Bfs(startNode, endNode);
		}

		private static void Bfs(int startNode, int endNode)
		{
			var queue = new Queue<int>();

			queue.Enqueue(startNode);

			visited[startNode] = true;

			while (queue.Count > 0)
			{
				int node = queue.Dequeue();

				if (node == endNode)
				{
					Stack<int> path = GetPath(endNode);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");

					Console.WriteLine(string.Join(' ', path));

                    break;
				}

				foreach (var child in graph[node])
				{
					if (!visited[child])
					{
						queue.Enqueue(child);

						visited[child] = true;

						parents[child] = node;
					}
				}
			}
		}

		private static Stack<int> GetPath(int endNode)
		{
			Stack<int> result = new Stack<int>();

			int currentNode = endNode;

			while (currentNode != -1)
			{
				result.Push(currentNode);

				currentNode = parents[currentNode];
			}

			return result;
		}
	}
}
