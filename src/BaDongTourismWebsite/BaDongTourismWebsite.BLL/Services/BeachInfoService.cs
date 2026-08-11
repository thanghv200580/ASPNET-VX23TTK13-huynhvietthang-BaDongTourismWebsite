using BaDongTourismWebsite.DAL.Data;
using BaDongTourismWebsite.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaDongTourismWebsite.BLL.Services;

public class BeachInfoService : IBeachInfoService
{
    private readonly ApplicationDbContext _context;

    public BeachInfoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BeachInfo?> GetBeachInfoAsync()
    {
        return await _context.BeachInfos.FirstOrDefaultAsync();
    }

    public async Task UpdateBeachInfoAsync(BeachInfo info)
    {
        info.UpdatedDate = DateTime.Now;
        _context.BeachInfos.Update(info);
        await _context.SaveChangesAsync();
    }
}
