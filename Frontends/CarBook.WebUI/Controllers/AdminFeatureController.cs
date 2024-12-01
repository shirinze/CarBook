using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeature)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeature);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/Features", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["AlertMessage"] = "Özellik başarıyla silindi.";
                return RedirectToAction("Index");
               
            }
            TempData["AlertMessage"] = "Özellik silinemedi.";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7100/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updatefeature)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonbData = JsonConvert.SerializeObject(updatefeature);
            StringContent stringcontent = new StringContent(jsonbData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7100/api/Features/", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
