using BankMgmtWebApi.DTOs;
using BankMgmtWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankMgmtWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
        {
            var result = await _service.CreateAccount(dto);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _service.Deposit(dto);
            var updated =await  _service.GetById(dto.AccountId);

            return Ok(new {mess=$"successfully deposited.Current Balance {updated.Balance}"});
        }

   
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _service.Withdraw(dto);
            var updated = await _service.GetById(dto.AccountId);

            return Ok(new { mess = $"successfully withdrawn.Current Balance {updated.Balance}" });
        }

        //[HttpPost("delete/{id}")]
        //public async Task<IActionResult> DeleteById(int id)   
        //{
        //    await _service
        //}
    }
}