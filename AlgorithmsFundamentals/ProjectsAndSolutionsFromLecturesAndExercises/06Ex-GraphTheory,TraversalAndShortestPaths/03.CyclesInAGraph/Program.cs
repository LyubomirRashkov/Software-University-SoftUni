using System;
using System.Collections.Generic;

namespace _03.CyclesInAGraph
{
	public class Program
	{
		private static Dictionary<string, List<string>> graph;
		private static HashSet<string> visited;
		private static HashSet<string> cycles;

		public static void Main(string[] args)
		{
			graph = new Dictionary<string, List<string>>();

			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine == "End")
				{
					break;
				}

				string[] parts = inputLine
					.Split('-', StringSplitOptions.RemoveEmptyEntries);

				string node = parts[0];

				if (!graph.ContainsKey(node))
				{
					graph.Add(node, new List<string>());
				}

				if (parts.Length > 1)
				{
					string child = parts[1];

					if (!graph.ContainsKey(child))
					{
						graph.Add(child, new List<string>());
					}

					graph[node].Add(child);
				}
			}

			visited = new HashSet<string>();

			cycles = new HashSet<string>();

			try
			{
				foreach (var node in graph.Keys)
				{
					Dfs(node);
				}

                Console.WriteLine("Acyclic: Yes");
            }
			catch (InvalidOperationException)
			{
                Console.WriteLine("Acyclic: No");
            }
		}

		private static void Dfs(string node)
		{
			if (cycles.Contains(node))
			{
				throw new InvalidOperationException();
			}

			if (visited.Contains(node))
			{
				return;
			}

			visited.Add(node);

			cycles.Add(node);

			foreach (var child in graph[node])
			{
				Dfs(child);
			}

			cycles.Remove(node);
		}
	}
}
