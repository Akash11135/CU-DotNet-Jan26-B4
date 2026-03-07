using System;

namespace SalesOrderProcessingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DAYS = 7;

            decimal[] weeklySales = new decimal[DAYS];
            string[] salesCategories = new string[DAYS];

            // 1. Read sales data
            ReadWeeklySales(weeklySales);

            // 2. Total & Average
            decimal totalSales = CalculateTotal(weeklySales);
            decimal averageSales = CalculateAverage(totalSales, DAYS);

            // 3. Highest & Lowest Sales
            int highestDay, lowestDay;
            decimal highestSale = FindHighestSale(weeklySales, out highestDay);
            decimal lowestSale = FindLowestSale(weeklySales, out lowestDay);

            // 4. Discount (Festival week assumed true for demo)
            bool isFestivalWeek = true;
            decimal discount = CalculateDiscount(totalSales, isFestivalWeek);

            // 5. Tax
            decimal tax = CalculateTax(totalSales - discount);

            // 6. Final Payable Amount
            decimal finalAmount = CalculateFinalAmount(totalSales, discount, tax);

            // 7. Sales Categorization
            GenerateSalesCategory(weeklySales, salesCategories);

            // Output Report
            PrintReport(
                totalSales,
                averageSales,
                highestSale,
                highestDay,
                lowestSale,
                lowestDay,
                discount,
                tax,
                finalAmount,
                salesCategories
            );
        }

        // -------------------- METHODS --------------------

        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal value) && value >= 0)
                    {
                        sales[i] = value;
                        break;
                    }
                    Console.WriteLine("Invalid input! Sales must be non-negative.");
                }
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal total = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                total += sales[i];
            }
            return total;
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal highest = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > highest)
                {
                    highest = sales[i];
                    day = i + 1;
                }
            }
            return highest;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal lowest = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < lowest)
                {
                    lowest = sales[i];
                    day = i + 1;
                }
            }
            return lowest;
        }

        // Method Overloading
        static decimal CalculateDiscount(decimal total)
        {
            return total >= 50000 ? total * 0.10m : total * 0.05m;
        }

        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = CalculateDiscount(total);

            if (isFestivalWeek)
            {
                discount += total * 0.05m;
            }

            return discount;
        }

        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }
        }

        static void PrintReport(
            decimal total,
            decimal average,
            decimal highest,
            int highDay,
            decimal lowest,
            int lowDay,
            decimal discount,
            decimal tax,
            decimal finalAmount,
            string[] categories)
        {
            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Sales        : {total:F2}");
            Console.WriteLine($"Average Daily Sale : {average:F2}\n");

            Console.WriteLine($"Highest Sale       : {highest:F2} (Day {highDay})");
            Console.WriteLine($"Lowest Sale        : {lowest:F2}  (Day {lowDay})\n");

            Console.WriteLine($"Discount Applied   : {discount:F2}");
            Console.WriteLine($"Tax Amount         : {tax:F2}");
            Console.WriteLine($"Final Payable      : {finalAmount:F2}\n");

            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }
    }
}
