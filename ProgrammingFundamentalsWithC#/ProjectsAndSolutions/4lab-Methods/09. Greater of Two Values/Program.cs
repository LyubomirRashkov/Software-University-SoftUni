using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firststr = Console.ReadLine();
            string secondstr = Console.ReadLine();

            string result = GetMax(type, firststr, secondstr);

            Console.WriteLine(result);
        }

        private static string GetMax(string type, string firststr, string secondstr)
        {
            string result = string.Empty;

            if (type == "int")
            {
                int firstNumber = int.Parse(firststr);
                int secondNumber = int.Parse(secondstr);

                if (firstNumber > secondNumber)
                {
                    result = firststr;
                }
                else
                {
                    result = secondstr;
                }
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(firststr);
                char secondChar = char.Parse(secondstr);

                if (firstChar > secondChar)
                {
                    result = firststr;
                }
                else
                {
                    result = secondstr;
                }
            }
            else if (type == "string")
            {
                int comparison = firststr.CompareTo(secondstr);

                if (comparison > 0 )
                {
                    result = firststr;
                }
                else
                {
                    result = secondstr;
                }
            }

            return result;
        }
    }
}
