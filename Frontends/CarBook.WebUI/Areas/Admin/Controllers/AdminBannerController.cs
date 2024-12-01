using CarBook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBanner")]
    public class AdminBannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateBanner")]
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerdto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBannerdto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/Banners", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }
            return View();
        }
        [Route("RemoveBanner/{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/Banners/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","AdminBanner",new {area="Admin"});
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7100/api/Banners/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBanner)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBanner);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7100/api/Banners", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminBanner", new {area="Admin"});
            }
            return View();
        }
    }
}
