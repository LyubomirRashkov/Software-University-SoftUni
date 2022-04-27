using System;

namespace TemplatePattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();

            Console.WriteLine();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            Console.WriteLine();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
