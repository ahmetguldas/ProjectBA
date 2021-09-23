using Microsoft.AspNetCore.Mvc;

namespace EticaretBA.UI.Controllers
{
    public class ContactUsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}