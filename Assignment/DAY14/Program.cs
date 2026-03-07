using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{

    class Employee
    {
        // 1. Private data member with explicit methods
        private int id;

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return id;
        }

        // 2. Auto property
        public string Name { get; set; }

        // 3. Full property (only specific values allowed)
        private string department;

        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                if (value == "Accounts" || value == "Sales" || value == "IT")
                {
                    department = value;
                }
                else
                {
                    Console.WriteLine("Invalid Department! Allowed: Accounts, Sales, IT");
                }
            }
        }

        // 4. Full property with range validation
        private int salary;

        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value >= 50000 && value <= 90000)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Invalid Salary! Range must be 50000 to 90000");
                }
            }
        }

        // 5. Display method
        public void Display()
        {
            Console.WriteLine("Employee Details");
            Console.WriteLine("----------------");
            Console.WriteLine("Id         : " + id);
            Console.WriteLine("Name       : " + Name);
            Console.WriteLine("Department : " + Department);
            Console.WriteLine("Salary     : " + Salary);
        }
    }


    internal class Program
    {
        static void Main()
        {
            Employee emp = new Employee();

            emp.SetId(101);
            emp.Name = "Akash";
            emp.Department = "IT";
            emp.Salary = 75000;

            emp.Display();
        }
    }

}

