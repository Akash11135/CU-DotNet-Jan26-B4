using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDayCodes
{   

    
   
    class Loan

    {
        
        // 1 , "Akash" , 1500.0 , 1
        public int LoanNumber;
        public string CustomerName;
        public decimal PrincipalAmount;
        public int TenureInYears;
       

        public Loan(int LoanNumber , string CustomerName , decimal PrincipalAmount , int TenureInYears)
        {
            this.LoanNumber = LoanNumber;
            this.CustomerName = CustomerName;
            this.PrincipalAmount = PrincipalAmount;
            this.TenureInYears = TenureInYears;    
        }



    }

    class HomeLoan : Loan
    {
        public HomeLoan(int loanNumber, string customerName, decimal principalAmount, int tenure)
           : base(loanNumber, customerName, principalAmount, tenure)
        {
        }


        public decimal Amount()
        {

            decimal rate = 0.08m;
            decimal gstRate = 0.05m;
            decimal otpFeeRate = 0.01m;

            decimal interest = PrincipalAmount * rate * TenureInYears;
            decimal otpFee = PrincipalAmount * otpFeeRate;
            decimal gst = interest * gstRate;

            decimal totalAmount = PrincipalAmount + interest + otpFee + gst;
            return totalAmount;
        }


    }


    class CarLoan : Loan 
    { 
           public CarLoan(int loanNumber , string customerName, decimal principalAmount, int tenure):base(loanNumber ,customerName , principalAmount , tenure ) { }
    
            public decimal Amount()
            {
                decimal rate = 0.09m;
               decimal specialInseuranceCharges = 1500.00m;
                decimal interest = PrincipalAmount * rate * TenureInYears;
                decimal totalAmount = PrincipalAmount + interest+specialInseuranceCharges ;
                return totalAmount;

            }
    }

    internal class LoanCalculation
    {
        public static void Main(string[] args)
        {


            Loan[] loans = new Loan [4]{
                new HomeLoan(1, "Akash", 1500m, 1),
                new HomeLoan(2, "Priya", 3000m, 3),
                new CarLoan(3, "John", 2000m, 2),
                new CarLoan(4, "Piyush", 50000m, 4),
            };

            for(int i=0; i<loans.Length;i++)
            {
                if(loans[i] is HomeLoan)
                {
                    HomeLoan homeLoan = (HomeLoan)loans[i];
                    Console.WriteLine("Total Home Loan Amount for " + homeLoan.CustomerName + ": " + homeLoan.Amount());
                }
                else if(loans[i] is CarLoan)
                {
                    CarLoan carLoan = (CarLoan)loans[i];
                    Console.WriteLine("Total Car Loan Amount for " + carLoan.CustomerName + ": " + carLoan.Amount());
                }
            }
        }
    }
}
