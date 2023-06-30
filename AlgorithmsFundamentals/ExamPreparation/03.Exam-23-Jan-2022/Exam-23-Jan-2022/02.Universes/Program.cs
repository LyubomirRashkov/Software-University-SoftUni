using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Universes
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Dictionary<string, List<string>> graph = ReadInput();

			int componentsCount = GetComponentsCount(graph);

			Console.WriteLine(componentsCount);
		}

		private static Dictionary<string, List<string>> ReadInput()
		{
			Dictionary<string, List<string>> inputGraph = new Dictionary<string, List<string>>();

			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] parts = Console.ReadLine()
					.Split('-', StringSplitOptions.RemoveEmptyEntries)
					.Select(x => x.Trim())
					.ToArray();

				string key = parts[0];

				if (!inputGraph.ContainsKey(key))
				{
					inputGraph.Add(key, new List<string>());
				}

				if (parts.Length == 2)
				{
					string child = parts[1];

					if (!inputGraph.ContainsKey(child))
					{
						inputGraph.Add(child, new List<string>());
					}

					inputGraph[key].Add(child);

					inputGraph[child].Add(key);
				}
			}

			return inputGraph;
		}

		private static int GetComponentsCount(Dictionary<string, List<string>> graph)
		{
			int count = 0;

			HashSet<string> visited = new HashSet<string>();

			foreach (var node in graph.Keys)
			{
				if (!visited.Contains(node))
				{
					Dfs(node, visited, graph);

					count++;
				}
			}

			return count;
		}

		private static void Dfs(string node, HashSet<string> visited, Dictionary<string, List<string>> graph)
		{
			if (visited.Contains(node))
			{
				return;
			}

			visited.Add(node);

			foreach (var child in graph[node])
			{
				Dfs(child, visited, graph);
			}
		}
	}
}
