using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using learnMVC.Models;

namespace learnMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Cat()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Hardcoded credentials, just for learning purposes.
        if (username == "admin" && password == "1234")
        {
            ViewBag.Message = "Login successful!";
            ViewBag.Success = true;
        }
        else
        {
            ViewBag.Message = "Invalid username or password.";
            ViewBag.Success = false;
        }

        return View();
    }
   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
