using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
