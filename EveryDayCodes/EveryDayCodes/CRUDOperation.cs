using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace EveryDayCodes
{

    class Student
    {
        public int Id { get; set; }
        public decimal Marks { get; set; }
        public string Name { get; set; }

        public Student(string Name ,int id , int marks )
        {
            this.Name = Name;
            this.Id = id;
            this.Marks = marks;
        }
    }

    class  Manager 
    {
        Dictionary<int , Student> students = new Dictionary<int , Student>(); 
        public string AddData(Student stud)
        {
            if (!students.ContainsKey(stud.Id))
            {
                students.Add(stud.Id , stud);
                return "Add data: Student added successfylly";
            }
           
            return "Add data : Id already existing.";
           
        }
        

        public void DisplayAllStudents()
        {
            Console.WriteLine("DETAILS--------------------------");
            foreach(var student in students)
            {
                Console.WriteLine($"id : {student.Key} | Name : {student.Value.Name} | Marks : {student.Value.Marks}");
            }
            Console.WriteLine("DETAILS--------------------------");

        }

        public void DisplayParticular()
        {

         
            bool check = true;
            while (check)
            {
                Console.Write("Search Id of student : ");
                
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID input.");
                    continue;
                }


                if (students.ContainsKey(id))
                {
                    Student student = students[id];
                    Console.WriteLine(
                        $"id : {student.Id} | Name : {student.Name} | Marks : {student.Marks}"
                    );
                }
                else
                {
                    Console.WriteLine($"No student found with id : {id}.");
                    
                }

                string choice = "";
                Console.Write("Do you want to search another student (y/n) : ");
                choice = Console.ReadLine();
                if (choice.ToLower() == "y")
                {
                    continue;
                }
                else if(choice.ToLower() == "n")
                {
                    check = false;
                }else
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
            }
            
        }

        public void UpdateStudent(Student student)
        {
            if (!students.ContainsKey(student.Id))
            {
                Console.WriteLine($"Student with id {student.Id} not found");
                return;
            }

            students[student.Id] = student;

            Console.WriteLine("Updated Student:");
            Console.WriteLine(
                $"Id: {student.Id} | Name: {student.Name} | Marks: {student.Marks}"
            );
        }


        public void DeleteStudent(int id)
        {
            if (students.ContainsKey(id))
            {
                students.Remove(id);
                Console.WriteLine($"Student with id {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Student with id {id} not found.");
            }
        }
    
        public void ValidatePan(string pan)
        {
            ////check 1
            //if (pan.Length != 10)
            //{
            //    Console.WriteLine("InValid Pan Number.");
            //    return;
            //}

            ////check 2 & 3
            //int alphaCnt = 0;
            //int digCnt = 0;

            //for (int i=0; i<pan.Length; i++) 
            //{
            //    char c = pan[i];

            //    if (char.IsLetter(c) && ((i>=0 && i<5) || i==pan.Length-1)) alphaCnt++;
            //    if(char.IsDigit(c) && (i>=5 && i<=pan.Length-2)) digCnt++;

            //}

            //if(alphaCnt==6 && digCnt==4)
            //{
            //    Console.WriteLine("Valid Pan Number.");
            //}
            //else
            //{
            //    Console.WriteLine("InValid Pan Number.");

            //}

            //REGEX APPROACH

            bool IsValid = Regex.IsMatch(pan, @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$");  //^ used for starting and $ for ending of string so that no extra char before and after.
            if(IsValid)
            {
                Console.WriteLine("Valid Pan Number.");
            }
            else
            {
                Console.WriteLine("InValid Pan Number.");
            }
        }

        public void ValidateMobileNumber(string mob) // number type : starts with 9 or 8 or 7; eg: 98765-43210
        {
            bool isValid = Regex.IsMatch(mob, @"^[7-9]{1}[0-9]{4}-[0-9]{5}$");
            if(isValid)
            {
                Console.WriteLine("Valid Mobile Number.");
            }
            else
            {
                Console.WriteLine("InValid Mobile Number.");
            }
        }
    }


    internal class CRUDOperation
    {
        //public static void Main(string[] args)
        //{
        //    Student[] students = new Student[]
        //    {
        //        new Student(
        //                "Akash" , 1 , 100
        //        ),
        //        new Student(
        //                "Piyush" , 2 , 90
        //        ),
        //        new Student(
        //                "Yash" , 3 , 50
        //        ),
        //        new Student(
        //                "Argha" , 4 , 10
        //        ),
        //    };

        //    Manager mgr = new Manager();

        //    //for (int i = 0; i < students.Length; i++)
        //    //{
        //    //    mgr.AddData(students[i]);

        //    //}

        //    //mgr.DisplayAllStudents();

        //    //mgr.AddData(
        //    //    new Student("Aryan", 6, 90)

        //    //);

        //    //mgr.DisplayParticular();


        //    //mgr.UpdateStudent(
        //    //   new Student("Piyush Kumar", 2, 95)
        //    //);

           
        //    mgr.ValidatePan("ABCDE1234F");
        //    mgr.ValidateMobileNumber("98398-74533");


        //}

    }
}
