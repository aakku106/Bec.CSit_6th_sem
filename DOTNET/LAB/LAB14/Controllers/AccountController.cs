using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab14.Controllers;

public class AccountController : Controller
{
    public static readonly (string Username, string Password, string Role, int Experience)[] DemoUsers =
    [
        ("admin", "123", "Admin", 3),
        ("user", "123", "User", 1)
    ];

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password, string? returnUrl = null)
    {
        var user = DemoUsers.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user.Username is null)
        {
            ViewData["Error"] = "Invalid username or password.";
            return View();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Role, user.Role),
            new("Experience", user.Experience.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

        return Redirect(returnUrl ?? "/");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
}
