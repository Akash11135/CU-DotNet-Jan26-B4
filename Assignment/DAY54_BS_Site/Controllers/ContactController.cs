using Microsoft.AspNetCore.Mvc;

namespace DAY54_BS_Site.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
