using Client.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;

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
            _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

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
            _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

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
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

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

            _http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var resp = await _http.PostAsJsonAsync("http://localhost:7002/accounts/edit", account);

            var result = await resp.Content.ReadFromJsonAsync<AccountDto>();

            return result;
        }

        public async Task<string> DeleteAsync(int id) 
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            _http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var resp = await _http.GetAsync($"http://localhost:7002/accounts/delete/{id}");

            if (resp.IsSuccessStatusCode)
            {
                return "deleted Successfully";
            }
            return "";
        }
    }
}
