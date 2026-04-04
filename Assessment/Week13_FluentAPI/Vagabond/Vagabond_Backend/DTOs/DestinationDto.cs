namespace Vagabond_Backend.DTOs
{
    public class DestinationDto
    {
        public string Country { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public DateTime LastVisited { get; set; }
    }
}
