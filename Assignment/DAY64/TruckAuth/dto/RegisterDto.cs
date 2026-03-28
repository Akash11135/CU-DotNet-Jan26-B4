namespace TruckAuth.dto
{
    public class RegisterDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName = string.Empty;

        public string Role {  get; set; } = string.Empty;
    }
}
