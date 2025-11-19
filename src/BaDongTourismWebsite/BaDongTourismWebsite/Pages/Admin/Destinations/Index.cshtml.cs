using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Destinations;

public class IndexModel : PageModel
{
    private readonly IDestinationService _destinationService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IDestinationService destinationService, ILogger<IndexModel> logger)
    {
        _destinationService = destinationService;
        _logger = logger;
    }

    public IEnumerable<Destination> Destinations { get; set; } = new List<Destination>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public async Task OnGetAsync()
    {
        try
        {
            Destinations = await _destinationService.GetAllDestinationsAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading destinations");
            Destinations = new List<Destination>();
        }
    }
}

