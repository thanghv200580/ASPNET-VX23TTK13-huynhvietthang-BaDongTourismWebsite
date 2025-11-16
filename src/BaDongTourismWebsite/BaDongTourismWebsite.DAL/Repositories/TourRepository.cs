using Microsoft.EntityFrameworkCore;
using BaDongTourismWebsite.DAL.Data;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.DAL.Repositories;

public class TourRepository : Repository<Tour>, ITourRepository
{
    public TourRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Tour>> GetFeaturedToursAsync(int count = 4)
    {
        return await _dbSet
            .Where(t => t.IsFeatured && t.IsActive && t.StartDate > DateTime.UtcNow)
            .OrderBy(t => t.StartDate)
            .Take(count)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Tour>> GetActiveToursAsync()
    {
        return await _dbSet
            .Where(t => t.IsActive && t.StartDate > DateTime.UtcNow)
            .OrderBy(t => t.StartDate)
            .ToListAsync();
    }
    
    public async Task<Tour?> GetTourWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(t => t.TourSchedules.OrderBy(s => s.DayNumber))
            .Include(t => t.TourDestinations.OrderBy(td => td.DisplayOrder))
                .ThenInclude(td => td.Destination)
            .Include(t => t.Reviews.Where(r => r.IsApproved))
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
    
    public async Task<IEnumerable<Tour>> SearchToursAsync(string searchTerm)
    {
        return await _dbSet
            .Where(t => (t.Name.Contains(searchTerm) || 
                        t.Description.Contains(searchTerm)) && 
                        t.IsActive)
            .OrderBy(t => t.StartDate)
            .ToListAsync();
    }
}
