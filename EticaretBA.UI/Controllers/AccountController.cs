using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}