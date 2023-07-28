using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Undefined
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

			int source = int.Parse(Console.ReadLine());

			int destination = int.Parse(Console.ReadLine());

			double[] weights = InitializeWeights(nodesCount + 1);

			int[] parents = InitializeParents(nodesCount + 1);

			bool hasNegativeCycle = false;

			ApplyBellmanFord(edges, weights, parents, nodesCount, source, ref hasNegativeCycle);

			if (hasNegativeCycle)
			{
                Console.WriteLine("Undefined");
            }
			else
			{
				Stack<int> path = GetPath(parents, destination);

                Console.WriteLine(string.Join(' ', path));

				Console.WriteLine(weights[destination]);
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
			double[] weights, 
			int[] parents, 
			int nodesCount, 
			int source, 
			ref bool hasNegativeCycle)
		{
			weights[source] = 0;

			for (int i = 0; i < nodesCount - 1; i++)
			{
				bool hasUpdatedWeights = false;

				foreach (var edge in edges)
				{
					if (!double.IsPositiveInfinity(weights[edge.From]))
					{
						double newWeight = weights[edge.From] + edge.Weight;

						if (newWeight < weights[edge.To])
						{
							weights[edge.To] = newWeight;

							parents[edge.To] = edge.From;

							hasUpdatedWeights = true;
						}
					}
				}

				if (!hasUpdatedWeights)
				{
					break;
				}
			}

			foreach (var edge in edges)
			{
				double newWeight = weights[edge.From] + edge.Weight;

				if (newWeight < weights[edge.To])
				{
					hasNegativeCycle = true;
				}
			}
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			Array.Fill(arr, -1);

			return arr;
		}

		private static double[] InitializeWeights(int size)
		{
			double[] arr = new double[size];

			Array.Fill(arr, double.PositiveInfinity);

			return arr;
		}

		private static List<Edge> ReadInputEdges()
		{
			List<Edge> inputEdges = new List<Edge>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				inputEdges.Add(new Edge()
				{
					From = edgeParts[0],
					To = edgeParts[1],
					Weight = edgeParts[2],
				});
			}

			return inputEdges;
		}
	}
}
