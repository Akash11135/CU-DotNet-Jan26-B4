using BankMgmtTransactions.DTOs;
using BankMgmtTransactions.Models;
using BankMgmtTransactions.Repository;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BankMgmtTransactions.Services
{
    public class TransactionServices : ITransactionService
    {
        private readonly ITransactionRepo _repo;
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _con;
        public TransactionServices(ITransactionRepo repo , HttpClient http , IHttpContextAccessor con)
        {   
            _repo = repo;
            _http = http;
            _con = con;
        }

        public async Task<CreateTransactionDto> Createtransaction(CreateTransactionDto dto)
        {
            
            var transaction = new Transaction()
            {
                TransactionType = dto.TransactionType,
                AccountId = dto.AccountId,
                Amount = dto.Amount,
                CreatedAt = DateTime.UtcNow,
            };

            await _repo.AddAsync(transaction);
            await _repo.SaveAsync();


            var reqBody = new
            {
                accountId = dto.AccountId,
                amount = dto.Amount,
                transactionType = dto.TransactionType,
          
            };

            var token = _con.HttpContext.Request.Headers["Authorization"]
                .ToString()
                .Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token)) {
                throw new Exception("in backend token is null while sending the token for deposite/withdraw account.");
            }

            _http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(
                JsonSerializer.Serialize(reqBody),
                Encoding.UTF8,
                "application/json"
            );

            
            if (dto.TransactionType.ToLower() == "deposit")
            {
                var response = await _http.PostAsync(
                    $"http://localhost:7001/accounts/deposit",
                    content
                );

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Deposit failed in Account Service {response.StatusCode} , {response.Content}");
            }
            else if (dto.TransactionType.ToLower() == "withdraw")
            {
                var response = await _http.PostAsync(
                    $"http://localhost:7002/accounts/withdraw",content
                  
                );

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Withdraw failed in Account Service  {response.StatusCode} , {response.Content}");
            }

            
            return new CreateTransactionDto
            {
                TransactionId = dto.TransactionId,
                Amount = dto.Amount,
                TransactionType = dto.TransactionType,
                AccountId = dto.AccountId,
            };
        }
        public async Task<List<CreateTransactionDto>> GetAllTransaction()
        {
            var allTrans = await _repo.GetAllAsync();
            return allTrans.Select(a => new CreateTransactionDto
            {
                TransactionId = a.Id,
                Amount = a.Amount,
                TransactionType = a.TransactionType,
                AccountId = a.AccountId,
            }).ToList();
        }

        public async Task<CreateTransactionDto> GetTransactionById(int id)
        {

            var transaction = await _repo.GetByIdAsync(id);
            if (transaction == null)
                throw new Exception("Transaction is null");

            return new CreateTransactionDto
            {
                TransactionId = transaction.Id,
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType
            };
        }

        public async Task<List<CreateTransactionDto>> GetTransactionForAccount(int id)
        {
            var transactions = await _repo.GetAllByAccount(id);

            return transactions.Select(a => new CreateTransactionDto 
            {
                TransactionId = a.Id,
                Amount = a.Amount,
                TransactionType = a.TransactionType,
                AccountId = a.AccountId,
            }).ToList();
        }
    }
}