using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _01.Bellman_Ford_sAlgorithm
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

			List<Edge> edges = ReadInputEdges();

			int startNode = int.Parse(Console.ReadLine());

			int endNode = int.Parse(Console.ReadLine());

			double[] distances = InitializeDistances(nodesCount);

			int[] parents = InitializeParents(nodesCount);

			bool hasNegativeCycle = false;

			ApplyBellmanFord(edges, distances, parents, nodesCount, startNode, ref hasNegativeCycle);

			if (hasNegativeCycle)
			{
                Console.WriteLine("Negative Cycle Detected");
            }
			else
			{
				Stack<int> path = GetPath(parents, endNode);

                Console.WriteLine(string.Join(' ', path));

				Console.WriteLine(distances[endNode]);
            }
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
				bool hasUpdatedDistances = false;

				foreach (var edge in edges)
				{
					if (!double.IsPositiveInfinity(distances[edge.From]))
					{
						double newDistance = distances[edge.From] + edge.Weight;

						if (newDistance < distances[edge.To])
						{
							distances[edge.To] = newDistance;

							parents[edge.To] = edge.From;

							hasUpdatedDistances = true;
						}
					}
				}

				if (!hasUpdatedDistances)
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

		private static int[] InitializeParents(int nodesCount)
		{
			int[] arr = new int[nodesCount + 1];

			Array.Fill(arr, -1);

			return arr;
		}

		private static double[] InitializeDistances(int nodesCount)
		{
			double[] arr = new double[nodesCount + 1];

			Array.Fill(arr, double.PositiveInfinity);

			return arr;
		}

		private static List<Edge> ReadInputEdges()
		{
			List<Edge> edges = new List<Edge>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				edges.Add(new Edge()
				{
					From = edgeParts[0],
					To = edgeParts[1],
					Weight = edgeParts[2],
				});
			}

			return edges;
		}
	}
}
