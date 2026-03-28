using Microsoft.AspNetCore.Identity;

namespace TruckAuth.Models

{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}