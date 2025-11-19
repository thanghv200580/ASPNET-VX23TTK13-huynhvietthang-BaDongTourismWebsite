using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public interface IDestinationService
{
    Task<IEnumerable<Destination>> GetFeaturedDestinationsAsync(int count = 6);
    Task<IEnumerable<Destination>> GetAllDestinationsAsync();
    Task<Destination?> GetDestinationByIdAsync(int id);
    Task<Destination?> GetDestinationWithDetailsAsync(int id);
    Task<IEnumerable<Destination>> SearchDestinationsAsync(string searchTerm);
    Task<IEnumerable<Destination>> GetDestinationsByCategoryAsync(int categoryId);
    Task<Destination> CreateDestinationAsync(Destination destination);
    Task<bool> UpdateDestinationAsync(Destination destination);
    Task<bool> DeleteDestinationAsync(int id);
}

