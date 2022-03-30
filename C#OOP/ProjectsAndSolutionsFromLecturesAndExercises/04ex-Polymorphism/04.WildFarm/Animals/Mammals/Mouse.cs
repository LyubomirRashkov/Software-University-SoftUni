using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WeightModifier = 0.1;

        private static HashSet<string> allowedFoods = new HashSet<string> 
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, livingRegion, WeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
