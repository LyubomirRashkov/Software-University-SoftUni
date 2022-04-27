using System;

namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        protected override void MixIngredients()
        {
            Console.WriteLine($"Gathering ingredients for {this.GetType().Name} Bread.");
        }

        protected override void Bake()
        {
            Console.WriteLine($"Baking the {this.GetType().Name} Bread. (20 minutes)");
        }

        protected override void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} Bread!");
        }
    }
}
