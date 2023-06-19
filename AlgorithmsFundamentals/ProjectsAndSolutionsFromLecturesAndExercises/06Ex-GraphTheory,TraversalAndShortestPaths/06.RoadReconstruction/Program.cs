using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _06.RoadReconstruction
{
	public class Edge
	{
        public Edge(int firstNode, int secondNode)
        {
			this.First = Math.Min(firstNode, secondNode);
			this.Second = Math.Max(firstNode, secondNode);
        }

        public int First { get; set; }

        public int Second { get; set; }
    }

	public class Program
	{
		private static List<int>[] graph;
		private static List<Edge> edges;

		public static void Main(string[] args)
		{
			ReadInput();

			List<Edge> importantEdges = GetImportantEdges();

            Console.WriteLine("Important streets:");

			foreach (var edge in importantEdges)
			{
                Console.WriteLine($"{edge.First} {edge.Second}");
            }
        }

		private static void ReadInput()
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int edgesCount = int.Parse(Console.ReadLine());

			graph = new List<int>[nodesCount];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<int>();
			}

			edges = new List<Edge>();

			for (int i = 0; i < edgesCount; i++)
			{
				int[] parts = Console.ReadLine()
					.Split(" - ", StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = parts[0];

				int secondNode = parts[1];

				graph[firstNode].Add(secondNode);

				graph[secondNode].Add(firstNode);

				Edge edge = new Edge(firstNode, secondNode);

				edges.Add(edge);
			}
		}

		private static List<Edge> GetImportantEdges()
		{
			List<Edge> importantEdges = new List<Edge>();

			foreach (var edge in edges)
			{
				graph[edge.First].Remove(edge.Second);

				graph[edge.Second].Remove(edge.First);

				bool areReachable = Bfs(edge.First, edge.Second);

				if (!areReachable)
				{
					importantEdges.Add(edge);
				}

				graph[edge.First].Add(edge.Second);

				graph[edge.Second].Add(edge.First);
			}

			return importantEdges;
		}

		private static bool Bfs(int startNode, int destinationNode)
		{
			HashSet<int> visited = new HashSet<int>();

			Queue<int> queue = new Queue<int>();

			visited.Add(startNode);

			queue.Enqueue(startNode);

			while (queue.Count > 0)
			{
				int node = queue.Dequeue();

				if (node == destinationNode)
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
	}
}
