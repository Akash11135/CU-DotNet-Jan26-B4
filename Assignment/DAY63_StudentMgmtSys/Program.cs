
using DAY63_StudentMgmtSys.Models;
using DAY63_StudentMgmtSys.Repositories;
using DAY63_StudentMgmtSys.Services;

namespace ConsoleAppLayers.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Storage Type");
            Console.WriteLine("1. In Memory");
            Console.WriteLine("2. JSON File");

            string choice = Console.ReadLine();

            IStudentRepository repository;

            if (choice == "1")
                repository = new ListStudentRepository();
            else
                repository = new JsonStudentRepository();

            StudentService service = new StudentService(repository);

            Console.Write("Enter Student Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Grade: ");
            int grade = int.Parse(Console.ReadLine());

            Student student = new Student
            {
                Id = id,
                Name = name,
                Grade = grade
            };

            service.AddStudent(student);

            Console.WriteLine("Student Saved!\n");

            var students = service.GetStudents();

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
            }
        }
    }
}