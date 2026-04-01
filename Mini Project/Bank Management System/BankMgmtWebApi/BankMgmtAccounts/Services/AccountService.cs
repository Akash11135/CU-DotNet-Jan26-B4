using BankMgmtWebApi.DTOs;
using BankMgmtWebApi.Models;
using BankMgmtWebApi.Repositories;

namespace BankMgmtWebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepositories _repo;

        public AccountService(IAccountRepositories repo)
        {
            _repo = repo;
        }

        public async Task<AccountDto> CreateAccount(CreateAccountDto dto)
        {

            

            if (dto.InitialDeposit < 1000)
                throw new Exception("Minimum deposit ₹1000");

            var account = new Account
            {
                Name = dto.Name,
                Balance = dto.InitialDeposit
            };

            await _repo.AddAsync(account);
            await _repo.SaveAsync();

            account.AccountNumber = $"SB-{DateTime.Now.Year}-{account.Id.ToString().PadLeft(6, '0')}";

            await _repo.SaveAsync();

            return new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber
            };
        }

        public async Task<List<AccountDto>> GetAll()
        {
            var accounts = await _repo.GetAllAsync();

            return accounts.Select(a => new AccountDto
            {
                Id = a.Id,
                Name = a.Name,
                Balance = a.Balance,
                AccountNumber = a.AccountNumber
            }).ToList();
        }

        public async Task<AccountDto> GetById(int id)
        {
            var account = await _repo.GetByIdAsync(id);

            if (account == null)
                throw new Exception("Account not found");

            return new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber
            };
        }

        
        public async Task Deposit(TransactionDto dto)
        {
            var account = await _repo.GetByIdAsync(dto.AccountId);

            if (account == null)
                throw new Exception("Account not found"); //add not found exception later.

            account.Balance += dto.Amount;

            await _repo.SaveAsync();
        }

        public async Task Withdraw(TransactionDto dto)
        {
            var account = await _repo.GetByIdAsync(dto.AccountId);

            if (account == null)
                throw new Exception("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new Exception("Minimum balance ₹1000 required");

            account.Balance -= dto.Amount;

            await _repo.SaveAsync();
        }
    
        public async Task<AccountDto> EditAccount(AccountDto account)
        {
            var editAccount = new Account
            {
                Id= account.Id,
                AccountNumber= account.AccountNumber,
                Name = account.Name,
                Balance = account.Balance,
            };

            var resp = await _repo.EditAsync(editAccount);

            if (resp == null)
            {
                throw new Exception("Account not found.");
            }

            var result = new AccountDto
            {
                Id = resp.Id,
                Name = resp.Name,
                AccountNumber = resp.AccountNumber,
                Balance = resp.Balance
            };

            return result;
        }
        
        public async Task DeleteAccount(int id)
        {
            var exist = await GetById(id);
            if (exist == null)
            {
                throw new Exception("Account not found.");
            }
            await _repo.DeleteAsync(id);
            return;
        }
    }
}