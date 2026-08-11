using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Services;

public class IndexModel : PageModel
{
    private readonly IBeachServiceService _beachServiceService;

    public IndexModel(IBeachServiceService beachServiceService)
    {
        _beachServiceService = beachServiceService;
    }

    public IEnumerable<BeachService> Services { get; set; } = new List<BeachService>();
    public string? SuccessMessage { get; set; }

    public async Task OnGetAsync()
    {
        if (TempData.ContainsKey("SuccessMessage"))
            SuccessMessage = TempData["SuccessMessage"]?.ToString();

        Services = await _beachServiceService.GetAllServicesAsync();
    }
}
