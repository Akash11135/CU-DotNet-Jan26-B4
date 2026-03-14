namespace Week10_FinanceWebsite.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Category { get; set; } = string.Empty; // e.g., Income, Expense
        public DateTime Date { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
