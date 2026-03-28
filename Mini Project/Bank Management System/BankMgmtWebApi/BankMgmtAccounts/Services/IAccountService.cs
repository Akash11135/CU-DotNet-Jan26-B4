using BankMgmtWebApi.DTOs;

namespace BankMgmtWebApi.Services
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAccount(CreateAccountDto dto);
        Task<List<AccountDto>> GetAll();
        Task<AccountDto> GetById(int id);
        Task Deposit(TransactionDto dto);
        Task Withdraw(TransactionDto dto);
    }
}