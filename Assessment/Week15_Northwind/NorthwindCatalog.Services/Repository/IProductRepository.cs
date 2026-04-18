using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        public Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();

    }
}
