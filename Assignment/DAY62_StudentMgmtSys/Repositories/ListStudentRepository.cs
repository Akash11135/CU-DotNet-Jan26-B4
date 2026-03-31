using DAY63_StudentMgmtSys.Models;
namespace DAY63_StudentMgmtSys.Repositories
{
    public class ListStudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
