using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse)
                                                    .ToArray());

            SortedDictionary<string, int> countOfFoodsByTheirName = new SortedDictionary<string, int>();

            string[] foods = new string[] { "Bread", "Cake", "Pastry", "Fruit Pie" };

            foreach (string food in foods)
            {
                if (!countOfFoodsByTheirName.ContainsKey(food))
                {
                    countOfFoodsByTheirName.Add(food, 0);
                }
            }

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();

                if ((currentLiquid + currentIngredient) == 25)
                {
                    countOfFoodsByTheirName["Bread"]++;
                }
                else if ((currentLiquid + currentIngredient) == 50)
                {
                    countOfFoodsByTheirName["Cake"]++;
                }
                else if ((currentLiquid + currentIngredient) == 75)
                {
                    countOfFoodsByTheirName["Pastry"]++;
                }
                else if ((currentLiquid + currentIngredient) == 100)
                {
                    countOfFoodsByTheirName["Fruit Pie"]++;
                }
                else
                {
                    ingredients.Push((currentIngredient + 3));
                }
            }

            int countOfCookedFoodsByTheirType = countOfFoodsByTheirName
                                              .Where(kvp => kvp.Value > 0)
                                              .Count();

            if (countOfCookedFoodsByTheirType == foods.Length)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var kvp in countOfFoodsByTheirName)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
