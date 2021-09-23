using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
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