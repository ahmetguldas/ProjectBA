using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
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