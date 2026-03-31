using BankMgmtTransactions.Data;
using Microsoft.EntityFrameworkCore;
using BankMgmtTransactions.Models;
namespace BankMgmtTransactions.Repository
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly AppDbContext _context;

        public TransactionRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            var allTransactions = await _context.Transactions.ToListAsync();
            return allTransactions;
        }


        public async Task<Transaction> GetByIdAsync(int Id)
        {
            var transactionById = await _context.Transactions.FirstOrDefaultAsync(a => a.Id == Id);
            return transactionById;
        }


        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetAllByAccount(int id) 
        {
            var result = await _context.Transactions.Where(t => t.AccountId == id).ToListAsync();
            return result;
        }
    }
}
