using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double totalPrice = 0;

            if (typeOfPeople == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    totalPrice = numberOfPeople * 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = numberOfPeople * 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = numberOfPeople * 10.46;
                }

                if (numberOfPeople >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (typeOfPeople == "Business")
            {
                if (numberOfPeople >= 100)
                {
                    numberOfPeople -= 10;
                }

                if (dayOfWeek == "Friday")
                {
                    totalPrice = numberOfPeople * 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = numberOfPeople * 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = numberOfPeople * 16;
                }
            }
            else if (typeOfPeople == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    totalPrice = numberOfPeople * 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    totalPrice = numberOfPeople * 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    totalPrice = numberOfPeople * 22.50;
                }

                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    totalPrice *= 0.95;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
