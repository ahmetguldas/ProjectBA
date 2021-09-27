using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
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