using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DogVet
{
	public class DogVet : IDogVet
	{
		private readonly Dictionary<string, Dog> dogsById;

		private readonly Dictionary<string, Dictionary<string, Dog>> dogsByNameByOwnerId;

		public DogVet()
		{
			this.dogsById = new Dictionary<string, Dog>();
			this.dogsByNameByOwnerId = new Dictionary<string, Dictionary<string, Dog>>();
		}

		public int Size => this.dogsById.Count;

		public void AddDog(Dog dog, Owner owner)
		{
			string ownerId = owner.Id;

			string dogName = dog.Name;

			if ((this.dogsById.ContainsKey(dog.Id))
				|| (this.dogsByNameByOwnerId.ContainsKey(ownerId)
					&& dogsByNameByOwnerId[ownerId].ContainsKey(dogName)))
			{
				throw new ArgumentException();
			}

			dog.Owner = owner;

			this.dogsById.Add(dog.Id, dog);

			if (!this.dogsByNameByOwnerId.ContainsKey(ownerId))
			{
				this.dogsByNameByOwnerId.Add(ownerId, new Dictionary<string, Dog>());
			}

			this.dogsByNameByOwnerId[ownerId].Add(dogName, dog);
		}

		public bool Contains(Dog dog) => this.dogsById.ContainsKey(dog.Id);

		public Dog GetDog(string name, string ownerId)
		{
			this.ValidateEntitiesExist(ownerId, name);

			return this.dogsByNameByOwnerId[ownerId][name];
		}

		public Dog RemoveDog(string name, string ownerId)
		{
			this.ValidateEntitiesExist(ownerId, name);

			Dog dog = this.dogsByNameByOwnerId[ownerId][name];

			this.dogsById.Remove(dog.Id);

			this.dogsByNameByOwnerId[ownerId].Remove(name);

			return dog;
		}

		public IEnumerable<Dog> GetDogsByOwner(string ownerId)
		{
			if (!this.dogsByNameByOwnerId.ContainsKey(ownerId))
			{
				throw new ArgumentException();
			}

			return this.dogsByNameByOwnerId[ownerId].Values;
		}

		public IEnumerable<Dog> GetDogsByBreed(Breed breed)
		{
			IEnumerable<Dog> dogs = this.dogsById.Values
				.Where(d => d.Breed == breed);

			if (dogs.Count() == 0)
			{
				throw new ArgumentException();
			}

			return dogs;
		}

		public void Vaccinate(string name, string ownerId)
		{
			this.ValidateEntitiesExist(ownerId, name);

			this.dogsByNameByOwnerId[ownerId][name].Vaccines++;
		}

		public void Rename(string oldName, string newName, string ownerId)
		{
			this.ValidateEntitiesExist(ownerId, oldName);

			Dog dog = this.dogsByNameByOwnerId[ownerId][oldName];

			dog.Name = newName;

			this.dogsByNameByOwnerId[ownerId].Remove(oldName);

			this.dogsByNameByOwnerId[ownerId].Add(newName, dog);
		}

		public IEnumerable<Dog> GetAllDogsByAge(int age)
		{
			IEnumerable<Dog> dogs = this.dogsById.Values
				.Where(d => d.Age == age);

			if (dogs.Count() == 0)
			{
				throw new ArgumentException();
			}

			return dogs;
		}

		public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
			=> this.dogsById.Values
			   .Where(d => d.Age >= lo && d.Age <= hi);

		public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
			=> this.dogsById.Values
			   .OrderBy(d => d.Age)
			   .ThenBy(d => d.Name)
			   .ThenBy(d => d.Owner.Name);

		private void ValidateEntitiesExist(string ownerId, string dogName)
		{
			if (!this.dogsByNameByOwnerId.ContainsKey(ownerId)
				|| !this.dogsByNameByOwnerId[ownerId].ContainsKey(dogName))
			{
				throw new ArgumentException();
			}
		}
	}
}