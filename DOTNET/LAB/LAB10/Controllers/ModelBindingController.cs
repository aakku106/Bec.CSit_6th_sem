using Lab10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers;

public class ModelBindingController : Controller
{
    public IActionResult Index() => View(new Person());

    [HttpPost]
    public IActionResult Create(Person person)
    {
        if (!ModelState.IsValid) return View("Index", person);
        return Content("Created: " + person.Name);
    }
}
