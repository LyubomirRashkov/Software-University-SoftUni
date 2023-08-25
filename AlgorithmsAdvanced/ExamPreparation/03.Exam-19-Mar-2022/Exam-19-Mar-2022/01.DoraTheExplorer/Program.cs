using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.DoraTheExplorer
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
			Dictionary<int, List<Edge>> graph = ReadInputEdges();

			int minutesAtNode = int.Parse(Console.ReadLine());

			int startNode = int.Parse(Console.ReadLine());

			int endNode = int.Parse(Console.ReadLine());

			int cellsRequired = graph.Keys.Max() + 1;

			double[] distances = InitializeDistances(cellsRequired);

			int[] parents = InitializeParents(cellsRequired);

			ApplyDijkstra(graph, distances, parents, minutesAtNode, startNode, endNode);

			PrintResult(distances, parents, endNode, minutesAtNode);
        }

		private static void PrintResult(double[] distances, int[] parents, int node, int minutesAtNode)
		{
            Console.WriteLine($"Total time: {distances[node] - minutesAtNode}");

			Stack<int> path = GetPath(parents, node);

            Console.WriteLine(string.Join(Environment.NewLine, path));
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
			Dictionary<int, List<Edge>> graph,
			double[] distances, 
			int[] parents, 
			int minutesAtNode, 
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

					if (double.IsPositiveInfinity(distances[otherNode]))
					{
						priorityQueue.Add(otherNode);
					}

					double newDistance = distances[nearestNode] + edge.Weight + minutesAtNode;

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

		private static Dictionary<int, List<Edge>> ReadInputEdges()
		{
			Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeData[0];

				int secondNode = edgeData[1];

				int weight = edgeData[2];

				if (!graph.ContainsKey(firstNode))
				{
					graph.Add(firstNode, new List<Edge>());
				}

				if (!graph.ContainsKey(secondNode))
				{
					graph.Add(secondNode, new List<Edge>());
				}

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = weight,
				};

				graph[firstNode].Add(edge);

				graph[secondNode].Add(edge);
			}

			return graph;
		}
	}
}
