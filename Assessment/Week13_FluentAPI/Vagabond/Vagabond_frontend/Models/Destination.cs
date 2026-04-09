namespace Vagabond_frontend.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public DateTime LastVisited { get; set; }
    }
}
