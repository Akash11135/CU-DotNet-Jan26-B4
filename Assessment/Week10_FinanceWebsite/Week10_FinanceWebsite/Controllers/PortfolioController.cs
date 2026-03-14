using Microsoft.AspNetCore.Mvc;
using Week10_FinanceWebsite.Models;
namespace Week10_FinanceWebsite.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> assets = new List<Asset>
        {   new Asset { Id = 1, Name = "Apple", Price = 180, Quantity = 5 },
            new Asset { Id = 2, Name = "Tesla", Price = 250, Quantity = 2 },
            new Asset { Id = 3, Name = "Microsoft", Price = 330, Quantity = 3 },
            new Asset { Id = 4, Name = "Amazon", Price = 145, Quantity = 4 },
            new Asset { Id = 5, Name = "Google", Price = 2800, Quantity = 1 },
            new Asset { Id = 6, Name = "Nvidia", Price = 900, Quantity = 2 },
        };

        public IActionResult Index()
        {
            double total = assets.Sum(a => a.Price * a.Quantity);
            ViewData["Total"] = total;

            return View(assets);
        }

        

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);
            return View(asset);
        }

        [Route("Asset/Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset != null)
            {
                assets.Remove(asset);
                TempData["Message"] = "Asset deleted successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}
