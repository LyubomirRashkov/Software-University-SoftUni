using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BlackMesa
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<int>[] graph = new List<int>[nodesCount + 1];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<int>();
			}

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] parts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int fromNode = parts[0];

				int toNode = parts[1];

				graph[fromNode].Add(toNode);
			}

			int startNode = int.Parse(Console.ReadLine());

			int destinationNode = int.Parse(Console.ReadLine());

			bool[] visited = new bool[graph.Length];

			int[] parents = new int[graph.Length];

			Array.Fill(parents, -1);

			BfsPathFinder(startNode, destinationNode, graph, visited, parents);

			Array.Fill(visited, false);

			BfsTraverseAll(startNode, graph, visited);

			SortedSet<int> unreachableNodes = new SortedSet<int>();

			for (int i = 1; i < graph.Length; i++)
			{
				if (!visited[i])
				{
					unreachableNodes.Add(i);
				}
			}

            if (unreachableNodes.Count > 0)
			{
                Console.WriteLine(string.Join(' ', unreachableNodes));
            }
        }

		private static void BfsTraverseAll(int startNode, List<int>[] graph, bool[] visited)
		{
			Queue<int> queue = new Queue<int>();

			queue.Enqueue(startNode);

			visited[startNode] = true;

			while (queue.Count > 0)
			{
				int node = queue.Dequeue();

				foreach (var child in graph[node])
				{
					if (!visited[child])
					{
						queue.Enqueue(child);

						visited[child] = true;
					}
				}
			}
		}

		private static void BfsPathFinder(
			int startNode, 
			int destinationNode, 
			List<int>[] graph, 
			bool[] visited, 
			int[] parents)
		{
			Queue<int> queue = new Queue<int>();

			queue.Enqueue(startNode);

			visited[startNode] = true;

			while (queue.Count > 0)
			{
				int node = queue.Dequeue();

				if (node == destinationNode)
				{
					Stack<int> path = GetPath(destinationNode, parents);

                    Console.WriteLine(string.Join(' ', path));

					break;
                }

				foreach (var child in graph[node])
				{
					if (!visited[child])
					{
						queue.Enqueue(child);

						visited[child] = true;

						parents[child] = node;
					}
				}
			}
		}

		private static Stack<int> GetPath(int node, int[] parents)
		{
			Stack<int> path = new Stack<int>();

			int currentNode = node;

			while (currentNode != -1)
			{
				path.Push(currentNode);

				currentNode = parents[currentNode];
			}

			return path;
		}
	}
}
