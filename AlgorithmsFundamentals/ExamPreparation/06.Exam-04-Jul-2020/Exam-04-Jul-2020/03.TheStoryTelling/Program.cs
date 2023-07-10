using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheStoryTelling
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Dictionary<string, List<string>> graph = ReadInputAndConstructTheGraph();

			Dictionary<string, int> countOfDependenciesByNode = ExtractDependencies(graph);

			List<string> sortedNodes = SortGraph(graph, countOfDependenciesByNode);

			Console.WriteLine(string.Join(' ', sortedNodes));
		}

		private static Dictionary<string, List<string>> ReadInputAndConstructTheGraph()
		{
			Dictionary<string, List<string>> inputGraph = new Dictionary<string, List<string>>();

			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine == "End")
				{
					break;
				}

				string[] parts = inputLine
					.Split("->", StringSplitOptions.RemoveEmptyEntries)
					.Select(x => x.Trim())
					.ToArray();

				string key = parts[0];

				if (!inputGraph.ContainsKey(key))
				{
					inputGraph.Add(key, new List<string>());
				}

				if (parts.Length == 2)
				{
					List<string> values = parts[1]
						.Split(' ', StringSplitOptions.RemoveEmptyEntries)
						.ToList();

					inputGraph[key].AddRange(values);
				}
			}

			return inputGraph;
		}

		private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph)
		{
			Dictionary<string, int> dependencies = new Dictionary<string, int>();

			foreach (var node in graph.Keys)
			{
				if (!dependencies.ContainsKey(node))
				{
					dependencies.Add(node, 0);
				}

				foreach (var child in graph[node])
				{
					if (!dependencies.ContainsKey(child))
					{
						dependencies.Add(child, 0);
					}

					dependencies[child]++;
				}
			}

			return dependencies;
		}

		private static List<string> SortGraph(
			Dictionary<string, List<string>> graphToSort,
			Dictionary<string, int> dependencies)
		{
			List<string> sorted = new List<string>();

			while (dependencies.Count > 0)
			{
				string nodeToRemove = dependencies.LastOrDefault(kvp => kvp.Value == 0).Key;

				if (nodeToRemove is null)
				{
					break;
				}

				sorted.Add(nodeToRemove);

				dependencies.Remove(nodeToRemove);

				foreach (var child in graphToSort[nodeToRemove])
				{
					dependencies[child]--;
				}
			}

			return sorted;
		}
	}
}
