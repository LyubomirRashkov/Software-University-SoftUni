using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BlackFriday
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

			List<Edge> edges = ReadInputEdges()
				.OrderBy(e => e.Weight)
				.ToList();

			int[] parents = InitializeParents(nodesCount);

			int MSTWeight = 0;

			ApplyKruskal(edges, parents, ref MSTWeight);

            Console.WriteLine(MSTWeight);
        }

		private static void ApplyKruskal(List<Edge> edges, int[] parents, ref int MSTWeight)
		{
			foreach (var edge in edges)
			{
				int firstNodeRoot = FindRoot(edge.First, parents);

				int secondNodeRoot = FindRoot(edge.Second, parents);

				if (firstNodeRoot != secondNodeRoot)
				{
					MSTWeight += edge.Weight;

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
			List<Edge> edges = new List<Edge>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				edges.Add(new Edge()
				{
					First = edgeData[0],
					Second = edgeData[1],
					Weight = edgeData[2],
				});
			}

			return edges;
		}
	}
}
