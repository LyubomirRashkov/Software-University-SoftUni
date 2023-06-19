using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BreakCycles
{
	public class Edge
	{
		public Edge(string first, string second)
		{
			this.First = first;
			this.Second = second;
		}

		public string First { get; set; }

		public string Second { get; set; }
	}

	public class Program
	{
		private static Dictionary<string, List<string>> graph;
		private static List<Edge> edges;

		public static void Main(string[] args)
		{
			ReadInput();

			List<Edge> removedEdges = RemoveEdges();

			PrintOutput(removedEdges);
        }

		private static void ReadInput()
		{
			graph = new Dictionary<string, List<string>>();

			edges = new List<Edge>();

			int nodesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < nodesCount; i++)
			{
				string[] parts = Console.ReadLine()
					.Split("->", StringSplitOptions.RemoveEmptyEntries)
					.Select(x => x.Trim())
					.ToArray();

				string node = parts[0];

				if (!graph.ContainsKey(node))
				{
					graph.Add(node, new List<string>());
				}

				if (parts.Length > 1)
				{
					string[] children = parts[1]
						.Split(' ', StringSplitOptions.RemoveEmptyEntries);

					foreach (var child in children)
					{
						if (!graph.ContainsKey(child))
						{
							graph.Add(child, new List<string>());
						}

						Edge edge = new Edge(node, child);

						edges.Add(edge);
					}

					graph[node].AddRange(children);
				}
			}

			edges = edges
				.OrderBy(e => e.First)
				.ThenBy(e => e.Second)
				.ToList();
		}

		private static List<Edge> RemoveEdges()
		{
			List<Edge> removedEdges = new List<Edge>();

			foreach (var edge in edges)
			{
				bool isSuccessfullyRemoved = graph[edge.First].Remove(edge.Second)
					&& graph[edge.Second].Remove(edge.First);

				if (!isSuccessfullyRemoved)
				{
					continue;
				}

				bool areNodesReachable = Bfs(edge.First, edge.Second);

				if (areNodesReachable)
				{
					removedEdges.Add(edge);
				}
				else
				{
					graph[edge.First].Add(edge.Second);

					graph[edge.Second].Add(edge.First);
				}
			}

			return removedEdges;
		}

		private static bool Bfs(string start, string destination)
		{
			HashSet<string> visited = new HashSet<string>();

			Queue<string> queue = new Queue<string>();

			visited.Add(start);

			queue.Enqueue(start);

			while (queue.Count > 0)
			{
				string node = queue.Dequeue();

				if (node == destination)
				{
					return true;
				}

				foreach (var child in graph[node])
				{
					if (!visited.Contains(child))
					{
						visited.Add(child);

						queue.Enqueue(child);
					}
				}
			}

			return false;
		}

		private static void PrintOutput(List<Edge> removedEdges)
		{
			Console.WriteLine($"Edges to remove: {removedEdges.Count}");

			foreach (var edge in removedEdges)
			{
				Console.WriteLine($"{edge.First} - {edge.Second}");
			}
		}
	}
}
