using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
