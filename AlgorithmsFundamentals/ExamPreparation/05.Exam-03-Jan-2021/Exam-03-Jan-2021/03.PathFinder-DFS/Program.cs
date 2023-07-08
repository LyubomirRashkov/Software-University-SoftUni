using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PathFinder
{
	public class Program
	{
		private static List<int>[] graph;
		private static bool[] visited;

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			graph = new List<int>[nodesCount];

			for (int i = 0; i < nodesCount; i++)
			{
				string input = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(input))
				{
					graph[i] = new List<int>();

					continue;
				}

				graph[i] = input
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToList();
			}

			int pathsCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < pathsCount; i++)
			{
				int[] nodesOfPath = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				visited = new bool[nodesCount];

				int startPathIndex = 0;

				int startNode = nodesOfPath[startPathIndex];

				Dfs(startNode, nodesOfPath , startPathIndex);

				if (PathExists(nodesOfPath))
				{
                    Console.WriteLine("yes");
                }
				else
				{
                    Console.WriteLine("no");
                }
			}
		}

		private static void Dfs(int node, int[] path, int pathIndex)
		{
			if (visited[node]
				|| pathIndex >= path.Length
				|| node != path[pathIndex])    
			{
				return;
			}

			visited[node] = true;

			foreach (var child in graph[node])
			{
				Dfs(child, path, pathIndex + 1);
			}
		}

		private static bool PathExists(int[] path)
		{
			foreach (var node in path)
			{
				if (!visited[node])
				{
					return false;
				}
			}

			return true;
		}
	}
}
