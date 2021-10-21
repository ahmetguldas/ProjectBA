using System.Linq;
using System.Security.Claims;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(NewCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                
                {
                    CategoryName = vm.CategoryName
                };
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public IActionResult New()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
           
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}