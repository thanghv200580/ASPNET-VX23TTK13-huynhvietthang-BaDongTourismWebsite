using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public interface ITourService
{
    Task<IEnumerable<Tour>> GetFeaturedToursAsync(int count = 4);
    Task<IEnumerable<Tour>> GetAllToursAsync();
    Task<Tour?> GetTourByIdAsync(int id);
    Task<Tour?> GetTourWithDetailsAsync(int id);
    Task<IEnumerable<Tour>> SearchToursAsync(string searchTerm);
    Task<Tour> CreateTourAsync(Tour tour);
    Task<bool> UpdateTourAsync(Tour tour);
    Task<bool> DeleteTourAsync(int id);
}
