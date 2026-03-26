using BankMgmtWebApi.Models;

namespace BankMgmtWebApi.Repositories
{
    public interface IAccountRepositories
    {
      
        public Task<Account> GetByIdAsync(int id);
        public Task<List<Account>> GetAllAsync();
        public Task AddAsync(Account account);
        public Task SaveAsync();
    }
}
