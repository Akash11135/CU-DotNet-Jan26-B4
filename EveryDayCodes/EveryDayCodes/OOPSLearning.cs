using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDayCodes
{
    //Partial is used in order to create  same named classes in one namespace.
    //Object here is the ultimate base class for all classes in C#.
    //static classes cannot be partial.
    //static means that the class cannot be instantiated.
    //static function means that the function can be called without creating an instance of the class. eg Math.Sqrt()
    //partial class can't have virtual methods.
    partial class Person : Object
    {
        public virtual void Display()
        {
             Console.WriteLine("This is a partial class example.");
        }
    }

    partial class Person : Object
    {
        public void Display2()
        {
            Console.WriteLine("This is a partial class example.");
        }
    }


    internal class OOPSLearning
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            //Console.WriteLine(person.Display2());
        }
         
    }
}
