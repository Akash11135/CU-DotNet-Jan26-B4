

using EFDemo.Data;
using EFDemo.Entity;

namespace EFDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ProjectContext context = new ProjectContext())
            {
                //var model = new Laptop {

                //    Name = "Pavillion",
                //    Model = "HP",
                //    Price = 100
                //};
                //context.Laptops.Add(model);
                //context.Laptops.Add
                //    (
                //        new Laptop
                //        {
                //            Name = "Dell",
                //            Model = "something",
                //            Price=200
                //        }
                //    );

                //context.Laptops.Add
                //    (
                //        new Laptop
                //        {
                //            Name = "Apple",
                //            Model = "M-4 Air",
                //            Price = 2000
                //        }
                //    );
                //context.SaveChanges();
                //Console.WriteLine("Inserted..");

                context.Laptops.Add(new Laptop
                {
                  
                    Name = "HP",
                    Model = "Probook",
                    Price = 100000
                });

                context.SaveChanges();
                Console.WriteLine("Added ");
                var LaptopFind = context.Laptops.Find(1);
                //Console.WriteLine("Laptop : "+string.Join(", ",LaptopFind));

                if (LaptopFind != null) {
                    Console.WriteLine("Name : "+LaptopFind.Name);
                }
                else
                {
                    Console.WriteLine("Not Found!");
                }
            }
        }
    }
}
