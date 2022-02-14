using System;
using System.Linq;

namespace Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = null;

            bool isNotAlreadyCreated = true;

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                if (inputLine == "Pop")
                {
                    stack.Pop();
                }
                else
                {
                    string[] input = inputLine
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    int[] inputNumbers = input.Skip(1).Select(int.Parse).ToArray();

                    if (isNotAlreadyCreated)
                    {
                        stack = new Stack<int>(inputNumbers);
                        isNotAlreadyCreated = false;
                    }
                    else
                    {
                        stack.Push(inputNumbers);
                    }
                }
            }

            Print(stack, 2);
        }

        private static void Print(Stack<int> stackToPrint, int printingTimes)
        {
            for (int i = 0; i < printingTimes; i++)
            {
                foreach (var element in stackToPrint)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
