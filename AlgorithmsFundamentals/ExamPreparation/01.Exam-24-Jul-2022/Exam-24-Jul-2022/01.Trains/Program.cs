using System;
using System.Linq;

namespace _01.Trains
{
	public class Program
	{
		public static void Main(string[] args)
		{
			double[] arrivalTimes = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(double.Parse)
				.OrderBy(at => at)
				.ToArray();

			double[] departureTimes = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(double.Parse)
				.OrderBy(dt => dt)
				.ToArray();

			int platformsNeeded = 1;

			int platformsOccupied = 0;

			int arrivalIndex = 0;

			int departureIndex = 0;

			while (arrivalIndex < arrivalTimes.Length && departureIndex < departureTimes.Length)
			{
				if (arrivalTimes[arrivalIndex] < departureTimes[departureIndex])
				{
					platformsOccupied++;

					platformsNeeded = Math.Max(platformsNeeded, platformsOccupied);

					arrivalIndex++;
				}
				else
				{
					platformsOccupied--;

					departureIndex++;
				}
			}

            Console.WriteLine(platformsNeeded);
        }
	}
}
