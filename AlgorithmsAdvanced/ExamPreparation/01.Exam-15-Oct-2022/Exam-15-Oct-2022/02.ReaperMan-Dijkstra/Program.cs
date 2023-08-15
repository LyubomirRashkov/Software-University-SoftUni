using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.ReaperMan
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int edgesCount = int.Parse(Console.ReadLine());

			int[] targetNodes = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int start = targetNodes[0];

			int destination = targetNodes[1];

			Dictionary<int, Dictionary<int, int>> graph = ReadInputEdges(nodesCount, edgesCount);

			double[] distances = InitializeDistances(nodesCount);

			int[] parents = InitializeParents(nodesCount);

			ApplyDijksta(graph, distances, parents, start, destination);

			if (!double.IsPositiveInfinity(distances[destination]))
			{
				PrintResult(parents, destination, distances);
			}
		}

		private static Dictionary<int, Dictionary<int, int>> ReadInputEdges(int nodesCount, int edgesCount)
		{
			Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

			for (int i = 0; i < nodesCount; i++)
			{
				graph[i] = new Dictionary<int, int>();
			}

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

		private static void PrintResult(int[] parents, int node, double[] distances)
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

		private static void ApplyDijksta(
			Dictionary<int, Dictionary<int, int>> graph,
			double[] distances,
			int[] parents,
			int startNode,
			int endNode)
		{
			OrderedBag<int> priorityQueue =
				new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));

			if (startNode != endNode)
			{
				distances[startNode] = 0;

				priorityQueue.Add(startNode);
			}
			else
			{
				foreach (var innerKVP in graph[startNode])
				{
					distances[innerKVP.Key] = innerKVP.Value;

					priorityQueue.Add(innerKVP.Key);

					parents[innerKVP.Key] = startNode;
				}
			}

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

				foreach (var kvp in graph[nearestNode])
				{
					int otherNode = kvp.Key;

					if (double.IsPositiveInfinity(distances[otherNode]))
					{
						priorityQueue.Add(otherNode);
					}

					double newDistance = distances[nearestNode] + kvp.Value;

					if (newDistance < distances[otherNode])
					{
						distances[otherNode] = newDistance;

						parents[otherNode] = nearestNode;

						priorityQueue = new OrderedBag<int>(
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
	}
}
