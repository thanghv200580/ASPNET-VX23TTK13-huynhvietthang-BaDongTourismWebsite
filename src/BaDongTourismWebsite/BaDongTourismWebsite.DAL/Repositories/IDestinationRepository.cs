using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.DAL.Repositories;

public interface IDestinationRepository : IRepository<Destination>
{
    Task<IEnumerable<Destination>> GetFeaturedDestinationsAsync(int count = 6);
    Task<IEnumerable<Destination>> GetDestinationsByCategoryAsync(int categoryId);
    Task<IEnumerable<Destination>> GetDestinationsByProvinceAsync(string province);
    Task<IEnumerable<Destination>> SearchDestinationsAsync(string searchTerm);
    Task<Destination?> GetDestinationWithImagesAsync(int id);
    Task<Destination?> GetDestinationWithDetailsAsync(int id);
}
