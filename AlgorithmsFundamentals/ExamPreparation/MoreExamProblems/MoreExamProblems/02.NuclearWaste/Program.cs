using System;
using System.Linq;

namespace _02.NuclearWaste
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] costs = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int targetCountOfFlasks = int.Parse(Console.ReadLine());

			int[] totalCostForIndexFlasks = new int[targetCountOfFlasks + 1];

			int[] lastCountOfFlasksTransported = new int[targetCountOfFlasks + 1];

			for (int i = 1; i <= targetCountOfFlasks; i++)
			{
				totalCostForIndexFlasks[i] = int.MaxValue;

				for (int j = 1; j <= i; j++)
				{
					if (j > costs.Length)
					{
						break;
					}

					int newCost = totalCostForIndexFlasks[i - j] + costs[j - 1];

					if (newCost < totalCostForIndexFlasks[i])
					{
						totalCostForIndexFlasks[i] = newCost;

						lastCountOfFlasksTransported[i] = j;
					}
				}
			}

            Console.WriteLine($"Cost: {totalCostForIndexFlasks[targetCountOfFlasks]}");

			while (targetCountOfFlasks > 0)
			{
				int lastTransportedCount = lastCountOfFlasksTransported[targetCountOfFlasks];

                Console.WriteLine($"{lastTransportedCount} => {costs[lastTransportedCount - 1]}");

				targetCountOfFlasks -= lastTransportedCount;
            }
        }
	}
}
