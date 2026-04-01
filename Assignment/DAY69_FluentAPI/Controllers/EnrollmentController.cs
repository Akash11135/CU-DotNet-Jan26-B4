using DAY69_FluentAPI.Data;
using DAY69_FluentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAY69_FluentAPI.Controllers
{
    [ApiController]
    [Route("api/enroll")]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(int studentId, int courseId)
        {
            var sc = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            _context.StudentCourses.Add(sc);
            await _context.SaveChangesAsync();

            return Ok("Enrolled");
        }
    }
}
