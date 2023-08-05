using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ElectricalSubstationNetwork
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<int>[] graph = new List<int>[nodesCount];

			List<int>[] reversedGraph = new List<int>[nodesCount];

			for (int i = 0; i < nodesCount; i++)
			{
				graph[i] = new List<int>();

				reversedGraph[i] = new List<int>();
			}

			ReadInputLines(graph, reversedGraph);

			Stack<int> sortedNodes = TopologicalSort(graph);

			List<Stack<int>> components = GetComponents(sortedNodes, reversedGraph);

			foreach (var component in components)
			{
                Console.WriteLine(string.Join(", ", component));
            }
		}

		private static List<Stack<int>> GetComponents(Stack<int> sorted, List<int>[] reversedGraph)
		{
			List<Stack<int>> components = new List<Stack<int>>();

			bool[] visited = new bool[reversedGraph.Length];

			while (sorted.Count > 0)
			{
				int currentNode = sorted.Pop();

				if (!visited[currentNode])
				{
					Stack<int> component = new Stack<int>();

					Dfs(currentNode, reversedGraph, visited, component);

					components.Add(component);
				}
			}

			return components;
		}

		private static Stack<int> TopologicalSort(List<int>[] graph)
		{
			Stack<int> sorted = new Stack<int>();

			bool[] visited = new bool[graph.Length];

			for (int i = 0; i < graph.Length; i++)
			{
				Dfs(i, graph, visited, sorted);
			}

			return sorted;
		}

		private static void Dfs(int node, List<int>[] currentGraph, bool[] visited, Stack<int> stack)
		{
			if (visited[node])
			{
				return;
			}

			visited[node] = true;

			foreach (var child in currentGraph[node])
			{
				Dfs(child, currentGraph, visited, stack);
			}

			stack.Push(node);
		}

		private static void ReadInputLines(List<int>[] graph, List<int>[] reversedGraph)
		{
			int linesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < linesCount; i++)
			{
				int[] inputNodes = Console.ReadLine()
					.Split(", ", StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = inputNodes[0];

				graph[firstNode].AddRange(inputNodes.Skip(1));

				for (int j = 1; j < inputNodes.Length; j++)
				{
					reversedGraph[inputNodes[j]].Add(firstNode);
				}
			}
		}
	}
}
