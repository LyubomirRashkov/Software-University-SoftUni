using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.TourDeSofia
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

			int targetNode = int.Parse(Console.ReadLine());

			List<Edge>[] edgesByNode = InitializeGraph(nodesCount);

			ReadInputEdges(edgesCount, edgesByNode);

			double[] distances = InitializeDistances(edgesByNode.Length);

			OrderedBag<int> priorityQueue = new OrderedBag<int>(
				Comparer<int>.Create((x, y) => distances[x].CompareTo(distances[y])));

			foreach (var edge in edgesByNode[targetNode])
			{
				priorityQueue.Add(edge.To);

				distances[edge.To] = edge.Weight;
			}

			ApplyDijkstra(edgesByNode, distances, priorityQueue, targetNode);

			if (double.IsPositiveInfinity(distances[targetNode]))
			{
                Console.WriteLine(distances.Count(d => !double.IsPositiveInfinity(d)) + 1);
            }
			else
			{
				Console.WriteLine(distances[targetNode]);
            }
		}

		private static void ApplyDijkstra(
			List<Edge>[] graph, 
			double[] distances, 
			OrderedBag<int> priorityQueue, 
			int targetNode)
		{
			while (priorityQueue.Count > 0)
			{
				int nearestNode = priorityQueue.RemoveFirst();

				if (nearestNode == targetNode)
				{
					break;
				}

				foreach (var edge in graph[nearestNode])
				{
					int otherNode = nearestNode == edge.From ? edge.To : edge.From;

					if (double.IsPositiveInfinity(distances[otherNode]))
					{
						priorityQueue.Add(otherNode);
					}

					double newDistance = distances[nearestNode] + edge.Weight;

					if (newDistance < distances[otherNode])
					{
						distances[otherNode] = newDistance;

						priorityQueue = new OrderedBag<int>(
							priorityQueue, 
							Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
					}
				}
			}
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

		private static void ReadInputEdges(int edgesCount, List<Edge>[] graph)
		{
			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				int fromNode = edgeData[0];

				graph[fromNode].Add(new Edge()
				{
					From = fromNode,
					To = edgeData[1],
					Weight = edgeData[2],
				});
			}
		}

		private static List<Edge>[] InitializeGraph(int size)
		{
			List<Edge>[] graph = new List<Edge>[size];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<Edge>();
			}

			return graph;
		}
	}
}
