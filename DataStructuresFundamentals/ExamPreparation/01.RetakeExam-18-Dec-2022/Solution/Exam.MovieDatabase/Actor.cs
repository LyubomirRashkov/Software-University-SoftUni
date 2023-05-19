using System.Collections.Generic;

namespace Exam.MovieDatabase
{
    public class Actor
    {
        public Actor(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;

            this.Movies = new HashSet<Movie>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public HashSet<Movie> Movies { get; set; }
	}
}
