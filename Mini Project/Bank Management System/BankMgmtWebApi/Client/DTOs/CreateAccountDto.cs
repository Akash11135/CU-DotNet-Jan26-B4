using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs
{
    public class CreateAccountDto
    {
        [Required]   
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1000, double.MaxValue, ErrorMessage = "Initial deposit must be at least ₹1000.")]
        public decimal InitialDeposit { get; set; }
    }
}