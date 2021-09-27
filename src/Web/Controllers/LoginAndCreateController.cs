using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginAndCreateController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}