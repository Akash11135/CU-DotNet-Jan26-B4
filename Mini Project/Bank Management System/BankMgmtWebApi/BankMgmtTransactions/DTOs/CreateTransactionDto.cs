namespace BankMgmtTransactions.DTOs
{
    public class CreateTransactionDto
    {
        public int AccountId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }


    }
}