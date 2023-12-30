using System.Collections.Generic;

namespace Exam.Categorization
{
    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Parent { get; set; }

        public List<Category> Children { get; set; }

        public int Depth { get; set; }

        public Category(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;

            this.Children = new List<Category>();
            this.Depth = 0;
        }
	}
}
