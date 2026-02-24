using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
       
        var students = new List<Student>{
            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
        };

        var top3 = students.OrderByDescending(s => s.Marks).Take(3);
        var avgByClass = students.GroupBy(s => s.Class)
                                 .Select(g => new { Class = g.Key, Avg = g.Average(x => x.Marks) });

        var belowAvg = students.Where(s => s.Marks <
                            students.Where(x => x.Class == s.Class).Average(x => x.Marks));

        var ordered = students.OrderBy(s => s.Class).ThenByDescending(s => s.Marks);

        var employees = new List<Employee>{
            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
        };

        var salaryStats = employees.GroupBy(e => e.Dept)
            .Select(g => new { Dept = g.Key, Max = g.Max(x => x.Salary), Min = g.Min(x => x.Salary), Count = g.Count() });

        var after2020 = employees.Where(e => e.JoinDate.Year > 2020);
        var annual = employees.Select(e => new { e.Name, AnnualSalary = e.Salary * 12 });

        Console.WriteLine("Done");
    }
}

class Student { public int Id; public string Name; public string Class; public int Marks; }
class Employee { public int Id; public string Name; public string Dept; public double Salary; public DateTime JoinDate; }