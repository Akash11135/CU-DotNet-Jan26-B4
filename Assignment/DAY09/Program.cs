using System;

namespace SalesAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DAYS = 7;

            decimal[] dailySales = new decimal[DAYS];
            string[] salesCategory = new string[DAYS];

            // 1. Data Capture with Validation
            for (int i = 0; i < DAYS; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal sale) && sale >= 0)
                    {
                        dailySales[i] = sale;
                        break;
                    }
                    Console.WriteLine("Invalid input! Sales must be a non-negative number.");
                }
            }

            // 2. Weekly Sales Analysis
            decimal totalSales = 0;
            decimal highestSale = dailySales[0];
            decimal lowestSale = dailySales[0];
            int highestDay = 1;
            int lowestDay = 1;

            for (int i = 0; i < DAYS; i++)
            {
                totalSales += dailySales[i];

                if (dailySales[i] > highestSale)
                {
                    highestSale = dailySales[i];
                    highestDay = i + 1;
                }

                if (dailySales[i] < lowestSale)
                {
                    lowestSale = dailySales[i];
                    lowestDay = i + 1;
                }
            }

            decimal averageSale = totalSales / DAYS;

            int daysAboveAverage = 0;
            for (int i = 0; i < DAYS; i++)
            {
                if (dailySales[i] > averageSale)
                {
                    daysAboveAverage++;
                }
            }

            // 3. Sales Categorization (Parallel Array)
            for (int i = 0; i < DAYS; i++)
            {
                if (dailySales[i] < 5000)
                    salesCategory[i] = "Low";
                else if (dailySales[i] <= 15000)
                    salesCategory[i] = "Medium";
                else
                    salesCategory[i] = "High";
            }

            // 4. Output Report
            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sales        : {totalSales:F2}");
            Console.WriteLine($"Average Daily Sale : {averageSale:F2}\n");

            Console.WriteLine($"Highest Sale       : {highestSale:F2} (Day {highestDay})");
            Console.WriteLine($"Lowest Sale        : {lowestSale:F2} (Day {lowestDay})\n");

            Console.WriteLine($"Days Above Average : {daysAboveAverage}\n");

            Console.WriteLine("Day-wise Sales Category:");
            for (int i = 0; i < DAYS; i++)
            {
                Console.WriteLine($"Day {i + 1} : {salesCategory[i]}");
            }
        }
    }
}
