using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Marks { get; set; }

}

class Employee
{
    public int Id;
    public string Name;
    public string Dept;
    public double Salary;
    public DateTime JoinDate;
}

class Product { public int Id; public string Name; public string Category; public double Price; }
class Sale { public int ProductId; public int Qty; }


class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
        };

        var topThree = students.OrderByDescending(s => s.Marks).Take(3);

        //var avgMarks = students.Select(s => s.Class && s.Avg(s.Marks)).GroupBy()


        //Employees---
        var employees = new List<Employee>
        {
            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
        };

        var heighestSal = employees.GroupBy(d => d.Dept).Select(g => new
        {
            Id = g.Key,
            HeighestSalary = g.Max(s => s.Salary),
            LowestSalary = g.Min(selector=>selector.Salary),
            count = g.Count()
        });

        foreach(var employee in heighestSal)
        {
            Console.WriteLine("Heighest Sal : "+employee.HeighestSalary+" LowestSalary : "+employee.LowestSalary+" Count : "+employee.count);
        }

        var employeesAfter2000 = employees.Where(d => d.JoinDate.Year > 2020);

        var nameAndAnnualSalary = employees.Select(g => new { 
            Name = g.Name,
            AnnualSalary = g.Salary*12
        });
        
        Console.WriteLine(string.Join(", ",employeesAfter2000.Select(e=>e.Name)));

        foreach(var i in nameAndAnnualSalary)
        {
            Console.WriteLine($"Name : {i.Name} , AnnualSalary : {i.AnnualSalary}");
        }

        //Products-----

        var products = new List<Product>
        {
            new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
            new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
            new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
        };

        var sales = new List<Sale>
        {
            new Sale{ProductId=1, Qty=10},
            new Sale{ProductId=2, Qty=20}
        };

        var joindata = products.Join(sales, p => p.Id, s => s.ProductId, (p, s) => new
        {
            ProductIdInSales = s.ProductId,
            ProductName = p.Name,
            TotalRevenue = p.Price * s.Qty,
            TotalSales = s.Qty
        });


        foreach(var i in joindata)
        {
            Console.WriteLine($"ProductInSales : {i.ProductIdInSales} , Name : {i.ProductName} , TotalRevenue : {i.TotalRevenue}");
        }
        var zeroSale = products.GroupJoin(sales, p => p.Id, s => s.ProductId, (p, s) => new
        {
            SalesProductId = s.ProductId,

        });

    }
}

