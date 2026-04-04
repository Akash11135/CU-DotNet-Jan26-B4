using Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class TransactionController(TransactionService service) : Controller
    {
        private readonly TransactionService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions(int id)
        {
            var resp = await _service.GetAllAsync(id);
            
            return View(resp);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)  
        {
            var details = await _service.GetDetailsByIdAsync(id);

            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(int id)
        //{

        //}
    }
}
