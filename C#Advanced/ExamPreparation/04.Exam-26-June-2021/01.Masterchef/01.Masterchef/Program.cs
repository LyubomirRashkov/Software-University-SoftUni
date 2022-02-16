using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] freshnessInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredients = new Queue<int>(ingredientsInput);

            Stack<int> freshness = new Stack<int>(freshnessInput);

            string[] dishes = new string[] { "Dipping sauce", "Green salad", "Chocolate cake", "Lobster" };

            Dictionary<string, int> countOfMadeDishesByDishes = new Dictionary<string, int>();

            for (int i = 0; i < dishes.Length; i++)
            {
                countOfMadeDishesByDishes.Add(dishes[i], 0);
            }

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngredient = ingredients.Peek();

                int currentFreshness = freshness.Peek();

                int result = currentIngredient * currentFreshness;

                if (currentIngredient == 0)
                {
                    ingredients.Dequeue();
                }
                else if (result == 150)
                {
                    countOfMadeDishesByDishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == 250)
                {
                    countOfMadeDishesByDishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == 300)
                {
                    countOfMadeDishesByDishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == 400)
                {
                    countOfMadeDishesByDishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();

                    currentIngredient += 5;

                    ingredients.Dequeue();
                    ingredients.Enqueue(currentIngredient);
                }
            }

            countOfMadeDishesByDishes = countOfMadeDishesByDishes
                .Where(kvp => kvp.Value > 0)
                .OrderBy(kvp => kvp.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            if (countOfMadeDishesByDishes.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }


            int sumOfIngredientsLeft = ingredients.Sum();

            if (sumOfIngredientsLeft > 0)
            {
                Console.WriteLine($"Ingredients left: {sumOfIngredientsLeft}");
            }

            foreach (var kvp in countOfMadeDishesByDishes)
            {
                Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
            }
        }
    }
}
