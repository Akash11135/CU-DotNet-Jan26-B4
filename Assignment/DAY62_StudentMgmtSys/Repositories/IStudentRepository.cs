using DAY63_StudentMgmtSys.Models;
namespace DAY63_StudentMgmtSys.Repositories
{

    public interface IStudentRepository
    {
        public void AddStudent(Student student);
        public List<Student> GetStudents();
    }
}
