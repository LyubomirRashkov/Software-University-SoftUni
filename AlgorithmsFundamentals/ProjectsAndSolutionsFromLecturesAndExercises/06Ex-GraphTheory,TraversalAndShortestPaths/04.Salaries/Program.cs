using System;
using System.Collections.Generic;

namespace _04.Salaries
{
	public class Program
	{
		private static List<int>[] graph;
		private static Dictionary<int, int> visitedNodesWithSalaries;

		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			graph = new List<int>[nodesCount];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<int>();

				string input = Console.ReadLine();

				for (int j = 0; j < input.Length; j++)
				{
					if (input[j] == 'Y')
					{
						graph[i].Add(j);
					}
				}
			}

			visitedNodesWithSalaries = new Dictionary<int, int>();

			int salary = 0;

			for (int i = 0; i < graph.Length; i++)
			{
				salary += Dfs(i);
			}

			Console.WriteLine(salary);
		}

		private static int Dfs(int node)
		{
			if (visitedNodesWithSalaries.ContainsKey(node))
			{
				return visitedNodesWithSalaries[node];
			}

			int salary = 0;

			if (graph[node].Count == 0)
			{
				salary += 1;
			}
			else
			{
				foreach (var child in graph[node])
				{
					salary += Dfs(child);
				}
			}

			visitedNodesWithSalaries.Add(node, salary);

			return salary;
		}
	}
}
