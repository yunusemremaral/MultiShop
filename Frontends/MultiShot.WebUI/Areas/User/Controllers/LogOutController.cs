using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Areas.User.Controllers
{
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
