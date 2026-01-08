using System;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Exercise 1: Student Attendance & Eligibility ===");
            int totalClasses = 180;
            int attendedClasses = 152;
            double attendancePercentage = (attendedClasses * 100.0) / totalClasses;
            int eligibility = (int)Math.Round(attendancePercentage);
            Console.WriteLine($"Attendance Percentage: {attendancePercentage}");
            Console.WriteLine($"Eligibility (Rounded): {eligibility}%");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 2: Online Examination Result Processing ===");
            int[] marks = { 78, 82, 91 };
            double averageMarks = marks.Average();
            double roundedAverage = Math.Round(averageMarks, 2);
            int scholarshipScore = (int)Math.Round(averageMarks);
            Console.WriteLine($"Average Marks: {roundedAverage}");
            Console.WriteLine($"Scholarship Score (Int): {scholarshipScore}");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 3: Library Fine Calculation System ===");
            decimal finePerDay = 2.50m;
            int daysLate = 6;
            decimal totalFine = finePerDay * daysLate;
            double analyticsFine = (double)totalFine;
            Console.WriteLine($"Total Fine (Decimal): {totalFine}");
            Console.WriteLine($"Fine for Analytics (Double): {analyticsFine}");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 4: Banking Interest Calculation ===");
            decimal balance = 100000m;
            float interestRate = 7.5f;
            decimal interest = balance * (decimal)interestRate / 100;
            balance += interest;
            Console.WriteLine($"Interest Added: {interest}");
            Console.WriteLine($"Updated Balance: {balance}");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 5: E-Commerce Order Pricing ===");
            double cartTotal = 3499.99;
            decimal tax = 0.18m;
            decimal discount = 0.10m;
            decimal finalAmount = (decimal)cartTotal * (1 + tax - discount);
            Console.WriteLine($"Cart Total: {cartTotal}");
            Console.WriteLine($"Final Payable Amount: {finalAmount}");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 6: Weather Monitoring ===");
            short sensorReading = 325; // example sensor value
            double celsius = sensorReading / 10.0;
            int displayTemperature = (int)Math.Round(celsius);
            Console.WriteLine($"Temperature in Celsius: {celsius}");
            Console.WriteLine($"Displayed Temperature: {displayTemperature}°C");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 7: University Grading Engine ===");
            double finalScore = 87.4;
            byte grade;
            if (finalScore >= 90) grade = 10;
            else if (finalScore >= 80) grade = 9;
            else if (finalScore >= 70) grade = 8;
            else grade = 0;
            Console.WriteLine($"Final Score: {finalScore}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 8: Mobile Data Usage Tracker ===");
            long bytesUsed = 5368709120; // 5 GB
            double usageInGB = bytesUsed / (1024.0 * 1024 * 1024);
            int roundedUsage = (int)Math.Round(usageInGB);
            Console.WriteLine($"Usage in GB: {usageInGB}");
            Console.WriteLine($"Rounded Monthly Usage: {roundedUsage} GB");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 9: Warehouse Inventory Capacity ===");
            int itemCount = 65000;
            ushort maxCapacity = 60000;
            bool capacityExceeded = itemCount > maxCapacity;
            Console.WriteLine($"Item Count: {itemCount}");
            Console.WriteLine($"Max Capacity: {maxCapacity}");
            Console.WriteLine($"Capacity Exceeded: {capacityExceeded}");
            Console.WriteLine();

            Console.WriteLine("=== Exercise 10: Payroll Salary Computation ===");
            int basicSalary = 40000;
            double allowance = 5500.75;
            double deduction = 1200.25;
            decimal netSalary = basicSalary + (decimal)allowance - (decimal)deduction;
            Console.WriteLine($"Basic Salary: {basicSalary}");
            Console.WriteLine($"Net Salary: {netSalary}");
            Console.WriteLine();

            Console.WriteLine("=== Program Execution Completed ===");
            Console.ReadLine();
        }
    }
}
