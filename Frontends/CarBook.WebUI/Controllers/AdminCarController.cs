using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

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
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7100/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brandValue = (from x in value
                                               select new SelectListItem
                                               {
                                                   Text = x.name,
                                                   Value = x.brandID.ToString()
                                               }).ToList();
            ViewBag.BrandValue = brandValue;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createcar)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createcar);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7100/api/Cars/", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7100/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7100/api/Brands");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var value1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
            List<SelectListItem> brandValue = (from x in value1
                                               select new SelectListItem
                                               {
                                                   Text = x.name,
                                                   Value = x.brandID.ToString()
                                               }).ToList();
            ViewBag.BrandValue = brandValue;
            var responseMessage = await client.GetAsync($"https://localhost:7100/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCar)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonbData = JsonConvert.SerializeObject(updateCar);
            StringContent stringcontent = new StringContent(jsonbData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7100/api/Cars/", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

       
    }
}
