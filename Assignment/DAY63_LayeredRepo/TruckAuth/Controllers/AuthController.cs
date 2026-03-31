using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TruckAuth.dto;
using TruckAuth.Models;
using TruckAuth.Services;

namespace TruckAuth.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenService _tokenService;
        public AuthController(UserManager<ApplicationUser> userManager , TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);

            var token = _tokenService.CreateToken(user , roles);

            return Ok(new { passport = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var newUser = new ApplicationUser()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.UserName
            };

            var result = await _userManager.CreateAsync(newUser);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(newUser, dto.Role);

            return Ok("User registered");
           
        }
    }
}
