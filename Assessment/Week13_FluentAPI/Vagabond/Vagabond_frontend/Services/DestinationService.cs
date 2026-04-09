using System.Text.Json;
using Vagabond_frontend.DTOs;
using Vagabond_frontend.Models;
namespace Vagabond_frontend.Services
{
    public class DestinationService
    {
        private readonly HttpClient _http;

        public DestinationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Destination>> GetAll()
        {
            var resp = await _http.GetFromJsonAsync <List<Destination>>("http://localhost:5113/api/destination");

            if(resp == null)
            {
                return new List<Destination>();
            }
            return resp;
        }

        public async Task<DestinationDto> Create(DestinationDto destination)
        {
            var response = await _http.PostAsJsonAsync("http://localhost:5113/api/destination", destination);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to create destination");

            return await response.Content.ReadFromJsonAsync<DestinationDto>();
        }

        public async Task<DestinationDto> GetById(int id)
        {
            return await _http.GetFromJsonAsync<DestinationDto>($"http://localhost:5113/api/destination/{id}");
        }

        public async Task<DestinationDto> Update(int id, DestinationDto destination)
        {
            var response = await _http.PutAsJsonAsync($"http://localhost:5113/api/destination/{id}", destination);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to update destination");

            return await response.Content.ReadFromJsonAsync<DestinationDto>();
        }

        public async Task<DestinationDto> Delete(int id)
        {
            var response = await _http.DeleteAsync($"http://localhost:5113/api/destination/{id}");

            return await response.Content.ReadFromJsonAsync<DestinationDto>();

        }
    }
}