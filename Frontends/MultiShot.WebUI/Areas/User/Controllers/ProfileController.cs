using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
