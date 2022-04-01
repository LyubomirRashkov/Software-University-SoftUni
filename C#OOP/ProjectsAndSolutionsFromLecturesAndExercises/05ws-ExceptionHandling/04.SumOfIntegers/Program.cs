using System;
using System.Text.RegularExpressions;

namespace _04.SumOfIntegers
{
    public class Program
    {
        static void Main()
        {
            string[] elements = Console.ReadLine().Split(' ');

            int sum = 0;

            Regex regex = new Regex(@"[+|-]{0,1}\d+");

            foreach (string element in elements)
            {
                try
                {
                    int currentInt = ParseToInteger(element, regex);
                    sum += currentInt;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        private static int ParseToInteger(string element, Regex regex)
        {
            int result = 0;

            if (!regex.IsMatch(element))
            {
                throw new FormatException();
            }

            checked
            {
                result = int.Parse(element);
            }

            return result;
        }
    }
}
