using Microsoft.AspNetCore.Mvc;

namespace Lab13.Controllers;

public class StateController : Controller
{
    [HttpPost]
    public IActionResult SetSession(string name, string email)
    {
        HttpContext.Session.SetString("Name", name);
        HttpContext.Session.SetString("Email", email);
        return RedirectToAction(nameof(ShowSession));
    }

    public IActionResult ShowSession() => View();

    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(ShowSession));
    }

    public IActionResult AddEmployee()
    {
        TempData["Message"] = "Employee added successfully!";
        return RedirectToAction(nameof(ShowMessage));
    }

    public IActionResult ShowMessage() => View();

    [HttpPost]
    public IActionResult SetTheme(string theme)
    {
        Response.Cookies.Append("Theme", theme, new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1) });
        return RedirectToAction(nameof(ShowSession));
    }

    public IActionResult DeleteTheme()
    {
        Response.Cookies.Delete("Theme");
        return RedirectToAction(nameof(ShowSession));
    }
}
