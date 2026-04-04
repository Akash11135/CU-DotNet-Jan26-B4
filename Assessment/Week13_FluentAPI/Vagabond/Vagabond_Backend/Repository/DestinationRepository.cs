using Microsoft.EntityFrameworkCore;
using Vagabond_Backend.Data;
using Vagabond_Backend.HandleException;
using Vagabond_Backend.Models;
using Vagabond_Backend.DTOs;
namespace Vagabond_Backend.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AppDbContext _context;

        public DestinationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var res = await _context.Destinations
                .FirstOrDefaultAsync(d => d.Id == id);

            if (res == null)
            {
                throw new DestinationNotFoundException(id);
            }
            return res;
        }

        public async Task<Destination> AddAsync(DestinationDto dto)
        {
            var entity = new Destination
            {
                Country = dto.Country,
                CityName = dto.CityName,
                Description = dto.Description,
                Rating = dto.Rating,
                LastVisited = dto.LastVisited
            };

            await _context.Destinations.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Destination> UpdateAsync(int id, DestinationDto dto)
        {
            var exist = await _context.Destinations
                .FirstOrDefaultAsync(d => d.Id == id);

            if (exist == null)
                throw new DestinationNotFoundException(id);

            exist.CityName = dto.CityName;
            exist.Description = dto.Description;
            exist.LastVisited = dto.LastVisited;
            exist.Rating = dto.Rating;
            exist.Country = dto.Country;

            await _context.SaveChangesAsync();

            return exist;
        }
        public async Task<Destination> DeleteAsync(int id)
        {
            var exist = await _context.Destinations
                .FirstOrDefaultAsync(d => d.Id == id);

            if (exist == null)
                throw new DestinationNotFoundException($"Id {id}");

            _context.Destinations.Remove(exist);
            await _context.SaveChangesAsync();

            return exist;
        }
    }
}