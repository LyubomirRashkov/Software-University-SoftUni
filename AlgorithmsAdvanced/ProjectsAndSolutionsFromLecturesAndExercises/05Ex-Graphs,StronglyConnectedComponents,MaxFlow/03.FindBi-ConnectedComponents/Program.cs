using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FindBi_ConnectedComponents
{
	public class Program
	{
		private static List<int>[] graph;

		private static int[] depths;

		private static int[] lowpoints;

		private static bool[] visited;

		private static int[] parents;

		private static Stack<int> componentElements;

		private static List<HashSet<int>> components;

		public static void Main(string[] args)
		{
			ReadInput();

			int componentsCount = GetComponentsCount();

			Console.WriteLine($"Number of bi-connected components: {componentsCount}");
		}

		private static int GetComponentsCount()
		{
			visited = new bool[graph.Length];

			depths = new int[graph.Length];

			lowpoints = new int[graph.Length];

			parents = InitializeParents();

			componentElements = new Stack<int>();

			components = new List<HashSet<int>>();

			for (int i = 0; i < graph.Length; i++)
			{
				if (!visited[i])
				{
					FindArticulationPoints(i, 1);

					components.Add(componentElements.ToHashSet());
				}
			}

			return components.Count;
		}

		private static void FindArticulationPoints(int node, int nodeDepth)
		{
			visited[node] = true;

			depths[node] = nodeDepth;

			lowpoints[node] = depths[node];

			int childrenCount = 0;

			foreach (var child in graph[node])
			{
				componentElements.Push(node);

				componentElements.Push(child);

				if (!visited[child])
				{
					parents[child] = node;

					FindArticulationPoints(child, nodeDepth + 1);

					childrenCount++;

					bool isArticulationPoint = (parents[node] == -1 && childrenCount > 1)
											   || (parents[node] != -1 && lowpoints[child] >= depths[node]);

					if (isArticulationPoint)
					{
						HashSet<int> currentComponentElements = new HashSet<int>();

						while (true)
						{
							int componentChild = componentElements.Pop();

							currentComponentElements.Add(componentChild);

							int componentNode = componentElements.Pop();

							currentComponentElements.Add(componentNode);

							if (componentChild == child && componentNode == node)
							{
								break;
							}
						}

						components.Add(currentComponentElements);
					}

					lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
				}
				else if (parents[node] != child && depths[child] < lowpoints[node])
				{
					lowpoints[node] = depths[child];
				}
			}
		}

		private static int[] InitializeParents()
		{
			int[] arr = new int[graph.Length];

			Array.Fill(arr, -1);

			return arr;
		}

		private static void ReadInput()
		{
			InitializeGraph();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeParts[0];

				int secondNode = edgeParts[1];

				graph[firstNode].Add(secondNode);

				graph[secondNode].Add(firstNode);
			}
		}

		private static void InitializeGraph()
		{
			int nodesCount = int.Parse(Console.ReadLine());

			graph = new List<int>[nodesCount];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<int>();
			}
		}
	}
}
