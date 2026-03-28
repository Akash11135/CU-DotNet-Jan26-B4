using Microsoft.AspNetCore.Mvc;

namespace AuthTruck.Controllers
{
    public class AuthController : Controller
    {

        [Route("/api/auth")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
