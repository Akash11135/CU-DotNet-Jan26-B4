using Vagabond_Backend.Models;
using Vagabond_Backend.DTOs;
namespace Vagabond_Backend.Repository
{
    public interface IDestinationRepository
    {
        Task<List<Destination>> GetAllAsync();
        Task<Destination> GetByIdAsync(int id);
        Task<Destination> AddAsync(DestinationDto dto);
        Task<Destination> UpdateAsync(int id, DestinationDto dto);
        Task<Destination> DeleteAsync(int id);
    }
}
