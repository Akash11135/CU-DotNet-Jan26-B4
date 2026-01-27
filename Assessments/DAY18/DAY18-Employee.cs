using System;

namespace EmployeeCompensation
{
    // 1️⃣ Base Class
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }

        public Employee(int id, string name, decimal basicSalary, int experience)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = basicSalary;
            ExperienceInYears = experience;
        }

        
        public decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"ID: {EmployeeId}");
            Console.WriteLine($"Name: {EmployeeName}");
            Console.WriteLine($"Experience: {ExperienceInYears} years");
            Console.WriteLine($"Annual Salary: {CalculateAnnualSalary()}");
            Console.WriteLine("--------------------------------");
        }
    }

    // 2️⃣ Permanent Employee
    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name, decimal basicSalary, int experience)
            : base(id, name, basicSalary, experience)
        {
        }

        // Method Hiding
        public new decimal CalculateAnnualSalary()
        {
            decimal hra = BasicSalary * 0.20m;
            decimal specialAllowance = BasicSalary * 0.10m;
            decimal bonus = ExperienceInYears >= 5 ? 50000m : 0m;

            return (BasicSalary * 12) + (hra * 12) + (specialAllowance * 12) + bonus;
        }
    }

    // 3️⃣ Contract Employee
    class ContractEmployee : Employee
    {
        public int ContractDurationInMonths { get; set; }

        public ContractEmployee(int id, string name, decimal basicSalary, int experience, int duration)
            : base(id, name, basicSalary, experience)
        {
            ContractDurationInMonths = duration;
        }

        // Method Hiding
        public new decimal CalculateAnnualSalary()
        {
            decimal bonus = ContractDurationInMonths >= 12 ? 30000m : 0m;
            return (BasicSalary * 12) + bonus;
        }
    }

    // 4️⃣ Intern Employee
    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal stipend, int experience)
            : base(id, name, stipend, experience)
        {
        }

        // Method Hiding
        public new decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }
    }

    // 5️⃣ Usage
    internal class Program // i you want to run this code, remove the main function from program.cs file.
    {
        static void Main(string[] args)
        {
            // Base class reference
            Employee emp1 = new PermanentEmployee(1, "Akash", 50000m, 6);

            // Derived class reference
            PermanentEmployee emp2 = new PermanentEmployee(2, "Priya", 50000m, 6);

            Employee emp3 = new ContractEmployee(3, "John", 40000m, 3, 14);
            Employee emp4 = new InternEmployee(4, "Ravi", 15000m, 0);

            Console.WriteLine("Base Reference Call:");
            Console.WriteLine(emp1.CalculateAnnualSalary()); // Base method

            Console.WriteLine("\nDerived Reference Call:");
            Console.WriteLine(emp2.CalculateAnnualSalary()); // Derived method

            Console.WriteLine("\nOther Employees:");
            Console.WriteLine(emp3.CalculateAnnualSalary()); // Base method
            Console.WriteLine(emp4.CalculateAnnualSalary()); // Base method

            Console.ReadLine();
        }
    }
}
