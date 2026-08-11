using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public interface IBeachServiceService
{
    Task<IEnumerable<BeachService>> GetAllServicesAsync();
    Task<IEnumerable<BeachService>> GetActiveServicesAsync();
    Task<BeachService?> GetServiceByIdAsync(int id);
    Task CreateServiceAsync(BeachService service);
    Task UpdateServiceAsync(BeachService service);
    Task DeleteServiceAsync(int id);
}
