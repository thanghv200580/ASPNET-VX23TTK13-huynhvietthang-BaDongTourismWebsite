using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.DAL.Repositories;

public interface ITourRepository : IRepository<Tour>
{
    Task<IEnumerable<Tour>> GetFeaturedToursAsync(int count = 4);
    Task<IEnumerable<Tour>> GetActiveToursAsync();
    Task<Tour?> GetTourWithDetailsAsync(int id);
    Task<IEnumerable<Tour>> SearchToursAsync(string searchTerm);
}
