using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDayCodes
{
    class Solution

    {
        public string name = "";
        public Solution()
        {
            this.name = "Akash";
        }
        public Solution(string name)
        {
            this.name = name;
        }
        public void SecondLargest(int[] nums)
        {
            Array.Sort(nums);
            Console.WriteLine("second largest element : " + nums[nums.Length - 2]);
        }

        //public virtual override Equals(Object obj)
        //{

        //    Solution obj1 = new Solution("Piyush");
        //    if (obj1.Equals(obj))
        //    {
        //        Console.WriteLine("Objects are equal.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Objects are not equal.");
        //    }
        //}

        public static void ReverseString(string s)

        {
            s.ToLower();
            string news = s[0].ToString().ToUpper() + s.Substring(1);
            news.Trim();
            s = news;
            char[] ch = s.ToCharArray();
            Array.Reverse(ch);
            string sub = "";
            int length = ch.Length;
            for (int i = 0; i < length; i++)
            {

                sub += ch[i];
            }
            Console.WriteLine(sub);
        }



    }


    partial class Person
    {
        public int AadharId { get; set; }
        public string Name { get; set; }
       
        public Person()
        {
            AadharId = 0;
            Name = string.Empty;
            Console.WriteLine("Person Default Constructor");
        }

        public Person(int Aadhar, string Name)
        {
            this.AadharId = Aadhar;
            this.Name = Name;
        }

        public override string ToString()
        {
            return $"Aadhar : {AadharId} , Name : {Name} ";
        }
    }

    class Student : Person
    {

        public string Degree { get; set; }
        public string College { get; set; }

        public Student()
        {
            Degree = string.Empty;
            College = string.Empty;
            Console.WriteLine("Student Default Constructor");
        }

        public Student(int id, string name, string degree, string college) : base(id, name) // to use SRP from SOLID principal
        {
            Degree = degree;
            College = college;
        }

        public override string ToString()
        {
            return base.ToString() + $"Degree: {Degree}, College: {College}";
        }
    }

    internal class Program
    {

        //static void Main(string[] args)
        //{

        //    Solution sol = new Solution();

        //    //sol.SecondLargest(new int[] { 3, 5, 7, 2, 8 });

        //    //Solution.ReverseString("hello");
        //    Person obj = new Student(1,"Akash" , "BE" , "CU");
        //    Console.WriteLine(obj.ToString()); 
        //}
    }
}
