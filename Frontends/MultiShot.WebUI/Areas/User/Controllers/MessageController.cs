using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
