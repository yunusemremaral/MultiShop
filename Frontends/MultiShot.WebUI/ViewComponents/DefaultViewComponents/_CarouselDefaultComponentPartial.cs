using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial:ViewComponent 

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
