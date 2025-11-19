using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.DAL.UnitOfWork;

namespace BaDongTourismWebsite.Pages.Admin;

public class DashboardModel : PageModel
{
    private readonly IDestinationService _destinationService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DashboardModel> _logger;

    public DashboardModel(
        IDestinationService destinationService,
        IUnitOfWork unitOfWork,
        ILogger<DashboardModel> logger)
    {
        _destinationService = destinationService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public int TotalDestinations { get; set; }
    public int TotalTours { get; set; }
    public int TotalUsers { get; set; }
    public int TotalBookings { get; set; }
    public IEnumerable<BaDongTourismWebsite.Entity.Entities.Destination> FeaturedDestinations { get; set; } = new List<BaDongTourismWebsite.Entity.Entities.Destination>();

    public async Task OnGetAsync()
    {
        try
        {
            TotalDestinations = await _unitOfWork.Repository<BaDongTourismWebsite.Entity.Entities.Destination>().CountAsync();
            TotalTours = await _unitOfWork.Repository<BaDongTourismWebsite.Entity.Entities.Tour>().CountAsync();
            TotalUsers = await _unitOfWork.Repository<BaDongTourismWebsite.Entity.Entities.User>().CountAsync();
            TotalBookings = await _unitOfWork.Repository<BaDongTourismWebsite.Entity.Entities.Booking>().CountAsync();
            FeaturedDestinations = await _destinationService.GetFeaturedDestinationsAsync(5);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading dashboard data");
        }
    }
}

