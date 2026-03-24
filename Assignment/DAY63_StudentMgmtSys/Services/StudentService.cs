using DAY63_StudentMgmtSys.Models;
using  DAY63_StudentMgmtSys.Repositories;
using DAY63_StudentMgmtSys.Models;
using DAY63_StudentMgmtSys.Repositories;

namespace DAY63_StudentMgmtSys.Services
{
    public class StudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repo)
        {
            repository = repo;
        }

        public void AddStudent(Student student)
        {
            if (student.Grade < 0 || student.Grade > 100)
                throw new Exception("Grade must be between 0 and 100");

            repository.AddStudent(student);
        }

        public List<Student> GetStudents()
        {
            return repository.GetStudents();
        }
    }
}