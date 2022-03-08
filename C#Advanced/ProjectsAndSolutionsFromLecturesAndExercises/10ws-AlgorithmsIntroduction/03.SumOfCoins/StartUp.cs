namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] availableCoins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(availableCoins);

            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> countOfCoinsByCoinValue = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {countOfCoinsByCoinValue.Sum(kvp => kvp.Value)}");

            foreach (var kvp in countOfCoinsByCoinValue)
            {
                Console.WriteLine($"{kvp.Value} coin(s) with value {kvp.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> countOfCoinsByCoinValue = new Dictionary<int, int>();

            int coinIndex = coins.Count - 1;

            while (targetSum > 0 && coinIndex >= 0)
            {
                int currentCoin = coins[coinIndex];

                int countOfCoins = targetSum / currentCoin;

                if (countOfCoins == 0)
                {
                    coinIndex--;

                    continue;
                }

                countOfCoinsByCoinValue.Add(currentCoin, countOfCoins);

                targetSum %= currentCoin;
            }

            if (coinIndex < 0)
            {
                throw new InvalidOperationException();
            }

            return countOfCoinsByCoinValue;
        }
    }
}