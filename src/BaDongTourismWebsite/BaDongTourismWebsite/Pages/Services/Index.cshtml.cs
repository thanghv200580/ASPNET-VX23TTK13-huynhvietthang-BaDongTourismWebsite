using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Services;

public class IndexModel : PageModel
{
    private readonly IBeachServiceService _beachServiceService;

    public IndexModel(IBeachServiceService beachServiceService)
    {
        _beachServiceService = beachServiceService;
    }

    public IEnumerable<BeachService> Services { get; set; } = new List<BeachService>();

    public async Task OnGetAsync()
    {
        Services = await _beachServiceService.GetActiveServicesAsync();
    }
}
