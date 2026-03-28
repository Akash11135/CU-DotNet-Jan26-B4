using BankMgmtTransactions.DTOs;
using BankMgmtTransactions.Models;
using BankMgmtTransactions.Repository;

namespace BankMgmtTransactions.Services
{
    public class TransactionServices : ITransactionService
    {
        private readonly ITransactionRepo _repo;

        public TransactionServices(ITransactionRepo repo)
        {
            _repo = repo;
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
    }
}