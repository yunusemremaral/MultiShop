using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShot.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace MultiShot.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;   

        //public _CarouselDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureSliders");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

        //        // Gelen veri sayısını ViewBag ile View'a aktar  dinamik carousel 
        //        ViewBag.SliderCount = values.Count;

        //        return View(values);
        //    }

        //    ViewBag.SliderCount = 0; // Eğer hata varsa, slider sayısını sıfır olarak ayarla
        //    return View(new List<ResultFeatureSliderDto>());




        //}

        // Yeni hali 

        
            private readonly IFeatureSliderService _featureSliderService;
            public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
            {
                _featureSliderService = featureSliderService;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {
                var values = await _featureSliderService.GetAllFeatureSliderAsync();
                return View(values);
            }
        
    }

}

