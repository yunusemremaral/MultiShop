using Microsoft.AspNetCore.Mvc;

namespace MultiShot.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpeacialOfferComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
  
}
