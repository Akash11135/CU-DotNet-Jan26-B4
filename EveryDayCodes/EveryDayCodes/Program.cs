using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDayCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            emp.Name = "John";
            emp.Department = "IT";
            emp.Salary = 70000;

            emp.DisplayDetails();

            Console.ReadLine(); // keeps console open
        }
    }
}
