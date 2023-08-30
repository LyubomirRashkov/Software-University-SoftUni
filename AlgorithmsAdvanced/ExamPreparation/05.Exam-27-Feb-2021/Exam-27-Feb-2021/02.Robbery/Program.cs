using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.Robbery
{
	public class Edge
	{
		public int First { get; set; }

		public int Second { get; set; }

		public int Weight { get; set; }
	}

	public class Program
	{
		private const char WorkingCameraSymbol = 'w';

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<Edge>[] graph = new List<Edge>[nodesCount];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<Edge>();
			}

			ReadInputEdges(graph);

			char[] cameras = new char[nodesCount];

			ReadInputCameras(cameras);

			int startNode = int.Parse(Console.ReadLine());

			int endNode = int.Parse(Console.ReadLine());

			double[] distances = InitializeDistances(nodesCount);

			ApplyDijkstra(graph, distances, cameras, startNode, endNode);

			Console.WriteLine(distances[endNode]);
        }

		private static void ApplyDijkstra(
			List<Edge>[] graph,
			double[] distances, 
			char[] cameras, 
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

				if (nearestNode == endNode)
				{
					break;
				}

				foreach (var edge in graph[nearestNode])
				{
					int otherNode = nearestNode == edge.First ? edge.Second : edge.First;

					if (cameras[otherNode] == WorkingCameraSymbol)
					{
						continue;
					}

					if (double.IsPositiveInfinity(distances[otherNode]))
					{
						priorityQueue.Add(otherNode);
					}

					double newDistance = distances[nearestNode] + edge.Weight;

					if (newDistance < distances[otherNode])
					{
						distances[otherNode] = newDistance;

						priorityQueue = 
							new OrderedBag<int>(
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

		private static void ReadInputCameras(char[] cameras)
		{
			string[] inputInfo = Console.ReadLine()
				.Split();

			foreach (var item in inputInfo)
			{
				int node = int.Parse(item.Substring(0, item.Length - 1));

				char symbol = item[item.Length - 1];

				cameras[node] = symbol;
			}
		}

		private static void ReadInputEdges(List<Edge>[] graph)
		{
			int edgesCount = int.Parse(Console.ReadLine());

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
	}
}
