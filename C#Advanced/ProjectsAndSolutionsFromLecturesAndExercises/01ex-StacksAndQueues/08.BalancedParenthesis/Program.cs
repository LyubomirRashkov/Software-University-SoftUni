using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequenceOfParentheses = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();

            bool isValid = true;

            for (int i = 0; i < sequenceOfParentheses.Length; i++)
            {
                if (sequenceOfParentheses[i] == '('
                    || sequenceOfParentheses[i] == '['
                    || sequenceOfParentheses[i] == '{')
                {
                    parentheses.Push(sequenceOfParentheses[i]);
                }
                else
                {
                    if (parentheses.Count == 0)
                    {
                        isValid = false;
                        Console.WriteLine("NO");
                        break;
                    }
                    else
                    {
                        char lastAddedBracket = parentheses.Pop();

                        if (lastAddedBracket == '(' && sequenceOfParentheses[i] == ')')
                        {
                            continue;
                        }
                        else if (lastAddedBracket == '[' && sequenceOfParentheses[i] == ']')
                        {
                            continue;
                        }
                        else if (lastAddedBracket == '{' && sequenceOfParentheses[i] == '}')
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            Console.WriteLine("NO");
                            break;
                        }

                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
