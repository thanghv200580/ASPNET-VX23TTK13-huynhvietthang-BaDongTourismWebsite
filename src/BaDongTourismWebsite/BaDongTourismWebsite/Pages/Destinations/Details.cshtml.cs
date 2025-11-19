using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Destinations;

public class DetailsModel : PageModel
{
    private readonly IDestinationService _destinationService;
    private readonly ILogger<DetailsModel> _logger;

    public DetailsModel(IDestinationService destinationService, ILogger<DetailsModel> logger)
    {
        _destinationService = destinationService;
        _logger = logger;
    }

    public Destination? Destination { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            Destination = await _destinationService.GetDestinationWithDetailsAsync(id);

            if (Destination == null)
            {
                return NotFound();
            }

            // Increment view count
            Destination.ViewCount++;
            await _destinationService.UpdateDestinationAsync(Destination);

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading destination {Id}", id);
            return NotFound();
        }
    }
}

