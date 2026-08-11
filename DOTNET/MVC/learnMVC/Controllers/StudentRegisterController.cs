using MCProgramStartup.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class StudentRegisterController : Controller
{
    [HttpGet] public IActionResult Index() { return View(); }
    [HttpPost] public IActionResult Index(StudentViewModelPost model) { return View(); }
}