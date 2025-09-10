using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task1mvc.Data;
using Task1mvc.Models;

namespace Task1mvc.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Create()
        {
            ViewBag.Categories=context.Categories.ToList();
            return View();
        }
        public RedirectToActionResult Add(Product request,IFormFile Image)
        {
            var fileName=Guid.NewGuid().ToString();
            fileName= fileName + Path.GetExtension(Image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images",fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                Image.CopyTo(stream);
            }
            request.Image = fileName;
            context.Products.Add(request);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product is null)
            {
                return View("NotFound");
            }
            if (!string.IsNullOrEmpty(product.Image))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", product.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product=context.Products.Find(id);
            return View(product);

        }
        public IActionResult Update(Product request)
        {
            context.Products.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        }
}
