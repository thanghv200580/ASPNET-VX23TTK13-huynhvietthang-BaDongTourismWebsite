using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using System.ComponentModel.DataAnnotations;

namespace BaDongTourismWebsite.Pages.Auth;

public class RegisterModel : PageModel
{
    private readonly IAuthService _authService;
    private readonly ILogger<RegisterModel> _logger;

    public RegisterModel(IAuthService authService, ILogger<RegisterModel> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [BindProperty]
    [Required(ErrorMessage = "Họ và tên là bắt buộc")]
    [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự")]
    public string FullName { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự")]
    public string? PhoneNumber { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc")]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            // Check if email already exists
            if (await _authService.EmailExistsAsync(Email))
            {
                ErrorMessage = "Email này đã được sử dụng. Vui lòng sử dụng email khác.";
                return Page();
            }

            var user = await _authService.RegisterAsync(FullName, Email, PhoneNumber ?? string.Empty, Password);

            if (user == null)
            {
                ErrorMessage = "Đăng ký không thành công. Vui lòng thử lại sau.";
                return Page();
            }

            _logger.LogInformation("New user registered: {Email}", Email);

            SuccessMessage = "Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.";
            
            // Clear form
            FullName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            ModelState.Clear();

            // Redirect to login after 2 seconds
            await Task.Delay(2000);
            return RedirectToPage("/Auth/Login", new { message = "Đăng ký thành công! Vui lòng đăng nhập." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during registration for {Email}", Email);
            ErrorMessage = "Đã xảy ra lỗi. Vui lòng thử lại sau.";
            return Page();
        }
    }
}

