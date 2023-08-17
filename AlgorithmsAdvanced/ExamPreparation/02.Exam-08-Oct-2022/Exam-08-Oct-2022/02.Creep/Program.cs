using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Creep
{
	public class Edge
	{
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }

		public override string ToString()
		{
			return $"{this.From} {this.To}";
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			Dictionary<int, Dictionary<int, int>> graph = ReadInputEdges();

			List<Edge> sortedEdges = GetEdgesOrderedByWeight(graph);

			List<Edge> forest = new List<Edge>();

			int[] parents = InitializeParents(graph.Count);

			ApplyKruskal(sortedEdges, forest, parents);

			PrintResult(forest);
		}

		private static void PrintResult(List<Edge> forest)
		{
			int totalWeight = 0;

			foreach (var edge in forest)
			{
                Console.WriteLine(edge);

				totalWeight += edge.Weight;
            }

            Console.WriteLine(totalWeight);
        }

		private static void ApplyKruskal(List<Edge> edges, List<Edge> forest, int[] parents)
		{
			foreach (Edge edge in edges) 
			{
				int firstNodeRoot = FindRoot(edge.From, parents);

				int secondNodeRoot = FindRoot(edge.To, parents);

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

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = i;
			}

			return arr;
		}

		private static List<Edge> GetEdgesOrderedByWeight(Dictionary<int, Dictionary<int, int>> graph)
		{
			List<Edge> edges = new List<Edge>();

			foreach (var outerKVP in graph)
			{
				foreach (var innerKVP in outerKVP.Value)
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

			return edges.OrderBy(e => e.Weight).ToList();
		}

		private static Dictionary<int, Dictionary<int, int>> ReadInputEdges()
		{
			Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

			int nodesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < nodesCount; i++)
			{
				graph.Add(i, new Dictionary<int, int>());
			}

			int edgesCount = int.Parse(Console.ReadLine());

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
	}
}
