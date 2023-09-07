using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.VampireLabyrinth
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
			Dictionary<int, Dictionary<int, int>> graph = InitializeGraph();

			int edgesCount = int.Parse(Console.ReadLine());

			int[] startAndEnd = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int startNode = startAndEnd[0];

			int endNode = startAndEnd[1];

			ReadInputEdges(graph, edgesCount);

			List<Edge>[] edgesByNode = ConvertToArrayOfLists(graph);

			double[] distances = InitializeDistances(edgesByNode.Length);

			int[] parents = InitializeParents(edgesByNode.Length);

			ApplyDijkstra(edgesByNode, distances, parents, startNode, endNode);

			PrintResult(parents, endNode, distances);
		}

		private static void PrintResult(int[] parents, int node, double[] distances)
		{
			Stack<int> path = GetPath(parents, node);

            Console.WriteLine(string.Join(' ', path));

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

		private static void ApplyDijkstra(
			List<Edge>[] edgesByNode, 
			double[] distances, 
			int[] parents, 
			int startNode, 
			int endNode)
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

				foreach (var edge in edgesByNode[nearestNode])
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

			Array.Fill(arr, -1);

			return arr;
		}

		private static double[] InitializeDistances(int size)
		{
			double[] arr = new double[size];

			Array.Fill(arr, double.PositiveInfinity);

			return arr;
		}

		private static List<Edge>[] ConvertToArrayOfLists(Dictionary<int, Dictionary<int, int>> graph)
		{
			List<Edge>[] edgesByNode = new List<Edge>[graph.Count];

			for (int i = 0; i < edgesByNode.Length; i++)
			{
				edgesByNode[i] = new List<Edge>();
			}

			foreach (var outerKVP in graph)
			{
				foreach (var innerKVP in outerKVP.Value)
				{
					Edge edge = new Edge()
					{
						First = outerKVP.Key,
						Second = innerKVP.Key,
						Weight = innerKVP.Value,
					};

					edgesByNode[outerKVP.Key].Add(edge);
				}
			}

			return edgesByNode;
		}

		private static void ReadInputEdges(Dictionary<int, Dictionary<int, int>> graph, int edgesCount)
		{
			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				graph[edgeData[0]][edgeData[1]] = edgeData[2];

				graph[edgeData[1]][edgeData[0]] = edgeData[2];
			}
		}

		private static Dictionary<int, Dictionary<int, int>> InitializeGraph()
		{
			Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

			int nodesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < nodesCount; i++)
			{
				graph.Add(i, new Dictionary<int, int>());
			}

			return graph;
		}
	}
}
