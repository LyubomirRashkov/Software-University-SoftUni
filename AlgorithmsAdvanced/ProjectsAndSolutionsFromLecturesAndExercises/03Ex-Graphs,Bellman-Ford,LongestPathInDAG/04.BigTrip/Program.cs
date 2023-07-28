using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BigTrip
{
	public class Edge
	{
		public int From { get; set; }

		public int To { get; set; }

		public int Weight { get; set; }
	}

	public class Program
	{
		private static List<Edge>[] graph;

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			InitializeGraph(nodesCount + 1);

			ReadInputEdges();

			double[] times = InitializeTimes(nodesCount + 1);

			int[] parents = InitializeParents(nodesCount + 1);

			Stack<int> sortedNodes = TopologicalSort();

			int source = int.Parse(Console.ReadLine());

			int destination = int.Parse(Console.ReadLine());

			ApplyLongestPath(sortedNodes, times, parents, source);

			PrintOutput(times, parents, destination);
		}

		private static void PrintOutput(double[] times, int[] parents, int node)
		{
			Console.WriteLine(times[node]);

			Stack<int> path = GetPath(parents, node);

            Console.WriteLine(string.Join(' ', path));
        }

		private static Stack<int> GetPath(int[] parents, int node)
		{
			Stack<int> path = new Stack<int>();

			while (node != -1)
			{
				path.Push(node);

				node = parents[node];
			}

			return path;
		}

		private static void ApplyLongestPath(
			Stack<int> sortedNodes, 
			double[] times, 
			int[] parents, 
			int source)
		{
			times[source] = 0;

			while (sortedNodes.Count > 0)
			{
				int node = sortedNodes.Pop();

				foreach (var edge in graph[node])
				{
					double newTime = times[edge.From] + edge.Weight;

					if (newTime > times[edge.To])
					{
						times[edge.To] = newTime;

						parents[edge.To] = edge.From;
					}
				}
			}
		}

		private static Stack<int> TopologicalSort()
		{
			Stack<int> sorted = new Stack<int>();

			bool[] visited = new bool[graph.Length];

			for (int i = 1; i < graph.Length; i++)
			{
				if (!visited[i])
				{
					Dfs(i, visited, sorted);
				}
			}

			return sorted;
		}

		private static void Dfs(int node, bool[] visited, Stack<int> result)
		{
			if (visited[node])
			{
				return;
			}

			visited[node] = true;

			foreach (var edge in graph[node])
			{
				Dfs(edge.To, visited, result);
			}

			result.Push(node);
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			Array.Fill(arr, -1);

			return arr;
		}

		private static double[] InitializeTimes(int size)
		{
			double[] arr = new double[size];

			Array.Fill(arr, double.NegativeInfinity);

			return arr;
		}

		private static List<Edge>[] ReadInputEdges()
		{
			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int fromNode = edgeParts[0];

				graph[fromNode].Add(new Edge()
				{
					From = fromNode,
					To = edgeParts[1],
					Weight = edgeParts[2],
				});
			}

			return graph;
		}

		private static void InitializeGraph(int size)
		{
			graph = new List<Edge>[size];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<Edge>();
			}
		}
	}
}
