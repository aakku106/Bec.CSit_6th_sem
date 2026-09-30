using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab14.Controllers;

[Authorize]
public class AuthorizationDemoController : Controller
{
    public IActionResult Dashboard() => Content("Authenticated dashboard");

    [Authorize(Roles = "Admin")]
    public IActionResult Admin() => Content("Admin page");

    [Authorize(Policy = "RequireExperience")]
    public IActionResult Senior() => Content("Senior page");
}
