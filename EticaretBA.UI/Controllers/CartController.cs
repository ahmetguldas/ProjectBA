using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
{
    public class CartController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}