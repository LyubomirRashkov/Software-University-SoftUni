﻿namespace _06.FoodShortage
{
    public class Citizen : Buyer
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
