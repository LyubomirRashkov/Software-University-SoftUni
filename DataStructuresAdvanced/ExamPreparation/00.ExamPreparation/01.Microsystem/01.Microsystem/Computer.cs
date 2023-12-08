namespace _01.Microsystem
{
    public class Computer
    {
        public Computer(int number, Brand brand, double price, double screenSize, string color)
        {
            this.Number = number;
            this.Brand = brand;
            this.RAM = 8;
            this.Price = price;
            this.ScreenSize = screenSize;
            this.Color = color;
        }
        public int Number { get; set; }

        public Brand Brand { get; set; }

        public int RAM { get; set; }

        public double Price { get; set; }

        public double ScreenSize { get; set; }

        public string Color { get; set; }

		public override bool Equals(object obj)
		{
            Computer other = obj as Computer;

			return this.Number == other.Number
                   && this.Brand == other.Brand
                   && this.RAM == other.RAM
                   && this.Price == other.Price
                   && this.ScreenSize == other.ScreenSize
                   && this.Color == other.Color;
		}
	}
}
