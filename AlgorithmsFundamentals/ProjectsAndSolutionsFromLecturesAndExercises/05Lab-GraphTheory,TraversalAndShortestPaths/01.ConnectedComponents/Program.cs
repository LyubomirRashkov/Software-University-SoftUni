using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ConnectedComponents
{
	public class Program
	{
		private static List<int>[] graph;
		private static bool[] visited;

		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			graph = new List<int>[n];

			for (int i = 0; i < n; i++)
			{
				graph[i] = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToList();
			
			}

			visited = new bool[graph.Length];

			for (int i = 0; i < graph.Length; i++)
			{
				if (visited[i])
				{
					continue;
				}

				List<int> component = new List<int>();

				Dfs(i, component);

				Console.WriteLine($"Connected component: {string.Join(' ', component)}");
            }
		}

		private static void Dfs(int node, List<int> component)
		{
			if (visited[node])
			{
				return;
			}

			visited[node] = true;

			foreach (var child in graph[node])
			{
				Dfs(child, component);
			}

			component.Add(node);
		}
	}
}
