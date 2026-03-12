using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_context.Todos.ToList());
        }

        [HttpPost]
        public IActionResult PostTodos(TodoItem item)
        {
            //var existing = _context.Todos.Find(item);
            //if (existing != null)
            //{
            //    return Ok(new { mess = "Item already exists." });
            //}
            _context.Add(item);
            return Ok(_context.Todos.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, TodoItem updatedItem)
        {
            var existingItem = _context.Todos.Find(id);
            if (existingItem == null)
            {
                return NotFound(new { mess = "Item not found." });
            }

            // Update properties
            existingItem.Title = updatedItem.Title;
            existingItem.Description = updatedItem.Description;
            existingItem.CreatedDate = updatedItem.CreatedDate; // optional

            _context.SaveChanges(); // save changes to DB

            return Ok(existingItem); // return the updated item
        }

        [HttpDelete("{id}")]
        public IActionResult PostDelete(int id)
        {
            var existing = _context.Todos.Find(id);
            if (existing == null)
            {
                return Ok(new { mess = "No data found to delete"});
            }
            _context.Todos.Remove(existing);
            return Ok(existing);
        }
    }
}
