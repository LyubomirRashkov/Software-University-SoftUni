using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] peopleWithTheirMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsWithTheirPrices = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> peopleByTheirNames = new Dictionary<string, Person>();
            Dictionary<string, Product> productsByTheirNames = new Dictionary<string, Product>();

            try
            {
                for (int i = 0; i < peopleWithTheirMoney.Length; i++)
                {
                    string[] personNameAndMoney = peopleWithTheirMoney[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string personName = personNameAndMoney[0];
                    decimal personMoney = decimal.Parse(personNameAndMoney[1]);

                    Person person = new Person(personName, personMoney);

                    peopleByTheirNames.Add(person.Name, person);
                }

                for (int i = 0; i < productsWithTheirPrices.Length; i++)
                {
                    string[] productWithPrice = productsWithTheirPrices[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string productName = productWithPrice[0];
                    decimal productPrice = decimal.Parse(productWithPrice[1]);

                    Product product = new Product(productName, productPrice);

                    productsByTheirNames.Add(product.Name, product);
                }

                while (true)
                {
                    string inputLine = Console.ReadLine();

                    if (inputLine == "END")
                    {
                        break;
                    }

                    string[] inputInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string personName = inputInfo[0];
                    string productName = inputInfo[1];

                    Person targetPerson = peopleByTheirNames[personName];
                    Product targetProduct = productsByTheirNames[productName];

                    Console.WriteLine(targetPerson.BuyProduct(targetProduct));
                }

                foreach (var kvp in peopleByTheirNames)
                {
                    Console.Write($"{kvp.Key} - ");

                    if (kvp.Value.Products.Count == 0)
                    {
                        Console.WriteLine("Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", ", kvp.Value.Products.Select( p => p.Name)));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
