using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BlogController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}