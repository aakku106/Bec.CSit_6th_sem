using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab14.Controllers;

[Authorize]
public class AuthorizationDemoController : Controller
{
    public IActionResult Index()
    {
        var claims = User.Claims.Select(claim => $"{claim.Type} = {claim.Value}");
        return Content($"Signed in as {User.Identity!.Name}\n{string.Join("\n", claims)}");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Admin() => Content("Admin page");

    [Authorize(Roles = "User")]
    public IActionResult UserOnly() => Content("User page");

    [Authorize(Policy = "RequireExperience")]
    public IActionResult Senior() => Content("Senior page");
}
