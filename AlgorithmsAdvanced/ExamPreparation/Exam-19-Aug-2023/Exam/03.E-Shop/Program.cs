using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.E_Shop
{
	public class Item
	{
		public string Name { get; set; }

		public int Weight { get; set; }

		public int Value { get; set; }
	}

	public class ItemCollection
	{
		public ItemCollection()
		{
			this.Items = new List<string>();
		}

		public List<string> Items { get; set; }

		public int Weight { get; set; }

		public int Value { get; set; }
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			List<Item> items = ReadInputItems();

			List<ItemCollection> itemCollections = ReadInputItemCollections(items);

			int capacity = int.Parse(Console.ReadLine());

			int[,] dp = new int[itemCollections.Count + 1, capacity + 1];

			bool[,] takenCollections = new bool[itemCollections.Count + 1, capacity + 1];

			FillMatrices(dp, takenCollections, itemCollections);

			SortedSet<string> itemsTaken = GetTakenItems(takenCollections, itemCollections, capacity);

            Console.WriteLine(string.Join(Environment.NewLine, itemsTaken));
        }

		private static List<ItemCollection> ReadInputItemCollections(List<Item> items)
		{
			List<ItemCollection> itemCollections = new List<ItemCollection>();

			int connectionsCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < connectionsCount; i++)
			{
				string[] itemNames = Console.ReadLine()
					.Split();

				Item itemOne = items.FirstOrDefault(i => i.Name == itemNames[0]);

				Item itemTwo = items.FirstOrDefault(i => i.Name == itemNames[1]);

				ItemCollection itemCollection = null;

				if (itemOne != null && itemTwo != null)
				{
					itemCollection = new ItemCollection()
					{
						Value = itemOne.Value + itemTwo.Value,
						Weight = itemOne.Weight + itemTwo.Weight,
					};

					itemCollection.Items.Add(itemOne.Name);

					itemCollection.Items.Add(itemTwo.Name);

					items.Remove(itemOne);

					items.Remove(itemTwo);

					itemCollections.Add(itemCollection);
				}
				else if (itemOne is null)
				{
					itemCollection = itemCollections.FirstOrDefault(ic => ic.Items.Contains(itemNames[0]));

					itemCollection.Value += itemTwo.Value;

					itemCollection.Weight += itemTwo.Weight;

					itemCollection.Items.Add(itemTwo.Name);

					items.Remove(itemTwo);
				}
				else if (itemTwo is null)
				{
					itemCollection = itemCollections.FirstOrDefault(ic => ic.Items.Contains(itemNames[1]));

					itemCollection.Value += itemOne.Value;

					itemCollection.Weight += itemOne.Weight;

					itemCollection.Items.Add(itemOne.Name);

					items.Remove(itemOne);
				}
				else
				{
					itemCollection = itemCollections.FirstOrDefault(ic => ic.Items.Contains(itemNames[0]));

					ItemCollection itemCollectionToRemove =
						itemCollections.FirstOrDefault(ic => ic.Items.Contains(itemNames[1]));

					itemCollection.Value += itemCollectionToRemove.Value;

					itemCollection.Weight += itemCollectionToRemove.Weight;

					itemCollection.Items.AddRange(itemCollectionToRemove.Items);

					itemCollections.Remove(itemCollectionToRemove);
				}
			}

			foreach (var item in items)
			{
				ItemCollection itemCollection = new ItemCollection()
				{
					Value = item.Value,
					Weight = item.Weight,
				};

				itemCollection.Items.Add(item.Name);

				itemCollections.Add(itemCollection);
			}

			return itemCollections;
		}

		private static List<Item> ReadInputItems()
		{
			List<Item> items = new List<Item>();

			int itemsNumber = int.Parse(Console.ReadLine());

			for (int i = 0; i < itemsNumber; i++)
			{
				string[] itemData = Console.ReadLine()
					.Split();

				Item item = new Item()
				{
					Name = itemData[0],
					Weight = int.Parse(itemData[1]),
					Value = int.Parse(itemData[2]),
				};

				items.Add(item);
			}

			return items;
		}

		private static SortedSet<string> GetTakenItems(
			bool[,] takenCollections, 
			List<ItemCollection> itemCollections, 
			int capacity)
		{
			SortedSet<string> itemsTaken = new SortedSet<string>();

			for (int row = takenCollections.GetLength(0) - 1; row > 0; row--)
			{
				if (!takenCollections[row, capacity])
				{
					continue;
				}

				ItemCollection currentCollection = itemCollections[row - 1];

				foreach (var itemName in currentCollection.Items)
				{
					itemsTaken.Add(itemName);
				}

				capacity -= currentCollection.Weight;

				if (capacity == 0)
				{
					break;
				}
			}

			return itemsTaken;
		}

		private static void FillMatrices(int[,] dp, bool[,] takenCollections, List<ItemCollection> itemCollections)
		{
			for (int row = 1; row < dp.GetLength(0); row++)
			{
				ItemCollection currentCollection = itemCollections[row - 1];

				for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
				{
					int excludingValue = dp[row - 1, capacity];

					if (capacity < currentCollection.Weight)
					{
						dp[row, capacity] = excludingValue;

						continue;
					}

					int includingValue = currentCollection.Value + dp[row - 1, capacity - currentCollection.Weight];

					if (includingValue > excludingValue)
					{
						dp[row, capacity] = includingValue;

						takenCollections[row, capacity] = true;
					}
					else
					{
						dp[row, capacity] = excludingValue;
					}
				}
			}
		}
	}
}