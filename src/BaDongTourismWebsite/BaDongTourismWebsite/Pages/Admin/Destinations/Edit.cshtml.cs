using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Destinations;

public class EditModel : PageModel
{
    private readonly IDestinationService _destinationService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<EditModel> _logger;

    public EditModel(
        IDestinationService destinationService,
        IUnitOfWork unitOfWork,
        ILogger<EditModel> logger)
    {
        _destinationService = destinationService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [BindProperty]
    public Destination? Destination { get; set; }

    public SelectList Categories { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Destination = await _destinationService.GetDestinationByIdAsync(id);

        if (Destination == null)
        {
            return NotFound();
        }

        await LoadCategoriesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return Page();
        }

        try
        {
            var success = await _destinationService.UpdateDestinationAsync(Destination!);
            if (success)
            {
                TempData["SuccessMessage"] = "Đã cập nhật điểm du lịch thành công!";
                return RedirectToPage("/Admin/Destinations/Index");
            }
            else
            {
                ModelState.AddModelError("", "Không tìm thấy điểm du lịch để cập nhật.");
                await LoadCategoriesAsync();
                return Page();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating destination {Id}", Destination?.Id);
            ModelState.AddModelError("", "Đã xảy ra lỗi khi cập nhật điểm du lịch.");
            await LoadCategoriesAsync();
            return Page();
        }
    }

    private async Task LoadCategoriesAsync()
    {
        var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
        Categories = new SelectList(categories, "Id", "Name", Destination?.CategoryId);
    }
}

