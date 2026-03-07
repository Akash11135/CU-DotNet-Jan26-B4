
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using System.Text.Json;

namespace DAY25
{

    internal class Program
    {
        //static void Main()
        //{
        //    string pin = "";

        //    Console.Write("Enter 4-digit PIN: ");


        //    while (pin.Length < 4)
        //    {
        //        ConsoleKeyInfo keyInfo = Console.ReadKey(true);


        //        if (char.IsDigit(keyInfo.KeyChar))
        //        {
        //            pin += keyInfo.KeyChar;   
        //            Console.Write("*");       
        //        }
        //    }

        //    Console.WriteLine("\nPIN captured securely.");

        //    Console.Write("Enter system message: ");
        //    string message = Console.ReadLine();


        //    File.WriteAllText("system_log.txt", message);

        //    Console.WriteLine("Message saved to file.");
        //}
    }
    
 

public class Serial
    {
        public class Laptop   // MUST be public
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public int Price { get; set; }
        }

        static void Main(string[] args)
        {
            List<Laptop> laptops = new List<Laptop>()
        {
            new Laptop { Id = 1, Model = "HP Pavilion", Price = 10000 },
            new Laptop { Id = 2, Model = "Dell", Price = 20000 },
            new Laptop { Id = 3, Model = "Acer", Price = 15000 },
        };

            string filepath = "file.xml";
            string dirPath = "D:/college/CAPEGIMINI/assessments/CU-DotNet-Jan26-B4/Assessments/DAY25/xmlfile/";

            string path = Path.Combine(dirPath , filepath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Laptop>));

            using (StreamWriter sw = new StreamWriter(path))
            {
                serializer.Serialize(sw, laptops);
            }

            Console.WriteLine("Serialization done -------------");


            string jsonfilepath = "laptops.json";
            string jsondirPath = "D:/college/CAPEGIMINI/assessments/CU-DotNet-Jan26-B4/Assessments/DAY25/xmlfile/";
            
            
            string jsonPath = Path.Combine(jsondirPath, jsonfilepath);

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true};

            var setData = JsonSerializer.Serialize(laptops , jsonSerializerOptions);
            File.WriteAllText(jsonPath , setData);

            Console.WriteLine("Json serlization done-------------");
            var data = File.ReadAllText(jsonPath);

            var res = JsonSerializer.Deserialize<List<Laptop>>(data);

            foreach(var i in res)
            {
                Console.WriteLine("Model : " + i.Model);
            }


        }
    }

}

