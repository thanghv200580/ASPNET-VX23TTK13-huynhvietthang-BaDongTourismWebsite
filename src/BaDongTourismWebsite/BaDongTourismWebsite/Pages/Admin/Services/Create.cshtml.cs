using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Services;

public class CreateModel : PageModel
{
    private readonly IBeachServiceService _beachServiceService;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(IBeachServiceService beachServiceService, ILogger<CreateModel> logger)
    {
        _beachServiceService = beachServiceService;
        _logger = logger;
    }

    [BindProperty]
    public BeachService Service { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            await _beachServiceService.CreateServiceAsync(Service);
            TempData["SuccessMessage"] = "Đã thêm dịch vụ biển thành công!";
            return RedirectToPage("/Admin/Services/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating beach service");
            ModelState.AddModelError("", "Đã xảy ra lỗi khi thêm dịch vụ.");
            return Page();
        }
    }
}
