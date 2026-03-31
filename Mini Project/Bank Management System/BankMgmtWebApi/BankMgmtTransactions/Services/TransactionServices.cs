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
        public TransactionServices(ITransactionRepo repo , HttpClient http)
        {
            _repo = repo;
            _http = http;
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
            };

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
                Amount = a.Amount,
                TransactionType = a.TransactionType,
                AccountId = a.AccountId,


            }).ToList();
        }

        public async Task<CreateTransactionDto> GetTransactionById(int id)
        {
            var transaction = await _repo.GetByIdAsync(id);
            return new CreateTransactionDto
            {
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType,
                AccountId = transaction.AccountId,
            };
        }

        public async Task<List<CreateTransactionDto>> GetTransactionForAccount(int id)
        {
            var transactions = await _repo.GetAllByAccount(id);

            return transactions.Select(a => new CreateTransactionDto 
            {
                Amount = a.Amount,
                TransactionType = a.TransactionType,
                AccountId = a.AccountId,
            }).ToList();
        }
    }
}