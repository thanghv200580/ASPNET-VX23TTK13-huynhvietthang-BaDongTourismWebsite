using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;

namespace BaDongTourismWebsite.Pages.Admin;

public class DashboardModel : PageModel
{
    private readonly IBeachServiceService _beachServiceService;

    public DashboardModel(IBeachServiceService beachServiceService)
    {
        _beachServiceService = beachServiceService;
    }

    public int TotalBeachServices { get; set; }

    public async Task OnGetAsync()
    {
        if (HttpContext.Session.GetString("UserId") == null)
        {
            Response.Redirect("/Auth/Login");
            return;
        }
        TotalBeachServices = (await _beachServiceService.GetAllServicesAsync()).Count();
    }
}


