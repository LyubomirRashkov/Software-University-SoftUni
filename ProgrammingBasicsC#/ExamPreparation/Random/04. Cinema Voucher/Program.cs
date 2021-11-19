using System;

namespace _04._Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int counterOfTickets = 0;
            int counterOfOtherThings = 0;

            while (input != "End")
            {
                int ticketPrice = 0;
                int otherThingsPrice = 0;

                if (input.Length > 8)
                {
                    int firstNumber = input[0];
                    int secondNumber = input[1];
                    ticketPrice = firstNumber + secondNumber;
                    if (ticketPrice > value)
                    {
                        break;
                    }
                    else
                    {
                        counterOfTickets++;
                    }
                }
                else
                {
                    otherThingsPrice = input[0];
                    if (otherThingsPrice > value)
                    {
                        break;
                    }
                    else
                    {
                        counterOfOtherThings++;
                    }
                }

                value -= (ticketPrice + otherThingsPrice);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counterOfTickets}");
            Console.WriteLine($"{counterOfOtherThings}");
        }
    }
}
