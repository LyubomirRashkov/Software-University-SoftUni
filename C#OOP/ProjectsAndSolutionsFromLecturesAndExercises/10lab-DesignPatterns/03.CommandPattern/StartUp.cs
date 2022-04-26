using System;

namespace _03.CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Product product = new Product("phone", 500);

            ModifyPrice modifyPrice = new ModifyPrice();

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);

            modifyPrice.Invoke();
        }
    }
}
