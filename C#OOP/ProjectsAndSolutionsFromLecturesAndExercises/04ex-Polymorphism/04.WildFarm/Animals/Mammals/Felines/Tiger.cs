using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double WeightModifier = 1;

        private static HashSet<string> allowedFoods = new HashSet<string> 
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, allowedFoods, livingRegion, breed, WeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
