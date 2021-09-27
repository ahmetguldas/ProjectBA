using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AboutUsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}