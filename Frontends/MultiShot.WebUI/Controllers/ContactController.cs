using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
