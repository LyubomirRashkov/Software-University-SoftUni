using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _05.SchoolTeams
{
	public class Program
	{
		private const int GirlsCountInATeam = 3;
		private const int BoysCountInATeam = 2;

		public static void Main(string[] args)
		{
			string[] girls = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries);

			string[] boys = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries);

			string[] girlsComb = new string[GirlsCountInATeam];

			List<string[]> girlsCombs = new List<string[]>();

			GenerateCombinations(0, 0, girls, girlsComb, girlsCombs);

			string[] boysComb = new string[BoysCountInATeam];

			List<string[]> boysCombs = new List<string[]>();

			GenerateCombinations(0, 0, boys, boysComb, boysCombs);

			foreach (var combinationOfGirls in girlsCombs)
			{
				foreach (var combinationOfBoys in boysCombs)
				{
                    Console.WriteLine($"{string.Join(", ", combinationOfGirls)}, {string.Join(", ", combinationOfBoys)}");
                }
			}
		}

		private static void GenerateCombinations(
			int index, 
			int startIndex, 
			string[] elements, 
			string[] comb,
			List<string[]> combs)
		{
			if (index == comb.Length)
			{
				combs.Add(comb.ToArray());

				return;
			}

			for (int i = startIndex; i < elements.Length; i++)
			{
				comb[index] = elements[i];

				GenerateCombinations(index + 1, i + 1, elements, comb, combs);
			}
		}
	}
}
