using Client.DTOs;
using Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _service;

        public AccountController(AccountService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var auth = HttpContext.Request.Cookies["jwt"];
            if (auth == null)
            {

                return Ok(new { Unauthorized = true });


            }
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllAsync();
            return View(res);
         }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto account)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.CreateAsync(account);
              
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var account = await _service.GetByIdAsync(id);
            if(account == null)
            {
                throw new Exception("Unable to edit. Get");
            }

            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountDto account)
        {
            var res = await _service.EditAsync(account);
            if (res == null)
            {
                throw new Exception("Unable to edit. Post");
            }
            return View(res);
        }

        
        
    }
}
