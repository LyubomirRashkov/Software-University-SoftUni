using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public int CompareTo([AllowNull] Person other)
        {
            int result = this.name.CompareTo(other.name);

            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            return result;
        }

        public override int GetHashCode()
        {
            int nameHashCode = this.name.GetHashCode();
            int ageHashCode = this.age.GetHashCode();

            return HashCode.Combine(nameHashCode, ageHashCode);
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}
