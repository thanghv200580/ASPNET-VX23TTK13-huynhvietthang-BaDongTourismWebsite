using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages;

public class IndexModel : PageModel
{
    private readonly IBeachInfoService _beachInfoService;
    private readonly IBeachServiceService _beachServiceService;

    public IndexModel(IBeachInfoService beachInfoService, IBeachServiceService beachServiceService)
    {
        _beachInfoService = beachInfoService;
        _beachServiceService = beachServiceService;
    }

    public BeachInfo? Info { get; set; }
    public IEnumerable<BeachService> FeaturedServices { get; set; } = new List<BeachService>();

    public async Task OnGetAsync()
    {
        Info = await _beachInfoService.GetBeachInfoAsync();
        FeaturedServices = (await _beachServiceService.GetActiveServicesAsync()).Take(4);
    }
}

