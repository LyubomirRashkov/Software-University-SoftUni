using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double WeightModifier = 0.4;

        private static HashSet<string> allowedFoods = new HashSet<string> 
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, allowedFoods, livingRegion, WeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
