﻿using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get 
            { 
                return this.name;
            }

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value; 
            }
        }

        public decimal Money
        {
            get 
            {
                return this.money;
            }

            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value; 
            }
        }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public string BuyProduct(Product product) 
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.products.Add(product);

                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }
    }
}
