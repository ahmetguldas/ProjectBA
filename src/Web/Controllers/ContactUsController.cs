using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
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