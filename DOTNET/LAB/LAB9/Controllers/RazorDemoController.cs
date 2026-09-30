using Lab9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers;

public class RazorDemoController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Message = "Hello from ViewBag";
        ViewData["Numbers"] = new List<int> { 5, 12, 8, 20 };
        return View(new RazorDemoModel());
    }

    [HttpPost]
    public IActionResult Index(RazorDemoModel model)
    {
        ViewBag.Message = "Hello from ViewBag";
        ViewData["Numbers"] = new List<int> { 5, 12, 8, 20 };
        return View(model);
    }
}
