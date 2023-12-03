namespace CollectionOfPeople
{
    using System;
    using System.Collections.Generic;
	using System.Linq;
	using Wintellect.PowerCollections;

	public class PeopleCollection : IPeopleCollection
    {
        private readonly Dictionary<string, Person> peopleByEmail;
        private readonly Dictionary<string, SortedSet<Person>> peopleByEmailDomain;
        private readonly Dictionary<(string name, string town), SortedSet<Person>> peopleByNameAndTown;
        private readonly OrderedDictionary<int, SortedSet<Person>> peopleByAge;
        private readonly Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge;

        public PeopleCollection()
        {
            this.peopleByEmail = new Dictionary<string, Person>();
            this.peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
            this.peopleByNameAndTown = new Dictionary<(string, string), SortedSet<Person>>();
            this.peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
            this.peopleByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        }

        public int Count => this.peopleByEmail.Count;

        public bool Add(string email, string name, int age, string town)
        {
            if (this.peopleByEmail.ContainsKey(email))
            {
                return false;
            }

            Person person = new Person(email, name, age, town);

            this.peopleByEmail.Add(email, person);

            this.peopleByEmailDomain.AppendValueToKey(this.GetEmailDomain(email), person);

            this.peopleByNameAndTown.AppendValueToKey((name, town), person);

            this.peopleByAge.AppendValueToKey(age, person);

            this.peopleByTownAndAge.EnsureKeyExists(town);

            this.peopleByTownAndAge[town].AppendValueToKey(age, person);

            return true;
        }

        public bool Delete(string email)
        {
            Person person = this.Find(email);

            if (person is null)
            {
                return false;
            }

            this.peopleByEmailDomain[this.GetEmailDomain(email)].Remove(person);

            this.peopleByNameAndTown[(person.Name, person.Town)].Remove(person);

            this.peopleByAge[person.Age].Remove(person);

            this.peopleByTownAndAge[person.Town][person.Age].Remove(person);

            return this.peopleByEmail.Remove(email);
        }

		public Person Find(string email) => this.peopleByEmail.GetValueOrDefault(email);

        public IEnumerable<Person> FindPeople(string emailDomain) 
            => this.peopleByEmailDomain.GetValuesForKey<string, SortedSet<Person>, Person>(emailDomain);

        public IEnumerable<Person> FindPeople(string name, string town)
            => this.peopleByNameAndTown.GetValuesForKey<(string, string), SortedSet<Person>, Person>((name, town));

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
            => this.peopleByAge
                .Range(startAge, true, endAge, true)
                .SelectMany(kvp => kvp.Value.Select(p => p));

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            if (!this.peopleByTownAndAge.ContainsKey(town))
            {
                return Enumerable.Empty<Person>();
            }

            return this.peopleByTownAndAge[town]
                .Range(startAge, true, endAge, true)
                .SelectMany(kvp => kvp.Value.Select(p => p));
        }

        private string GetEmailDomain(string email) => email.Split("@", StringSplitOptions.RemoveEmptyEntries)[1];
    }
}
