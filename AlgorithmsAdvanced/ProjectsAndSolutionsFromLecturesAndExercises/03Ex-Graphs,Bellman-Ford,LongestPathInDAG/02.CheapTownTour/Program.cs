using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CheapTownTour
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
			int nodesCount = int.Parse(Console.ReadLine());

			List<Edge> edges = ReadInputEdges();

			int[] parents = InitializeParents(nodesCount);

			int treeWeight = ApplyKruskal(edges, parents);

            Console.WriteLine($"Total cost: {treeWeight}");
        }

		private static int ApplyKruskal(List<Edge> edges, int[] parents)
		{
			int weight = 0;

			foreach (var edge in edges.OrderBy(e => e.Weight))
			{
				int firstNodeRoot = FindRoot(edge.First, parents);

				int secondNodeRoot = FindRoot(edge.Second, parents);

				if (firstNodeRoot != secondNodeRoot)
				{
					weight += edge.Weight;

					parents[firstNodeRoot] = secondNodeRoot;
				}
			}

			return weight;
		}

		private static int FindRoot(int node, int[] parents)
		{
			while (node != parents[node])
			{
				node = parents[node];
			}

			return node;
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = i;
			}

			return arr;
		}

		private static List<Edge> ReadInputEdges()
		{
			List<Edge> inputEdges = new List<Edge>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(" - ", StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				inputEdges.Add(new Edge()
				{
					First = edgeParts[0],
					Second = edgeParts[1],
					Weight = edgeParts[2],
				});
			}

			return inputEdges;
		}
	}
}
