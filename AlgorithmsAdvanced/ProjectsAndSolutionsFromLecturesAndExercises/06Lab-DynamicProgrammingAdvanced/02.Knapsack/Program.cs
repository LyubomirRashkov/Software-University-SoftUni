using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Knapsack
{
	public class Item
	{
		public string Name { get; set; }

		public int Weight { get; set; }

		public int Value { get; set; }
	}

	public class ItemComparer : IComparer<Item>
	{
		public int Compare(Item x, Item y) => x.Name.CompareTo(y.Name);
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			int capacity = int.Parse(Console.ReadLine());

			List<Item> items = ReadInput();

			int[,] dp = new int[items.Count + 1, capacity + 1];

			bool[,] usedItems = new bool[items.Count + 1, capacity + 1];

			FillTheMatrices(dp, usedItems, items);

			SortedSet<Item> itemsTaken = GetTakenItems(usedItems, items, capacity);

			PrintResult(dp, itemsTaken);
		}

		private static void PrintResult(int[,] dp, SortedSet<Item> itemsTaken)
		{
			Console.WriteLine($"Total Weight: {itemsTaken.Select(i => i.Weight).Sum()}");

			Console.WriteLine($"Total Value: {dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1]}");

			Console.WriteLine(string.Join(Environment.NewLine, itemsTaken.Select(i => i.Name)));
		}

		private static SortedSet<Item> GetTakenItems(bool[,] usedItems, List<Item> allItems, int capacity)
		{
			SortedSet<Item> itemsTaken = new SortedSet<Item>(new ItemComparer());

			for (int row = usedItems.GetLength(0) - 1; row > 0; row--)
			{
				if (!usedItems[row, capacity])
				{
					continue;
				}

				Item currentItem = allItems[row - 1];

				itemsTaken.Add(currentItem);

				capacity -= currentItem.Weight;

				if (capacity == 0)
				{
					break;
				}
			}

			return itemsTaken;
		}

		private static void FillTheMatrices(int[,] dp, bool[,] usedItems, List<Item> items)
		{
			for (int row = 1; row < dp.GetLength(0); row++)
			{
				Item currentItem = items[row - 1];

				for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
				{
					int excludingValue = dp[row - 1, capacity];

					if (capacity < currentItem.Weight)
					{
						dp[row, capacity] = excludingValue;

						continue;
					}

					int includingValue = currentItem.Value + dp[row - 1, capacity - currentItem.Weight];

					if (capacity >= currentItem.Weight && includingValue > excludingValue)
					{
						dp[row, capacity] = includingValue;

						usedItems[row, capacity] = true;
					}
					else
					{
						dp[row, capacity] = excludingValue;
					}
				}
			}
		}

		private static List<Item> ReadInput()
		{
			List<Item> inputItems = new List<Item>();

			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine == "end")
				{
					break;
				}

				string[] itemData = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				inputItems.Add(new Item()
				{
					Name = itemData[0],
					Weight = int.Parse(itemData[1]),
					Value = int.Parse(itemData[2]),
				});
			}

			return inputItems;
		}
	}
}
