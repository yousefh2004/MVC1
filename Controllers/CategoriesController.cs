using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Task1mvc.Data;

namespace Task1mvc.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public ViewResult Index()
        {
            var categories=context.Categories.ToList();
            return View(categories);
        }
    }
}
