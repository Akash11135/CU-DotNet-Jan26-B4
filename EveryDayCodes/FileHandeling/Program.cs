namespace FileHandeling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string DirPath = @"D:\college\CAPEGIMINI\assessments\CU-DotNet-Jan26-B4\FileHandeling\FileHandeling\";

            if (!Directory.Exists(DirPath))
            {
                Console.WriteLine("Directory doesnt exist.");
            }

            string path = "file.txt";

            string FinalPath = Path.Combine(DirPath , path);

            //fs
            using (FileStream fs = new FileStream(FinalPath, FileMode.Open)) //using mean no need of fs.close();
            {
                if (!File.Exists(FinalPath))
                {
                    Console.WriteLine("No File Present, creating a new File.");
                    return;
                }

            }

            //fw

            using (StreamWriter fw = new StreamWriter(FinalPath , true))   //true means the file is ready to append.
            {
                do
                {
                    Console.WriteLine("Enter data to put on the CSV file : ");
                    string data = Console.ReadLine();

                    if (data == "stop") break;

                    fw.WriteLine(data);
                } while (true);
                
            }


            using (StreamReader fr = new StreamReader(FinalPath))
            {
                do
                {
                    string read = fr.ReadLine();
                    Console.WriteLine("Read data : "+read);
                    if (read == null) break;
                } while (true);

            }
        }
    }
}
