using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Task1mvc.Data;

namespace Task1mvc.Areas.Customer
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            ViewBag.categories = context.Categories.ToList();
            ViewBag.products = context.Products.ToList();
            return View();
        }
    }
}
