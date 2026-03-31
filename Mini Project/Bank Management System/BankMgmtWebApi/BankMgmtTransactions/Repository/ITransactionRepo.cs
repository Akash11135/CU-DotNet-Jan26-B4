
using BankMgmtTransactions.Models;

namespace BankMgmtTransactions.Repository
{
    public interface ITransactionRepo
    {
        public Task<Transaction> GetByIdAsync(int id);
        public Task<List<Transaction>> GetAllAsync();
        public Task AddAsync(Transaction transaction);
        public Task SaveAsync();
        public Task<List<Transaction>> GetAllByAccount(int id);
    }
}
