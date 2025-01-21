using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
