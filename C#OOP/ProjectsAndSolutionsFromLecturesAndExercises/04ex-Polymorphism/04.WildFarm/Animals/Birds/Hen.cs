using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WeightModifier = 0.35;

        private static HashSet<string> allowedFoods = new HashSet<string> 
        {
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, allowedFoods, wingSize, WeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
