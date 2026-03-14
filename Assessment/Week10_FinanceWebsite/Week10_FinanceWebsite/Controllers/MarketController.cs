using Microsoft.AspNetCore.Mvc;

namespace Week10_FinanceWebsite.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Summary()
        {
            ViewBag.MarketStatus = "Open";

            ViewData["TopGainer"] = "NVIDIA";
            ViewData["Volume"] = 98000000L;


            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker, int? days)
        {
            int period = days ?? 30;

            ViewBag.Ticker = ticker;
            ViewBag.Days = period;

            return View();
        }
    }
}
