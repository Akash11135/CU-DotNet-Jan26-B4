namespace Client.DTOs
{
    public class TransactionByIdDto
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        

    }
}
