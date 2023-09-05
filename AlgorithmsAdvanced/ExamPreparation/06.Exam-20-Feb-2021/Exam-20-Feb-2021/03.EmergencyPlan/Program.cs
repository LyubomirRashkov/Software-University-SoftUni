using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03.EmergencyPlan
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
			int nodesCount = int.Parse(Console.ReadLine());

			List<Edge>[] graph = InitializeGraph(nodesCount);

			int[] exitNodes = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			ReadInputEdges(graph);

			int exitTime = ConvertToSeconds(Console.ReadLine());

			Dictionary<int, int> timesToExitByNode = InitializeTimesToExitByNode(nodesCount, exitNodes);

			FindTimesToNearestExit(graph, timesToExitByNode, exitNodes);

			PrintResult(timesToExitByNode, exitTime);
		}

		private static void PrintResult(Dictionary<int, int> timesToExitByNode, int exitTime)
		{
			foreach (var kvp in timesToExitByNode)
			{
				if (kvp.Value == int.MaxValue)
				{
					Console.WriteLine($"Unreachable {kvp.Key} (N/A)");
				}
				else if (kvp.Value > exitTime)
				{
					string time = ConvertFromSeconds(kvp.Value);

					Console.WriteLine($"Unsafe {kvp.Key} ({time})");
				}
				else
				{
					string time = ConvertFromSeconds(kvp.Value);

					Console.WriteLine($"Safe {kvp.Key} ({time})");
				}
			}
		}

		private static string ConvertFromSeconds(int timeInSeconds)
		{
			int seconds = timeInSeconds % 60;

			int minutes = timeInSeconds / 60;

			int hours = 0;

			if (minutes > 59)
			{
				hours = minutes / 60;

				minutes %= 60;
			}

			string str = $"{hours:d2}:{minutes:d2}:{seconds:d2}";

			return str;
		}

		private static void FindTimesToNearestExit(
			List<Edge>[] graph,
			Dictionary<int, int> timesToExitByNode,
			int[] exitNodes)
		{
			for (int i = 0; i < graph.Length; i++)
			{
				if (exitNodes.Contains(i))
				{
					continue;
				}

				double[] distances = InitializeDistances(graph.Length);

				ApplyDijkstra(graph, distances, i, exitNodes);

				foreach (var exitNode in exitNodes)
				{
					if (timesToExitByNode[i] > distances[exitNode])
					{
						timesToExitByNode[i] = (int)distances[exitNode];
					}
				}
			}
		}

		private static void ApplyDijkstra(
			List<Edge>[] graph,
			double[] distances,
			int startNode,
			int[] exitNodes)
		{
			distances[startNode] = 0;

			OrderedBag<int> priorityQueue =
					new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));

			priorityQueue.Add(startNode);

			while (priorityQueue.Count > 0)
			{
				int nearestNode = priorityQueue.RemoveFirst();

				if (exitNodes.Contains(nearestNode))
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

		private static Dictionary<int, int> InitializeTimesToExitByNode(int nodesCount, int[] exitNodes)
		{
			Dictionary<int, int> timesToExitByNode = new Dictionary<int, int>();

			for (int i = 0; i < nodesCount; i++)
			{
				if (exitNodes.Contains(i))
				{
					continue;
				}

				timesToExitByNode.Add(i, int.MaxValue);
			}

			return timesToExitByNode;
		}

		private static void ReadInputEdges(List<Edge>[] graph)
		{
			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				string[] edgeData = Console.ReadLine().Split();

				int firstNode = int.Parse(edgeData[0]);

				int secondNode = int.Parse(edgeData[1]);

				int weight = ConvertToSeconds(edgeData[2]);

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = weight,
				};

				graph[firstNode].Add(edge);

				graph[secondNode].Add(edge);
			}
		}

		private static int ConvertToSeconds(string str)
		{
			int[] parts = str
				.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int seconds = (parts[0] * 60) + parts[1];

			return seconds;
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
