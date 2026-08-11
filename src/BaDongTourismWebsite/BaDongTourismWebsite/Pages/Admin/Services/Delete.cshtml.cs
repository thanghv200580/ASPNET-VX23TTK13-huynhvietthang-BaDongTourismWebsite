using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaDongTourismWebsite.Pages.Admin.Services;

public class DeleteModel : PageModel
{
    private readonly IBeachServiceService _beachServiceService;

    public DeleteModel(IBeachServiceService beachServiceService)
    {
        _beachServiceService = beachServiceService;
    }

    [BindProperty]
    public BeachService? Service { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if (HttpContext.Session.GetString("UserId") == null)
            return RedirectToPage("/Auth/Login");

        Service = await _beachServiceService.GetServiceByIdAsync(id);
        if (Service == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (HttpContext.Session.GetString("UserId") == null)
            return RedirectToPage("/Auth/Login");

        if (Service != null)
        {
            await _beachServiceService.DeleteServiceAsync(Service.Id);
            TempData["SuccessMessage"] = "Đã xóa dịch vụ thành công!";
        }
        return RedirectToPage("/Admin/Services/Index");
    }
}
