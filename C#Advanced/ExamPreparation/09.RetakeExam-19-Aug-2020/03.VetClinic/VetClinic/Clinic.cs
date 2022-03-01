using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            foreach (Pet pet in this.data)
            {
                if (pet.Name == name)
                {
                    this.data.Remove(pet);

                    return true;
                }
            }

            return false;
        }

        public Pet GetPet(string name, string owner) => this.data.FirstOrDefault(pet => pet.Name == name && pet.Owner == owner);

        public Pet GetOldestPet() => this.data.OrderByDescending(pet => pet.Age).First();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (Pet pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
