using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BitcoinGroups
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

			ReadInputEdges(graph, reversedGraph);

			Stack<int> sortedNodes = TopologicalSort(graph);

			List<Stack<int>> components = GetComponents(sortedNodes, reversedGraph);

			Stack<int> mostActiveComponent = GetMostActiveComponent(components);

			PrintResult(graph, mostActiveComponent);
		}

		private static void PrintResult(List<int>[] graph, Stack<int> component)
		{
			foreach (var node in component)
			{
				foreach (var child in graph[node])
				{
					if (component.Contains(child))
					{
						Console.WriteLine($"{node} -> {child}");
					}
				}
			}
		}

		private static Stack<int> GetMostActiveComponent(List<Stack<int>> components)
		{
			Stack<int> mostActiveComponent = new Stack<int>();

			foreach (var component in components)
			{
				if (mostActiveComponent.Count < component.Count)
				{
					mostActiveComponent = component;
				}
			}

			return mostActiveComponent;
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

		private static void ReadInputEdges(List<int>[] graph, List<int>[] reversedGraph)
		{
			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeData[0];

				int secondNode = edgeData[1];

				graph[firstNode].Add(secondNode);

				reversedGraph[secondNode].Add(firstNode);
			}
		}
	}
}
