using System;

namespace TemplatePattern
{
    internal class WholeWheat : Bread
    {
        protected override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Whole Wheat Bread.");
        }

        protected override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }

        protected override void Slice()
        {
            Console.WriteLine("Slicing the Whole Wheat Bread!");
        }
    }
}
