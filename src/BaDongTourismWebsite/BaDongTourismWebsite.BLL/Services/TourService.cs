using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public class TourService : ITourService
{
    private readonly IUnitOfWork _unitOfWork;

    public TourService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Tour>> GetFeaturedToursAsync(int count = 4)
    {
        return await _unitOfWork.Tours.GetFeaturedToursAsync(count);
    }

    public async Task<IEnumerable<Tour>> GetAllToursAsync()
    {
        return await _unitOfWork.Tours.GetActiveToursAsync();
    }

    public async Task<Tour?> GetTourByIdAsync(int id)
    {
        return await _unitOfWork.Tours.GetByIdAsync(id);
    }

    public async Task<Tour?> GetTourWithDetailsAsync(int id)
    {
        return await _unitOfWork.Tours.GetTourWithDetailsAsync(id);
    }

    public async Task<IEnumerable<Tour>> SearchToursAsync(string searchTerm)
    {
        return await _unitOfWork.Tours.SearchToursAsync(searchTerm);
    }

    public async Task<Tour> CreateTourAsync(Tour tour)
    {
        // Ensure all DateTime values are UTC
        tour.StartDate = tour.StartDate.Kind == DateTimeKind.Unspecified 
            ? DateTime.SpecifyKind(tour.StartDate, DateTimeKind.Utc) 
            : tour.StartDate.ToUniversalTime();
            
        tour.EndDate = tour.EndDate.Kind == DateTimeKind.Unspecified 
            ? DateTime.SpecifyKind(tour.EndDate, DateTimeKind.Utc) 
            : tour.EndDate.ToUniversalTime();
            
        tour.CreatedDate = DateTime.UtcNow;
        tour.UpdatedDate = null; // Set to null for new entities
        
        await _unitOfWork.Tours.AddAsync(tour);
        await _unitOfWork.SaveChangesAsync();
        return tour;
    }

    public async Task<bool> UpdateTourAsync(Tour tour)
    {
        var existing = await _unitOfWork.Tours.GetByIdAsync(tour.Id);
        if (existing == null) return false;

        // Ensure all DateTime values are UTC
        tour.StartDate = tour.StartDate.Kind == DateTimeKind.Unspecified 
            ? DateTime.SpecifyKind(tour.StartDate, DateTimeKind.Utc) 
            : tour.StartDate.ToUniversalTime();
            
        tour.EndDate = tour.EndDate.Kind == DateTimeKind.Unspecified 
            ? DateTime.SpecifyKind(tour.EndDate, DateTimeKind.Utc) 
            : tour.EndDate.ToUniversalTime();
            
        tour.UpdatedDate = DateTime.UtcNow;
        
        _unitOfWork.Tours.Update(tour);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTourAsync(int id)
    {
        var tour = await _unitOfWork.Tours.GetByIdAsync(id);
        if (tour == null) return false;

        _unitOfWork.Tours.Delete(tour);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
