using BankMgmtTransactions.DTOs;
using BankMgmtTransactions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankMgmtTransactions.Controllers
{
    [Authorize]
    [ApiController]
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionServices _services;

        public TransactionController(TransactionServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionDto dto)
        {
            var res = await _services.Createtransaction(dto);
            return Ok(res);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAllTransactions()
        {
            var result = await _services.GetAllTransaction();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            var res = await _services.GetTransactionById(id);
            if (res == null)
            {
                return Ok("No transaction exists.");
            }
            return Ok(res);
        }

        [HttpGet("getallbyaccount/{id}")]
        public async Task<IActionResult> GetAllTransactionsByAccount(int id)
        {
            var result = await _services.GetTransactionForAccount(id);
            return Ok(result);
        }
    }
}
