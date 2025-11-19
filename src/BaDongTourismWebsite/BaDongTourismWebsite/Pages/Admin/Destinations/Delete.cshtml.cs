using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Destinations;

public class DeleteModel : PageModel
{
    private readonly IDestinationService _destinationService;
    private readonly ILogger<DeleteModel> _logger;

    public DeleteModel(IDestinationService destinationService, ILogger<DeleteModel> logger)
    {
        _destinationService = destinationService;
        _logger = logger;
    }

    public Destination? Destination { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Destination = await _destinationService.GetDestinationByIdAsync(id);

        if (Destination == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        try
        {
            var success = await _destinationService.DeleteDestinationAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Đã xóa điểm du lịch thành công!";
                return RedirectToPage("/Admin/Destinations/Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Không tìm thấy điểm du lịch để xóa.";
                return RedirectToPage("/Admin/Destinations/Index");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting destination {Id}", id);
            TempData["ErrorMessage"] = "Đã xảy ra lỗi khi xóa điểm du lịch.";
            return RedirectToPage("/Admin/Destinations/Index");
        }
    }
}

