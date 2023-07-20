using System;
using System.Collections.Generic;

namespace _02.Chainanalysis
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

			int nodesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < nodesCount; i++)
			{
				string[] parts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				string fromNode = parts[0];

				string toNode = parts[1];

				if (!inputGraph.ContainsKey(fromNode))
				{
					inputGraph.Add(fromNode, new List<string>());
				}

				if (!inputGraph.ContainsKey(toNode))
				{
					inputGraph.Add(toNode, new List<string>());
				}

				if (int.Parse(parts[2]) > 0)
				{
					inputGraph[fromNode].Add(toNode);

					inputGraph[toNode].Add(fromNode);
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
					Dfs(node, graph, visited);

					count++;
				}
			}

			return count;
		}

		private static void Dfs(string node, Dictionary<string, List<string>> graph, HashSet<string> visited)
		{
			if (visited.Contains(node))
			{
				return;
			}

			visited.Add(node);

			foreach (var child in graph[node])
			{
				Dfs(child, graph, visited);
			}
		}
	}
}
