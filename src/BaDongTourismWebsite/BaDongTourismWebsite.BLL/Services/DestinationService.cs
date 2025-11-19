using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public class DestinationService : IDestinationService
{
    private readonly IUnitOfWork _unitOfWork;

    public DestinationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Destination>> GetFeaturedDestinationsAsync(int count = 6)
    {
        return await _unitOfWork.Destinations.GetFeaturedDestinationsAsync(count);
    }

    public async Task<IEnumerable<Destination>> GetAllDestinationsAsync()
    {
        return await _unitOfWork.Destinations.GetAllDestinationsAsync();
    }

    public async Task<Destination?> GetDestinationByIdAsync(int id)
    {
        return await _unitOfWork.Destinations.GetDestinationWithImagesAsync(id);
    }

    public async Task<Destination?> GetDestinationWithDetailsAsync(int id)
    {
        return await _unitOfWork.Destinations.GetDestinationWithDetailsAsync(id);
    }

    public async Task<IEnumerable<Destination>> SearchDestinationsAsync(string searchTerm)
    {
        return await _unitOfWork.Destinations.SearchDestinationsAsync(searchTerm);
    }

    public async Task<IEnumerable<Destination>> GetDestinationsByCategoryAsync(int categoryId)
    {
        return await _unitOfWork.Destinations.GetDestinationsByCategoryAsync(categoryId);
    }

    public async Task<Destination> CreateDestinationAsync(Destination destination)
    {
        destination.CreatedDate = DateTime.UtcNow;
        await _unitOfWork.Destinations.AddAsync(destination);
        await _unitOfWork.SaveChangesAsync();
        return destination;
    }

    public async Task<bool> UpdateDestinationAsync(Destination destination)
    {
        var existing = await _unitOfWork.Destinations.GetByIdAsync(destination.Id);
        if (existing == null) return false;

        _unitOfWork.Destinations.Update(destination);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteDestinationAsync(int id)
    {
        var destination = await _unitOfWork.Destinations.GetByIdAsync(id);
        if (destination == null) return false;

        _unitOfWork.Destinations.Delete(destination);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}

