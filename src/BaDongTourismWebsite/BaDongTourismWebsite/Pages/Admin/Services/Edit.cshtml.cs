using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Services;

public class EditModel : PageModel
{
    private readonly IBeachServiceService _beachServiceService;
    private readonly ILogger<EditModel> _logger;

    public EditModel(IBeachServiceService beachServiceService, ILogger<EditModel> logger)
    {
        _beachServiceService = beachServiceService;
        _logger = logger;
    }

    [BindProperty]
    public BeachService Service { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var svc = await _beachServiceService.GetServiceByIdAsync(id);
        if (svc == null) return NotFound();
        Service = svc;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            await _beachServiceService.UpdateServiceAsync(Service);
            TempData["SuccessMessage"] = "Đã cập nhật dịch vụ thành công!";
            return RedirectToPage("/Admin/Services/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating beach service");
            ModelState.AddModelError("", "Đã xảy ra lỗi khi cập nhật dịch vụ.");
            return Page();
        }
    }
}
