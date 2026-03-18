namespace DAY60_WealthTrack.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; } = string.Empty;// e.g., "SILVERBEES"
        public string AssetName { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
