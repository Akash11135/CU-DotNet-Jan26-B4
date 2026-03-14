namespace Week10_FinanceWebsite.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; }

        public List<Transaction> Transactions { get; set; }

    }
}
