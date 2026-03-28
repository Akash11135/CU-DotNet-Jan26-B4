using Assessment_63_02.Models;
using Assessment_63_02.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_63_02.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IPricingServices _pricingServices;

        public CheckOutController(IPricingServices pricingServices)
        {
            _pricingServices = pricingServices;
        }

        public IActionResult Index()
        {
            string promo = "FREESHIP";

            var cartItems = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Apple",
                    Description = "Apple products",
                    Price = 1000,
                    FinalPrice = _pricingServices.CalculatePrice(1000,promo,true)
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Microsoft",
                    Description = "Windows products",
                    Price = 2000,
                    FinalPrice = _pricingServices.CalculatePrice(2000,promo,false)
                }
            };

            double total = cartItems.Sum(p => p.FinalPrice);

            ViewBag.Total = total;
            ViewBag.Promo = promo;

            return View(cartItems);
        }
    }
}