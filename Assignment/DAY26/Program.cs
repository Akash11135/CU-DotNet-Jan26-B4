using System;
using System.IO;

namespace DAY26
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    string DirPath = @"D:\college\CAPEGIMINI\assessments\CU-DotNet-Jan26-B4\Assessments\DAY26\Journal\";
        //    string FilePath = "Journal.txt";

        //    string FinalPath = Path.Combine(DirPath, FilePath);

        //    if (!Directory.Exists(DirPath))
        //    {
        //        Console.WriteLine("Directory doesn't exist");
        //        return;
        //    }

        //    if (!File.Exists(FinalPath))
        //    {
        //        Console.WriteLine("File doesn't exist, creating a new file.");
        //        File.Create(FinalPath).Close();
        //    }

        //    // WRITE journal
        //    using (StreamWriter sw = new StreamWriter(FinalPath, true))
        //    {
        //        Console.WriteLine("Welcome to your Journal: THE DAILY LOGGER");
        //        Console.WriteLine("Write your thoughts (type 'done' to finish):");

        //        //sw.WriteLine("\nDate & Time: " + DateTime.Now);

        //        while (true)
        //        {
        //            string data = Console.ReadLine();
        //            if (data?.ToLower() == "done") break;

        //            sw.WriteLine(data);
        //        }
        //    }

        //    // READ journal
        //    using (StreamReader sr = new StreamReader(FinalPath))
        //    {
        //        Console.WriteLine("\nData added to the journal:\n");

        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            Console.WriteLine(line);
        //        }
        //    }
        //}
    }
}
