using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Eco_FriendlyHighwayConstruction
{
	public class Edge
	{
        public string First { get; set; }

        public string Second { get; set; }

        public int Weight { get; set; }
    }

	public class Program
	{
		public static void Main(string[] args)
		{
			List<Edge> edges = ReadInput();

			edges = edges
				.OrderBy(e => e.Weight)
				.ToList();

			Dictionary<string, string> parentByNode = InitializeParents(edges);

			int totalWeight = ApplyKruskal(edges, parentByNode);

            Console.WriteLine($"Total cost of building highways: {totalWeight}");
        }

		private static int ApplyKruskal(List<Edge> edges, Dictionary<string, string> parentByNode)
		{
			int totalWeight = 0;

			foreach (var edge in edges)
			{
				string firstNodeRoot = FindRoot(edge.First, parentByNode);

				string secondNodeRoot = FindRoot(edge.Second, parentByNode);

				if (firstNodeRoot != secondNodeRoot)
				{
					totalWeight += edge.Weight;

					parentByNode[firstNodeRoot] = secondNodeRoot;
				}
			}

			return totalWeight;
		}

		private static string FindRoot(string node, Dictionary<string, string> parentByNode)
		{
			while (node != parentByNode[node])
			{
				node = parentByNode[node];
			}

			return node;
		}

		private static Dictionary<string, string> InitializeParents(List<Edge> edges)
		{
			Dictionary<string, string> parentByNode = new Dictionary<string, string>();

			foreach (var edge in edges)
			{
				string firstNode = edge.First;

				string secondNode = edge.Second;

				if (!parentByNode.ContainsKey(firstNode))
				{
					parentByNode.Add(firstNode, firstNode);
				}

				if (!parentByNode.ContainsKey(secondNode))
				{
					parentByNode.Add(secondNode, secondNode);
				}
			}

			return parentByNode;
		}

		private static List<Edge> ReadInput()
		{
			List<Edge> edges = new List<Edge>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				string[] edgeData = Console.ReadLine()
				   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

				int weight = int.Parse(edgeData[2]);

				if (edgeData.Length == 4)
				{
					weight += int.Parse(edgeData[3]);
				}

				edges.Add(new Edge()
				{
					First = edgeData[0],
					Second = edgeData[1],
					Weight = weight,
				});
			}

			return edges;
		}
	}
}
