using System;

namespace _06._The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int wordLength = 0;
            char symbol = '\0';
            double maxSum = double.MinValue;
            string mostPowerfulWord = "";

            while (input != "End of words")
            {
                wordLength = input.Length;
                double sum = 0;
                char firstSymbol = '\0';

                for (int i = 0; i < wordLength; i++)
                {
                    symbol = input[i];
                    int number = symbol;
                    sum += number;
                    firstSymbol = input[0];
                }

                switch (firstSymbol)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'Y':
                        sum *= input.Length;
                        break;
                    default:
                        sum = Math.Floor(sum / input.Length);
                        break;
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                    mostPowerfulWord = input;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {maxSum}");
        }
    }
}
