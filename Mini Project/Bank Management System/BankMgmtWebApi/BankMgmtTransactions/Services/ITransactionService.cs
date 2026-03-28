using BankMgmtTransactions.DTOs;

namespace BankMgmtTransactions.Services
{
    public interface ITransactionService
    {
        Task<CreateTransactionDto> Createtransaction(CreateTransactionDto dto);
        Task<List<CreateTransactionDto>> GetAllTransaction();
        Task<CreateTransactionDto> GetTransactionById(int id);

    }
}
