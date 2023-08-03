using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ArticulationPoints
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
			int nodesCount = int.Parse(Console.ReadLine());

			graph = InitializeGraph(nodesCount);

			ReadInput();

			GetArticulationPoints();

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

		private static void GetArticulationPoints()
		{
			visited = new bool[graph.Length];

			depths = new int[graph.Length];

			lowpoints = new int[graph.Length];

			parents = InitializeParents(graph.Length);

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

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			Array.Fill(arr, -1);

			return arr;
		}

		private static void ReadInput()
		{
			int linesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < linesCount; i++)
			{
				int[] inputNumbers = Console.ReadLine()
					.Split(", ", StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				//int firstNode = inputNumbers[0];

				//graph[firstNode].AddRange(inputNumbers.Skip(1));

				//for (int j = 1; j < inputNumbers.Length; j++)
				//{
				//	graph[inputNumbers[j]].Add(firstNode);
				//}

				graph[inputNumbers[0]].AddRange(inputNumbers.Skip(1));
			}
		}

		private static List<int>[] InitializeGraph(int size)
		{
			List<int>[] graph = new List<int>[size];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<int>();
			}

			return graph;
		}
	}
}
