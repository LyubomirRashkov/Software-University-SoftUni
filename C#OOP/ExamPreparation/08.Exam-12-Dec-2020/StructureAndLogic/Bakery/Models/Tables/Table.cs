using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private const int MinValue = 0;

        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal bill;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();

            this.bill = 0;
        }

        public int TableNumber
        {
            get => this.tableNumber;
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsEqualOrLessThanTheGivenBase(value, MinValue, ExceptionMessages.InvalidTableCapacity);

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                Validator.ThrowsExceptionWhenParameterIsEqualOrLessThanTheGivenBase(value, MinValue, ExceptionMessages.InvalidNumberOfPeople);

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get => this.pricePerPerson;
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved
        {
            get => this.isReserved;
            private set 
            {
                this.isReserved = value;
            }
        }

        public decimal Price => (this.NumberOfPeople * this.PricePerPerson);

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.bill = 0;

            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal foodsPrice = this.foodOrders.Sum(f => f.Price);
            decimal drinksPrice = this.drinkOrders.Sum(d => d.Price);

            return (this.bill + foodsPrice + drinksPrice);
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.Append($"Price per Person: {this.PricePerPerson:F2}");

            return sb.ToString();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;

            this.bill += (this.NumberOfPeople * this.PricePerPerson);
        }
    }
}
