namespace _06.FoodShortage
{
    public abstract class Buyer
    {
        private const int InitialFood = 0;

        protected Buyer(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = InitialFood;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
