using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Task1mvc.Data;
using Task1mvc.Models;

namespace Task1mvc.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public ViewResult Index()
        {
            var categories=context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return View("NotFound");
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        public RedirectToActionResult Add(Category request)
        {
            context.Categories.Add(request);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
