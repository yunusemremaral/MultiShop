using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShot.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShot.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //public SpecialOfferController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}
        //[Route("Index")]
        //public async Task<IActionResult> Index()
        //{
        //    ViewBag.v1 = "Ana Sayfa";
        //    ViewBag.v2 = "Özel Teklifler";
        //    ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
        //    ViewBag.v0 = "Kategori İşlemleri";

        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}

        //[HttpGet]
        //[Route("CreateSpecialOffer")]
        //public IActionResult CreateSpecialOffer()
        //{
        //    ViewBag.v1 = "Ana Sayfa";
        //    ViewBag.v2 = "Özel Teklifler";
        //    ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
        //    ViewBag.v0 = "Kategori İşlemleri";
        //    return View();
        //}

        //[HttpPost]
        //[Route("CreateSpecialOffer")]
        //public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7070/api/SpecialOffers", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[Route("DeleteSpecialOffer/{id}")]
        //public async Task<IActionResult> DeleteSpecialOffer(string id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync("https://localhost:7070/api/SpecialOffers?id=" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[Route("UpdateSpecialOffer/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> UpdateSpecialOffer(string id)
        //{
        //    ViewBag.v1 = "Ana Sayfa";
        //    ViewBag.v2 = "Özel Teklifler";
        //    ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
        //    ViewBag.v0 = "Kategori İşlemleri";
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers/" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}
        //[Route("UpdateSpecialOffer/{id}")]
        //[HttpPost]
        //public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        //{

        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("https://localhost:7070/api/SpecialOffers/", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        //    }
        //    return View();


        //------------DİĞER YÖNTEM ----------------

        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        void SpecialOfferViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
            ViewBag.v0 = "Kategori İşlemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewBagList();
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewBagList();
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}

