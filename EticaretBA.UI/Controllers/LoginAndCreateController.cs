using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
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