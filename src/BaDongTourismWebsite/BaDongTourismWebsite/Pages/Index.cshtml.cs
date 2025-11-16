using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages;

public class IndexModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IUnitOfWork unitOfWork, ILogger<IndexModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IEnumerable<Destination> FeaturedDestinations { get; set; } = new List<Destination>();
    public IEnumerable<Tour> PopularTours { get; set; } = new List<Tour>();

    public async Task OnGetAsync()
    {
        FeaturedDestinations = await _unitOfWork.Destinations.GetFeaturedDestinationsAsync(6);
        PopularTours = await _unitOfWork.Tours.GetFeaturedToursAsync(4);
    }
}