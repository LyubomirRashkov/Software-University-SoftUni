using System;
using System.Collections.Generic;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> employeesByCompany = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string company = parts[0];
                string employeeId = parts[1];

                if (!employeesByCompany.ContainsKey(company))
                {
                    employeesByCompany.Add(company, new List<string>() { employeeId });
                }
                else
                {
                    if (!employeesByCompany[company].Contains(employeeId))
                    {
                        employeesByCompany[company].Add(employeeId);
                    }
                }
            }

            foreach (var kvp in employeesByCompany)
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var employeeId in kvp.Value)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }
    }
}
