using Microsoft.EntityFrameworkCore;
using BaDongTourismWebsite.DAL.Data;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.DAL.Repositories;

public class DestinationRepository : Repository<Destination>, IDestinationRepository
{
    public DestinationRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Destination>> GetAllDestinationsAsync()
    {
        return await _dbSet
            .Include(d => d.Category)
            .OrderByDescending(d => d.CreatedDate)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Destination>> GetFeaturedDestinationsAsync(int count = 6)
    {
        return await _dbSet
            .Include(d => d.Category)
            .Where(d => d.IsFeatured && d.IsActive)
            .OrderByDescending(d => d.Rating)
            .Take(count)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Destination>> GetDestinationsByCategoryAsync(int categoryId)
    {
        return await _dbSet
            .Include(d => d.Category)
            .Where(d => d.CategoryId == categoryId && d.IsActive)
            .OrderByDescending(d => d.Rating)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Destination>> GetDestinationsByProvinceAsync(string province)
    {
        return await _dbSet
            .Include(d => d.Category)
            .Where(d => d.Province == province && d.IsActive)
            .OrderByDescending(d => d.Rating)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Destination>> SearchDestinationsAsync(string searchTerm)
    {
        return await _dbSet
            .Include(d => d.Category)
            .Where(d => (d.Name.Contains(searchTerm) || 
                        d.Description.Contains(searchTerm) || 
                        d.Location.Contains(searchTerm)) && 
                        d.IsActive)
            .OrderByDescending(d => d.Rating)
            .ToListAsync();
    }
    
    public async Task<Destination?> GetDestinationWithImagesAsync(int id)
    {
        return await _dbSet
            .Include(d => d.Category)
            .Include(d => d.Images.OrderBy(i => i.DisplayOrder))
            .FirstOrDefaultAsync(d => d.Id == id);
    }
    
    public async Task<Destination?> GetDestinationWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(d => d.Category)
            .Include(d => d.Images.OrderBy(i => i.DisplayOrder))
            .Include(d => d.Reviews.Where(r => r.IsApproved))
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(d => d.Id == id);
    }
}
