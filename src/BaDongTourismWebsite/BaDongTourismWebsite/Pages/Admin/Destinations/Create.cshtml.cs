using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.Pages.Admin.Destinations;

public class CreateModel : PageModel
{
    private readonly IDestinationService _destinationService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(
        IDestinationService destinationService,
        IUnitOfWork unitOfWork,
        ILogger<CreateModel> logger)
    {
        _destinationService = destinationService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [BindProperty]
    public Destination Destination { get; set; } = new();

    public SelectList Categories { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await LoadCategoriesAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Destination.Category");

        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return Page();
        }

        try
        {
            await _destinationService.CreateDestinationAsync(Destination);
            TempData["SuccessMessage"] = "Đã thêm điểm du lịch thành công!";
            return RedirectToPage("/Admin/Destinations/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating destination");
            ModelState.AddModelError("", "Đã xảy ra lỗi khi thêm điểm du lịch.");
            await LoadCategoriesAsync();
            return Page();
        }
    }

    private async Task LoadCategoriesAsync()
    {
        var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
        Categories = new SelectList(categories, "Id", "Name");
    }
}

