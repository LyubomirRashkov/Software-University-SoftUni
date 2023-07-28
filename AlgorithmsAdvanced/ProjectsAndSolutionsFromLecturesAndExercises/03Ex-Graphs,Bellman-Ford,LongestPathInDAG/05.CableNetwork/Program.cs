using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CableNetwork
{
	public class Edge
	{
		public int First { get; set; }

		public int Second { get; set; }

		public int Weight { get; set; }
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			int budget = int.Parse(Console.ReadLine());

			List<Edge>[] graph = InitializeGraph();

			HashSet<int> spanningTree = new HashSet<int>();

			ReadInputEdges(graph, spanningTree);

			int usedBudget = ApplyPrim(graph, spanningTree, budget);

			Console.WriteLine($"Budget used: {usedBudget}");
		}

		private static int ApplyPrim(
			List<Edge>[] graph,
			HashSet<int> spanningTree,
			int budget)
		{
			int usedBudget = 0;

			List<Edge> edges = new List<Edge>();

			foreach (var node in spanningTree)
			{
				edges.AddRange(graph[node]);
			}

			edges = edges
				.OrderBy(e => e.Weight)
				.ToList();

			while (edges.Count > 0)
			{
				Edge edge = edges[0];

				edges.RemoveAt(0);

				int nonTreeNode = -1;

				if (spanningTree.Contains(edge.First)
					&& !spanningTree.Contains(edge.Second))
				{
					nonTreeNode = edge.Second;
				}

				if (spanningTree.Contains(edge.Second)
					&& !spanningTree.Contains(edge.First))
				{
					nonTreeNode = edge.First;
				}

				if (nonTreeNode != -1)
				{
					if (usedBudget + edge.Weight > budget)
					{
						break;
					}

					usedBudget += edge.Weight;

					spanningTree.Add(nonTreeNode);

					edges.AddRange(graph[nonTreeNode]);

					edges = edges
						.OrderBy(e => e.Weight)
						.ToList();
				}
			}

			return usedBudget;
		}

		private static void ReadInputEdges(List<Edge>[] graph, HashSet<int> spanningTree)
		{
			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				string[] edgeParts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				int firstNode = int.Parse(edgeParts[0]);

				int secondNode = int.Parse(edgeParts[1]);

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = int.Parse(edgeParts[2]),
				};

				graph[firstNode].Add(edge);

				graph[secondNode].Add(edge);

				if (edgeParts.Length == 4)
				{
					spanningTree.Add(firstNode);

					spanningTree.Add(secondNode);
				}
			}
		}

		private static List<Edge>[] InitializeGraph()
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<Edge>[] graph = new List<Edge>[nodesCount];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<Edge>();
			}

			return graph;
		}
	}
}
