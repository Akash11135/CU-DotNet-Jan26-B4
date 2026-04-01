using DAY69_FluentAPI.Data;
using DAY69_FluentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAY69_FluentAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Students.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var s = await _context.Students.FindAsync(id);
            return s == null ? NotFound() : Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student s)
        {
            _context.Students.Add(s);
            await _context.SaveChangesAsync();
            return Ok(s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student s)
        {
            if (id != s.Id) return BadRequest();

            _context.Entry(s).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(s);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null) return NotFound();

            _context.Students.Remove(s);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
