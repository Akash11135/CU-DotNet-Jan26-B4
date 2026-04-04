using System.ComponentModel.DataAnnotations;

namespace Client.DTOs
{
    public class RegistrationDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[A-Z]{1}[a-z][0-9]$")]
        [MinLength(7, ErrorMessage = "inimum length must be 7.One Capital is needed followed by numbers and special characters.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty; 
    }
}
