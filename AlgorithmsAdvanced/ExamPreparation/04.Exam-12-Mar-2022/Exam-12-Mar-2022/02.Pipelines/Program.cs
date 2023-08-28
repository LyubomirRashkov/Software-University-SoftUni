using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Pipelines
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int agentsCount = int.Parse(Console.ReadLine());

			int pipelinesCount = int.Parse(Console.ReadLine());

			Dictionary<string, int> nodeByAgentName = ReadInputAgents(agentsCount);

			Dictionary<string, int> nodeByPipelineName = ReadInputPipelines(pipelinesCount, agentsCount);

			int nodesCount = agentsCount + pipelinesCount + 2;

			bool[,] graph = InitializeGraph(nodesCount, nodeByAgentName, nodeByPipelineName);

			//PrintGraph(graph);

			AssignTasks(graph);

			HashSet<string> agentsWithPipelines = GetAgentsWithPipelines(graph, nodeByAgentName, nodeByPipelineName);

			foreach (var item in agentsWithPipelines)
			{
                Console.WriteLine(item);
            }
		}

		private static HashSet<string> GetAgentsWithPipelines(
			bool[,] graph, 
			Dictionary<string, int> nodeByAgentName, 
			Dictionary<string, int> nodeByPipelineName)
		{
			HashSet<string> agentsWithPipelines = new HashSet<string>();

			for (int pipeline = nodeByAgentName.Count + 1; pipeline <= nodeByAgentName.Count + nodeByPipelineName.Count; pipeline++)
			{
				for (int agent = 1; agent <= nodeByAgentName.Count; agent++)
				{
					if (graph[pipeline, agent])
					{
						string agentName = nodeByAgentName.FirstOrDefault(kvp => kvp.Value == agent).Key;

						string pipelineName = nodeByPipelineName.FirstOrDefault(kvp => kvp.Value == pipeline).Key;

						string output = $"{agentName} - {pipelineName}";

						agentsWithPipelines.Add(output);
					}
				}
			}

			return agentsWithPipelines;
		}

		private static void AssignTasks(bool[,] graph)
		{
			int source = 0;

			int target = graph.GetLength(0) - 1;

			int[] parents = InitializeParents(graph.GetLength(0));

			bool hasAugmentingPath = Bfs(source, target, graph, parents);

			while (hasAugmentingPath)
			{
				int currentNode = target;

				while (parents[currentNode] != -1)
				{
					int parent = parents[currentNode];

					graph[parent, currentNode] = false;

					graph[currentNode, parent] = true;

					currentNode = parent;
				}

				hasAugmentingPath = Bfs(source, target, graph, parents);
			}
		}

		private static bool Bfs(int source, int target, bool[,] graph, int[] parents)
		{
			bool[] visited = new bool[graph.GetLength(0)];

			Queue<int> queue = new Queue<int>();

			queue.Enqueue(source);

			visited[source] = true;

			while (queue.Count > 0)
			{
				int currentNode = queue.Dequeue();

				for (int child = 0; child < graph.GetLength(1); child++)
				{
					if (!visited[child] && graph[currentNode, child])
					{
						parents[child] = currentNode;

						queue.Enqueue(child);

						visited[child] = true;
					}
				}
			}

			return visited[target];
		}

		private static int[] InitializeParents(int size)
		{
			int[] arr = new int[size];

			Array.Fill(arr, -1);

			return arr;
		}

		private static void PrintGraph(bool[,] graph)
		{
			for (int row = 0; row < graph.GetLength(0); row++)
			{
				for (int col = 0; col < graph.GetLength(1); col++)
				{
					if (graph[row, col])
					{
						Console.Write("Y ");
					}
					else
					{
						Console.Write("N ");
					}
				}

				Console.WriteLine();
			}
		}

		private static bool[,] InitializeGraph(
			int nodesCount, 
			Dictionary<string, int> nodeByAgentName, 
			Dictionary<string, int> nodeByPipelineName)
		{
			bool[,] graph = new bool[nodesCount, nodesCount];

			for (int agent = 1; agent <= nodeByAgentName.Count; agent++)
			{
				graph[0, agent] = true;
			}

			for (int i = 0; i < nodeByAgentName.Count; i++)
			{
				string[] inputLine = Console.ReadLine()
					.Split(", ", StringSplitOptions.RemoveEmptyEntries);

				string agentName = inputLine[0];

				for (int j = 1; j < inputLine.Length; j++)
				{
					graph[nodeByAgentName[agentName], nodeByPipelineName[inputLine[j]]] = true;
				}
			}

			for (int pipeline = nodeByAgentName.Count + 1; pipeline <= nodeByAgentName.Count + nodeByPipelineName.Count; pipeline++)
			{
				graph[pipeline, graph.GetLength(0) - 1] = true;
			}

			return graph;
		}

		private static Dictionary<string, int> ReadInputPipelines(int pipelinesCount, int agentsCount)
		{
			Dictionary<string, int> nodeByPipelineName = new Dictionary<string, int>();

			for (int i = 0; i < pipelinesCount; i++)
			{
				string pipelineName = Console.ReadLine();

				nodeByPipelineName.Add(pipelineName, i + 1 + agentsCount);
			}

			return nodeByPipelineName;
		}

		private static Dictionary<string, int> ReadInputAgents(int agentsCount)
		{
			Dictionary<string, int> nodeByAgentName = new Dictionary<string, int>();

			for (int i = 0; i < agentsCount; i++)
			{
				string agentName = Console.ReadLine();

				nodeByAgentName.Add(agentName, i + 1);
			}

			return nodeByAgentName;
		}
	}
}
