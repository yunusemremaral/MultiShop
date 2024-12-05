using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
