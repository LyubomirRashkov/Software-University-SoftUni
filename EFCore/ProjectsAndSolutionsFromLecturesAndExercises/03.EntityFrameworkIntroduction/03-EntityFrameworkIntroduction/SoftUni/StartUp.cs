using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        private static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            var dbContext = new SoftUniContext();

            /*
             
            --- Employees Full Information

                Console.WriteLine(GetEmployeesFullInformation(dbContext));
            
            ---	Employees with Salary Over 50 000

                Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));

            ---	Employees from Research and Development

                Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));

            ---	Adding a New Address and Updating Employee

                Console.WriteLine(AddNewAddressToEmployee(dbContext));

            ---	Employees and Projects

                Console.WriteLine(GetEmployeesInPeriod(dbContext));

            ---	Addresses by Town

                Console.WriteLine(GetAddressesByTown(dbContext));

            ---	Employee 147

                Console.WriteLine(GetEmployee147(dbContext));

            ---	Departments with More Than 5 Employees

                Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbContext));
            
            ---	Find Latest 10 Projects

                Console.WriteLine(GetLatestProjects(dbContext));

            ---	Increase Salaries

                Console.WriteLine(IncreaseSalaries(dbContext));

            ---	Find Employees by First Name Starting with "Sa"

                Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dbContext));

            ---	Delete Project by Id

                Console.WriteLine(DeleteProjectById(dbContext));

            ---	Remove Town

                Console.WriteLine(RemoveTown(dbContext));
            */
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                })
                .ToList();

            sb.Clear();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var filteredEmployees = context.Employees
                .Where(e => e.Salary > 50_000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary,
                })
                .ToList();

            sb.Clear();

            foreach (var employee in filteredEmployees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            string targetDepartmentName = "Research and Development";

            var filteredEmployees = context.Employees
                .Where(e => e.Department.Name == targetDepartmentName)
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary,
                })
                .ToList();

            sb.Clear();

            foreach (var employee in filteredEmployees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var employeeNakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employeeNakov.Address = new Address
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4,
                };

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    AddressId = e.AddressId,
                    AddressText = e.Address.AddressText,
                })
                .ToList();

            sb.Clear();

            foreach (var address in addresses)
            {
                sb.AppendLine(address.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001
                                                          && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate,
                        EndDate = ep.Project.EndDate,
                    })
                })
                .ToList();

            sb.Clear();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    string endDate = project.EndDate != null
                                     ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                     : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count,
                })
                .ToList();

            sb.Clear();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects.
                               Select(ep => new
                               {
                                   ProjectName = ep.Project.Name,
                               })
                               .OrderBy(p => p.ProjectName)
                               .ToList()
                })
                .FirstOrDefault(e => e.EmployeeId == 147);

            sb.Clear();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                sb.AppendLine(project.ProjectName);
            }

            return sb.ToString().TrimEnd();

            /*
             var employee147 = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            sb.Clear();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.EmployeesProjects.OrderBy(ep => ep.Project.Name))
            {
                sb.AppendLine(project.Project.Name);
            }

            return sb.ToString().TrimEnd();
            */
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    Name = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                                .Select(e => new
                                {
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    JobTitle = e.JobTitle,
                                })
                                .OrderBy(e => e.FirstName)
                                .ThenBy(e => e.LastName)
                                .ToList()
                })
                .ToList();

            sb.Clear();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate,
                })
                .ToList();

            sb.Clear();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] targetDepartments = new string[]
            {
                "Engineering", 
                "Tool Design", 
                "Marketing",
                "Information Services",
            };

            var employees = context.Employees
                .Where(e => targetDepartments.Contains(e.Department.Name))
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var outputEmployees = context.Employees
                .Where(e => targetDepartments.Contains(e.Department.Name))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            sb.Clear();

            foreach (var employee in outputEmployees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "Sa%"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            sb.Clear();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            int projectIdToDelete = 2;

            var employeesProject = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectIdToDelete)
                .ToList();

            foreach (var employeeProject in employeesProject)
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            var projectToDelete = context.Projects
                .Find(projectIdToDelete);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                })
                .ToList();

            sb.Clear();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            string townNameToDelete = "Seattle";

            var townToDelete = context.Towns
                .FirstOrDefault(t => t.Name == townNameToDelete);

            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == townNameToDelete)
                .ToList();

            var employeesForChangingAddress = context.Employees
                .Where(e => addressesToDelete.Contains(e.Address))
                .ToList();

            foreach (var employee in employeesForChangingAddress)
            {
                employee.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            string result = $"{addressesToDelete.Count} addresses in Seattle were deleted";

            return result;
        }
    }
}
