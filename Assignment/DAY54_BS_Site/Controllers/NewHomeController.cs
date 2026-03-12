using Microsoft.AspNetCore.Mvc;

namespace DAY54_BS_Site.Controllers
{
    public class NewHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

    }
}
