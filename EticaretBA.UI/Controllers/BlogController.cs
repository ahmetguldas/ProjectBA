using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
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