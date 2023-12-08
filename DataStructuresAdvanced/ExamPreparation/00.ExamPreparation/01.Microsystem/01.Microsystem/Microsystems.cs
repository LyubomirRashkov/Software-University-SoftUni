namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
	using System.Linq;

	public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer> computersByNumber;

        public Microsystems()
        {
            this.computersByNumber = new Dictionary<int, Computer>();
        }

        public void CreateComputer(Computer computer)
        {
            if (this.computersByNumber.ContainsKey(computer.Number))
            {
                throw new ArgumentException();
            }

            this.computersByNumber.Add(computer.Number, computer);
        }

        public bool Contains(int number) => this.computersByNumber.ContainsKey(number);

        public int Count() => this.computersByNumber.Count;

        public Computer GetComputer(int number)
        {
            this.ValidateComputerExists(number);

            return this.computersByNumber[number];
        }

		public void Remove(int number)
        {
            this.ValidateComputerExists(number);

            this.computersByNumber.Remove(number);
        }

        public void RemoveWithBrand(Brand brand)
        {
            int initialCount = this.computersByNumber.Count;

            this.computersByNumber = this.computersByNumber
                .Where(kvp => kvp.Value.Brand != brand)
                .ToDictionary(x => x.Key, x => x.Value);

            if (initialCount == this.computersByNumber.Count)
            {
                throw new ArgumentException();
            }
        }

        public void UpgradeRam(int ram, int number)
        {
            this.ValidateComputerExists(number);

            this.computersByNumber[number].RAM = Math.Max(this.computersByNumber[number].RAM, ram);
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
            => this.computersByNumber.Values
               .Where(c => c.Brand == brand)
               .OrderByDescending(c => c.Price);

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
            => this.computersByNumber.Values
               .Where(c => c.ScreenSize == screenSize)
               .OrderByDescending(c => c.Number);

        public IEnumerable<Computer> GetAllWithColor(string color)
            => this.computersByNumber.Values
               .Where(c => c.Color == color)
               .OrderByDescending(c => c.Price);

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
            => this.computersByNumber.Values
               .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
               .OrderByDescending(c => c.Price);

		private void ValidateComputerExists(int number)
		{
            if (!this.computersByNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }
		}
    }
}
