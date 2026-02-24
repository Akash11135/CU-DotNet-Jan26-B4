using app1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using app1.Models;

namespace app1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _config;

        public StudentController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/student
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<Student>();

            string conStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string query = "SELECT * FROM Students";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = (int)reader["Age"]
                    });
                }
            }

            return Ok(students);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            string conStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string query = "INSERT INTO Students (Name, Age) VALUES (@name, @age)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@age", student.Age);

                cmd.ExecuteNonQuery();
            }

            return Ok("Student Added");
        }
    }
}