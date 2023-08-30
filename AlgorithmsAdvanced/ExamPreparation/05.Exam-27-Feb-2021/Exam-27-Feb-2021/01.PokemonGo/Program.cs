using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.PokemonGo
{
	public class Street
	{
		public string Name { get; set; }

		public int PokemonsCount { get; set; }

		public int Length { get; set; }

		public override string ToString()
		{
			return this.Name;
		}
	}

	public class StreetComparer : IComparer<Street>
	{
		public int Compare(Street x, Street y) => x.Name.CompareTo(y.Name);
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			int totalFuel = int.Parse(Console.ReadLine());

			List<Street> streets = ReadInput();

			int[,] dp = new int[streets.Count + 1, totalFuel + 1];

			bool[,] checkedStreets = new bool[streets.Count + 1, totalFuel + 1];

			FillMatrices(dp, checkedStreets, streets);

			SortedSet<Street> streetsToPatrol = GetStreetsToPatrol(checkedStreets, streets, totalFuel);

			PrintResult(totalFuel, streetsToPatrol);
		}

		private static void PrintResult(int totalFuel, SortedSet<Street> streetsToPatrol)
		{
			if (streetsToPatrol.Count > 0)
			{
				Console.WriteLine(string.Join(" -> ", streetsToPatrol));
			}

			Console.WriteLine($"Total Pokemon caught -> {streetsToPatrol.Select(s => s.PokemonsCount).Sum()}");

			Console.WriteLine($"Fuel Left -> {totalFuel - streetsToPatrol.Select(s => s.Length).Sum()}");
		}

		private static SortedSet<Street> GetStreetsToPatrol(bool[,] checkedStreets, List<Street> streets, int fuel)
		{
			SortedSet<Street> streetsToPatrol = new SortedSet<Street>(new StreetComparer());

			for (int row = checkedStreets.GetLength(0) - 1; row > 0; row--)
			{
				if (!checkedStreets[row, fuel])
				{
					continue;
				}

				Street currentStreet = streets[row - 1];

				streetsToPatrol.Add(currentStreet);

				fuel -= currentStreet.Length;

				if (fuel == 0)
				{
					break;
				}
			}

			return streetsToPatrol;
		}

		private static void FillMatrices(int[,] dp, bool[,] checkedStreets, List<Street> streets)
		{
			for (int row = 1; row < dp.GetLength(0); row++)
			{
				Street currentStreet = streets[row - 1];

				for (int fuel = 1; fuel < dp.GetLength(1); fuel++)
				{
					int excludingValue = dp[row - 1, fuel];

					if (fuel < currentStreet.Length)
					{
						dp[row, fuel] = excludingValue;

						continue;
					}

					int includingValue = currentStreet.PokemonsCount + dp[row - 1, fuel - currentStreet.Length];

					if (includingValue > excludingValue)
					{
						dp[row, fuel] = includingValue;

						checkedStreets[row, fuel] = true;
					}
					else
					{
						dp[row, fuel] = excludingValue;
					}
				}
			}
		}

		private static List<Street> ReadInput()
		{
			List<Street> streets = new List<Street>();

			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine == "End")
				{
					break;
				}

				string[] streetData = inputLine
					.Split(", ", StringSplitOptions.RemoveEmptyEntries);

				streets.Add(new Street()
				{
					Name = streetData[0],
					PokemonsCount = int.Parse(streetData[1]),
					Length = int.Parse(streetData[2]),
				});
			}

			return streets;
		}
	}
}
