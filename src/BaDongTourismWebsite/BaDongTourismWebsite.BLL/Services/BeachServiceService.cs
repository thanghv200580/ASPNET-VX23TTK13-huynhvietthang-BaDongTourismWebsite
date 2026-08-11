using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using BaDongTourismWebsite.DAL.Data;

namespace BaDongTourismWebsite.BLL.Services;

public class BeachServiceService : IBeachServiceService
{
    private readonly ApplicationDbContext _context;

    public BeachServiceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BeachService>> GetAllServicesAsync()
        => await _context.BeachServices.OrderBy(s => s.DisplayOrder).ThenBy(s => s.Name).ToListAsync();

    public async Task<IEnumerable<BeachService>> GetActiveServicesAsync()
        => await _context.BeachServices.Where(s => s.IsActive && !s.IsDeleted)
            .OrderBy(s => s.DisplayOrder).ThenBy(s => s.Name).ToListAsync();

    public async Task<BeachService?> GetServiceByIdAsync(int id)
        => await _context.BeachServices.FirstOrDefaultAsync(s => s.Id == id);

    public async Task CreateServiceAsync(BeachService service)
    {
        _context.BeachServices.Add(service);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateServiceAsync(BeachService service)
    {
        _context.BeachServices.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteServiceAsync(int id)
    {
        var service = await _context.BeachServices.FindAsync(id);
        if (service != null)
        {
            service.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
