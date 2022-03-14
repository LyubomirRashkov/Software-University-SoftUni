namespace _03.FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;

        public Fish(string fishType, double length, double weight)
        {
            this.FishType = fishType;
            this.Length = length;
            this.Weight = weight;
        }

        public string FishType
        {
            get { return this.fishType; }
            private set { this.fishType = value; }
        }

        public double Length
        {
            get { return this.length; }
            private set { this.length = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}
