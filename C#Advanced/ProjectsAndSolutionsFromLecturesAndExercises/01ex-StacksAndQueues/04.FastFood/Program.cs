using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ordersInTheQueue = new Queue<int>(orders);

            Console.WriteLine(ordersInTheQueue.Max());

            while (ordersInTheQueue.Count > 0)
            {
                int currentOrder = ordersInTheQueue.Peek();

                if (currentOrder <= quantityOfTheFood)
                {
                    quantityOfTheFood -= currentOrder;
                    ordersInTheQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (ordersInTheQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(" ", ordersInTheQueue));
            }
        }
    }
}
