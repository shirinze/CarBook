using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Cars/GetCarsListBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultCarwithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            return View();
        }
    }
}
