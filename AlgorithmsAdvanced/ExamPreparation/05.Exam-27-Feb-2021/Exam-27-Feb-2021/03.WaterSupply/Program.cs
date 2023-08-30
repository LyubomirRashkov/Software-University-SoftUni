using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WaterSupply
{
	public class Program
	{
		private static List<int>[] graph;

		private static bool[] visited;

		private static int[] depths;

		private static int[] lowpoints;

		private static int[] parents;

		private static List<int> articulationPoints;

		public static void Main(string[] args)
		{
			InitializeGraph();

			int targetComponentsCount = int.Parse(Console.ReadLine());

			ReadInput();

			GetArticulationPoints();

			PrintResult(targetComponentsCount);
		}

		private static void PrintResult(int targetComponentsCount)
		{
			int output = 0;

			foreach (var point in articulationPoints)
			{
				int componentsCount = 0;

				visited = new bool[graph.Length];

				for (int i = 1; i < graph.Length; i++)
				{
					if (i == point || visited[i])
					{
						continue;
					}

					componentsCount++;

					Dfs(i, point);
				}

				if (componentsCount == targetComponentsCount)
				{
					output = point;
				}
			}

			Console.WriteLine(output);
		}

		private static void Dfs(int node, int point)
		{
			if (visited[node])
			{
				return;
			}

			visited[node] = true;

			foreach (var child in graph[node])
			{
				if (child != point)
				{
					Dfs(child, point);
				}
			}
		}

		private static void GetArticulationPoints()
		{
			visited = new bool[graph.Length];

			depths = new int[graph.Length];

			lowpoints = new int[graph.Length];

			parents = InitializeParents();

			articulationPoints = new List<int>();

			for (int i = 0; i < graph.Length; i++)
			{
				if (!visited[i])
				{
					FindArticulationPoints(i, 1);
				}
			}
		}

		private static void FindArticulationPoints(int node, int nodeDepth)
		{
			visited[node] = true;

			depths[node] = nodeDepth;

			lowpoints[node] = depths[node];

			int childrenCount = 0;

			bool isArticulationPoint = false;

			foreach (var child in graph[node])
			{
				if (!visited[child])
				{
					parents[child] = node;

					FindArticulationPoints(child, nodeDepth + 1);

					childrenCount++;

					lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);

					if (lowpoints[child] >= depths[node])
					{
						isArticulationPoint = true;
					}
				}
				else if (parents[node] != child)
				{
					lowpoints[node] = Math.Min(lowpoints[node], depths[child]);
				}
			}

			if ((parents[node] == -1 && childrenCount > 1)
				|| (parents[node] != -1 && isArticulationPoint))
			{
				articulationPoints.Add(node);
			}
		}

		private static int[] InitializeParents()
		{
			int[] arr = new int[graph.Length];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = -1;
			}

			return arr;
		}

		private static void ReadInput()
		{
			for (int i = 1; i < graph.Length; i++)
			{
				List<int> inputNodes = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToList();

				graph[i].AddRange(inputNodes);
			}
		}

		private static void InitializeGraph()
		{
			int nodesCount = int.Parse(Console.ReadLine());

			graph = new List<int>[nodesCount + 1];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<int>();
			}
		}
	}
}