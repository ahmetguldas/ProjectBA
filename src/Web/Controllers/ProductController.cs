using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}