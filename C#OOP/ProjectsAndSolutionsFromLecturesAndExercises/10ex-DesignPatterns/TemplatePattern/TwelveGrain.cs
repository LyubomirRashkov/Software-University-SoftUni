using System;

namespace TemplatePattern
{
    public class TwelveGrain : Bread
    {
        protected override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for 12-Grain Bread.");
        }

        protected override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }

        protected override void Slice()
        {
            Console.WriteLine("Slicing the 12-Grain Bread!");
        }
    }
}
