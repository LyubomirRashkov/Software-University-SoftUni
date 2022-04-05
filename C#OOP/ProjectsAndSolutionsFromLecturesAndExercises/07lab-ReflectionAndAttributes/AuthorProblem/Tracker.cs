using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static
                                                    | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                IEnumerable<AuthorAttribute> attributes = method.GetCustomAttributes()
                                                                    .Where(m => m.GetType() == typeof(AuthorAttribute))
                                                                    .Cast<AuthorAttribute>();

                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
