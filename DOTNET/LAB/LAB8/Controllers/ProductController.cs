using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Lab8.Controllers;

public class ProductController : Controller
{
    public IActionResult Index() => View(new[] { "Pen", "Book", "Bag" });
    public JsonResult GetProductInfo() => Json(new { Name = "Pen", Price = 20 });
    public RedirectResult RedirectToHome() => Redirect("/Home/Index");
    public FileResult DownloadProductFile() => File(Encoding.UTF8.GetBytes("Product data"), "text/plain", "product.txt");
    public ContentResult DisplayMessage() => Content("This is a product message");
    public StatusCodeResult ReturnStatusCode() => StatusCode(204);
}
