using System;

namespace Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {

            string product = Console.ReadLine();
            string output = "";

            switch (product)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    output = "fruit";
                    break;

                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    output = "vegetable";
                    break;

                default:
                    output = "unknown";
                    break;
            }

            Console.WriteLine(output);

        }
    }
}
