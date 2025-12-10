using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Tours;

public class DetailsModel : PageModel
{
    private readonly ITourService _tourService;
    private readonly ILogger<DetailsModel> _logger;

    public DetailsModel(
        ITourService tourService,
        ILogger<DetailsModel> logger)
    {
        _tourService = tourService;
        _logger = logger;
    }

    public Tour? Tour { get; set; }

    public async Task OnGetAsync(int id)
    {
        try
        {
            Tour = await _tourService.GetTourWithDetailsAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading tour {TourId}", id);
        }
    }
}
