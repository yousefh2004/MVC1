using Microsoft.AspNetCore.Mvc;

namespace Task1mvc.Areas.Admin
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
