
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SetCover
{
	public class Program
	{
		public static void Main(string[] args)
		{
			List<int> universe = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();

			int setsCount = int.Parse(Console.ReadLine());

			List<int[]> sets = new List<int[]>(setsCount);

			for (int i = 0; i < setsCount; i++)
			{
				int[] set = Console.ReadLine()
					.Split(", ", StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				sets.Add(set);
			}

			List<int[]> selectedSets = new List<int[]>();

			while (universe.Count > 0)
			{
				int[] currentSet = sets
					.OrderByDescending(s => s.Count(e => universe.Contains(e)))
					.FirstOrDefault();

				selectedSets.Add(currentSet);

				sets.Remove(currentSet);

				foreach (var element in currentSet)
				{
					universe.Remove(element);
				}
			}

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");


			foreach (var set in selectedSets)
			{
                Console.WriteLine(string.Join(", ", set));
            }
		}
	}
}
