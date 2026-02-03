using System;

namespace EveryDayCodes
{
    internal class Employee
    {
        // Backing fields
        private string name;
        private string department;
        private double salary;

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Department
        {
            get { return department; }
            set
            {
                if (value != "Account" && value != "Sales" && value != "IT")
                {
                    throw new Exception("Invalid Department");
                }
                department = value;
            }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 50000 || value > 90000)
                {
                    throw new Exception("Salary must be between 50k and 90k");
                }
                salary = value;
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("Salary: " + Salary);
        }
    }

}
