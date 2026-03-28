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
            return Ok(new { transaction = res });
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAllTransactions()
        {
            var result = await _services.GetAllTransaction();
            return Ok(new {transactions = result});
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            var res = await _services.GetTransactionById(id);
            return Ok(new { transaction = res });
        }
    }
}
