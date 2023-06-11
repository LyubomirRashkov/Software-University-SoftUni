using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Cinema
{
	public class Program
	{
		private static List<string> names;
		private static string[] orderedNames;

		public static void Main(string[] args)
		{
			names = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			orderedNames = new string[names.Count];

			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine == "generate")
				{
					break;
				}

				string[] tokens = inputLine
					.Split(" - ", StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				string name = tokens[0];

				int position = int.Parse(tokens[1]) - 1;

				names.Remove(name);

				orderedNames[position] = name;
			}

			Permute(0);
		}

		private static void Permute(int index)
		{
			if (index == names.Count)
			{
				PrintOrder();

				return;
			}

			Permute(index + 1);

			for (int i = index + 1; i < names.Count; i++)
			{
				Swap(index, i);

				Permute(index + 1);

				Swap(index, i);
			}
		}

		private static void PrintOrder()
		{
			List<string> result = new List<string>(names.Count);

			int pointer = 0;

			for (int i = 0; i < orderedNames.Length; i++)
			{
				if (orderedNames[i] != null)
				{
					result.Add(orderedNames[i]);
                }
				else
				{
					result.Add(names[pointer++]);
                }
			}

            Console.WriteLine(string.Join(' ', result));
        }

		private static void Swap(int firstIndex, int secondIndex)
		{
			string temp = names[firstIndex];

			names[firstIndex] = names[secondIndex];

			names[secondIndex] = temp;
		}
	}
}
