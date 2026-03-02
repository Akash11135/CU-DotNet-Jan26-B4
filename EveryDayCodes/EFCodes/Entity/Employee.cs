using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodes.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; } //pk
        public string EmployeeName { get; set; }



        public int Salary { get; set; }

        //Creates Foreign Key
        public int DepartmentId { get; set; } //fk

        //many to 1  (Not necessory but highly recommended)
        //🔍 Behind the scenes(SQL)

        //EF creates something like:

        //FOREIGN KEY(DepartmentId)
        //REFERENCES Departments(DepartmentId)
        public Department Department { get; set; }

    }
}
