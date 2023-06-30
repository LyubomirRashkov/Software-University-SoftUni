using System;
using System.Collections.Generic;

namespace _03.StringsMashup
{
	public class Program
	{
		public static void Main(string[] args)
		{
			char[] input = Console.ReadLine().ToCharArray();

			HashSet<string> results = new HashSet<string>();

			Mashup(0, input, results);

			Console.WriteLine(string.Join(Environment.NewLine, results));
		}

		private static void Mashup(int index, char[] arr, HashSet<string> results)
		{
			if (index == arr.Length)
			{
				results.Add(new string(arr));

				return;
			}

			for (int i = 0; i < 2; i++)
			{
				if (i == 0)
				{
					arr[index] = char.ToLower(arr[index]);
				}
				else
				{
					arr[index] = char.ToUpper(arr[index]);
				}

				Mashup(index + 1, arr, results);
			}
		}
	}
}
