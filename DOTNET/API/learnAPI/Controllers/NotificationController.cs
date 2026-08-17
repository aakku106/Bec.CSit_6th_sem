using learnAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace learnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("all")]
        public IActionResult Index()
        {
            var a = _notificationService.SendMessage();
            Console.WriteLine("\n\nweeeeeeeeeeeeeeeeeee\n\n" + a);
            return Ok();
        }

        // EmailNotificationService em

    }
}