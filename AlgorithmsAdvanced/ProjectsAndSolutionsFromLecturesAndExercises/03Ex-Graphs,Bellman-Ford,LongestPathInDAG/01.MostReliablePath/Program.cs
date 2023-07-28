using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.MostReliablePath
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
			List<Edge>[] graph = ReadInputEdges();

			double[] reliabilities = InitializeReliabilities(graph.Length);

			int[] parents = InitializeParents(graph.Length);

			int start = int.Parse(Console.ReadLine());

			int destination = int.Parse(Console.ReadLine());

			ApplyDijkstra(graph, reliabilities, parents, start, destination);

			PrintResults(destination, reliabilities, parents);
		}

		private static void PrintResults(int node, double[] reliabilities, int[] parents)
		{
            Console.WriteLine($"Most reliable path reliability: {reliabilities[node]:F2}%");

			Stack<int> path = GetPath(parents, node);

            Console.WriteLine(string.Join(" -> ", path));
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
			List<Edge>[] graph, 
			double[] reliabilities, 
			int[] parents, 
			int start, 
			int destination)
		{
			reliabilities[start] = 100;

			OrderedBag<int> priorityQueue = 
				new OrderedBag<int>(Comparer<int>.Create((x, y) => reliabilities[y].CompareTo(reliabilities[x])));

			priorityQueue.Add(start);

			while (priorityQueue.Count > 0)
			{
				int minNode = priorityQueue.RemoveFirst();

				if (double.IsNegativeInfinity(reliabilities[minNode]))
				{
					break;
				}

				if (minNode == destination)
				{
					break;
				}

				foreach (var edge in graph[minNode])
				{
					int otherNode = minNode == edge.First ? edge.Second : edge.First;

					if (double.IsNegativeInfinity(reliabilities[otherNode]))
					{
						priorityQueue.Add(otherNode);
					}

					double newReliability = (reliabilities[minNode] * edge.Weight) / 100;

					if (newReliability > reliabilities[otherNode])
					{
						reliabilities[otherNode] = newReliability;

						parents[otherNode] = minNode;

						priorityQueue = new OrderedBag<int>(
							priorityQueue, 
							Comparer<int>.Create((x, y) => reliabilities[y].CompareTo(reliabilities[x])));
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

		private static double[] InitializeReliabilities(int size)
		{
			double[] arr = new double[size];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = double.NegativeInfinity;
			}

			return arr;
		}

		private static List<Edge>[] ReadInputEdges()
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<Edge>[] inputGraph = new List<Edge>[nodesCount];

			for (int i = 0; i < inputGraph.Length; i++)
			{
				inputGraph[i] = new List<Edge>();
			}

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeParts[0];

				int secondNode = edgeParts[1];

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = edgeParts[2],
				};

				inputGraph[firstNode].Add(edge);

				inputGraph[secondNode].Add(edge);
			}

			return inputGraph;
		}
	}
}
