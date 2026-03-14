namespace WebAppMVC7.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string City { get; set; } = string.Empty;
        public double Salary { get; set; }

    }
}
