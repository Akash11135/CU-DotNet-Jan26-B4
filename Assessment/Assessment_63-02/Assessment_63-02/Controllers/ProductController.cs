using Assessment_63_02.Models;
using Assessment_63_02.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assessment_63_02.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPricingServices _pricingServices;

        public ProductController(IPricingServices pricingServices)
        {
            _pricingServices = pricingServices;
        }

        

        public IActionResult Index()
        {
            string promo = "WINTER25";
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name="Apple",
                    Description="Apple products",
                    Price=1000,
                    FinalPrice= _pricingServices.CalculatePrice(1000,promo,true)
                },
                new Product
                {
                    ProductId = 2,
                    Name="Microsoft",
                    Description="Windows products",
                    Price=2000,
                    FinalPrice= _pricingServices.CalculatePrice(2000,"",false)

                },   new Product
                {
                    ProductId = 3,
                    Name="Tesla",
                    Description="Tesla products",
                    Price=1000,
                    FinalPrice= _pricingServices.CalculatePrice(1500,promo,true)
                },
                new Product
                {
                    ProductId = 4,
                    Name="Amazon",
                    Description="Amazon products",
                    Price=2000,
                    FinalPrice= _pricingServices.CalculatePrice(2500,"",false)

                },
            };

            ViewData["Promo"] = "WINTER25";
            
            return View(products);
        }
    }
}
