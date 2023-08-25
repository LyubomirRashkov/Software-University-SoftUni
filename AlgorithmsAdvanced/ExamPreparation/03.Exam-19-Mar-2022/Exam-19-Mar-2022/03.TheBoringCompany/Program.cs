using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03.TheBoringCompany
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

			int edgesCount = int.Parse(Console.ReadLine());

			int connectedDisticts = int.Parse(Console.ReadLine());

			List<Edge>[] graph = InitializeGraph(nodesCount);

			ReadInputEdges(graph, edgesCount);

			HashSet<int> spanningTree = ReadInputNodes(connectedDisticts);

			int requiredBudget = ApplyPrim(graph, spanningTree);

            Console.WriteLine($"Minimum budget: {requiredBudget}");
        }

		private static int ApplyPrim(List<Edge>[] graph, HashSet<int> spanningTree)
		{
			int budget = 0;

			OrderedBag<Edge> priorityQueue = 
				new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

			foreach (var node in spanningTree)
			{
				priorityQueue.AddMany(graph[node]);
			}

			while (priorityQueue.Count > 0)
			{
				Edge edge = priorityQueue.RemoveFirst();

				int nonTreeNode = -1;

				if (spanningTree.Contains(edge.First) && !spanningTree.Contains(edge.Second))
				{
					nonTreeNode = edge.Second;
				}

				if (!spanningTree.Contains(edge.First) && spanningTree.Contains(edge.Second))
				{
					nonTreeNode = edge.First;
				}

				if (nonTreeNode != -1)
				{
					budget += edge.Weight;

					spanningTree.Add(nonTreeNode);

					priorityQueue.AddMany(graph[nonTreeNode]);
				}
			}

			return budget;
 		}

		private static HashSet<int> ReadInputNodes(int size)
		{
			HashSet<int> spanningTree = new HashSet<int>();

			for (int i = 0; i < size; i++)
			{
				int[] nodesData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				spanningTree.Add(nodesData[0]);

				spanningTree.Add(nodesData[1]);
			}

			return spanningTree;
		}

		private static void ReadInputEdges(List<Edge>[] graph, int size)
		{
			for (int i = 0; i < size; i++)
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

		private static List<Edge>[] InitializeGraph(int size)
		{
			List<Edge>[] graph = new List<Edge>[size];

			for (int i = 0; i < size; i++)
			{
				graph[i] = new List<Edge>();
			}

			return graph;
		}
	}
}
