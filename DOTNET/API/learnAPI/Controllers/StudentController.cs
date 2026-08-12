using learnAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace learnAPI.Controllers
{

    // Routes: 
    // api/student/add (post)
    // api/student/all (get)

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static readonly List<Student> students = new List<Student>();

        [HttpPost("add")]
        public IActionResult StudentAdd()
        {
            return Ok();
        }
        [HttpGet]

    }

}