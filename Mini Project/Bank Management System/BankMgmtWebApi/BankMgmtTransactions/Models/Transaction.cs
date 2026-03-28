namespace BankMgmtTransactions.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}