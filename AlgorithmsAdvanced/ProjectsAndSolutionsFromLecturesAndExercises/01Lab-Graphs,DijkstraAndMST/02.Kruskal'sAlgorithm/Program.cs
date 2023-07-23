using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Kruskal_sAlgorithm
{
	public class Edge
	{
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }

		public override string ToString()
		{
			return $"{this.First} - {this.Second}";
		}
	}

	public class Program
	{
		private static int maxNode = -1;

		public static void Main(string[] args)
		{
			List<Edge> edges = ReadInputEdges();

			List<Edge> forest = new List<Edge>();

			int[] parents = InitializeParents(maxNode);

			edges = edges
				.OrderBy(e => e.Weight)
				.ToList();

			ApplyKruskal(edges, forest, parents);

			foreach (var edge in forest)
			{
                Console.WriteLine(edge);
            }
		}

		private static void ApplyKruskal(List<Edge> edges, List<Edge> forest, int[] parents)
		{
			foreach (var edge in edges)
			{
				int firstNodeRoot = FindRoot(edge.First, parents);

				int secondNodeRoot = FindRoot(edge.Second, parents);

				if (firstNodeRoot != secondNodeRoot)
				{
					forest.Add(edge);

					parents[firstNodeRoot] = secondNodeRoot;
				}
			}
		}

		private static int FindRoot(int node, int[] parents)
		{
			while (node != parents[node])
			{
				node = parents[node];
			}

			return node;
		}

		private static int[] InitializeParents(int maxNode)
		{
			int[] arr = new int[maxNode + 1];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = i;
			}

			return arr;
		}

		private static List<Edge> ReadInputEdges()
		{
			List<Edge> edges = new List<Edge>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(", ")
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeParts[0];

				int secondNode = edgeParts[1];

				maxNode = Math.Max(maxNode, Math.Max(firstNode, secondNode));

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = edgeParts[2],
				};

				edges.Add(edge);
			}

			return edges;
		}
	}
}
