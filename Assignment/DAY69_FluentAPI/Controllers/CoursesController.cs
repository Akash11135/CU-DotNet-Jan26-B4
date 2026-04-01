using DAY69_FluentAPI.Data;
using DAY69_FluentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAY69_FluentAPI.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Courses.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Course c)
        {
            _context.Courses.Add(c);
            await _context.SaveChangesAsync();
            return Ok(c);
        }
    }
}
