using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PathFinder
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			List<int>[] graph = new List<int>[nodesCount];

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

				bool isPathValid = CheckIfPathExists(nodesOfPath, graph);

				if (isPathValid)
				{
                    Console.WriteLine("yes");
                }
				else
				{
                    Console.WriteLine("no");
                }
			}
		}

		private static bool CheckIfPathExists(int[] nodesOfPath, List<int>[] graph)
		{
			for (int i = 0; i < nodesOfPath.Length - 1; i++)
			{
				int parent = nodesOfPath[i];

				int child = nodesOfPath[i + 1];

				if (!graph[parent].Contains(child))
				{
					return false;
				}
			}

			return true;
		}
	}
}
