using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToList();

            bool isChanged = false;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Add")
                {
                    numbers.Add(int.Parse(parts[1]));
                    isChanged = true;
                }
                else if (parts[0] == "Remove")
                {
                    numbers.Remove(int.Parse(parts[1]));
                    isChanged = true;
                }
                else if (parts[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(parts[1]));
                    isChanged = true;
                }
                else if (parts[0] == "Insert")
                {
                    numbers.Insert(int.Parse(parts[2]), int.Parse(parts[1]));
                    isChanged = true;
                }
                else if (parts[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(parts[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (parts[0] == "PrintEven")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            Console.Write(numbers[i] + " ");
                        }
                    }

                    Console.WriteLine();
                }
                else if (parts[0] == "PrintOdd")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 1)
                        {
                            Console.Write(numbers[i] + " ");
                        }
                    }

                    Console.WriteLine();
                }
                else if (parts[0] == "GetSum")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        sum += numbers[i];
                    }

                    Console.WriteLine(sum);
                }
                else
                {
                    string condition = parts[1];
                    int target = int.Parse(parts[2]);

                    if (condition == "<")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n < target)));
                    }
                    else if (condition == ">")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n > target)));
                    }
                    else if (condition == "<=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n <= target)));
                    }
                    else if (condition == ">=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n >= target)));
                    }
                }
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
