using Client.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Client.Services
{
    public class AccountService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _con;

        public AccountService(HttpClient http , IHttpContextAccessor con)
        {
            _http = http;
            _con = con;
        }

        public async Task<List<AccountDto>> GetAllAsync()
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            //add header
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var res = await _http.GetFromJsonAsync<List<AccountDto>>("http://localhost:7002/accounts/getall");

            if (res == null)
            {
                return new List<AccountDto>();
            }
            return res;

        }

        public async Task<AccountDto> GetByIdAsync(int id)
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            //add header
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var res = await _http.GetFromJsonAsync<AccountDto>($"http://localhost:7002/accounts/{id}");

            if (res == null)
            {
                return new AccountDto();
            }
            return res;
            
        }

        public async Task<AccountDto> CreateAsync(CreateAccountDto account)
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var resp = await _http.PostAsJsonAsync("http://localhost:7002/accounts", account);

           
            if (!resp.IsSuccessStatusCode)
            {
                var error = await resp.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {error}");
            }

            var result = await resp.Content.ReadFromJsonAsync<AccountDto>();

            return result;
        }

        public async Task<AccountDto> EditAsync(AccountDto account)
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            if (string.IsNullOrEmpty(token))
                throw new Exception("JWT token missing");

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var resp = await _http.PutAsJsonAsync("http://localhost:7002/accounts/edit", account);

            //CHECK STATUS FIRST
            if (!resp.IsSuccessStatusCode)
            {
                var error = await resp.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {resp.StatusCode} - {error}");
            }

            //DEBUG RAW RESPONSE
            var raw = await resp.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(raw))
            {
                return account;
            }

            var result = JsonSerializer.Deserialize<AccountDto>(raw, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }

        public async Task<string> DeleteAsync(int id) 
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token value is null/empty.");
            }

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var resp = await _http.DeleteAsync($"http://localhost:7002/accounts/delete/{id}");

            if (!resp.IsSuccessStatusCode)
            {
                var error = await resp.Content.ReadAsStringAsync();
                throw new Exception($"Error -> {error}, status code-->{resp.StatusCode}");
            }

            if (resp.IsSuccessStatusCode)
            {
                return "deleted Successfully";
            }

            return "error in deletion";
        }
    }
}
