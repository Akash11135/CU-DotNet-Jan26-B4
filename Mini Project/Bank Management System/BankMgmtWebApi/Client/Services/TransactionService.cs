using Client.DTOs;
using System.Net.Http.Headers;
namespace Client.Services
{
    public class TransactionService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _con;

        public TransactionService(HttpClient http, IHttpContextAccessor con)
        {
            _http = http;
            _con = con;
        }

        public async Task<List<TransactionByIdDto>> GetAllAsync(int id)
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            if (string.IsNullOrEmpty(token))
                throw new Exception("Null or empty token (frontend)");

            
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            
            var resp = await _http.GetFromJsonAsync<List<TransactionByIdDto>>(
                $"http://localhost:7003/transaction/getallbyaccount/{id}"
            );

          
            return resp ?? new List<TransactionByIdDto>();
        }

        public async Task<TransactionByIdDto> GetDetailsByIdAsync(int id)
        {
            var token = _con.HttpContext.Request.Cookies["jwt"];

            if (string.IsNullOrEmpty(token))
                throw new Exception("Null or empty token (frontend)");


            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var resp = await _http.GetFromJsonAsync<TransactionByIdDto>($"http://localhost:7003/transaction/getbyid/{id}");

            return resp;
        }
    }
}
