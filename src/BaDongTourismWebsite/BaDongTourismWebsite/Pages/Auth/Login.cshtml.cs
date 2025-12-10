using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using System.ComponentModel.DataAnnotations;

namespace BaDongTourismWebsite.Pages.Auth;

public class LoginModel : PageModel
{
    private readonly IAuthService _authService;
    private readonly ILogger<LoginModel> _logger;

    public LoginModel(IAuthService authService, ILogger<LoginModel> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [BindProperty]
    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public bool RememberMe { get; set; }

    public string? ErrorMessage { get; set; }

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
            var user = await _authService.LoginAsync(Email, Password);

            if (user == null)
            {
                ErrorMessage = "Email hoặc mật khẩu không đúng.";
                return Page();
            }

            // Simple session-based authentication
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", user.FullName);

            var roles = await _authService.GetUserRolesAsync(user.Id);
            if (roles.Count > 0)
            {
                HttpContext.Session.SetString("UserRole", roles[0]);
                HttpContext.Session.SetString("UserRoles", string.Join(',', roles));
            }
            else
            {
                HttpContext.Session.Remove("UserRole");
                HttpContext.Session.Remove("UserRoles");
            }

            _logger.LogInformation("User {Email} logged in successfully", Email);

            var returnUrl = Request.Query["ReturnUrl"].ToString();
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            if (roles.Contains("Admin", StringComparer.OrdinalIgnoreCase))
            {
                return RedirectToPage("/Admin/Dashboard");
            }

            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login for {Email}", Email);
            ErrorMessage = "Đã xảy ra lỗi. Vui lòng thử lại sau.";
            return Page();
        }
    }
}

