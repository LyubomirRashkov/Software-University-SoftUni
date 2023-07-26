using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.LongestPathInDAG
{
	public class Edge
	{
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

	public class Program
	{
		private static Dictionary<int, List<Edge>> graph;

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			graph = ReadInputEdges();

			double[] distances = InitializeDistances(nodesCount);

			Stack<int> sortedNodes = TopologicalSort();

			int startNode = int.Parse(Console.ReadLine());

			int endNode = int.Parse(Console.ReadLine());

			ApplyLongestPath(sortedNodes, distances, startNode);

			Console.WriteLine(distances[endNode]);
        }

		private static void ApplyLongestPath(Stack<int> sortedNodes, double[] distances, int startNode)
		{
			distances[startNode] = 0;

			while (sortedNodes.Count > 0)
			{
				int node = sortedNodes.Pop();

				foreach (var edge in graph[node])
				{
					double newDistance = distances[edge.From] + edge.Weight;

					if (newDistance > distances[edge.To])
					{
						distances[edge.To] = newDistance;
					}
				}
			}
		}

		private static Stack<int> TopologicalSort()
		{
			Stack<int> sorted = new Stack<int>();

			HashSet<int> visited = new HashSet<int>();

			foreach (var node in graph.Keys)
			{
				Dfs(node, visited, sorted);
			}

			return sorted;
		}

		private static void Dfs(int node, HashSet<int> visited, Stack<int> result)
		{
			if (visited.Contains(node))
			{
				return;
			}

			visited.Add(node);

			foreach (var edge in graph[node])
			{
				Dfs(edge.To, visited, result);
			}

			result.Push(node);
		}

		private static double[] InitializeDistances(int nodesCount)
		{
			double[] arr = new double[nodesCount + 1];

			Array.Fill(arr, double.NegativeInfinity);

			return arr;
		}

		private static Dictionary<int, List<Edge>> ReadInputEdges()
		{
			Dictionary<int, List<Edge>> inputGraph = new Dictionary<int, List<Edge>>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int fromNode = edgeParts[0];

				int toNode = edgeParts[1];

				if (!inputGraph.ContainsKey(fromNode))
				{
					inputGraph.Add(fromNode, new List<Edge>());
				}

				inputGraph[fromNode].Add(new Edge()
				{
					From = fromNode,
					To = toNode,
					Weight = edgeParts[2],
				});

				if (!inputGraph.ContainsKey(toNode))
				{
					inputGraph.Add(toNode, new List<Edge>());
				}
			}

			return inputGraph;
		}
	}
}
