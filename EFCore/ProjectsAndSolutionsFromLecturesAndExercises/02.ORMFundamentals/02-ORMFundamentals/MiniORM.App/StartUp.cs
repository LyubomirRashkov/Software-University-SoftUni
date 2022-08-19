using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main()
        {
            string connectionString = "Server = (local)\\SQLEXPRESS; Database = MiniORM; Integrated Security = true; Encrypt = false";

            var dbContext = new SoftUniDbContextClass(connectionString);

            dbContext.Employees.Add(new Employee
            {
                FirstName = "George",
                LastName = "LastlyInserted",
                DepartmentId = dbContext.Departments.First().Id,
                IsEmployed = true,
            });

            var employeeToRename = dbContext.Employees.Last();

            employeeToRename.FirstName = "ModifiedNow";

            dbContext.SaveChanges();
        }
    }
}
