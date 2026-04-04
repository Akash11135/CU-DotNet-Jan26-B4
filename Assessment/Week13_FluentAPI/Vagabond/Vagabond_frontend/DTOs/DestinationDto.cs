using System.ComponentModel.DataAnnotations;

namespace Vagabond_frontend.DTOs
{
    public class DestinationDto
    {
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        public string CityName { get; set; } = string.Empty;

      
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }
        public DateTime LastVisited { get; set; }
    }
}
