using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<furnitureName>[A-Z]+[a-z]*)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");

            List<string> boughtFurnitures = new List<string>();

            double totalSpentMoney = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(line);

                if (!match.Success)
                {
                    continue;
                }

                string furnitureName = match.Groups["furnitureName"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                boughtFurnitures.Add(furnitureName);

                double spentMoneyForThisFurniture = price * quantity;

                totalSpentMoney += spentMoneyForThisFurniture;
            }

            Console.WriteLine("Bought furniture:");

            foreach (string furniture in boughtFurnitures)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalSpentMoney:F2}");
        }
    }
}
