using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.ChainLightning
{
	public class Edge
	{
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

	public class Program
	{
		public static void Main(string[] args)
		{
			int nodesCount = int.Parse(Console.ReadLine());

			int edgesCount = int.Parse(Console.ReadLine());

			int lightningsCount = int.Parse(Console.ReadLine());

			List<Edge>[] edgesByNode = InitializeGraph(nodesCount);

			ReadInputEdges(edgesByNode, edgesCount);

			int[] damageByNode = new int[nodesCount];

			ApplyLightnings(lightningsCount, edgesByNode, damageByNode);

            Console.WriteLine(damageByNode.Max());
        }

		private static void ApplyLightnings(int lightningsCount, List<Edge>[] graph, int[] damageByNode)
		{
			for (int i = 0; i < lightningsCount; i++)
			{
				int[] lightningData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				int targetNode = lightningData[0];

				int lightningPower = lightningData[1];

				ApplyPrim(graph, damageByNode, targetNode, lightningPower);
			}
		}

		private static void ApplyPrim(List<Edge>[] graph, int[] damageByNode, int startNode, int lightningPower)
		{
			damageByNode[startNode] += lightningPower;

			HashSet<int> mst = new HashSet<int> { startNode };

			int[] lightningJumps = new int[graph.Length];

			OrderedBag<Edge> priorityQueue = new OrderedBag<Edge>(
				Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

			priorityQueue.AddMany(graph[startNode]);

			while (priorityQueue.Count > 0)
			{
				Edge minEdge = priorityQueue.RemoveFirst();

				int treeNode = -1;

				int nonTreeNode = -1;

				if (mst.Contains(minEdge.First) && !mst.Contains(minEdge.Second))
				{
					treeNode = minEdge.First;

					nonTreeNode = minEdge.Second;
				}

				if (!mst.Contains(minEdge.First) && mst.Contains(minEdge.Second))
				{
					treeNode = minEdge.Second;

					nonTreeNode = minEdge.First;
				}

				if (nonTreeNode != -1)
				{
					mst.Add(nonTreeNode);

					priorityQueue.AddMany(graph[nonTreeNode]);

					lightningJumps[nonTreeNode] = lightningJumps[treeNode] + 1;

					damageByNode[nonTreeNode] += CalculateDamage(lightningPower, lightningJumps[nonTreeNode]);
				}
			}
		}

		private static int CalculateDamage(int lightningPower, int jumpsCount)
		{
			int damageTaken = lightningPower;

			for (int i = 0; i < jumpsCount; i++)
			{
				damageTaken /= 2;
			}

			return damageTaken;
		}

		private static void ReadInputEdges(List<Edge>[] graph, int edgesCount)
		{
			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeData = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeData[0];

				int secondNode = edgeData[1];

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = edgeData[2],
				};

				graph[firstNode].Add(edge);

				graph[secondNode].Add(edge);
			}
		}

		private static List<Edge>[] InitializeGraph(int size)
		{
			List<Edge>[] graph = new List<Edge>[size];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<Edge>();
			}

			return graph;
		}
	}
}
