using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.TrainsPartTwo
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
			List<Edge>[] graph = InitializeGraph();

			int edgesCount = int.Parse(Console.ReadLine());

			int[] startAndEnd = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int startNode = startAndEnd[0];

			int endNode = startAndEnd[1];

			ReadInputEdges(graph, edgesCount);

			double[] distances = InitializeDistances(graph.Length);

			int[] parents = InitializeParents(graph.Length);

			ApplyDijkstra(graph, distances, parents, startNode, endNode);

			PrintResult(distances, parents, endNode);
		}

		private static void PrintResult(double[] distances, int[] parents, int node)
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

		private static void ApplyDijkstra(List<Edge>[] graph, double[] distances, int[] parents, int startNode, int endNode)
		{
			distances[startNode] = 0;

			OrderedBag<int> priorityQueue = 
				new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));

			priorityQueue.Add(startNode);

			while (priorityQueue.Count > 0)
			{
				int nearestNode = priorityQueue.RemoveFirst();

				if (double.IsPositiveInfinity(distances[nearestNode]))
				{
					break;
				}

				if (nearestNode == endNode)
				{
					break;
				}

				foreach (var edge in graph[nearestNode])
				{
					int otherNode = nearestNode == edge.First ? edge.Second : edge.First;

					if (double.IsPositiveInfinity(distances[otherNode]))
					{
						priorityQueue.Add(otherNode);
					}

					double newDistance = distances[nearestNode] + edge.Weight;

					if (newDistance < distances[otherNode])
					{
						distances[otherNode] = newDistance;

						parents[otherNode] = nearestNode;

						priorityQueue = 
							new OrderedBag<int>(
								priorityQueue, 
								Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
					}
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

		private static void ReadInputEdges(List<Edge>[] graph, int edgesCount)
		{
			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeData[0];

				int secondNode = edgeData[1];

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = edgeData[2],
				};

				graph[firstNode].Add(edge);

				graph[secondNode].Add(edge);
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
