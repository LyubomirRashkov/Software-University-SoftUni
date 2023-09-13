﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DataStreaming
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[,] graph = ReadInput();

			int[] corruptedNodes = Console.ReadLine()
				.Split(',', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int source = int.Parse(Console.ReadLine());

			int destination = int.Parse(Console.ReadLine());

			int[] parents = InitializeParents(graph.GetLength(0));

			int maxFlow = GetMaxFlow(graph, parents, corruptedNodes, source, destination);

			Console.WriteLine(maxFlow);
		}

		private static int GetMaxFlow(int[,] graph, int[] parents, int[] corruptedNodes, int source, int destination)
		{
			int maxFlow = 0;

			bool hasAugmentingPath = Bfs(source, destination, graph, parents, corruptedNodes);

			while (hasAugmentingPath)
			{
				int currentFlow = GetCurrentFlow(graph, parents, destination);

				ApplyFlow(graph, parents, destination, currentFlow);

				maxFlow += currentFlow;

				hasAugmentingPath = Bfs(source, destination, graph, parents, corruptedNodes);
			}

			return maxFlow;
		}

		private static void ApplyFlow(int[,] graph, int[] parents, int node, int currentFlow)
		{
			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				graph[previousNode, node] -= currentFlow;

				node = previousNode;
			}
		}

		private static int GetCurrentFlow(int[,] graph, int[] parents, int node)
		{
			int currentFlow = int.MaxValue;

			while (parents[node] != -1)
			{
				int previousNode = parents[node];

				int possibleFlow = graph[previousNode, node];

				if (currentFlow > possibleFlow)
				{
					currentFlow = possibleFlow;
				}

				node = previousNode;
			}

			return currentFlow;
		}

		private static bool Bfs(int source, int destination, int[,] graph, int[] parents, int[] corruptedNodes)
		{
			bool[] visited = new bool[graph.GetLength(0)];

			Queue<int> queue = new Queue<int>();

			queue.Enqueue(source);

			visited[source] = true;

			while (queue.Count > 0)
			{
				int currentNode = queue.Dequeue();

				if (corruptedNodes.Contains(currentNode))
				{
					continue;
				}

				for (int child = 0; child < graph.GetLength(1); child++)
				{
					if (!visited[child] && graph[currentNode, child] > 0)
					{
						queue.Enqueue(child);

						visited[child] = true;

						parents[child] = currentNode;
					}
				}
			}

			return visited[destination];
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			Array.Fill(arr, -1);

			return arr;
		}

		private static int[,] ReadInput()
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int[,] inputGraph = new int[nodesCount, nodesCount];

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				inputGraph[edgeData[0], edgeData[1]] = edgeData[2];
			}

			return inputGraph;
		}
	}
}
