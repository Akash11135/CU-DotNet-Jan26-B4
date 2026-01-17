using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Assessment
    {
        public void ReadPolicyData(string[] names, decimal[] premiums)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Enter the name of policy holder {i + 1}:");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    i--;
                    continue;
                }

                names[i] = name.ToUpper();

                Console.WriteLine($"Enter the annual premium for {names[i]}:");
                decimal premium;

                if (!decimal.TryParse(Console.ReadLine(), out premium) || premium <= 0)
                {
                    Console.WriteLine("Premium must be a numeric value greater than 0.");
                    i--;
                    continue;
                }

                premiums[i] = premium;
            }
        }

        public string GetCategory(decimal premium)
        {
            if (premium < 10000)
                return "LOW";
            else if (premium <= 25000)
                return "MEDIUM";
            else
                return "HIGH";
        }

        public void DisplaySummary(string[] names, decimal[] premiums)
        {
            decimal total = premiums.Sum();
            decimal avg = total / premiums.Length;
            decimal highest = premiums.Max();
            decimal lowest = premiums.Min();

            Console.WriteLine("----------------------------");
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("----------------------------");

            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Name", "Premium", "Category");
            Console.WriteLine("---------------------------------------------");

            for (int i = 0; i < premiums.Length; i++)
            {
                Console.WriteLine(
                    "{0,-20} {1,-20:N2} {2,-20}",
                    names[i],
                    premiums[i],
                    GetCategory(premiums[i])
                );
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Total Premium     : Rs {total:N2}");
            Console.WriteLine($"Average Premium   : Rs {avg:N2}");
            Console.WriteLine($"Highest Premium   : Rs {highest:N2}");
            Console.WriteLine($"Lowest Premium    : Rs {lowest:N2}");
        }
    }
}
