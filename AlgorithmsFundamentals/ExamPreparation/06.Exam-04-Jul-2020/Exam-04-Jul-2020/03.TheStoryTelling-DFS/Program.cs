using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TopologicalSorting_DFS
{
	public class Program
	{
		private static Dictionary<string, List<string>> graph;
		private static Stack<string> sortedNodes;
		private static HashSet<string> visited;
		private static HashSet<string> cycles;

		public static void Main(string[] args)
		{
			graph = ReadInputAndConstructTheGraph();

			sortedNodes = new Stack<string>();

			visited = new HashSet<string>();

			cycles = new HashSet<string>();

			bool hasCycles = false;

			foreach (var node in graph.Keys)
			{
				try
				{
					Dfs(node);
				}
				catch (InvalidOperationException)
				{
					hasCycles = true;
				}
			}

			if (hasCycles)
			{
				Console.WriteLine("Invalid topological sorting - graph has cycles!");
			}
			else
			{
				Console.WriteLine(string.Join(" ", sortedNodes));
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

			cycles.Add(node);

			visited.Add(node);

			foreach (var child in graph[node])
			{
				Dfs(child);
			}

			sortedNodes.Push(node);

			cycles.Remove(node);
		}

		private static Dictionary<string, List<string>> ReadInputAndConstructTheGraph()
		{
			Dictionary<string, List<string>> graphStructure = new Dictionary<string, List<string>>();

			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine == "End")
				{
					break;
				}

				string[] parts = inputLine
					.Split("->")
					.Select(x => x.Trim())
					.ToArray();

				string key = parts[0];

				if (parts.Length == 1)
				{
					graphStructure[key] = new List<string>();
				}
				else
				{
					graphStructure[key] = parts[1]
						.Split(" ", StringSplitOptions.RemoveEmptyEntries)
						.ToList();
				}
			}

			return graphStructure;
		}
	}
}
