using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Tours;

public class CreateModel : PageModel
{
    private readonly ITourService _tourService;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(
        ITourService tourService,
        ILogger<CreateModel> logger)
    {
        _tourService = tourService;
        _logger = logger;
    }

    [BindProperty]
    public Tour Tour { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Tour.TourDestinations");
        ModelState.Remove("Tour.TourSchedules");
        ModelState.Remove("Tour.Bookings");
        ModelState.Remove("Tour.Reviews");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _tourService.CreateTourAsync(Tour);
            TempData["SuccessMessage"] = "Đã thêm tour thành công!";
            return RedirectToPage("/Admin/Tours/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating tour");
            ModelState.AddModelError("", "Đã xảy ra lỗi khi thêm tour.");
            return Page();
        }
    }
}
