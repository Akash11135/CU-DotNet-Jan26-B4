using DAY26;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


//take input 

//Enter Client Name :
//Charlie
//Enter Principal :
//50000.00
//Enter rate of interest :
//8.9
//Enter Client Name :
//Alice
//Enter Principal :
//250000.00
//Enter rate of interest :
//3.2
//Enter Client Name :
//Bob
//Enter Principal :
//15000
//Enter rate of interest :
//12.5
//Enter Client Name :
//stop

//---------------------- LOAN DETAILS ----------------------

//CLIENT          |    PRINCIPAL |   INTEREST | RISK LEVEL
//------------------------------------------------------------
//Charlie         | $   50,000.00 | $  4,450.00 | MEDIUM
//Alice           | $ 2,50,000.00 | $  8,000.00 | LOW
//Bob             | $   15,000.00 | $  1,875.00 | HIGH

namespace DAY26
{

    class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; } // e.g., 5.5 for 5.5%

        public Loan(string ClientName, double Principal, double InterestRate)
        {
            this.ClientName = ClientName;
            this.Principal = Principal;
            this.InterestRate = InterestRate;

        }
    }
    internal class LoanPortFolio
    {
        static string DirPath = @"D:\college\CAPEGIMINI\assessments\CU-DotNet-Jan26-B4\Assessments\DAY26\Loan\";
        static string FilePath = "Loan.csv";

        static string FinalPath = Path.Combine(DirPath, FilePath);

        static void Main(string[] args)
        {
            FileExists(DirPath , FinalPath);

            AddFileAttributes(FinalPath);

            Display(FinalPath);
            
        }

        static void FileExists(string DirPath , string FinalPath)
        {
            if (!Directory.Exists(DirPath))
            {
                Console.WriteLine("Directory doesnt exist!");
            }

            if (!File.Exists(FinalPath))
            {
                Console.WriteLine("File Doesnt Exists. Creating a new File!");
                File.Create(FinalPath).Close();

            }
        }
    
        static void AddFileAttributes(string DirPath)
        {
            using(StreamWriter sw = new StreamWriter(FinalPath))
            {
                do
                {
                    Console.WriteLine("Enter Client Name : ");
                    string ClientName = Console.ReadLine();
                    if (ClientName.ToLower() == "stop") break;
                    
                    Console.WriteLine("Enter Principal : ");
                    double principal;
                    if(!double.TryParse(Console.ReadLine(), out principal))
                    {
                        Console.WriteLine("Invalid principal!");
                    }
                    
                    Console.WriteLine("Enter rate of interest : ");
                    double interest;
                    if (!double.TryParse(Console.ReadLine(), out interest))
                    {
                        Console.WriteLine("Invalid interest!");
                    }

                    sw.WriteLine($"{ClientName},{principal},{interest}");

                } while (true);
            
                
            }


        }

        static void Display(string FinalPath)
        {
            List<Loan> loanDetails = new List<Loan>();

            using(StreamReader sr = new StreamReader(FinalPath))
            {
                do
                {
                    string line;
                    line = sr.ReadLine();
                    if (line == null) break;
                    string[] sepArr = line.Split(',');
                    string ClientName = sepArr[0];
                    double principal = Convert.ToDouble(sepArr[1]);
                    double interest = Convert.ToDouble(sepArr[2]);
                    loanDetails.Add(new Loan(ClientName, principal, interest));

                } while (true);
            }

            Console.WriteLine("\n---------------------- LOAN DETAILS ----------------------\n");

            Console.WriteLine(
                $"{"CLIENT",-15} | {"PRINCIPAL",12} | {"INTEREST",10} | {"RISK LEVEL",-10}");
            Console.WriteLine(new string('-', 60));

            foreach (var loan in loanDetails)
            {
                double interestAmount = loan.Principal * loan.InterestRate / 100;

                string risk =
                    loan.InterestRate > 10 ? "HIGH" :
                    loan.InterestRate >= 5 ? "MEDIUM" :
                    "LOW";

                Console.WriteLine(
                    $"{loan.ClientName,-15} | " +
                    $"${loan.Principal,12:N} | " +
                    $"${interestAmount,10:N} | " +
                    $"{risk,-10}");
            }
        }
    }
}

