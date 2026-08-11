using learnMVC.Models;
using MCProgramStartup.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class StudentRegisterController : Controller
{

    private static List<Student> students = new List<Student>();

    [HttpGet] public IActionResult Index() { return View(); }

    public IActionResult Success() { return View(); }

    [HttpPost]
    IActionResult Index(StudentViewModelPost model)
    {
        if (ModelState.IsValid)
        {
            Student student = new Student();
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Email = model.Email;
            student.password = model.Password;
            student.DOB = model.DOB;
            students.Add(student);
            return RedirectToAction("Success");
        }
        return View();
    }

}

