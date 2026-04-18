using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Repository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync(); 
    }
}
