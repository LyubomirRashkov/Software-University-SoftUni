using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private Dictionary<string, Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new Dictionary<string, Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Employee employee)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(employee.Name, employee);
            }
        }

        public bool Remove(string name) => this.data.Remove(name);

        public Employee GetOldestEmployee() => this.data.OrderByDescending(kvp => kvp.Value.Age).First().Value;

        public Employee GetEmployee(string name) => this.data[name];

        public string Report() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var kvp in this.data)
            {
                sb.AppendLine(kvp.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
