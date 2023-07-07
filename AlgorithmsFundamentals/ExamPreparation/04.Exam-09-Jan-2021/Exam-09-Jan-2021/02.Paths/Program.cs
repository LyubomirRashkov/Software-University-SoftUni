using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Paths
{
	public class Program
	{
		private static List<int>[] graph;
		private static bool[] visited;

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			graph = new List<int>[nodesCount];

			for (int i = 0; i < nodesCount; i++)
			{
				string input = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(input))
				{
					graph[i] = new List<int>();
				}
				else
				{
					graph[i] = input
						.Split(' ', StringSplitOptions.RemoveEmptyEntries)
						.Select(int.Parse)
						.ToList();
				}
			}

			visited = new bool[graph.Length];

			for (int i = 0; i < graph.Length - 1; i++)
			{
				Dfs(i, new LinkedList<int>());
			}
		}

		private static void Dfs(int node, LinkedList<int> path)
		{
			if (visited[node])
			{
				return;
			}

			path.AddLast(node);

			if (node == graph.Length - 1)
			{
				Console.WriteLine(string.Join(' ', path));

				path.RemoveLast();

				return;
			}

			visited[node] = true;

			foreach (var child in graph[node])
			{
				Dfs(child, path);
			}

			visited[node] = false;

			path.RemoveLast();
		}
	}
}
