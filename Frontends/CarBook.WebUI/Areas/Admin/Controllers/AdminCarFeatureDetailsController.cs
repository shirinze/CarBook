using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarFeatureDeatilDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarDetails")]
    public class AdminCarFeatureDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCarFeatureDetailDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureDetailDto> carfeaturedetaildto)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var item in carfeaturedetaildto)
            {
                if (item.Available)
                {
                    await client.GetAsync("https://localhost:7100/api/CarFeatures/ChangeCarFeatureAvailableTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    await client.GetAsync("https://localhost:7100/api/CarFeatures/ChangeCarFeatureAvailableFalse?id=" + item.CarFeatureID);

                }
            }
            
            return RedirectToAction("Index","AdminCar");
        }
    }
}
