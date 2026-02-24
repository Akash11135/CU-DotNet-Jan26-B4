using System;
using System.Collections.Generic;

class Student
{
    public int Id;
    public string Name;
    public string Class;
    public int Marks;
}

class Employee
{
    public int Id;
    public string Name;
    public string Dept;
    public double Salary;
    public DateTime JoinDate;
}

internal class Demo05LINQOperations
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


        var employees = new List<Employee>
        {
            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
        };
    }
}