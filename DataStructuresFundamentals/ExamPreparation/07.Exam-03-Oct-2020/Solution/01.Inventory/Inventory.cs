namespace _01.Inventory
{
	using _01.Inventory.Interfaces;
	using _01.Inventory.Models;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	public class Inventory : IHolder
	{
		private readonly List<IWeapon> weapons = new List<IWeapon>();

		public int Capacity => this.weapons.Count;

		public void Add(IWeapon weapon) => this.weapons.Add(weapon);

		public IWeapon GetById(int id) => this.weapons.FirstOrDefault(w => w.Id == id);

		public bool Contains(IWeapon weapon) => this.weapons.Contains(weapon);

		public int Refill(IWeapon weapon, int ammunition)
		{
			IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Id == weapon.Id)
				?? throw new InvalidOperationException("Weapon does not exist in inventory!");

			currentWeapon.Ammunition += ammunition;

			if (currentWeapon.Ammunition > currentWeapon.MaxCapacity)
			{
				currentWeapon.Ammunition = currentWeapon.MaxCapacity;
			}

			return currentWeapon.Ammunition;
		}

		public bool Fire(IWeapon weapon, int ammunition)
		{
			IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Id == weapon.Id)
				?? throw new InvalidOperationException("Weapon does not exist in inventory!");

			if (currentWeapon.Ammunition < ammunition)
			{
				return false;
			}

			currentWeapon.Ammunition -= ammunition;

			return true;
		}

		public IWeapon RemoveById(int id)
		{
			IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Id == id)
				?? throw new InvalidOperationException("Weapon does not exist in inventory!");

			this.weapons.Remove(currentWeapon);

			return currentWeapon;
		}

		public void Clear() => this.weapons.Clear();

		public List<IWeapon> RetrieveAll() => new List<IWeapon>(this.weapons);

		public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
		{
			int firstIndex = this.weapons.IndexOf(firstWeapon);

			int secondIndex = this.weapons.IndexOf(secondWeapon);

			if (firstIndex < 0 || secondIndex < 0)
			{
				throw new InvalidOperationException("Weapon does not exist in inventory!");
			}

			if (firstWeapon.Category == secondWeapon.Category)
			{
				(this.weapons[firstIndex], this.weapons[secondIndex]) 
					= (this.weapons[secondIndex], this.weapons[firstIndex]);
			}
		}

		public List<IWeapon> RetriveInRange(Category lower, Category upper) 
			=> this.weapons
				.Where(w => w.Category >= lower && w.Category <= upper)
				.ToList();

		public void EmptyArsenal(Category category)
		{
			foreach (var weapon in this.weapons)
			{
				if (weapon.Category == category)
				{
					weapon.Ammunition = 0;
				}
			}
		}

		public int RemoveHeavy()
		{
			int counter = 0;

			for (int i = 0; i < this.weapons.Count; i++)
			{
				if (this.weapons[i].Category == Category.Heavy)
				{
					this.weapons.RemoveAt(i);

					counter++;

					i--;
				}
			}

			return counter;
		}

		public IEnumerator GetEnumerator()
		{
			foreach (var weapon in this.weapons)
			{
				yield return weapon;
			}
		}
	}
}
