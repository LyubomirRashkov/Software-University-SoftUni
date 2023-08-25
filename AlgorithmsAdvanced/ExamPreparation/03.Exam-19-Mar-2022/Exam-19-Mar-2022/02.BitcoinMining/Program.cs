using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BitcoinMining
{
	public class Transaction
	{
        public string Hash { get; set; }

        public int Size { get; set; }

        public int Fees { get; set; }
    }

	public class Program
	{
		public const int MaxSize = 1_000_000;

		public static void Main(string[] args)
		{
			List<Transaction> transactions = ReadInput();

			int[,] dp = new int[transactions.Count + 1, MaxSize + 1];

			bool[,] madeTransactions = new bool[transactions.Count + 1, MaxSize + 1];

			FillMatrices(dp, madeTransactions, transactions);

			HashSet<Transaction> completedTransactions = GetCompletedTransactions(madeTransactions, transactions, MaxSize);

			PrintResult(dp, completedTransactions);
        }

		private static void PrintResult(int[,] dp, HashSet<Transaction> completedTransactions)
		{
            Console.WriteLine($"Total Size: {completedTransactions.Select(t => t.Size).Sum()}");

			Console.WriteLine($"Total Fees: {completedTransactions.Select(t => t.Fees).Sum()}");

			Console.WriteLine(string.Join(Environment.NewLine, completedTransactions.Select(t => t.Hash)));
        }

		private static HashSet<Transaction> GetCompletedTransactions(
			bool[,] madeTransactions, 
			List<Transaction> allTransactions, 
			int size)
		{
			HashSet<Transaction> completedTransactions = new HashSet<Transaction>();

			for (int row = madeTransactions.GetLength(0) - 1; row > 0; row--)
			{
				if (!madeTransactions[row, size])
				{
					continue;
				}

				Transaction currentTransaction = allTransactions[row - 1];

				completedTransactions.Add(currentTransaction);

				size -= currentTransaction.Size;

				if (size == 0)
				{
					break;
				}
			}

			return completedTransactions;
		}

		private static void FillMatrices(int[,] dp, bool[,] madeTransactions, List<Transaction> transactions)
		{
			for (int row = 1; row < dp.GetLength(0); row++)
			{
				Transaction currentTransaction = transactions[row - 1];

				for (int size = 1; size < dp.GetLength(1); size++)
				{
					int excludingValue = dp[row - 1, size];

					if (size < currentTransaction.Size)
					{
						dp[row, size] = excludingValue;

						continue;
					}

					int includingValue = currentTransaction.Fees + dp[row - 1, size - currentTransaction.Size];

					if (includingValue > excludingValue)
					{
						dp[row, size] = includingValue;

						madeTransactions[row, size] = true;
					}
					else
					{
						dp[row, size] = excludingValue;
					}
				}
			}
		}

		private static List<Transaction> ReadInput()
		{
			List<Transaction> transactions = new List<Transaction>();

			int transactionsCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < transactionsCount; i++)
			{
				string[] transactionData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				transactions.Add(new Transaction()
				{
					Hash = transactionData[0],
					Size = int.Parse(transactionData[1]),
					Fees = int.Parse(transactionData[2]),
				});
			}

			return transactions;
		}
	}
}
