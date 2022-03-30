using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double WeightModifier = 0.25;

        private static HashSet<string> allowedFoods = new HashSet<string> 
        {
            nameof(Meat)
        }; 

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, allowedFoods, wingSize, WeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
