using Client.DTOs;
using Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _auth.Login(dto);
            Response.Cookies.Append("jwt", token);

            return Redirect("/Account/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationDto dto)
        {
            if (ModelState.IsValid)
            {
                var resp = await _auth.Register(dto);
                if (resp == null)
                {
                    throw new Exception("Error in auth controller registration fe");
                }
            }
            return RedirectToAction("GetAll","Account");
        }
        
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Login","Auth");
        }
    }
}
