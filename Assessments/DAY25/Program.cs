using System;
using System.IO;


namespace DAY25
{
   
    class Program
    {
        static void Main()
        {
            string pin = "";

            Console.Write("Enter 4-digit PIN: ");

           
            while (pin.Length < 4)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                
                if (char.IsDigit(keyInfo.KeyChar))
                {
                    pin += keyInfo.KeyChar;   
                    Console.Write("*");       
                }
            }

            Console.WriteLine("\nPIN captured securely.");

            Console.Write("Enter system message: ");
            string message = Console.ReadLine();

          
            File.WriteAllText("system_log.txt", message);

            Console.WriteLine("Message saved to file.");
        }
    }

}
