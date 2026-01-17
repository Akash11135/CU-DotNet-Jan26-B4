using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 3;

            string[] policyHolderNames = new string[size];
            decimal[] annualPremiums = new decimal[size];

            // Create object of Assessment class with all the methods.
            Assessment assessment = new Assessment();

           
            assessment.ReadPolicyData(policyHolderNames, annualPremiums);
            assessment.DisplaySummary(policyHolderNames, annualPremiums);
        }
    }
}
