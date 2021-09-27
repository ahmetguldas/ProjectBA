using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
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