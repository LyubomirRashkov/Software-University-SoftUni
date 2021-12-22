using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"%(?<customer>[A-Z][a-z]+)%([^|$%.]*?)<(?<product>\w+)>([^|$%.]*?)\|(?<count>\d+)\|([^|$%.]*?)(?<price>\d+\.?\d*)\$");

            double totalIncome = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of shift")
                {
                    break;
                }

                Match match = regex.Match(line);

                if (!match.Success)
                {
                    continue;
                }

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int count = int.Parse(match.Groups["count"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                double currentIncome = count * price;

                Console.WriteLine($"{customer}: {product} - {currentIncome:F2}");

                totalIncome += currentIncome;
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
