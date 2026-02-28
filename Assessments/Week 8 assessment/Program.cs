using System;
namespace Week_8_assessment
{
    internal class Program
    {

public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
              
                if (BaseSalary <= 0)
                    return 0;

 
                if (PerformanceRating < 1 || PerformanceRating > 5)
                    throw new InvalidOperationException("Rating must be between 1 and 5");

                if (AttendancePercentage < 0 || AttendancePercentage > 100)
                    throw new InvalidOperationException("Attendance must be between 0 and 100");

                decimal bonusPercent = 0;

              
                switch (PerformanceRating)
                {
                    case 5: bonusPercent = 25; break;
                    case 4: bonusPercent = 18; break;
                    case 3: bonusPercent = 12; break;
                    case 2: bonusPercent = 5; break;
                    case 1: bonusPercent = 0; break;
                }

              
                if (YearsOfExperience > 10)
                    bonusPercent += 5;
                else if (YearsOfExperience > 5)
                    bonusPercent += 3;

                decimal bonus = BaseSalary * (bonusPercent / 100m);

               
                if (AttendancePercentage < 85)
                    bonus -= bonus * 0.20m;

              
                bonus *= DepartmentMultiplier;

              
                decimal cap = BaseSalary * 0.40m;
                if (bonus > cap)
                    bonus = cap;

               
                if (bonus <= 150000)
                    bonus -= bonus * 0.10m;
                else if (bonus <= 300000)
                    bonus -= bonus * 0.20m;
                else
                    bonus -= bonus * 0.30m;

                return Math.Round(bonus, 2);
            }
        }
}
        
        static void Main(string[] args)
        {
            EmployeeBonus e = new EmployeeBonus();
            Console.WriteLine(e.NetAnnualBonus);
        }
    }
}
