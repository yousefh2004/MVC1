using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1mvc.Data;
using Task1mvc.Models;

namespace Task1mvc.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ViewResult Create()
        {
            return View();
        }
        public RedirectToActionResult Add(Product request)
        {
            context.Products.Add(request);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ViewResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public ViewResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }
        
    }
}
