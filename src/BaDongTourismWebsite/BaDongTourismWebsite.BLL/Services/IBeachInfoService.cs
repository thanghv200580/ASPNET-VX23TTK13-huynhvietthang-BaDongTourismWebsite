using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public interface IBeachInfoService
{
    Task<BeachInfo?> GetBeachInfoAsync();
    Task UpdateBeachInfoAsync(BeachInfo info);
}
