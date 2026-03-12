using Microsoft.AspNetCore.Mvc;

namespace DAY54_BS_Site.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Consulting()
        {
            return View();
        }

        public IActionResult Training()
        {
            return View();
        }

    }
}
