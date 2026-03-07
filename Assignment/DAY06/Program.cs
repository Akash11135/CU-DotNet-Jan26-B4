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
            string cityNames = "Delhi,Mumbai, ,Bangalore, ,Chennai, ,Hyderabad";

            string[] city = cityNames.Split(',');
            for (int i = 0; i < city.length; i++)
            {
                Console.WriteLine(city[i]);
            }
        }
}
