using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstMultiplier = Console.ReadLine();
            int secondMultiplier = int.Parse(Console.ReadLine());

            int currentResult = 0;
            StringBuilder result = new StringBuilder();

            if (secondMultiplier == 0)
            {
                Console.WriteLine(0);
            }
            else
            {

                for (int i = firstMultiplier.Length - 1; i >= 0; i--)
                {
                    int currentMultiplier = int.Parse(firstMultiplier[i].ToString());

                    currentResult += (currentMultiplier * secondMultiplier);

                    int currentDigit = currentResult % 10;

                    result.Append(currentDigit);

                    currentResult /= 10;
                }

                if (currentResult > 0)
                {
                    result.Append(currentResult);
                }

                string output = result.ToString();

                Console.WriteLine(string.Join("", output.Reverse()));
            }

        }
    }
}
