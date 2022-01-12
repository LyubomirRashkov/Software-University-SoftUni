using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int everyNth = int.Parse(Console.ReadLine());

            Queue<string> namesInAQueue = new Queue<string>(names);

            while (namesInAQueue.Count > 1)
            {
                for (int i = 1; i < everyNth; i++)
                {
                    string temp = namesInAQueue.Dequeue();
                    namesInAQueue.Enqueue(temp);
                }

                Console.WriteLine($"Removed {namesInAQueue.Dequeue()}");
            }

            Console.WriteLine($"Last is {namesInAQueue.Dequeue()}");
        }
    }
}
