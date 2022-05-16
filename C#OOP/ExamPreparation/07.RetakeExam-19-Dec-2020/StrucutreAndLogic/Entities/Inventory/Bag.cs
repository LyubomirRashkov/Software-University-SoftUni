using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;

            this.items = new List<Item>();
        }

        public int Capacity 
        {
            get => this.capacity;
            set 
            {
                this.capacity = value;
            } 
        }

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public int Load => this.Items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.Items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
