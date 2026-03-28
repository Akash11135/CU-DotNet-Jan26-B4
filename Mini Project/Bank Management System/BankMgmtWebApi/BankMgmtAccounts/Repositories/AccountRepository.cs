using BankMgmtWebApi.Data;
using BankMgmtWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace BankMgmtWebApi.Repositories
{
    public class AccountRepository : IAccountRepositories
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            var allAccounts = await _context.Accounts.ToListAsync();
            return allAccounts;
        }

        
        public async Task<Account> GetByIdAsync(int Id)
        {
           

            var accountById = await _context.Accounts.FirstOrDefaultAsync(a=>a.Id==Id);

            if (accountById == null)
            {
                return null;
            }

            return accountById;
        }

        
        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteAsync(int Id)
        //{
        //    var objToRemove = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == Id);
        //    if(objToRemove==null)return 
        //    return await _context.Remove();
        //}
    }
}