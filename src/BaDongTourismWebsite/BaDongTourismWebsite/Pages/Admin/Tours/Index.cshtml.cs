using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Tours;

public class IndexModel : PageModel
{
    private readonly ITourService _tourService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        ITourService tourService,
        ILogger<IndexModel> logger)
    {
        _tourService = tourService;
        _logger = logger;
    }

    public IEnumerable<Tour> Tours { get; set; } = new List<Tour>();

    public async Task OnGetAsync()
    {
        try
        {
            Tours = await _tourService.GetAllToursAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading tours");
        }
    }
}
