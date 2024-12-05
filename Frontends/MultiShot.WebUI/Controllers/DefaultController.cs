using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
