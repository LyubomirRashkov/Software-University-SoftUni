using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03.Prim_sAlgorithm
{
	public class Edge
	{
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }

		public override string ToString()
		{
			return $"{this.First} - {this.Second}";
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			Dictionary<int, List<Edge>> edgesByNode = ReadInputEdges();

			HashSet<int> forestNodes = new HashSet<int>();

			List<Edge> forestEdges = new List<Edge>();

			foreach (var node in edgesByNode.Keys)
			{
				if (!forestNodes.Contains(node))
				{
					ApplyPrim(edgesByNode, forestNodes, forestEdges, node);
				}
			}

			foreach (var edge in forestEdges)
			{
                Console.WriteLine(edge);
            }
		}

		private static void ApplyPrim(
			Dictionary<int, List<Edge>> edgesByNode, 
			HashSet<int> forestNodes, 
			List<Edge> forestEdges,
			int node)
		{
			forestNodes.Add(node);

			OrderedBag<Edge> priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((x, y) => x.Weight - y.Weight));

			priorityQueue.AddMany(edgesByNode[node]);

			while (priorityQueue.Count > 0)
			{
				Edge minEdge = priorityQueue.RemoveFirst();

				int nonTreeNode = -1;

				if (forestNodes.Contains(minEdge.First)
					&& !forestNodes.Contains(minEdge.Second))
				{
					nonTreeNode = minEdge.Second;
				}

				if (!forestNodes.Contains(minEdge.First)
					&& forestNodes.Contains(minEdge.Second))
				{
					nonTreeNode = minEdge.First;
				}

				if (nonTreeNode != -1)
				{
					forestNodes.Add(nonTreeNode);

					forestEdges.Add(minEdge);

					priorityQueue.AddMany(edgesByNode[nonTreeNode]);
				}
			}
		}

		private static Dictionary<int, List<Edge>> ReadInputEdges()
		{
			Dictionary<int, List<Edge>> edgesByNode = new Dictionary<int, List<Edge>>();

			int edgesCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < edgesCount; i++)
			{
				int[] edgeParts = Console.ReadLine()
					.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				int firstNode = edgeParts[0];

				int secondNode = edgeParts[1];

				if (!edgesByNode.ContainsKey(firstNode))
				{
					edgesByNode.Add(firstNode, new List<Edge>());
				}

				if (!edgesByNode.ContainsKey(secondNode))
				{
					edgesByNode.Add(secondNode, new List<Edge>());
				}

				Edge edge = new Edge()
				{
					First = firstNode,
					Second = secondNode,
					Weight = edgeParts[2],
				};

				edgesByNode[firstNode].Add(edge);

				edgesByNode[secondNode].Add(edge);
			}

			return edgesByNode;
		}
	}
}
