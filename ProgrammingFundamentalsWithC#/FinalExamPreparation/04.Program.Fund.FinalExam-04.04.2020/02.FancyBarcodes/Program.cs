using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int barcodesCount = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"^@#+([A-Z][A-Za-z\d]{4,}[A-Z])@#+$");

            Regex digitsRegex = new Regex(@"\d+");

            for (int i = 0; i < barcodesCount; i++)
            {
                string barcode = Console.ReadLine();

                Match match = regex.Match(barcode);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    MatchCollection matches = digitsRegex.Matches(barcode);

                    string productGroup = string.Empty;

                    if (matches.Count == 0)
                    {
                        productGroup = "00";
                    }
                    else
                    {
                        foreach (Match item in matches)
                        {
                            sb.Append(item.Value);
                        }

                        productGroup = sb.ToString();
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
            }
        }
    }
}
