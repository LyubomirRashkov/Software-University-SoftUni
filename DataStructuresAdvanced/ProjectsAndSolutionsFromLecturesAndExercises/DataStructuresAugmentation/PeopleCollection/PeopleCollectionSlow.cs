namespace CollectionOfPeople
{
    using System.Collections.Generic;
	using System.Linq;

	public class PeopleCollectionSlow : IPeopleCollection
    {
        private List<Person> people;

        public PeopleCollectionSlow()
        {
            this.people = new List<Person>();
        }

        public int Count => this.people.Count;

        public bool Add(string email, string name, int age, string town)
        {
            if (this.Find(email) != null)
            {
                return false;
            }

            this.people.Add(new Person(email, name, age, town));

            return true;
        }

        public bool Delete(string email) => this.people.Remove(this.Find(email));

        public Person Find(string email) => this.people.FirstOrDefault(p => p.Email == email);

        public IEnumerable<Person> FindPeople(string emailDomain) 
            => this.people
                .Where(p => p.Email.Split("@", System.StringSplitOptions.RemoveEmptyEntries)[1] == emailDomain)
                .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPeople(string name, string town)
            => this.people
                .Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
            => this.people
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
            => this.FindPeople(startAge, endAge)
                .Where(p => p.Town == town);
    }
}
