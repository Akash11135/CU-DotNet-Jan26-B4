using DAY63_StudentMgmtSys.Models;
using System.Text.Json;
namespace DAY63_StudentMgmtSys.Repositories
{
    public class JsonStudentRepository : IStudentRepository
    {
        private string filePath = "students.json";

        public void AddStudent(Student student)
        {
            var students = GetStudents();
            students.Add(student);

            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(filePath, json);
        }

        public List<Student> GetStudents()
        {
            if (!File.Exists(filePath))
                return new List<Student>();

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Student>>(json)
                   ?? new List<Student>();
        }
    }
}
