using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
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