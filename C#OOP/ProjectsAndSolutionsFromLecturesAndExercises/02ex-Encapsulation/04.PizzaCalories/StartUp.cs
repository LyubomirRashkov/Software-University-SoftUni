using System;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(' ');

                string pizzaName = pizzaInfo[1];

                Pizza pizza = new Pizza(pizzaName);

                string[] doughInfo = Console.ReadLine().Split(' ');

                string doughFlourType = doughInfo[1];
                string doughBakingTechnique = doughInfo[2];
                double doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);

                pizza.Dough = dough;

                while (true)
                {
                    string inputLine = Console.ReadLine();

                    if (inputLine == "END")
                    {
                        break;
                    }

                    string[] toppingInfo = inputLine.Split(' ');

                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}
    }
}
