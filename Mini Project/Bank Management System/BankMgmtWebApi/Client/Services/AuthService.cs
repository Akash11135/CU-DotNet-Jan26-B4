using Client.DTOs;

namespace Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var response = await _http.PostAsJsonAsync("http://localhost:7001/auth/login", dto);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<TokenDto>();

            if (result == null || result.token == null)
                throw new Exception("Token is null");

            return result.token;
        }

        public async Task<RegistrationDto> Register(RegistrationDto dto)
        {
            var resp =await _http.PostAsJsonAsync<RegistrationDto>("http://localhost:7001/auth/register", dto);

            if (!resp.IsSuccessStatusCode)
            {
                var error = await resp.Content.ReadAsStringAsync();
                throw new Exception($"Regstration FE API Error: {error}");
            }

            var result = await resp.Content.ReadFromJsonAsync<RegistrationDto>();
            if (result == null)
            {
                throw new Exception("Registration is null");
            }
            return result;
        }
    }
}
