using EFCodes.Data;
using EFCodes.Entity;

using EFCodes.Data;
using EFCodes.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCodes
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new ProjectContext())
            {
               
                var departments = new List<Department>
                {
                    new Department { DepartmentName = "HR" },
                    new Department { DepartmentName = "IT" },
                    new Department { DepartmentName = "Finance" }
                };

                await context.AddRangeAsync(departments);
                await context.SaveChangesAsync(); // generate IDs

              
                var employees = new List<Employee>
                {
                   
                    new Employee { EmployeeName = "Akash", DepartmentId = departments[0].DepartmentId },
                    new Employee { EmployeeName = "Rohit", DepartmentId = departments[0].DepartmentId },

                  
                    new Employee { EmployeeName = "Neha", DepartmentId = departments[1].DepartmentId },
                    new Employee { EmployeeName = "Amit", DepartmentId = departments[1].DepartmentId },

                    // Finance
                    new Employee { EmployeeName = "Priya", DepartmentId = departments[2].DepartmentId },
                    new Employee { EmployeeName = "Karan", DepartmentId = departments[2].DepartmentId }
                };

                await context.AddRangeAsync(employees);
                await context.SaveChangesAsync();

                Console.WriteLine("Data inserted successfully!");

                var empl = await context.Employees
                  .Include(e => e.Department)
                  .ToListAsync();

                foreach (var e in empl)
                {
                    Console.WriteLine($"{e.EmployeeName} - {e.Department.DepartmentName}");
                }
            }
        }
    }
}