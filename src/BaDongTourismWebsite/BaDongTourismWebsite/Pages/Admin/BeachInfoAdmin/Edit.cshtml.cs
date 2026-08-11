using BaDongTourismWebsite.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BeachInfoEntity = BaDongTourismWebsite.Entity.Entities.BeachInfo;

namespace BaDongTourismWebsite.Pages.Admin;

public class BeachInfoEditModel : PageModel
{
    private readonly IBeachInfoService _beachInfoService;

    public BeachInfoEditModel(IBeachInfoService beachInfoService)
    {
        _beachInfoService = beachInfoService;
    }

    [BindProperty]
    public BeachInfoEntity Info { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Session.GetString("UserId") == null)
            return RedirectToPage("/Auth/Login");

        var info = await _beachInfoService.GetBeachInfoAsync();
        if (info == null) return NotFound();
        Info = info;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (HttpContext.Session.GetString("UserId") == null)
            return RedirectToPage("/Auth/Login");

        if (!ModelState.IsValid) return Page();

        await _beachInfoService.UpdateBeachInfoAsync(Info);
        TempData["SuccessMessage"] = "Đã cập nhật thông tin Biển Ba Động thành công!";
        return RedirectToPage("/Admin/BeachInfoAdmin/Edit");
    }
}
