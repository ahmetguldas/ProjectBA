using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}