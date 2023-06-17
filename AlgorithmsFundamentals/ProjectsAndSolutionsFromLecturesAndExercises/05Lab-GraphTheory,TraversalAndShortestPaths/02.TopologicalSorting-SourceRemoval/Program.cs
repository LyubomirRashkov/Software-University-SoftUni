using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TopologicalSorting_SourceRemoval
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Dictionary<string, List<string>> graph = ReadInputAndConstructTheGraph();

			Dictionary<string, int> countOfDependenciesByNode = ExtractDependencies(graph);

			List<string> sortedNodes = SortGraph(graph, countOfDependenciesByNode);

			PrintOutput(countOfDependenciesByNode, sortedNodes);
		}

		private static Dictionary<string, List<string>> ReadInputAndConstructTheGraph()
		{
			Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

			int nodesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < nodesCount; i++)
			{
				string[] input = Console.ReadLine()
					.Split("->")
					.Select(x => x.Trim())
					.ToArray();

				string key = input[0];

				if (input.Length == 1)
				{
					graph[key] = new List<string>();
				}
				else
				{
					graph[key] = input[1]
						.Split(", ", StringSplitOptions.RemoveEmptyEntries)
						.ToList();
				}
			}

			return graph;
		}

		private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph)
		{
			Dictionary<string, int> countOfDependenciesByNode = new Dictionary<string, int>();

			foreach (var node in graph.Keys)
			{
				if (!countOfDependenciesByNode.ContainsKey(node))
				{
					countOfDependenciesByNode.Add(node, 0);
				}

				foreach (var child in graph[node])
				{
					if (!countOfDependenciesByNode.ContainsKey(child))
					{
						countOfDependenciesByNode.Add(child, 0);
					}

					countOfDependenciesByNode[child]++;
				}
			}

			return countOfDependenciesByNode;
		}

		private static List<string> SortGraph(
			Dictionary<string, List<string>> graph, 
			Dictionary<string, int> countOfDependenciesByNode)
		{
			List<string> sortedNodes = new List<string>();

			while (countOfDependenciesByNode.Count > 0)
			{
				string nodeToRemove = countOfDependenciesByNode.FirstOrDefault(kvp => kvp.Value == 0).Key;

				if (nodeToRemove is null)
				{
					break;
				}

				sortedNodes.Add(nodeToRemove);

				countOfDependenciesByNode.Remove(nodeToRemove);

				foreach (var child in graph[nodeToRemove])
				{
					countOfDependenciesByNode[child]--;
				}
			}

			return sortedNodes;
		}

		private static void PrintOutput(Dictionary<string, int> countOfDependenciesByNode, List<string> sortedNodes)
		{
			if (countOfDependenciesByNode.Count == 0)
			{
				Console.WriteLine($"Topological sorting: {string.Join(", ", sortedNodes)}");
			}
			else
			{
				Console.WriteLine("Invalid topological sorting");
			}
		}
	}
}
