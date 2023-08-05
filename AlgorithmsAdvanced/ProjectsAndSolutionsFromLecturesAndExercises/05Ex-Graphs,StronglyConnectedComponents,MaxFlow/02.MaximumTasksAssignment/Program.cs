using System;
using System.Collections.Generic;

namespace _02.MaximumTasksAssignment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int peopleCount = int.Parse(Console.ReadLine());

			int tasksCount = int.Parse(Console.ReadLine());

			int nodesCount = peopleCount + tasksCount + 2;

			bool[,] graph = InitializeGraph(peopleCount, tasksCount, nodesCount);

			//PrintGraph(graph);

			AssignTasks(graph);

			//PrintGraph(graph);

			SortedSet<string> peopleWithTasks = GetPeopleWithTasks(graph, peopleCount, tasksCount);

			foreach (var item in peopleWithTasks)
			{
				Console.WriteLine(item);
			}
		}

		private static SortedSet<string> GetPeopleWithTasks(bool[,] graph, int peopleCount, int tasksCount)
		{
			SortedSet<string> peopleWithTasks = new SortedSet<string>();

			for (int task = peopleCount + 1; task <= peopleCount + tasksCount; task++)
			{
				for (int person = 1; person <= peopleCount; person++)
				{
					if (graph[task, person])
					{
						char currentPerson = (char)(64 + person);

						int currentTask = task - peopleCount;

						string personWithTask = $"{currentPerson}-{currentTask}";

						peopleWithTasks.Add(personWithTask);
					}
				}
			}

			return peopleWithTasks;
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

		private static bool[,] InitializeGraph(int peopleCount, int tasksCount, int nodesCount)
		{
			bool[,] graph = new bool[nodesCount, nodesCount];

			for (int person = 1; person <= peopleCount; person++)
			{
				graph[0, person] = true;
			}

			for (int i = 0; i < peopleCount; i++)
			{
				string inputLine = Console.ReadLine();

				for (int j = 0; j < inputLine.Length; j++)
				{
					if (inputLine[j] == 'Y')
					{
						graph[1 + i, 1 + peopleCount + j] = true;
					}
				}
			}

			for (int task = peopleCount + 1; task <= peopleCount + tasksCount; task++)
			{
				graph[task, graph.GetLength(0) - 1] = true;
			}

			return graph;
		}
	}
}
