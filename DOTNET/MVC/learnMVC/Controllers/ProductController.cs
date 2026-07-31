using Microsoft.AspNetCore.Mvc;

namespace learnMVC.Controllers
{
    public class ProductController : Controller
    {

        public class Fruits
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public decimal Price { get; set; }
        }
        private static List<Fruits> fruits = new List<Fruits>
    {
 new Fruits{ID=1,Name="apple",Price=230},
 new Fruits{ID=2,Name="mango",Price=140},

    };
        public IActionResult Fruit()
        {
            return View(fruits);
        }
        [HttpPost]
        public IActionResult AddProduct(Fruits fruit)//object store hunxa fruit ma then we add that in temp db.
        {
            fruits.Add(fruit);

            //redirect to product list
            return RedirectToAction("Fruit");
        }


    }
}
