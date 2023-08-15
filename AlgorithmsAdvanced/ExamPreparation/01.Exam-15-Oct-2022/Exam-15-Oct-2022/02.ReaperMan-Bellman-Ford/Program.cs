using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReaperMan
{
	public class Edge
	{
		public int From { get; set; }

		public int To { get; set; }

		public int Weight { get; set; }
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int edgesCount = int.Parse(Console.ReadLine());

			int[] targetNodes = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int start = targetNodes[0];

			int destination = targetNodes[1];

			Dictionary<int, Dictionary<int, int>> graph = ReadInputEdges(nodesCount, edgesCount);

			double[] distances = InitializeDistances(nodesCount);

			int[] parents = InitializeParents(nodesCount);

			List<Edge> edges = ConvertToList(graph);

			bool hasNegativeCycle = false;

			ApplyBellmanFord(edges, distances, parents, nodesCount, start, ref hasNegativeCycle);

			if (!hasNegativeCycle)
			{
				PrintResult(parents, destination, distances);
			}
		}

		private static Dictionary<int, Dictionary<int, int>> ReadInputEdges(int nodesCount, int edgesCount)
		{
			Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

			for (int i = 0; i < nodesCount; i++)
			{
				graph[i] = new Dictionary<int, int>();
			}

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				graph[edgeData[0]][edgeData[1]] = edgeData[2];
			}

			return graph;
		}

		private static List<Edge> ConvertToList(Dictionary<int, Dictionary<int, int>> graph)
		{
			List<Edge> edges = new List<Edge>();

			foreach (var outerKVP in graph)
			{
				foreach (var innerKVP in graph[outerKVP.Key])
				{
					Edge edge = new Edge()
					{
						From = outerKVP.Key,
						To = innerKVP.Key,
						Weight = innerKVP.Value,
					};

					edges.Add(edge);
				}
			}

			return edges;
		}

		private static void PrintResult(int[] parents, int node, double[] distances)
		{
			Stack<int> path = GetPath(parents, node);

			Console.WriteLine(string.Join(" ", path));

			Console.WriteLine(distances[node]);
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

		private static void ApplyBellmanFord(
			List<Edge> edges,
			double[] distances,
			int[] parents,
			int nodesCount,
			int startNode,
			ref bool hasNegativeCycle)
		{
			distances[startNode] = 0;

			for (int i = 0; i < nodesCount - 1; i++)
			{
				bool hasUpdatedDistance = false;

				foreach (var edge in edges)
				{
					if (!double.IsPositiveInfinity(distances[edge.From]))
					{
						double newDistance = distances[edge.From] + edge.Weight;

						if (newDistance < distances[edge.To])
						{
							distances[edge.To] = newDistance;

							parents[edge.To] = edge.From;

							hasUpdatedDistance = true;
						}
					}
				}

				if (!hasUpdatedDistance)
				{
					break;
				}
			}

			foreach (var edge in edges)
			{
				double newDistance = distances[edge.From] + edge.Weight;

				if (newDistance < distances[edge.To])
				{
					hasNegativeCycle = true;
				}
			}
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = -1;
			}

			return arr;
		}

		private static double[] InitializeDistances(int size)
		{
			double[] arr = new double[size];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = double.PositiveInfinity;
			}

			return arr;
		}
	}
}