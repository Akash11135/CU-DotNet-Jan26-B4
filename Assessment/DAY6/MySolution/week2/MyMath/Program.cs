using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary;

namespace UseLiberaryDemo

{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMathFunctions math = new MyMathFunctions();
            Console.WriteLine(math.Add(5, 10)) ;
        }
    }
}
