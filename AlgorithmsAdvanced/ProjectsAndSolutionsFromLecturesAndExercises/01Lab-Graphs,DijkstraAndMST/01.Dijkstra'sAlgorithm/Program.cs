using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.Dijkstra_sAlgorithm
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
			Dictionary<int, List<Edge>> edgesByNode = ReadInputEdges();

			int biggestNode = edgesByNode.Keys.Max();

			double[] distances = InitializeDistances(biggestNode);

			int[] parents = InitializeParents(biggestNode);

			int startNode = int.Parse(Console.ReadLine());

			int endNode = int.Parse(Console.ReadLine());

			ApplyDijkstra(edgesByNode, distances, parents, startNode, endNode);

			PrintResult(distances, endNode, parents);
		}

		private static void PrintResult(double[] distances, int node, int[] parents)
		{
			if (double.IsPositiveInfinity(distances[node]))
			{
                Console.WriteLine("There is no such path.");
            }
			else
			{
				Console.WriteLine(distances[node]);

				Stack<int> path = GetPath(parents, node);

                Console.WriteLine(string.Join(" ", path));
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

		private static void ApplyDijkstra(
			Dictionary<int, List<Edge>> edgesByNode, 
			double[] distances, 
			int[] parents, 
			int startNode, 
			int endNode)
		{
			distances[startNode] = 0;

			OrderedBag<int> priorityQueue = 
				new OrderedBag<int>(Comparer<int>.Create((x, y) => (int) (distances[x] - distances[y])));

			priorityQueue.Add(startNode);

			while (priorityQueue.Count > 0)
			{
				int minNode = priorityQueue.RemoveFirst();

				if (double.IsPositiveInfinity(distances[minNode]))
				{
					break;
				}

				if (minNode == endNode)
				{
					break;
				}

				foreach (var edge in edgesByNode[minNode])
				{
					int otherNode = minNode == edge.First ? edge.Second : edge.First;

					if (double.IsPositiveInfinity(distances[otherNode]))
					{
						priorityQueue.Add(otherNode);
					}

					double newDistance = distances[minNode] + edge.Weight;

					if (newDistance < distances[otherNode])
					{
						distances[otherNode] = newDistance;

						parents[otherNode] = minNode;

						priorityQueue = new OrderedBag<int>(
							priorityQueue, 
							Comparer<int>.Create((x, y) => (int)(distances[x] - distances[y])));
					}
				}
			}
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size + 1];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = -1;
			}

			return arr;
		}

		private static double[] InitializeDistances(int size)
		{
			double[] arr = new double[size + 1];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = double.PositiveInfinity;
			}

			return arr;
		}

		private static Dictionary<int, List<Edge>> ReadInputEdges()
		{
			Dictionary<int, List<Edge>> edgesByNode = new Dictionary<int, List<Edge>>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeParts[0];

				int secondNode = edgeParts[1];

				if (!edgesByNode.ContainsKey(firstNode))
				{
					edgesByNode.Add(firstNode, new List<Edge>());
				}

				if (!edgesByNode.ContainsKey(secondNode))
				{
					edgesByNode.Add(secondNode, new List<Edge>());
				}

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = edgeParts[2],
				};

				edgesByNode[firstNode].Add(edge);

				edgesByNode[secondNode].Add(edge);
			}

			return edgesByNode;
		}
	}
}
