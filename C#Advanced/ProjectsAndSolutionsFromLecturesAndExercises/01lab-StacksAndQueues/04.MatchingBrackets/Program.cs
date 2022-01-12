using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> indices = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indices.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int endIndex = i;
                    int startIndex = indices.Pop();

                    int subexpressionLength = endIndex - startIndex + 1;

                    string subexpression = expression.Substring(startIndex, subexpressionLength);

                    Console.WriteLine(subexpression);
                }
            }
        }
    }
}
