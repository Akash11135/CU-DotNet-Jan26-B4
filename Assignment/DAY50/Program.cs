using System;
using System.Collections.Generic;

class Student
{
    public int StudId { get; set; }
    public string SName { get; set; }

    public Student(int id, string name)
    {
        StudId = id;
        SName = name;
    }

    
    public override bool Equals(object obj)
    {
        if (obj is Student s)
            return this.StudId == s.StudId;
        return false;
    }

   
    public override int GetHashCode()
    {
        return StudId.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Dictionary<Student, int> studentMarks = new Dictionary<Student, int>();

        AddOrUpdateStudent(studentMarks, new Student(1, "Rahul"), 80);
        AddOrUpdateStudent(studentMarks, new Student(2, "Aman"), 75);
        AddOrUpdateStudent(studentMarks, new Student(1, "Rahul"), 85); 
        AddOrUpdateStudent(studentMarks, new Student(2, "Aman"), 70); 
        AddOrUpdateStudent(studentMarks, new Student(3, "Neha"), 90);

        Display(studentMarks);
    }

    static void AddOrUpdateStudent(Dictionary<Student, int> dict, Student student, int marks)
    {
        if (dict.ContainsKey(student))
        {
            if (marks > dict[student])
            {
                dict[student] = marks;
            }
        }
        else
        {
            dict.Add(student, marks);
        }
    }

    static void Display(Dictionary<Student, int> dict)
    {
        Console.WriteLine("Student Records:");

        foreach (var entry in dict)
        {
            Console.WriteLine($"ID: {entry.Key.StudId}, Name: {entry.Key.SName}, Marks: {entry.Value}");
        }
    }
}