using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TruckUsers.Controllers
{
    [ApiController]   
    [Route("api/[controller]")]   // ✅ REQUIRED
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
       
        public IActionResult Public()
        {
            return Ok("Public endpoint");
        }

        [Authorize]
        [HttpGet("secure")]
        public IActionResult Secure()
        {
            return Ok("Secure endpoint");
        }
    }
}